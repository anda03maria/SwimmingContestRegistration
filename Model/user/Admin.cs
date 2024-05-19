using System;

namespace SwimmingModel.user
{
    public class Admin : Person
    {
        public String Password { get; set; }
        
        public Admin(int id) : base(id)
        {
        }
        
        public Admin(int id, string password) : base(id)
        {
            Password = password;
        }

        public Admin(int id, string name, DateTime birthDate, string email, Address address) : base(id, name, birthDate, email, address)
        {
        }
        
        public Admin(string name, DateTime birthDate, string email, Address address, string password) : base(name, birthDate, email, address)
        {
            Password = password;
        }

        public Admin(int id, string name, DateTime birthDate, string email, Address address, string password) : base(id, name, birthDate, email, address)
        {
            Password = password;
        }

    }
}