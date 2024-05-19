using System;

namespace SwimmingNetworking.dto
{
    [Serializable]
    public class AdminDTO
    {
        public AdminDTO(int id, string password)
        {
            Id = id;
            Password = password;
        }

        public int Id { get;}
        public string Password { get;}

        public override string ToString()
        {
            return "AdminDTO[" + Id.ToString() + " " + Password + "]";
        }
    }
}