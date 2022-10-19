using Sport.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sport.Models
{
    public class Coach : Person
    {
        public int CoachID { get; set; }
        public IEnumerable<Team> Teams { get; set; }
        public IEnumerable<Training> Training { get; set; }
        public IEnumerable<Game> Games { get; set; }

        //parameterless constructor for EF migration
        private Coach() : this("", "", null) { }
        
        public Coach(Person person) : this(person.FirstName, person.LastName, person.BirthDate)
        {
        }

        public Coach(string firstName, string lastName, DateOnly? birthDate) : base(firstName, lastName, birthDate)
        {
            Teams = new List<Team>();
            Training = new List<Training>();
            Games = new List<Game>();
        }
    }
}
