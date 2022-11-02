using Sport.Data;
using Sport.Data.Repositories;
using Sport.Models.Interfaces;
using SportData.Data.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportData.Data
{
    internal class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly SportContext _context;

        public IClubRepository Club { get; private set; }
        public ITeamRepository Team { get; private set; }
        public IPlayerRepository Player { get; private set; }
        public ICoachRepository Coach { get; private set; }
        public IGameRepository Game { get; private set; }
        public ITrainingRepository Training { get; private set; }
        public IAdressRepository Adress { get; private set; }
        public IScoreRepository Score { get; private set; }

        private bool _disposed;


        public UnitOfWork(SportContext context)
        {
            _context = context;
            Club = new ClubRepository(_context);
            Team = new TeamRepository(_context);
            Player = new PlayerRepository(_context);
            Coach = new CoachRepository(_context);
            Game = new GameRepository(_context);
            Training = new TrainingRepository(_context);
            Adress = new AdressRepository(_context);
            Score = new ScoreRepository(_context);
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                _disposed = true;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
