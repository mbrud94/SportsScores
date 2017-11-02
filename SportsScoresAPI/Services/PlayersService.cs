using Microsoft.EntityFrameworkCore;
using SportsScoresAPI.Data;
using SportsScoresAPI.Models.DTO;
using SportsScoresAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsScoresAPI.Services
{
    public class PlayersService
    {
        private ApplicationDbContext context;

        public PlayersService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<PlayerDTO> GetTeamPlayers(int teamId)
        {
            return GetPlayers(a => a.TeamID == teamId);
        }

        public IEnumerable<PlayerDTO> GetTeamPlayers(string teamName)
        {
            return GetPlayers(a => a.Team.ShortName.ToUpper() == teamName.ToUpper());
        }

        private IEnumerable<PlayerDTO> GetPlayers(Func<PlayerToTeamAssignmentEntity, bool> predicate)
        {
            return context.PlayerToTeamAssignments
                .Include(a => a.Team)
                .Include(a => a.Player)
                .ThenInclude(p => p.Nationality)
                .Include(a => a.Player)
                .ThenInclude(p => p.PlayerPosition)
                .Where(predicate)
                .Select(a => MapEntityToDTO(a.Player))
                .ToList();
        }

        private PlayerDTO MapEntityToDTO(PlayerEntity entity)
        {
            return new PlayerDTO
            {
                DateOfBirth = entity.DateOfBirth,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                MarketValue = entity.MarketValue,
                PlayerId = entity.PlayerId,
                Nationality = new NationalityDTO
                {
                    FlagURL = entity.Nationality.FlagURL,
                    Name = entity.Nationality.Name,
                    ShortName = entity.Nationality.ShortName
                },
                PlayerPosition = new PlayerPositionDTO
                {
                    Code = entity.PlayerPosition.Code,
                    Name = entity.PlayerPosition.Name
                }
            };
        }
    }
}
