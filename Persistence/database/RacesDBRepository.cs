using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using log4net;
using SwimmingModel.contest;
using SwimmingModel.dto;


namespace SwimmingPersistence.database
{
    public class RacesDBRepository: IRacesRepository, IDBRepository<int, Race>
    {

        private static readonly ILog log = LogManager.GetLogger("RacesDBRepository");
        private IDictionary<string, string> props;

        public RacesDBRepository(IDictionary<string, string> props)
        {
            log.Info("Creating RacesDBRepository");
            this.props = props;
        }
        
        public Race FindOne(int id)
        {
            log.InfoFormat("Entering findOne with value {0}", id);
            IDbConnection connection = DBUtils.GetConnection(props);
            
            using (var comm = connection.CreateCommand())
            {
                comm.CommandText = "select * from Races where id = @id";
                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                comm.Parameters.Add(paramId);

                using (var dataR = comm.ExecuteReader())
                {
                    if (dataR.Read())
                    {
                        Race race = extractEntity(dataR);
                       log.InfoFormat("Exiting findOne with value {0}", race);
                        return race;
                    }
                }
            }
            log.InfoFormat("Exiting findOne with value {0}", null);
            return null;
        }

        public IList<Race> FindAll()
        {
            log.Info("Entering findAll");
            IDbConnection connection = DBUtils.GetConnection(props);
            IList<Race> allRaces = new List<Race>();
            using (var comm = connection.CreateCommand())
            {
                comm.CommandText = "select * from Races";

                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        allRaces.Add(extractEntity(dataR));
                    }
                }
            }
            if (allRaces.Count == 0)
            {
                log.Warn("No Race found");
            }
            log.Info("Exiting findAll");
            return allRaces;
        }

        public bool Save(Race entity)
        {
            log.Info("Entering Save");
            IDbConnection connection = DBUtils.GetConnection(props);
            using (var comm = connection.CreateCommand())
            {
                comm.CommandText = "insert into Races(distance, scheduled_day, style) values " +
                                   "(@distance, @date, @style)";
                //Distance
                var paramDistance = comm.CreateParameter();
                paramDistance.ParameterName = "@distance";
                paramDistance.Value = entity.Distance;
                comm.Parameters.Add(paramDistance);
                //Scheduled Day
                var paramDate = comm.CreateParameter();
                paramDate.ParameterName = "@date";
                paramDate.Value = entity.Date.ToString("yyyy-MM-dd");
                comm.Parameters.Add(paramDate);
                //Swimming Style
                var paramStyle = comm.CreateParameter();
                paramStyle.ParameterName = "@style";
                paramStyle.Value = entity.Style.ToString();
                comm.Parameters.Add(paramStyle);

                int result = comm.ExecuteNonQuery();
                if (result == 0)
                {
                    log.Warn("No Race saved");
                    return false;
                }
            }
            log.Info("Exiting Save");
            return true;
        }

        public Race Delete(int id)
        {
            //throw new System.NotImplementedException();
            return null;
        }

        public bool Update(Race entity)
        {
            //throw new System.NotImplementedException();
            return false;
        }

        public Race extractEntity(IDataReader dataR)
        {
            int idRace = dataR.GetInt32(0);
            int distance = dataR.GetInt32(1);
            DateTime scheduledDay = dataR.GetDateTime(3);
            SwimmingStyle swimmingStyle = (SwimmingStyle) Enum.Parse(typeof(SwimmingStyle), dataR.GetString(2), true);
            Race race = new Race(idRace, distance, swimmingStyle, scheduledDay);
            return race;
        }

        public IList<Race> GetRacesByContestantId(int contestantId)
        {
            log.InfoFormat("Entering GetRacesByContestantId with value {}", contestantId);
            IDbConnection connection = DBUtils.GetConnection(props);
            IList<Race> foundRaces = new List<Race>();
            using (var comm = connection.CreateCommand())
            {
                comm.CommandText = "select * from Races R inner join Registrations Reg on R.id = Reg.id_race inner join Contestants C on C.id = Reg.id_contestant where C.id = @id";
                var paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = contestantId;
                comm.Parameters.Add(paramId);

                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        foundRaces.Add(extractEntity(dataR));
                    }
                }
            }
            log.Info("Exiting GetRacesByContestantId");
            return foundRaces;
        }

        public IList<RaceInfo> GetRacesDetails()
        {
            log.InfoFormat("Entering GetRacesDetails with value");
            IList<RaceInfo> racesInfo = new List<RaceInfo>();
            IDbConnection connection = DBUtils.GetConnection(props);
            using (var comm = connection.CreateCommand())
            {
                comm.CommandText =
                    "select R.id, R.distance, R.scheduled_day, R.style, count(Reg.id) as 'count' from Races R " +
                    "inner join Registrations Reg on R.id = Reg.id_race " +
                    "group by R.id";

                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int raceId = dataR.GetInt32(0);
                        int distance = dataR.GetInt32(1);
                        DateTime scheduledDay = dataR.GetDateTime(2);
                        SwimmingStyle swimmingStyle = (SwimmingStyle) Enum.Parse(typeof(SwimmingStyle), dataR.GetString(3), true);
                        int count = dataR.GetInt32(4);
                        racesInfo.Add(new RaceInfo(
                            raceId, distance, scheduledDay, swimmingStyle, count));
                    }                    
                }
            }
            log.Info("Exiting GetRacesDetails");
            return racesInfo;
        }
    }
}