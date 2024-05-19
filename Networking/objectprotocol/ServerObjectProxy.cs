using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using Services;
using SwimmingModel.contest;
using SwimmingModel.dto;
using SwimmingModel.user;
using SwimmingNetworking.dto;
using SwimmingServices;

namespace SwimmingNetworking.objectprotocol
{
    public class ServerObjectProxy : IService
    {

        private string Host;
        private int Port;

        private IObserver Client;

        private NetworkStream Stream;

        private IFormatter Formatter;
        private TcpClient Connection;

        private Queue<Response> Responses;
        private volatile bool finished;
        private EventWaitHandle _waitHandle;

        public ServerObjectProxy(string host, int port)
        {
            this.Host = host;
            this.Port = port;
            Responses = new Queue<Response>();
        }



        public virtual void Login(Admin admin, IObserver client)
        {
            InitializeConnection();
            AdminDTO adminDto = DTOUtils.GetDTO(admin);
            SendRequest(new LoginRequest(adminDto));
            Response response = ReadResponse();
            if (response is OKResponse)
            {
                this.Client = client;
                return;
            }

            if (response is ErrorResponse)
            {
                ErrorResponse err = (ErrorResponse)response;
                CloseConnection();
                throw new ServiceException(err.Message);
            }
        }

        public virtual void Logout(Admin admin, IObserver client)
        {
            AdminDTO adminDto = DTOUtils.GetDTO(admin);
            SendRequest(new LogoutRequest(adminDto));
            Response response = ReadResponse();
            CloseConnection();
            if (response is ErrorResponse)
            {
                Console.WriteLine("Eroare");
                ErrorResponse err = (ErrorResponse)response;
                throw new ServiceException(err.Message);
            }
        }

        public Race FindRace(int raceId)
        {
            SendRequest(new GetRaceByIdRequest(raceId));
            Response response = ReadResponse();
            if (response is ErrorResponse)
            {
                ErrorResponse err = (ErrorResponse)response;
                throw new ServiceException(err.Message);
            }

            GetRaceByIdResponse resp = (GetRaceByIdResponse)response;
            RaceDTO raceDto = resp.Race;
            Race race = DTOUtils.GetFromDTO(raceDto);
            return race;
        }

        public RaceInfo[] GetRacesInfo()
        {
            SendRequest(new GetRacesInfoRequest());
            Response response = ReadResponse();
            if (response is ErrorResponse)
            {
                ErrorResponse err = (ErrorResponse)response;
                throw new ServiceException(err.Message);
            }

            GetRacesInfoResponse resp = (GetRacesInfoResponse)response;
            RaceInfoDTO[] raceInfoDtos = resp.Races;
            RaceInfo[] raceInfos = DTOUtils.GetFromDTO(raceInfoDtos);
            return raceInfos;
        }

        public ContestantInfo[] GetContestantsFromRace(int raceId, string nameText)
        {
            SendRequest(new GetContestantsByRaceIdAndNameRequest(raceId, nameText));
            Response response = ReadResponse();
            if (response is ErrorResponse)
            {
                ErrorResponse err = (ErrorResponse)response;
                throw new ServiceException(err.Message);
            }

            GetContestantsByRaceIdAndNameResponse resp = (GetContestantsByRaceIdAndNameResponse)response;
            ContestantInfoDTO[] contestantInfoDtos = resp.Contestants;
            ContestantInfo[] contestantInfos = DTOUtils.GetFromDTO(contestantInfoDtos);
            return contestantInfos;
        }

        public void RegisterContestant(Contestant contestant, IList<int> raceIds)
        {
            int[] ids = new int[raceIds.Count];
            for (int i = 0; i < ids.Length; i++)
            {
                ids[i] = raceIds[i];
            }

            ContestantDTO contestantDto = new ContestantDTO(
                contestant.Name, contestant.BirthDate, contestant.Email, contestant.Address.Country,
                contestant.Address.City, contestant.Address.Street, contestant.Address.PostalCode, ids
            );
            SendRequest(new AddContestantRequest(contestantDto));
            Response response = ReadResponse();
            if (response is ErrorResponse)
            {
                ErrorResponse err = (ErrorResponse)response;
                throw new ServiceException(err.Message);
            }
        }

        private void SendRequest(Request request)
        {
            try
            {
                Formatter.Serialize(Stream, request);
                Stream.Flush();
            }
            catch (Exception e)
            {
                throw new ServiceException("Error sending request..." + e.Message);
            }
        }

        private Response ReadResponse()
        {
            Response response = null;
            try
            {
                _waitHandle.WaitOne();
                lock (Responses)
                {
                    response = Responses.Dequeue();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

            return response;
        }

        private void CloseConnection()
        {
            finished = true;
            try
            {
                Stream.Close();
                Connection.Close();
                _waitHandle.Close();
                Client = null;
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }
        }

        private void InitializeConnection()
        {
            try
            {
                Connection = new TcpClient(Host, Port);
                Stream = Connection.GetStream();
                Formatter = new BinaryFormatter();
                finished = false;
                _waitHandle = new AutoResetEvent(false);
                StartReader();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void StartReader()
        {
            Thread tw = new Thread(Run);
            tw.Start();
        }

        private void HandleUpdate(UpdateResponse update)
        {
            if (update is AddedContestantResponse)
            {
                try
                {
                    Client.Update();
                }
                catch (ServiceException e)
                {
                    Console.WriteLine(e.StackTrace);
                }
            }
        }
        
        public virtual void Run()
        {
            while (!finished)
            {
                try
                {
                    object response = Formatter.Deserialize(Stream);
                    Console.WriteLine("Response received " + response.ToString());
                    if (response is UpdateResponse)
                    {
                        HandleUpdate((UpdateResponse)response);
                    }
                    else
                    {
                        lock (Responses)
                        {
                            Responses.Enqueue((Response)response);
                        }

                        _waitHandle.Set();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Reading error " + e.Message);
                }
            }
        }
    }
}