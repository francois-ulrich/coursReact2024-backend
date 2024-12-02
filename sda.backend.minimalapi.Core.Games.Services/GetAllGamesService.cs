using sda.backend.minimalapi.Core.Games.Interfaces;
using sda.backend.minimalapi.Core.Games.Models;
using Microsoft.EntityFrameworkCore;
using sda.backend.minimalapi.Core.Games.Services.Models;


namespace sda.backend.minimalapi.Core.Games.Services
{
    public class GetAllGamesService : IGetAllGamesService
    {
        private readonly GameDbContext _gameDbContext;

        public GetAllGamesService(GameDbContext gameDbContext)
        {
            _gameDbContext = gameDbContext;
        }

        public IEnumerable<Game> GetAll()
        {
            return _gameDbContext.Games.ToList();
        }
    }
}
