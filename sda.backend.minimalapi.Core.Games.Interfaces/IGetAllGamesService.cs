using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sda.backend.minimalapi.Core.Games.Models;

namespace sda.backend.minimalapi.Core.Games.Interfaces
{
    public interface IGetAllGamesService
    {
        public IEnumerable<Game> GetAll();
    }
}
