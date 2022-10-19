using Sport.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sport.Models
{
    public class Team : Active
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public IEnumerable<Player> Players { get; set; }
        public IEnumerable<Coach> Coach { get; set; }

        //parameterless constructor for EF migration
        private Team() : this("") { }

        public Team(string teamName)
        {
            TeamName = teamName;
            Players = new List<Player>();
            Coach = new List<Coach>();
        }

        public Team(string teamName, IEnumerable<Player> players) : this(teamName)
        {
            Players = players;
        }

        public Team(string teamName, IEnumerable<Player> players, IEnumerable<Coach> coaches) : this(teamName, players)
        {
            Coach = coaches;
        }
    }
}
