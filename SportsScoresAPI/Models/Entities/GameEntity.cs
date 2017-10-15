using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportsScoresAPI.Models.Entities
{
    public class GameEntity
    {
        [Key]
        public int GameId { get; set; }

        public int MatchDay { get; set; }
        public DateTime MatchDate { get; set; }
        public GameStatus Status { get; set; }

        public int CompetitionId { get; set; }
        public CompetitionEntity Competition { get; set; }

        public int HomeTeamId { get; set; }
        public TeamEntity HomeTeam { get; set; }

        public int AwayTeamId { get; set; }
        public TeamEntity AwayTeam { get; set; }

        public int? HomeTeamGoals { get; set; }
        public int? AwayTeamGoals { get; set; }

        public int? HalfHomeTeamGoals { get; set; }
        public int? HalfAwayTeamGoals { get; set; }

        public List<GameEventEntity> GameEvents { get; set; }
        public List<GameSquadAssignmentEntity> GameSquadAssignments { get; set; }


    }
}
