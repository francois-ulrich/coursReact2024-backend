using sda.backend.minimalapi.Core.Games.Models;

namespace sda.backend.minimalapi.Core.Games.Interfaces
{
  public interface IPutGameService
  {
    public Task<Game> Put(int id, GameDto gameDto);
  }
}
