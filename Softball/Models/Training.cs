using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sport.Models
{
    public class Training
    {
        public int TrainingId {get; set;}
        public DateTime Datum { get; set; }
        public Team? Team { get; set; }
        public IEnumerable<Coach> Coach { get; set; }
        public IEnumerable<Player> Player { get; set; }

        public Training()
        {
            Datum = DateTime.Now;
            Team = null;
            Coach = new List<Coach>();
            Player = new List<Player>();
        }

        public Training(DateTime datum) : this()
        {
            Datum = datum;
        }

        public Training(DateTime datum, IEnumerable<Coach> coach) : this(datum)
        {
            Coach = coach;
        }

        public Training(DateTime datum, Coach coach) : this(datum)
        {
            Datum = datum;
            Coach = Coach.Append(coach);
        }

        public Training(DateTime datum, Team team) : this(datum)
        {
            Team = team;
            Coach = team.Coach;
        }
    }
}
