using Sport.Models;
using System.IO;
using System.Reflection.Emit;

namespace MVC.Models
{
    public class AdressViewModel : Adress
    {
        public bool Edit { get; set; }

        //Parameterless constructor
        public AdressViewModel() : this(new Adress())
        {
            Edit = false;
        }

        //Adress constructor
        public AdressViewModel(Adress adress)
        {
            AdressId = adress.AdressId;
            Street = adress.Street;
            StreetNumber = adress.StreetNumber;
            StreetNumberAddition = adress.StreetNumberAddition;
            Zipcode = adress.Zipcode;
            City = adress.City;
            PhoneNumber = adress.PhoneNumber;
            Edit = false;
        }
    }

}
