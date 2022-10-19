using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sport.Models
{
    public class Game
    {
        public int GameId { get; set; }
        public DateTime Date { get; set; }
        public DateTime? StartTime { get; private set; }
        public Team HomeTeam { get; set; }
        public Team GuestTeam { get; set; }
        public Score Score { get; set; }
        public int Innings { get; private set; }
        public TimeSpan Duration { get; private set; }
        public IEnumerable<Player> Players { get; set; }
        public IEnumerable<Coach> Coaches { get; set; }

        //parameterless constructor for EF migration
        private Game() : this(DateTime.Now, new Team(""), new Team("")) { }

        public Game(DateTime date, Team homeTeam, Team guestTeam)
        {
            Date = date;
            HomeTeam = homeTeam;
            GuestTeam = guestTeam;
            Score = new Score();
            Innings = 0;
            Duration = TimeSpan.Zero;
        }

        public void AddInning()
        {
            Innings++;
        }

        public void StartGame()
        {
            StartTime = DateTime.Now;
        }

        public void StopGame()
        {
            if (StartTime != null)
                Duration = (TimeSpan)(StartTime - (StartTime + Duration));
        }
    }
}
