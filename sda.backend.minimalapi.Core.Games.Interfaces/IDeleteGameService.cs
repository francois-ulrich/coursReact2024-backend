using sda.backend.minimalapi.Core.Games.Models;

namespace sda.backend.minimalapi.Core.Games.Interfaces
{
  public interface IDeleteGameService
  {
    public Task Delete(int id);
  }
}
