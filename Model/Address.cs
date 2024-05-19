using System;

namespace SwimmingModel
{
    public class Address
    {
        public String City { get; set; }
        public String Street { get; set; }
        public String PostalCode { get; set; }
        public String Country { get; set; }

        public Address(string country, string city, string street, string postalCode)
        {
            this.Country = country;
            this.City = city;
            this.Street = street;
            this.PostalCode = postalCode;
        }
    }
}