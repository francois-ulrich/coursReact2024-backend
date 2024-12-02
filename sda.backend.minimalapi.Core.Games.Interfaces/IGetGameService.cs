using sda.backend.minimalapi.Core.Games.Models;

namespace sda.backend.minimalapi.Core.Games.Interfaces
{
  public interface IGetGameService
  {
    public Task<Game?> Get(int id);
  }
}
