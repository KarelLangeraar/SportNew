using Sport.Data.Repositories.Interfaces;
using Sport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Sport.Data.Repositories
{
    public class ClubRepository : Repository<Club>, IClubRepository
    {
        public ClubRepository(SportContext context) : base(context) { }
        public SportContext SportContext => Context as SportContext;

        /// <summary>
        /// Get all clubs that contain the name string in their name
        /// </summary>
        /// <param name="name">string containig the search term</param>
        /// <returns>IEnumerable<Club></returns>
        public IEnumerable<Club> GetClubsByName(string name)
        {
            return SportContext.Clubs.Where(x => x.Name.Contains(name)).ToList(); ;
        }
    }
}
