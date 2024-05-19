using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using log4net;
using SwimmingModel;
using SwimmingModel.user;


namespace SwimmingPersistence.database
{
    public class ContestantsDBRepository: IContestantsRepository, IDBRepository<int, Contestant>
    {
        private static readonly ILog log = LogManager.GetLogger("ContestantsDBRepository");
        private IDictionary<string, string> props;

        public ContestantsDBRepository(IDictionary<string, string> props)
        {
            log.Info("Creating ContestantsDBRepository");
            this.props = props;
        }
        
        public Contestant FindOne(int id)
        {
            log.InfoFormat("Entering findOne with value {0}", id);
            IDbConnection connection = DBUtils.GetConnection(props);
            using (var comm = connection.CreateCommand())
            {
                comm.CommandText = "select * from Contestants where id = @id";
                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                comm.Parameters.Add(paramId);

                using (var dataR = comm.ExecuteReader())
                {
                    if (dataR.Read())
                    {
                        Contestant contestant = extractEntity(dataR);
                        log.InfoFormat("Exiting findOne with value {0}", contestant);
                        return contestant;
                    }
                }
            }
            log.Warn("Exiting findOne with value {0}", null);
            return null;        }

        public IList<Contestant> FindAll()
        {
            log.Info("Entering findAll");
            IDbConnection connection = DBUtils.GetConnection(props);
            IList<Contestant> allContestants = new List<Contestant>();
            using (var comm = connection.CreateCommand())
            {
                comm.CommandText = "select * from Contestants";

                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        allContestants.Add(extractEntity(dataR));
                    }
                }
            }
            if (allContestants.Count == 0)
            {
                log.Warn("No Contestant found");
            }
            log.Info("Exiting findAll");
            return allContestants;        }

        public bool Save(Contestant entity)
        {
            log.InfoFormat("Entering Save with value {0}", entity.ToString());
            IDbConnection connection = DBUtils.GetConnection(props);
            using (var comm = connection.CreateCommand())
            {
                comm.CommandText =
                    "insert into Contestants(name, birth_date, email, country, city, street, postal_code) values " +
                    "(@name, @birthDate, @email, @country, @city, @street, @postalCode)";
                //Name
                var paramName = comm.CreateParameter();
                paramName.ParameterName = "@name";
                paramName.Value = entity.Name;
                comm.Parameters.Add(paramName);
                //Birth Date
                var paramDate = comm.CreateParameter();
                paramDate.ParameterName = "@birthDate";
                paramDate.Value = entity.BirthDate.ToString("yyyy-MM-dd");
                comm.Parameters.Add(paramDate);
                //Email
                var paramEmail = comm.CreateParameter();
                paramEmail.ParameterName = "@email";
                paramEmail.Value = entity.Email;
                comm.Parameters.Add(paramEmail);
                //Country
                var paramCountry = comm.CreateParameter();
                paramCountry.ParameterName = "@country";
                paramCountry.Value = entity.Address.Country;
                comm.Parameters.Add(paramCountry);
                //City
                var paramCity = comm.CreateParameter();
                paramCity.ParameterName = "@city";
                paramCity.Value = entity.Address.City;
                comm.Parameters.Add(paramCity);
                //Street
                var paramStreet = comm.CreateParameter();
                paramStreet.ParameterName = "@street";
                paramStreet.Value = entity.Address.Street;
                comm.Parameters.Add(paramStreet);
                //Postal code
                var paramCode = comm.CreateParameter();
                paramCode.ParameterName = "@postalCode";
                paramCode.Value = entity.Address.PostalCode;
                comm.Parameters.Add(paramCode);
               
                int result = comm.ExecuteNonQuery();
                if (result == 0)
                {
                    log.Warn("No Admin saved");
                    return false;
                }
            }
            log.Info("Exiting Save");
            return true;
        }

        public Contestant Delete(int id)
        {
            return null;
        }

        public bool Update(Contestant entity)
        {
            return false;
        }

        public Contestant extractEntity(IDataReader dataR)
        {
            int contestantId = dataR.GetInt32(1);
            string name = dataR.GetString(0);
            DateTime birthDate = dataR.GetDateTime(3);
            string email = dataR.GetString(2);
            string country = dataR.GetString(4);
            string city = dataR.GetString(5);
            string street = dataR.GetString(6);
            string postalCode = dataR.GetString(7);
            return new Contestant(contestantId, name, birthDate, email, new Address(
                country, city, street, postalCode));
        }

        public int GetNumberOfContestantsFromRace(int raceId)
        {
            log.InfoFormat("Entering numberOfContestantsFromRace with value {0}", raceId);
            IDbConnection connection = DBUtils.GetConnection(props);
            using (var comm = connection.CreateCommand())
            {
                comm.CommandText =
                    "select count(*) as 'count' from Contestants inner join Registrations on Contestants.id = Registrations.id_contestant inner join Races on Registrations.id_race = Races.id where Races.id = @raceId";
                IDbDataParameter paramRaceId = comm.CreateParameter();
                paramRaceId.ParameterName = "@raceId";
                paramRaceId.Value = raceId;
                comm.Parameters.Add(paramRaceId);

                using (var dataR = comm.ExecuteReader())
                {
                    if (dataR.Read())
                    {
                        int count = dataR.GetInt32(0);
                        log.InfoFormat("Exiting numberOfContestantsFromRace with value {0}", count);
                        return count;
                    }
                }
            }
            log.Warn("Something went wrong");
            return 0;
        }

        public IList<Contestant> GetContestantsFromRace(int raceId)
        {
            log.InfoFormat("Entering contestantsFromRace with value {0}", raceId);
            IList<Contestant> foundCOntestants = new List<Contestant>();
            IDbConnection connection = DBUtils.GetConnection(props);
            using (var comm = connection.CreateCommand())
            {
                comm.CommandText =
                    "select * from Contestants inner join Registrations on Contestants.id = Registrations.id_contestant inner join Races on Registrations.id_race = Races.id where Races.id = @raceId";
                IDbDataParameter paramRaceId = comm.CreateParameter();
                paramRaceId.ParameterName = "@raceId";
                paramRaceId.Value = raceId;
                comm.Parameters.Add(paramRaceId);
                
                
                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        foundCOntestants.Add(extractEntity(dataR));
                    }
                }
            }
            log.InfoFormat("Exiting contestantsFromRace");
            return foundCOntestants;
        }

        
        public IList<Contestant> GetContestantsFromRaceAndName(int raceId, string searchText)
        {
            log.InfoFormat("Entering contestantsFromRace with value {0}", raceId);
            IList<Contestant> foundCOntestants = new List<Contestant>();
            IDbConnection connection = DBUtils.GetConnection(props);
            using (var comm = connection.CreateCommand())
            {
                comm.CommandText =
                    "select * from Contestants inner join Registrations on Contestants.id = Registrations.id_contestant inner join Races on Registrations.id_race = Races.id where Races.id = @raceId and name like @text";
                IDbDataParameter paramRaceId = comm.CreateParameter();
                paramRaceId.ParameterName = "@raceId";
                paramRaceId.Value = raceId;
                comm.Parameters.Add(paramRaceId);

                IDbDataParameter paramText = comm.CreateParameter();
                paramText.ParameterName = "@text";
                paramText.Value = "%" + searchText + "%";
                comm.Parameters.Add(paramText);
                
                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        foundCOntestants.Add(extractEntity(dataR));
                    }
                }
            }
            log.InfoFormat("Exiting contestantsFromRace");
            return foundCOntestants;
        }
        
        
        public Contestant GetLastContestantInserted()
        {
            log.InfoFormat("Entering GetLastContestantInserted");
            IDbConnection connection = DBUtils.GetConnection(props);
            using (var comm = connection.CreateCommand())
            {
                comm.CommandText = "select * from Contestants where id = (select max(id) from Contestants)";
                using (var dataR = comm.ExecuteReader())
                {
                    if (dataR.Read())
                    {
                        return extractEntity(dataR);
                    }
                    else
                    {
                        log.Warn("Something went wrong");
                    }
                }
            }

            return null;
        }
    }
}