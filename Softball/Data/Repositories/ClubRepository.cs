
using Sport.Models;
using Sport.Models.Interfaces;

namespace Sport.Data.Repositories
{
    public class ClubRepository : Repository<Club>, IClubRepository
    {
        public ClubRepository(SportContext context) : base(context) { }
        public SportContext SportContext => _context as SportContext;

        /// <summary>
        /// Get all clubs that contain the name string in their name
        /// </summary>
        /// <param name="name">string containig the search term</param>
        /// <returns>IEnumerable<Club></returns>
        public IEnumerable<Club> GetClubsByName(string name)
        {
            return SportContext.Club.Where(x => x.Name.Contains(name)).ToList(); 
        }
    }
}
