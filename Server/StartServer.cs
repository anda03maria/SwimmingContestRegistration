using System;
using System.Collections.Generic;
using System.Configuration;
using SwimmingModel.contest;
using SwimmingNetworking.utils;
using SwimmingPersistence;
using SwimmingPersistence.database;
using SwimmingServices;

namespace SwimmingServer
{
   class StartServer
    {
        static void Main()
        {
            IDictionary<string, string> dict = new Dictionary<string, string>();
            dict["ConnectionString"] = GetConnectionStringByName("swimming_contest");
            IAdminsRepository adminsRepository = new AdminsDBRepository(dict);
            IContestantsRepository contestantsRepository = new ContestantsDBRepository(dict);
            IRacesRepository racesRepository = new RacesDBRepository(dict);
            IRegistrationsRepository registrationsRepository = new RegistrationsDBRepository(dict);

            IService serviceImpl = new ServicesImpl(adminsRepository, contestantsRepository, racesRepository,
                registrationsRepository);

            SerialServer server = new SerialServer("127.0.0.1", 55556, serviceImpl);
            server.Start();

        }
        
        private static string GetConnectionStringByName(string swimmingContest)
        {
            string returnValue = "";
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[swimmingContest];
            if (settings != null)
            {
                returnValue = settings.ConnectionString;
            }

            return returnValue;
        }
    }
}