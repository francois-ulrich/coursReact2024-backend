using sda.backend.minimalapi.Core.Games.Interfaces;
using sda.backend.minimalapi.Core.Games.Models;
using sda.backend.minimalapi.Core.Games.Services.Models;

namespace sda.backend.minimalapi.Core.Games.Services
{
    public class PostGameService : IPostGameService
    {
        private readonly GameDbContext _gameDbContext;

        public PostGameService(GameDbContext gameDbContext)
        {
            _gameDbContext = gameDbContext;
        }

        public async Task<Game> Post(GameDto gameDto)
        {
            var game = new Game
            {
                Name = gameDto.Name,
                CharacterName = gameDto.CharacterName,
                Success = gameDto.Success,
                DateStart = gameDto.DateStart,
                DateEnd = gameDto.DateEnd
            };

            _gameDbContext.Games.Add(game);
            await _gameDbContext.SaveChangesAsync();
            return game;
        }
    }
}
