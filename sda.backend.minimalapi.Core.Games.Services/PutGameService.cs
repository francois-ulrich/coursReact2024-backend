using sda.backend.minimalapi.Core.Games.Interfaces;
using sda.backend.minimalapi.Core.Games.Models;
using sda.backend.minimalapi.Core.Games.Services.Models;

namespace sda.backend.minimalapi.Core.Games.Services
{
  public class PutGameService : IPutGameService
  {
    private readonly GameDbContext _gameDbContext;

    public PutGameService(GameDbContext gameDbContext)
    {
      _gameDbContext = gameDbContext;
    }

    public async Task<Game> Put(int id, GameDto gameDto)
    {
      var existingGame = await _gameDbContext.Games.FindAsync(id);

      if (existingGame == null)
        throw new Exception("Game not found");

      existingGame.Name = gameDto.Name;
      existingGame.CharacterName = gameDto.CharacterName;
      existingGame.Success = gameDto.Success;
      existingGame.DateStart = gameDto.DateStart;
      existingGame.DateEnd = gameDto.DateEnd;

      await _gameDbContext.SaveChangesAsync();
      return existingGame;
    }
  }
}
