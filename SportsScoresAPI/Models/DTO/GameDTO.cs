using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsScoresAPI.Models.DTO
{
    public class GameDTO
    {
        public int GameId { get; set; }

        public int MatchDay { get; set; }
        public DateTime MatchDate { get; set; }
        public string Status { get; set; }

        public int CompetitionId { get; set; }

        public int HomeTeamId { get; set; }
        public string HomeTeam { get; set; }

        public int AwayTeamId { get; set; }
        public string AwayTeam { get; set; }

        public int? HomeTeamGoals { get; set; }
        public int? AwayTeamGoals { get; set; }

        public int? HalfHomeTeamGoals { get; set; }
        public int? HalfAwayTeamGoals { get; set; }
    }
}
