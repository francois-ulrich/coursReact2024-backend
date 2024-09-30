using System;

namespace sda.backend.minimalapi.Core.Games.Models { 
    public class Game
    {
      /// <summary>
      /// Game model
      /// </summary>

      #region Properties
      public int Id { get; set; }
      public DateTime DateStart { get; set; }
      public DateTime? DateEnd { get; set; }
      public string Character { get; set; } = string.Empty;
      public bool Success { get; set; }
      #endregion
    }
}
