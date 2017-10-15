using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportsScoresAPI.Models.Entities
{
    public class TeamToCompetitionAssignmentEntity
    {
        [Key]
        public int TeamAssignmentId { get; set; }

        public int TeamId { get; set; }
        public TeamEntity Team { get; set; }

        public int CompetitionId { get; set; }
        public CompetitionEntity Competition { get; set; }


    }
}
