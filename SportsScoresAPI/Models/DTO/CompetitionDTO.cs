using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsScoresAPI.Models.DTO
{
    public class CompetitionDTO
    {
        public int CompetitionId { get; set; }
        public string Name { get; set; }
        public string Season { get; set; }
    }
}
