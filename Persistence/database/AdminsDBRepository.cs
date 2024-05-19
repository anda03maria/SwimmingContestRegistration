using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using log4net;
using SwimmingModel;
using SwimmingModel.user;


namespace SwimmingPersistence.database
{
    public class AdminsDBRepository: IAdminsRepository, IDBRepository<int, Admin>
    {
        private static readonly ILog log = LogManager.GetLogger("AdminsDBRepository");
        private IDictionary<string, string> props;

        public AdminsDBRepository(IDictionary<string, string> props)
        {
            log.Info("Creating AdminDBRepository");
            this.props = props;
        }

        public Admin FindOne(int id)
        {
            log.InfoFormat("Entering findOne with value {0}", id);
            IDbConnection connection = DBUtils.GetConnection(props);
            using (var comm = connection.CreateCommand())
            {
                comm.CommandText = "select * from Admins where id = @id";
                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                comm.Parameters.Add(paramId);

                using (var dataR = comm.ExecuteReader())
                {
                    if (dataR.Read())
                    {
                        Admin admin = extractEntity(dataR);
                        log.InfoFormat("Exiting findOne with value {0}", admin);
                        return admin;
                    }
                }
            }
            log.Warn("Exiting findOne with value {0}", null);
            return null;
        }

        public IList<Admin> FindAll()
        {
            log.Info("Entering findAll");
            IDbConnection connection = DBUtils.GetConnection(props);
            IList<Admin> allAdmins = new List<Admin>();
            using (var comm = connection.CreateCommand())
            {
                comm.CommandText = "select * from Admins";

                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        allAdmins.Add(extractEntity(dataR));
                    }
                }
            }
            if (allAdmins.Count == 0)
            {
                log.Warn("No Admin found");
            }
            log.Info("Exiting findAll");
            return allAdmins;
        }

        public bool Save(Admin entity)
        {
            log.InfoFormat("Entering Save with value {0}", entity.ToString());
            IDbConnection connection = DBUtils.GetConnection(props);
            using (var comm = connection.CreateCommand())
            {
                comm.CommandText =
                    "insert into Admins(name, birth_date, email, country, city, street, postal_code, password) values " +
                    "(@name, @birthDate, @email, @country, @city, @street, @postalCode, @password)";
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
                //Password
                var paramPassword = comm.CreateParameter();
                paramPassword.ParameterName = "@password";
                paramPassword.Value = entity.Password;
                comm.Parameters.Add(paramPassword);
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

        public Admin Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(Admin entity)
        {
            throw new System.NotImplementedException();
        }

        public Admin extractEntity(IDataReader dataR)
        {
            int adminId = dataR.GetInt32(0);
            string name = dataR.GetString(1);
            DateTime birthDate = dataR.GetDateTime(6);
            string email = dataR.GetString(5);
            string country = dataR.GetString(3);
            string city = dataR.GetString(4);
            string street = dataR.GetString(7);
            string postalCode = dataR.GetString(8);
            string password = dataR.GetString(2);
            Admin admin = new Admin(
                adminId, name, birthDate, email, new Address(
                    country, city, street, postalCode), password);
            return admin;
        }
    }
}