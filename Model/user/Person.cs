using System;

namespace SwimmingModel.user
{
    public abstract class Person : Entity<int>
    {

        public String Name { get; set; }
        public DateTime BirthDate { get; set; }
        public String Email { get; set; }
        public Address Address { get; set; }
        
        protected Person(int id) : base(id)
        {
        }

        protected Person(int id, string name, DateTime birthDate, string email, Address address) : base(id)
        {
            Name = name;
            BirthDate = birthDate;
            Email = email;
            Address = address;
        }
        
        protected Person(string name, DateTime birthDate, string email, Address address) : base()
        {
            Name = name;
            BirthDate = birthDate;
            Email = email;
            Address = address;
        }
        public string ToString()
        {
            return String.Format("id: {0}\nname: {1}\nemail: {2}\nbirth date: {3}\n", Id, Name, Email,
                BirthDate.ToString());
        }
    }
}