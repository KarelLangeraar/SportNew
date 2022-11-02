using Sport.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportData.Data.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IClubRepository Club { get; }
        ITeamRepository Team { get; }
        IPlayerRepository Player { get; }
        ICoachRepository Coach { get; }
        IGameRepository Game { get; }
        ITrainingRepository Training { get; }
        IAdressRepository Adress { get; }
        IScoreRepository Score { get; }

        Task<int> CompleteAsync();
        int Complete();

    }
}
