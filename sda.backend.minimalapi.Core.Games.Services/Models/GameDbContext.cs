using Microsoft.EntityFrameworkCore;
using sda.backend.minimalapi.Core.Games.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sda.backend.minimalapi.Core.Games.Services.Models
{
    public class GameDbContext : DbContext
    {
        #region Properties
        public DbSet<Game> Games { get; set; }
        #endregion
    }
}
