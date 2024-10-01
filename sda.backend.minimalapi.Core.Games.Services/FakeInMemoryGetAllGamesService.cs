using sda.backend.minimalapi.Core.Games.Interfaces;
using sda.backend.minimalapi.Core.Games.Models;

namespace sda.backend.minimalapi.Core.Games.Services;

public class FakeInMemoryGetAllGamesService: IGetAllGamesService
{
    public IEnumerable<Game> GetAll()
    {
        return new List<Game>()
        {
            new Game { Id = 1, DateStart = DateTime.Now, Character = "Bilbo" },
            new Game { Id = 2, DateStart = DateTime.Now, Character = "Gandalf" },
            new Game { Id = 3, DateStart = DateTime.Now, Character = "Thorin" },
            new Game { Id = 4, DateStart = DateTime.Now, Character = "Balin" },
            new Game { Id = 5, DateStart = DateTime.Now, Character = "Dwalin" },
            new Game { Id = 6, DateStart = DateTime.Now, Character = "Bombur" },
        };
    }
}