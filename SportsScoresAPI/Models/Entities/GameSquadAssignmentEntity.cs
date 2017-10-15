using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportsScoresAPI.Models.Entities
{
    public class GameSquadAssignmentEntity
    {
        [Key]
        public int GameSquadAssignmentId { get; set; }
        public TimeSpan TimeIn { get; set; }
        public TimeSpan? TimeOut { get; set; }

        public int GameId { get; set; }
        public GameEntity Game { get; set; }

        public int TeamId { get; set; }
        public TeamEntity Team { get; set; }

        public int PlayerId { get; set; }
        public PlayerEntity PLayer { get; set; }

    }
}
