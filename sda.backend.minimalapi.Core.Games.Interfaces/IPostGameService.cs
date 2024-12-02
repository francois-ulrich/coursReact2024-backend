using sda.backend.minimalapi.Core.Games.Models;

namespace sda.backend.minimalapi.Core.Games.Interfaces
{
    public interface IPostGameService
    {
        public Task<Game> Post(GameDto game);
    }
}
