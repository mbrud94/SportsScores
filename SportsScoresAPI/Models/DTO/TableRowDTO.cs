using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsScoresAPI.Models.DTO
{
    public class TableRowDTO
    {
        public string TeamName { get; set; }
        public int Position { get; set; }
        public int Points { get; set; }
        public int PlayedGames { get; set; }
        public int Wins { get; set; }
        public int Losts { get; set; }
        public int Draws { get; set; }
        public int GoalsScored { get; set; }
        public int GoalsLost { get; set; }

    }
}
