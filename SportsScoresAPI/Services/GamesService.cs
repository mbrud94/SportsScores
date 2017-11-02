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
    public class GamesService
    {
        private ApplicationDbContext context;

        public GamesService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<GameDTO> GetAllCompetitionGames(int competitionId)
        {
            return GetGames(g => g.CompetitionId == competitionId);
        }

        public IEnumerable<GameDTO> GetAllCompetitionGames(string competitionName)
        {
            return GetGames(g => g.Competition.Name.Replace(" ", string.Empty).ToUpper() == competitionName.ToUpper());
        }

        public IEnumerable<GameDTO> GetFinishedCompetitionGames(int competitionId)
        {
            return GetGames(g => g.CompetitionId == competitionId && g.Status == Models.GameStatus.Finished);
        }

        public IEnumerable<GameDTO> GetFinishedCompetitionGames(string competitionName)
        {
            return GetGames(g => g.Competition.Name.Replace(" ", string.Empty).ToUpper() == competitionName.ToUpper() 
                && g.Status == Models.GameStatus.Finished);
        }

        public IEnumerable<GameDTO> GetScheduledCompetitionGames(int competitionId)
        {
            return GetGames(g => g.CompetitionId == competitionId && g.Status == Models.GameStatus.Scheduled);
        }

        public IEnumerable<GameDTO> GetScheduledCompetitionGames(string competitionName)
        {
            return GetGames(g => g.Competition.Name.Replace(" ", string.Empty).ToUpper() == competitionName.ToUpper()
                && g.Status == Models.GameStatus.Scheduled);
        }

        public IEnumerable<GameDTO> GetCompetitionGamesByMatchday(int competitionId, int matchday)
        {
            return GetGames(g => g.CompetitionId == competitionId && g.MatchDay == matchday);
        }

        public IEnumerable<GameDTO> GetCompetitionGamesByMatchday(string competitionName, int matchday)
        {
            return GetGames(g => g.Competition.Name.Replace(" ", string.Empty).ToUpper() == competitionName.ToUpper()
                && g.MatchDay == matchday);
        }

        private IEnumerable<GameDTO> GetGames(Func<GameEntity, bool> predicate)
        {
            return context.Games
                .Include(g => g.Competition)
                .Include(g => g.HomeTeam)
                .Include(g => g.AwayTeam)
                .Where(predicate)
                .Select(g => MapEntityToDTO(g))
                .ToList();
        }

        private GameDTO MapEntityToDTO(GameEntity e)
        {
            return new GameDTO
            {
                AwayTeam = e.AwayTeam.Name,
                AwayTeamGoals = e.AwayTeamGoals,
                AwayTeamId = e.AwayTeamId,
                CompetitionId = e.CompetitionId,
                GameId = e.GameId,
                HomeTeam = e.HomeTeam.Name,
                HomeTeamGoals = e.HomeTeamGoals,
                HalfAwayTeamGoals = e.HalfAwayTeamGoals,
                HalfHomeTeamGoals = e.HalfHomeTeamGoals,
                HomeTeamId = e.HomeTeamId,
                MatchDate = e.MatchDate,
                MatchDay = e.MatchDay,
                Status = e.Status.ToString()
            };
        }
    }
}
