using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportsScoresAPI.Models.Entities
{
    public class PlayerToTeamAssignmentEntity
    {
        [Key]
        public int PlayerAssignmentId { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public int? JerseyNumber { get; set; }

        public int PlayerID { get; set; }
        public PlayerEntity Player { get; set; }

        public int TeamID { get; set; }
        public TeamEntity Team { get; set; }
    }
}
