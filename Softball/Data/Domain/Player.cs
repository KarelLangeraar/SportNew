using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Sport.Models.Interfaces;

namespace Sport.Models
{
    public class Player : Person
    {
        public int PlayerID { get; set; }
        public int? PlayerNumber { get; set; }
        public IEnumerable<Team> Teams { get; set; }
        public IEnumerable<Training> Training { get; set; }
        public IEnumerable<Game> Games { get; set; }


        //parameterless constructor for EF migration
        public Player() : this(0, "", "", DateTime.Now) { }

        public Player(int? playerNumber, Person person) : this(playerNumber,person.FirstName, person.LastName, person.BirthDate)
        {
        }

        public Player(int? playerNumber, string firstName, string lastName, DateTime? birthDate) : base(firstName, lastName, birthDate)
        {
            PlayerNumber = playerNumber;
            Teams = new List<Team>();
            Training = new List<Training>();
            Games = new List<Game>();
        }
    }
}
