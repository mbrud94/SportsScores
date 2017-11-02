using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsScoresAPI.Models.DTO
{
    public class PlayerDTO
    {
        public int PlayerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string MarketValue { get; set; }

        public NationalityDTO Nationality { get; set; }
        public PlayerPositionDTO PlayerPosition { get; set; }
    }
}
