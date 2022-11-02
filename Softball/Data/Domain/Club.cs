using Sport.Models.Interfaces;

namespace Sport.Models
{
    public class Club : Active
    {
        public int ClubId { get; set; }
        public string Name { get; set; }
        public Adress Adress { get; set; }
        public IEnumerable<Team> Teams { get; set; }


        //parameterless constructor for EF migration
        public Club() : this("") { }

        public Club(string name)
        {
            Name = name;
            Teams = new List<Team>();
            Adress = new Adress();
        }

        public Club(string name, Adress adress) :this (name)
        {
            Adress = adress;
        }

        public override void Activate()
        {
            base.Activate();
            //activate all teams if club is active
            Teams.ToList().ForEach(x => x.Activate());
        }

        public override void Inactivate()
        {
            base.Inactivate();
            //inactivate all teams if club is inactive
            Teams.ToList().ForEach(x => x.Inactivate());
        }
    }
}
