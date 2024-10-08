using sda.backend.minimalapi.Core.Games.Interfaces;
using sda.backend.minimalapi.Core.Games.Models;
using sda.backend.minimalapi.Core.Games.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace sda.backend.minimalapi.Core.Games.Services;

public class FakeInMemoryGetAllGamesService: IGetAllGamesService
{
    private readonly GameDbContext _gameDbContext;

    public FakeInMemoryGetAllGamesService(GameDbContext gameDbContext)
    {
        _gameDbContext = gameDbContext;
    }

    public IEnumerable<Game> GetAll()
    {
        return new List<Game>()
        {
            new Game { Id = 1, DateStart = DateTime.Now, CharacterName = "Bilbo" },
            new Game { Id = 2, DateStart = DateTime.Now, CharacterName = "Gandalf" },
            new Game { Id = 3, DateStart = DateTime.Now, CharacterName = "Thorin" },
            new Game { Id = 4, DateStart = DateTime.Now, CharacterName = "Balin" },
            new Game { Id = 5, DateStart = DateTime.Now, CharacterName = "Dwalin" },
            new Game { Id = 6, DateStart = DateTime.Now, CharacterName = "Bombur" },
        };
    }
}