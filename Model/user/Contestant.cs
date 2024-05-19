using System;

namespace SwimmingModel.user
{
    public class Contestant : Person
    {
        public Contestant(int id, string name, DateTime birthDate, string email, Address address) : base(id, name, birthDate, email, address)
        {
        }
        
        public Contestant(string name, DateTime birthDate, string email, Address address) : base(name, birthDate, email, address)
        {
        }
        
    }
}