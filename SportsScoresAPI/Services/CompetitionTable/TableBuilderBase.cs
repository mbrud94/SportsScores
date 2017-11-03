using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportsScoresAPI.Models.DTO;

namespace SportsScoresAPI.Services.CompetitionTable
{
    public abstract class TableBuilderBase : ITableBuilder
    {
        public abstract IEnumerable<TableRowDTO> Build(IEnumerable<GameDTO> games);

        protected List<TableRowDTO> tableRows = new List<TableRowDTO>();

        protected void ParseHomeTeamResult(GameDTO game)
        {
            var teamResult = tableRows.FirstOrDefault(r => r.TeamName == game.HomeTeam);
            if (teamResult == null)
            {
                teamResult = new TableRowDTO { TeamName = game.HomeTeam };
                tableRows.Add(teamResult);
            }
            teamResult.GoalsLost += game.AwayTeamGoals.Value;
            teamResult.GoalsScored += game.HomeTeamGoals.Value;
            teamResult.PlayedGames++;
            GameResult gameResult = GetGameResult(game.HomeTeamGoals.Value, game.AwayTeamGoals.Value);
            ParseGameResult(teamResult, gameResult);
        }

        protected void ParseAwayTeamResult(GameDTO game)
        {
            var teamResult = tableRows.FirstOrDefault(r => r.TeamName == game.AwayTeam);
            if (teamResult == null)
            {
                teamResult = new TableRowDTO { TeamName = game.AwayTeam };
                tableRows.Add(teamResult);
            }
            teamResult.GoalsLost += game.HomeTeamGoals.Value;
            teamResult.GoalsScored += game.AwayTeamGoals.Value;
            teamResult.PlayedGames++;
            GameResult gameResult = GetGameResult(game.AwayTeamGoals.Value, game.HomeTeamGoals.Value);
            ParseGameResult(teamResult, gameResult);
        }

        protected void AssingPositions()
        {
            this.tableRows = this.tableRows.OrderByDescending(r => r.Points)
                .ThenByDescending(r => r.GoalsScored - r.GoalsLost)
                .ThenByDescending(r => r.GoalsScored).ToList();

            int pos = 1;
            this.tableRows.ForEach(r => r.Position = pos++);
        }

        protected void AddMissingTeams(IEnumerable<GameDTO> games)
        {
            foreach(var game in games)
            {
                if(!tableRows.Any(r => r.TeamName == game.HomeTeam))
                {
                    tableRows.Add(new TableRowDTO { TeamName = game.HomeTeam });
                }
                if (!tableRows.Any(r => r.TeamName == game.AwayTeam))
                {
                    tableRows.Add(new TableRowDTO { TeamName = game.AwayTeam });
                }
            }
        }

        private GameResult GetGameResult(int firstTeamGoals, int secondTeamGoals)
        {
            if (firstTeamGoals == secondTeamGoals)
                return GameResult.Draw;
            else if (firstTeamGoals > secondTeamGoals)
                return GameResult.Win;
            return GameResult.Lost;
        }

        private void ParseGameResult(TableRowDTO teamResult, GameResult gameResult)
        {
            teamResult.Points += ConvertGameResultToPoints(gameResult);
            switch(gameResult)
            {
                case GameResult.Lost:
                    teamResult.Losts++;
                    break;
                case GameResult.Draw:
                    teamResult.Draws++;
                    break;
                case GameResult.Win:
                    teamResult.Wins++;
                    break;
            }
        }

        private int ConvertGameResultToPoints(GameResult res)
        {
            switch (res)
            {
                case GameResult.Lost: return 0;
                case GameResult.Draw: return 1;
                case GameResult.Win: return 3;
            }
            throw new ArgumentException("Invalid value of GameResult");
        }

        private enum GameResult
        {
            Win,
            Draw,
            Lost,
        }
    }
}
