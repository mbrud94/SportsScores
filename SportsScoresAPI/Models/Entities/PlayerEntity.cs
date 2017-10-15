using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportsScoresAPI.Models.Entities
{
    public class PlayerEntity
    {
        [Key]
        public int PlayerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string MarketValue { get; set; }

        public int NationalityId { get; set; }
        public NationalityEntity Nationality { get; set; }

        public int PlayerPositionId { get; set; }
        public PlayerPositionEntity PlayerPosition { get; set; }

        public List<PlayerToTeamAssignmentEntity> PlayerAssignments { get; set; }
        public List<GameSquadAssignmentEntity> GameSquadAssignments { get; set; }
        public List<GameEventEntity> GameEvents { get; set; }
    }
}
