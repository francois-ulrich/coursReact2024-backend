using System;

namespace sda.backend.minimalapi.Core.Games.Models { 
    public class Game
    {
        /// <summary>
        /// Game model
        /// </summary>

        #region Properties
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string CharacterName { get; set; } = string.Empty;
        public bool Success { get; set; } = false;
        public DateTime DateStart { get; set; } = DateTime.Now;
        public DateTime? DateEnd { get; set; } = DateTime.Now;
        #endregion
    }
}
