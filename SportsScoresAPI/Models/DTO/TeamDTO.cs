using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsScoresAPI.Models.DTO
{
    public class TeamDTO
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Code { get; set; }
        public string MarektValue { get; set; }
        public string CrestURL { get; set; }

    }
}
