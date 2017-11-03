using SportsScoresAPI.Data;
using SportsScoresAPI.Models.DTO;
using SportsScoresAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsScoresAPI.Services
{
    public class CompetitionsService
    {
        private ApplicationDbContext context;

        public CompetitionsService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<CompetitionDTO> GetAll()
        {
            return context.Competitions.Select(c => MapEntityToDTO(c)).ToList();
        }

        public bool IsCompetitionExist(int id)
        {
            return context.Competitions.Any(c => c.CompetitionId == id);
        }

        private CompetitionDTO MapEntityToDTO(CompetitionEntity entity)
        {
            return new CompetitionDTO
            {
                CompetitionId = entity.CompetitionId,
                Name = entity.Name,
                Season = entity.Season
            };
        }

    }
}
