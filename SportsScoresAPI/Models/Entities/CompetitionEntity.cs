using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportsScoresAPI.Models.Entities
{
    public class CompetitionEntity
    {
        [Key]
        public int CompetitionId { get; set; }
        public string Name { get; set; }
        public string Season { get; set; }

        public int? NationalityId { get; set; }
        public NationalityEntity Nationality { get; set; }

        public List<TeamToCompetitionAssignmentEntity> TeamAssignments { get; set; }
        public List<GameEntity> Games { get; set; }
    }
}
