namespace Sport.Models.Interfaces
{
    public interface IClubRepository : IRepository<Club>
    {
        IEnumerable<Club> GetClubsByName(string name);
    }
}
