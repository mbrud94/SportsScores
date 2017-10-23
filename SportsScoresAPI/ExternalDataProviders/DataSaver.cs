using Microsoft.EntityFrameworkCore;
using SportsScoresAPI.Data;
using SportsScoresAPI.ExternalDataProviders.ExternalModel;
using SportsScoresAPI.Models;
using SportsScoresAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsScoresAPI.ExternalDataProviders
{
    public class DataSaver
    {
        private ApplicationDbContext _context;

        public DataSaver(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Save(ExternalData data)
        {
            if(IsCompetitionExist(data.Competition))
            {
                return;
            }
            using (var transaction = _context.Database.BeginTransaction())
            {
                _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Competitions] ON");
                var competition = SaveCompetition(data.Competition);
                _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Competitions] OFF");

                _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Teams] ON");
                SaveCompetitionTeams(data.Competition.Teams, competition.CompetitionId);
                _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Teams] OFF");

                foreach (var team in data.Competition.Teams.Teams)
                {
                    SaveTeamPlayers(team);
                }
                SaveCompetitionGames(data.Competition.Fixtures, competition.CompetitionId);
       
                transaction.Commit();
            }
        }

        private void SaveTeamPlayers(TeamExt team)
        {
            foreach (var playerExt in team.Players.Players)
            {
                var nameParts = ExtractPlayerNameParts(playerExt.Name);
                PlayerEntity player = new PlayerEntity
                {
                    DateOfBirth = playerExt.DateOfBirth,
                    FirstName = nameParts.Item1,
                    LastName = nameParts.Item2,
                    MarketValue = playerExt.MarketValue,
                    NationalityId = GetNationalityId(playerExt.Nationality),
                    PlayerPositionId = GetPositonId(playerExt.Position)
                };
                _context.Players.Add(player);
                _context.SaveChanges();
                var assignemt = CreatePlayerAssignment(team, player, playerExt);
                _context.PlayerToTeamAssignments.Add(assignemt);
                _context.SaveChanges();
            }
        }

        private CompetitionEntity SaveCompetition(CompetitionExt data)
        {
            var namesPart = ParseCompetitionName(data.Caption);
            CompetitionEntity ent = new CompetitionEntity
            {
                Name = namesPart.Item1,
                Season = namesPart.Item2,
                NationalityId = null,
                CompetitionId = ExtractIdFromLinks(data._links)
            };
            _context.Competitions.Add(ent);
            _context.SaveChanges();
            return ent;
        }

        private void SaveCompetitionTeams(TeamsList teams, int competitionId)
        {
            List<TeamEntity> teamEntities = new List<TeamEntity>();
            List<TeamToCompetitionAssignmentEntity> assignmentEntites = new List<TeamToCompetitionAssignmentEntity>();
            foreach (var item in teams.Teams)
            {
                TeamEntity team = new TeamEntity
                {
                    TeamId = ExtractIdFromLinks(item._links),
                    Code = item.Code,
                    CrestURL = item.CrestUrl,
                    MarektValue = item.SquadMarketValue,
                    Name = item.Name,
                    ShortName = item.ShortName
                };
                teamEntities.Add(team);
                assignmentEntites.Add(CreateTeamAssignments(competitionId, team.TeamId));
            }
            _context.Teams.AddRange(teamEntities);
            _context.SaveChanges();
            _context.TeamToCompetitionAssignments.AddRange(assignmentEntites);
            _context.SaveChanges();
        }

        private void SaveCompetitionGames(FixturesList games, int competitionId)
        {
            List<GameEntity> gameEnitites = new List<GameEntity>();
            foreach (var game in games.Fixtures)
            {
                GameEntity entity = new GameEntity()
                {
                    CompetitionId = competitionId,
                    AwayTeamGoals = game.Result.GoalsAwayTeam,
                    HomeTeamGoals = game.Result.GoalsHomeTeam,
                    HalfAwayTeamGoals = game.Result.HalfTime?.GoalsAwayTeam,
                    HalfHomeTeamGoals = game.Result.HalfTime?.GoalsHomeTeam,
                    MatchDate = game.Date.Value,
                    MatchDay = game.Matchday.Value,
                    Status = (GameStatus)Enum.Parse(typeof(GameStatus), game.Status.Replace("_", string.Empty), true),
                    HomeTeamId = ExtractIdFromLinkItem(game._links.HomeTeam),
                    AwayTeamId = ExtractIdFromLinkItem(game._links.AwayTeam)
                };
                gameEnitites.Add(entity);
            }
            _context.Games.AddRange(gameEnitites);
            _context.SaveChanges();
        }

        #region Assignments
        private PlayerToTeamAssignmentEntity CreatePlayerAssignment(TeamExt team, PlayerEntity playerEntity, PlayerExt playerExt)
        {
            PlayerToTeamAssignmentEntity assignment = new PlayerToTeamAssignmentEntity()
            {
                EndDate = playerExt.ContractUntil,
                JerseyNumber = playerExt.JerseyNumber,
                PlayerID = playerEntity.PlayerId,
                TeamID = ExtractIdFromLinks(team._links)
            };
            return assignment;
        }

        private TeamToCompetitionAssignmentEntity CreateTeamAssignments(int competitionId, int TeamId)
        {
            TeamToCompetitionAssignmentEntity assignment = new TeamToCompetitionAssignmentEntity
            {
                CompetitionId = competitionId,
                TeamId = TeamId
            };
            return assignment;
        }
        #endregion

        #region Tools
        private Tuple<string, string> ParseCompetitionName(string name)
        {
            var seasonPart = name.Split(' ').Last();
            var competitionName = name.Replace(seasonPart, string.Empty).Trim();
            return Tuple.Create(competitionName, seasonPart);
        }

        private Tuple<string, string> ExtractPlayerNameParts(string name)
        {
            var parts = name.Split(' ');
            if (parts.Length > 1)
            {
                return Tuple.Create(parts[0], parts[1]);
            }
            return Tuple.Create("", parts[0]);
        }

        private int ExtractIdFromLinks(Links links)
        {
            return Convert.ToInt32(links.Self.Href.TrimEnd('/').Split('/').Last());
        }
        private int ExtractIdFromLinkItem(LinkItem item)
        {
            return Convert.ToInt32(item.Href.TrimEnd('/').Split('/').Last());
        }

        private int GetNationalityId(string name)
        {
            NationalityEntity ent = _context.Nationalities.FirstOrDefault(n => n.Name == name);
            if(ent == null)
            {
                ent = new NationalityEntity()
                {
                    Name = name,
                    ShortName = name.Substring(0, 3).ToUpper(),
                };
                _context.Nationalities.Add(ent);
                _context.SaveChanges();
            }
            return ent.NationalityId;
        }

        private int GetPositonId(string name)
        {
            string code = string.Join(string.Empty, name.Split(' ', '-').ToList().Select(s => s[0]));
            if (code == "K" && name == "Keeper") code = "GK";
            PlayerPositionEntity ent = _context.PlayerPositions.FirstOrDefault(p => p.Code == code);
            if (ent == null)
            {
                ent = new PlayerPositionEntity()
                {
                    Name = name,
                    Code = code
                };
                _context.PlayerPositions.Add(ent);
                _context.SaveChanges();
            }
            return ent.PlayerPositionId;
        }

        private bool IsCompetitionExist(CompetitionExt comp)
        {
            int compId = ExtractIdFromLinks(comp._links);
            return _context.Competitions.Any(c => c.CompetitionId == compId);
        }

        #endregion
    }
}
