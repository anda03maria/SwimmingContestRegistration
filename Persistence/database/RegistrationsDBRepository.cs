using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;
using log4net;
using SwimmingModel.contest;

namespace SwimmingPersistence.database
{
    public class RegistrationsDBRepository: IRegistrationsRepository, IDBRepository<int, Registration>
    {
        private static readonly ILog log = LogManager.GetLogger("RegistrationDBRepository");
        private IDictionary<string, string> props;

        public RegistrationsDBRepository(IDictionary<string, string> props)
        {
            log.Info("Creating RegistrationDBRepository");
            this.props = props;
        }

        public Registration FindOne(int id)
        {
            log.InfoFormat("Entering findOne with value {0}", id);
            IDbConnection connection = DBUtils.GetConnection(props);
            using (var comm = connection.CreateCommand())
            {
                comm.CommandText = "select * from Registrations where id = @id";
                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                comm.Parameters.Add(paramId);
                using (var dataR = comm.ExecuteReader())
                {
                    if (dataR.Read())
                    {
                        Registration registration = extractEntity(dataR);
                        log.InfoFormat("Exiting findOne with value {0}", registration);
                        return registration;
                    }
                }
            }
            log.Warn("Exiting findOne with value {0}", null);
            return null;
        }

        public Registration FindRegistrationByPairIds(int contestantId, int raceId)
        {
            log.InfoFormat("Entering findOneByPairIds with value {0}, {1}", contestantId, raceId);
            IDbConnection connection = DBUtils.GetConnection(props);
            using (var comm = connection.CreateCommand())
            {
                comm.CommandText = "select * from Registrations where id_contestant = @idContestant and id_race = @idRace";
                //Contestant ID
                IDbDataParameter paramIdContestant = comm.CreateParameter();
                paramIdContestant.ParameterName = "@idContestant";
                paramIdContestant.Value = contestantId;
                comm.Parameters.Add(paramIdContestant);
                
                //Race ID
                IDataParameter paramIdRace = comm.CreateParameter();
                paramIdRace.ParameterName = "@idRace";
                paramIdRace.Value = raceId;
                comm.Parameters.Add(paramIdRace);
                using (var dataR = comm.ExecuteReader())
                {
                    if (dataR.Read())
                    {
                        Registration registration = extractEntity(dataR);
                        log.InfoFormat("Exiting findOne with value {0}", registration);
                        return registration;
                    }
                }
            }
            log.Warn("Exiting findOne with value {0}", null);
            return null;
        }

        public IList<Registration> FindAll()
        {
            log.Info("Entering findAll");
            IDbConnection connection = DBUtils.GetConnection(props);
            IList<Registration> allRegistrations = new List<Registration>();
            using (var comm = connection.CreateCommand())
            {
                comm.CommandText = "select * from Registrations";

                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        allRegistrations.Add(extractEntity(dataR));
                    }
                }
            }
            if (allRegistrations.Count == 0)
            {
                log.Warn("No Registration found");
            }
            log.Info("Exiting findAll");
            return allRegistrations;
        }

        public bool Save(Registration entity)
        {
            log.InfoFormat("Entering Save with value {0}", entity);
            if (FindRegistrationByPairIds(entity.ContestantId, entity.RaceId) != null)
            {
                log.Warn("Registration already exists");
                return false;
            }
            IDbConnection connection = DBUtils.GetConnection(props);
            using (var comm = connection.CreateCommand())
            {
                comm.CommandText = "insert into Registrations(id_contestant, id_race, registration_date) values " +
                                   "(@idContestant, @idRace, @date)";
                //Contestant ID
                var paramIdContestant = comm.CreateParameter();
                paramIdContestant.ParameterName = "@idContestant";
                paramIdContestant.Value = entity.ContestantId;
                comm.Parameters.Add(paramIdContestant);
                
                //Race ID
                var paramIdRace = comm.CreateParameter();
                paramIdRace.ParameterName = "idRace";
                paramIdRace.Value = entity.RaceId;
                comm.Parameters.Add(paramIdRace);
                
                //Date
                var paramDate = comm.CreateParameter();
                paramDate.ParameterName = "date";
                paramDate.Value = entity.RegistrationDate.ToString("yyyy-MM-dd");
                comm.Parameters.Add(paramDate);

                int result = comm.ExecuteNonQuery();
                if (result == 0)
                {
                    log.Warn("No registration saved");
                    return false;
                }
                log.Info("Exiting Save");
                return true;
            }
        }

        public Registration Delete(int id)
        {
            return null;
        }

        public bool Update(Registration entity)
        {
            return false;
        }

        public Registration extractEntity(IDataReader dataR)
        {
            int id = dataR.GetInt32(0);
            int contestantId = dataR.GetInt32(1);
            int raceId = dataR.GetInt32(2);
            DateTime registrationDate = dataR.GetDateTime(3);
            return new Registration(id, contestantId, raceId, registrationDate);
        }
    }
}