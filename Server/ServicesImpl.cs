using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services;
using SwimmingModel.contest;
using SwimmingModel.dto;
using SwimmingModel.user;
using SwimmingPersistence;
using SwimmingServices;

namespace SwimmingServer
{
    public class ServicesImpl : IService
    {

        private IAdminsRepository AdminsRepository;
        private IContestantsRepository ContestantsRepository;
        private IRacesRepository RacesRepository;
        private IRegistrationsRepository RegistrationsRepository;
        private readonly IDictionary<int, IObserver> LoggedClients;

        public ServicesImpl(IAdminsRepository adminsRepository, IContestantsRepository contestantsRepository,
            IRacesRepository racesRepository,
            IRegistrationsRepository registrationsRepository)
        {
            this.AdminsRepository = adminsRepository;
            this.ContestantsRepository = contestantsRepository;
            this.RacesRepository = racesRepository;
            this.RegistrationsRepository = registrationsRepository;
            LoggedClients = new Dictionary<int, IObserver>();
        }
        
        public void Login(Admin admin, IObserver client)
        {
            Console.WriteLine(admin.Password);
            Admin adminR = AdminsRepository.FindOne(admin.Id);
            if (adminR != null && adminR.Password.Equals(admin.Password))
            {
                if (LoggedClients.ContainsKey(admin.Id))
                    throw new ServiceException("Admin already logged in");
                LoggedClients[admin.Id] = client;
            }
            else
            {
                throw new ServiceException("Authentication failed");
            }
        }

        public void Logout(Admin admin, IObserver client)
        {
            IObserver localClient = LoggedClients[admin.Id];
            if (localClient == null)
            {
                throw new ServiceException("Admin " + admin.Id + " is not logged in");
            }
            LoggedClients.Remove(admin.Id);
        }

        public Race FindRace(int raceId)
        {
            return RacesRepository.FindOne(raceId);
        }

        public RaceInfo[] GetRacesInfo()
        {
            IList<RaceInfo> races = RacesRepository.GetRacesDetails();
            RaceInfo[] raceInfos = new RaceInfo[races.Count];
            for (int i = 0; i < raceInfos.Length; i++)
            {
                raceInfos[i] = races[i];
            }

            return raceInfos;
        }

        public ContestantInfo[] GetContestantsFromRace(int raceId, string nameText)
        {
            IList<Contestant> contestantsFromRace = ContestantsRepository.GetContestantsFromRaceAndName(raceId, nameText);
            IList<ContestantInfo> contestantDtos = new List<ContestantInfo>();
            foreach (var contestant in contestantsFromRace)
            {
                
                IList<Race> associatedRaces = RacesRepository.GetRacesByContestantId(contestant.Id);
                IList<int> raceIds = new List<int>();
                foreach (var race in associatedRaces)
                {
                    raceIds.Add(race.Id);
                }
                contestantDtos.Add(
                    new ContestantInfo(contestant.Name, contestant.BirthDate, raceIds));
                
            }
            return contestantDtos.ToArray();
        }

        public void RegisterContestant(Contestant contestant, IList<int> raceIds)
        {
            if (ContestantsRepository.Save(contestant))
            {
                Contestant savedContestant = ContestantsRepository.GetLastContestantInserted();
                foreach (var id in raceIds)
                {
                    RegistrationsRepository.Save(new Registration(savedContestant.Id, id));
                }
                NotifyUpdate();
            }
            else
            {
                throw new ServiceException("Contestant could not be saved");
            }
        }

        private void NotifyUpdate()
        {
            IList<Admin> admins = AdminsRepository.FindAll();
            foreach (var admin in admins)
            {
                if (LoggedClients.ContainsKey(admin.Id))
                {
                    IObserver observer = LoggedClients[admin.Id];
                    Task.Run(() => observer.Update());
                }
            }
        }
    }
}