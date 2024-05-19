using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using Services;
using SwimmingModel;
using SwimmingModel.contest;
using SwimmingModel.dto;
using SwimmingModel.user;
using SwimmingNetworking.dto;
using SwimmingServices;

namespace SwimmingNetworking.objectprotocol
{
    public class ClientObjectWorker : IObserver
    {
        private IService Service;
        private TcpClient Connection;

        private NetworkStream Stream;
        private IFormatter Formatter;
        private volatile bool connected;

        public ClientObjectWorker(IService service, TcpClient connection)
        {
            this.Service = service;
            this.Connection = connection;
            try
            {
                Stream = Connection.GetStream();
                Formatter = new BinaryFormatter();
                connected = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        public void Update()
        {
            Console.WriteLine("Added contestant");
            try
            {
                SendResponse(new AddedContestantResponse());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        
        public virtual void run()
        {
            while (connected)
            {
                try
                {
                    object request = Formatter.Deserialize(Stream);
                    object response = HandleRequest((Request)request);
                    if (response != null)
                    {
                        SendResponse((Response)response);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }

                try
                {
                    Thread.Sleep(1000);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
            }

            try
            {
                Stream.Close();
                Connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        private Response HandleRequest(Request request)
        {
            Response response = null;
            if (request is LoginRequest)
            {
                Console.WriteLine("Login Request...");
                LoginRequest logReq = (LoginRequest)request;
                AdminDTO adminDto = logReq.Admin;
                Admin admin = DTOUtils.GetFromDTO(adminDto);
                try
                {
                    lock (Service)
                    {
                        Service.Login(admin, this);
                    }

                    return new OKResponse();
                }
                catch (ServiceException e)
                {
                    connected = false;
                    return new ErrorResponse(e.Message);
                }
            } else if (request is LogoutRequest)
            {
                Console.WriteLine("Logout Request...");
                LogoutRequest logReq = (LogoutRequest)request;
                AdminDTO adminDto = logReq.Admin;
                Admin admin = DTOUtils.GetFromDTO(adminDto);
                try
                {
                    lock (Service)
                    {
                        Service.Logout(admin, this);
                    }

                    connected = false;
                    return new OKResponse();
                }
                catch (ServiceException e)
                {
                    return new ErrorResponse(e.Message);
                }
            } else if (request is GetRacesInfoRequest)
            {
                Console.WriteLine("Get Races Info Request...");
                try
                {
                    lock (Service)
                    {
                        RaceInfo[] races = Service.GetRacesInfo();
                        RaceInfoDTO[] raceInfoDtos = DTOUtils.GetDTO(races);
                        return new GetRacesInfoResponse(raceInfoDtos);
                    }
                }
                catch (ServiceException e)
                {
                    return new ErrorResponse(e.Message);
                }
            } else if (request is GetRaceByIdRequest)
            {
                Console.WriteLine("Get Race by ID Request...");
                GetRaceByIdRequest getRaceReq = (GetRaceByIdRequest)request;
                int raceId = getRaceReq.RaceId;
                try
                {
                    lock (Service)
                    {
                        Race race = Service.FindRace(raceId);
                        RaceDTO raceDto = DTOUtils.GetDTO(race);
                        return new GetRaceByIdResponse(raceDto);
                    }
                }
                catch (ServiceException e)
                {
                    return new ErrorResponse(e.Message);
                }
            } else if (request is GetContestantsByRaceIdAndNameRequest)
            {
                Console.WriteLine("Get Contestants by Race ID and Name Request...");
                GetContestantsByRaceIdAndNameRequest getContestantsReq = (GetContestantsByRaceIdAndNameRequest)request;
                int raceId = getContestantsReq.RaceId;
                string nameText = getContestantsReq.NameText;
                try
                {
                    lock (Service)
                    {
                        ContestantInfo[] contestantInfos = Service.GetContestantsFromRace(raceId, nameText);
                        ContestantInfoDTO[] contestantInfoDtos = DTOUtils.GetDTO(contestantInfos);
                        return new GetContestantsByRaceIdAndNameResponse(contestantInfoDtos);
                    }
                }
                catch (ServiceException e)
                {
                    return new ErrorResponse(e.Message);
                }
            } else if (request is AddContestantRequest)
            {
                Console.WriteLine("Add Contestant Request...");
                AddContestantRequest addReq = (AddContestantRequest)request;
                ContestantDTO contestantDto = addReq.Contestant;
                try
                {
                    lock (Service)
                    {
                        IList<int> raceIds = new List<int>();
                        int[] ids = contestantDto.RaceIds;
                        for (int i = 0; i < ids.Length; i++)
                        {
                            raceIds.Add(ids[i]);
                        }

                        Service.RegisterContestant(
                            new Contestant(contestantDto.Name, contestantDto.BirthDate, contestantDto.Email,
                                new Address(contestantDto.Country, contestantDto.City, contestantDto.Street,
                                    contestantDto.PostalCode)
                            ), raceIds);
                        return new OKResponse();
                    }
                }
                catch (ServiceException e)
                {
                    return new ErrorResponse(e.Message);
                }
            }

            return response;
        }

        public void SendResponse(Response response)
        {
            Console.WriteLine("Sending response... " + response.ToString()) ;
            lock (Stream)
            {
                Formatter.Serialize(Stream, response);
                Stream.Flush();
            }
        }
    }
}