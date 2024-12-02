using sda.backend.minimalapi.Core.Games.Interfaces;
using sda.backend.minimalapi.Core.Games.Models;
using Microsoft.EntityFrameworkCore;
using sda.backend.minimalapi.Core.Games.Services.Models;


namespace sda.backend.minimalapi.Core.Games.Services
{
  public class GetGameService : IGetGameService
  {
    private readonly GameDbContext _gameDbContext;

    public GetGameService(GameDbContext gameDbContext)
    {
      _gameDbContext = gameDbContext;
    }

    public async Task<Game?> Get(int id)
    {
      return await _gameDbContext.Games.FindAsync(id);
    }
  }
}
