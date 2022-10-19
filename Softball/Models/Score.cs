using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sport.Models
{
    public class Score
    {
        public int ScoreId { get; set; }
        public int HomePoints { get; set; }
        public int GuestPoints { get; set; }

        public Score()
        {
            HomePoints = 0;
            GuestPoints = 0;
        }

        public Score(int homePoints, int guestPoints)
        {
            HomePoints = homePoints;
            GuestPoints = guestPoints;
        }

        public void Homepoint()
        {
            HomePoints++;
        }

        public void GuestPoint()
        {
            GuestPoints++;
        }
        public void SetScore(int homePoints, int guestPoints)
        {
            HomePoints = homePoints;
            GuestPoints = guestPoints;
        }
    }
}
