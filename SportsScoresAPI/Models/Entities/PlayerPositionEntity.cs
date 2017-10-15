using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportsScoresAPI.Models.Entities
{
    public class PlayerPositionEntity
    {
        [Key]
        public int PlayerPositionId { get; set; }

        public string Name { get; set; }
        public string Code { get; set; }

        public List<PlayerEntity> Players { get; set; }
    }
}
