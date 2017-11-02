using Microsoft.EntityFrameworkCore;
using SportsScoresAPI.Data;
using SportsScoresAPI.ExternalDataProviders;
using SportsScoresAPI.Models.DTO;
using SportsScoresAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsScoresAPI.Services
{
    public class TeamsService
    {
        private ApplicationDbContext context;

        public TeamsService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<TeamDTO> GetCompetitionTeams(int competitionId)
        {
            return GetTeams(a => a.CompetitionId == competitionId);
        }

        public IEnumerable<TeamDTO> GetCompetitionTeams(string competitionName)
        {
            return GetTeams(a => a.Competition.Name.Replace(" ", string.Empty).ToUpper() == competitionName.ToUpper());
        }

        private IEnumerable<TeamDTO> GetTeams(Func<TeamToCompetitionAssignmentEntity, bool> predicate)
        {
            return context.TeamToCompetitionAssignments
                .Include(a => a.Team)
                .Include(a => a.Competition)
                .Where(predicate)
                .Select(a => MapEntityToDTO(a.Team))
                .ToList();
        }

        private TeamDTO MapEntityToDTO(TeamEntity entity)
        {
            return new TeamDTO
            {
                Code = entity.Code,
                CrestURL = entity.CrestURL,
                MarektValue = entity.MarektValue,
                Name = entity.Name,
                ShortName = entity.ShortName,
                TeamId = entity.TeamId
            };
        }

    }
}
