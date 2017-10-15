using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportsScoresAPI.Models.Entities
{
    public class GameEventEntity
    {
        [Key]
        public int GameEventId { get; set; }
        public GameEventType EventType { get; set; }
        public TimeSpan OccurenceTime { get; set; }

        public int GameId { get; set; }
        public GameEntity Game { get; set; }

        public int TeamId { get; set; }
        public TeamEntity Team { get; set; }

        public int PlayerId { get; set; }
        public PlayerEntity Player { get; set; }
    }
}
