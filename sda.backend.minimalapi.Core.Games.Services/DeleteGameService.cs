using sda.backend.minimalapi.Core.Games.Interfaces;
using sda.backend.minimalapi.Core.Games.Models;
using sda.backend.minimalapi.Core.Games.Services.Models;

namespace sda.backend.minimalapi.Core.Games.Services
{
  public class DeleteGameService : IDeleteGameService
  {
    private readonly GameDbContext _gameDbContext;

    public DeleteGameService(GameDbContext gameDbContext)
    {
      _gameDbContext = gameDbContext;
    }

    public async Task Delete(int id)
    {
      var gameToDelete = await _gameDbContext.Games.FindAsync(id);

      if (gameToDelete == null)
        throw new Exception("Game not found");

      _gameDbContext.Games.Remove(gameToDelete);
      await _gameDbContext.SaveChangesAsync();
    }
  }
}
