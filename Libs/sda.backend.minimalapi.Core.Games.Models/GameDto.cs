using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sda.backend.minimalapi.Core.Games.Models
{
    public class GameDto
    {
        public string Name { get; set; } = string.Empty;
        public string CharacterName { get; set; } = string.Empty;
        public bool Success { get; set; } = false;
        public DateTime DateStart { get; set; } = DateTime.Now;
        public DateTime? DateEnd { get; set; } = DateTime.Now;
    }
}
