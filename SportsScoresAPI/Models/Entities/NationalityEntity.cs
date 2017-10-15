using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportsScoresAPI.Models.Entities
{
    public class NationalityEntity
    {
        [Key]
        public int NationalityId { get; set; }

        public string Name { get; set; }
        public string ShortName { get; set; }
        public string FlagURL { get; set; }

        public List<PlayerEntity> Players { get; set; }
        public List<CompetitionEntity> Competitions { get; set; }
    }
}
