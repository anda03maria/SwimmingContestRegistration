using System;

namespace SwimmingNetworking.dto
{
    [Serializable]
    public class ContestantDTO
    {
        public string Name { get;}
        public DateTime BirthDate { get; }
        public string Email { get; }
        public string Country { get;  }
        public string City { get; }
        public string Street { get;  }
        public string PostalCode { get;  }
        public int[] RaceIds { get;}

        public ContestantDTO(string name, DateTime birthDate, string email, string country, string city, string street, string postalCode, int[] raceIds)
        {
            Name = name;
            BirthDate = birthDate;
            Email = email;
            Country = country;
            City = city;
            Street = street;
            PostalCode = postalCode;
            RaceIds = raceIds;
        }
    }
}