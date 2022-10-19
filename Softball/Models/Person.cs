using Sport.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sport.Models
{
    public class Person : Active
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly? BirthDate { get; set; }


        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = null;
        }

        public Person(string firstName, string lastName, DateOnly? birthDate) : this(firstName, lastName)
        {
            BirthDate = birthDate;
        }
    }
}
