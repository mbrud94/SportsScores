using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsScoresAPI.Models.DTO
{
    public class TableRowDTO
    {
        public TableRowDTO(){}

        public TableRowDTO(string teamName, int points, int wins, int draws, int losts, int played, int pos, int goalsScored, int goalsLost)
        {
            TeamName = teamName;
            Points = points;
            Wins = wins;
            Draws = draws;
            Losts = losts;
            PlayedGames = played;
            Position = pos;
            GoalsScored = goalsScored;
            GoalsLost = goalsLost;
        }
        public string TeamName { get; set; }
        public int Position { get; set; }
        public int Points { get; set; }
        public int PlayedGames { get; set; }
        public int Wins { get; set; }
        public int Losts { get; set; }
        public int Draws { get; set; }
        public int GoalsScored { get; set; }
        public int GoalsLost { get; set; }
        public string CrestUrl { get; set; }

    }
}
