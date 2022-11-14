using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork9
{
    struct MailSorting
    {
        public string City;
        public string Street;
        public string House;
        public string Apartment;
        public string ToWho;
        public double Value;

        public MailSorting(string city, string street, 
            string house, string apartment, string toWho, double value)
        {
            City = city;
            Street = street;
            House = house;
            Apartment = apartment;
            Value = value;
            ToWho = toWho;
            Value = value;
        }
    }
}
