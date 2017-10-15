using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportsScoresAPI.Models.Entities
{
    public class TeamEntity
    {
        [Key]
        public int TeamId { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Code { get; set; }
        public string MarektValue { get; set; }
        public string CrestURL { get; set; }

        public List<PlayerToTeamAssignmentEntity> PlayerAssignments { get; set; }
        public List<TeamToCompetitionAssignmentEntity> TeamAssignments { get; set; }
        public List<GameEntity> HomeGames { get; set; }
        public List<GameEntity> AwayGames { get; set; }
        public List<GameSquadAssignmentEntity> GameSquadAssignments { get; set; }
        public List<GameEventEntity> GameEvents { get; set; }

    }
}
