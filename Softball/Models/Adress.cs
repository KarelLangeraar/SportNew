using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Sport.Models
{
    public class Adress
    {
        public int AdressId { get; set; }
        public string Street { get; set; }
        public int StreetNumber { get; set; }
        public string StreetNumberAddition { get; set; }
        public string Zipcode { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }

        //parameterless constructor for EF migration
        private Adress() : this("", 0, "", "", "", "") { }

        public Adress(string street, int streetNumber, string zipcode, string city, string phoneNumber)
        {
            Street = street;
            StreetNumber = streetNumber;
            StreetNumberAddition = "";
            Zipcode = zipcode;
            City = city;
            PhoneNumber = phoneNumber;
        }

        public Adress(string street, int streetNumber, string streetNumberAddition, string zipcode, string city, string phoneNumber)
        {
            Street = street;
            StreetNumber = streetNumber;
            StreetNumberAddition = streetNumberAddition;
            Zipcode = zipcode;
            City = city;
            PhoneNumber = phoneNumber;
        }
    }
}
