using SportsScoresAPI.Models;
using SportsScoresAPI.Models.DTO;
using SportsScoresAPI.Services.CompetitionTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsScoresAPI.Services
{
    public class CompetitionTablesService
    {
        private GamesService gamesService;

        public CompetitionTablesService(GamesService gamesService)
        {
            this.gamesService = gamesService;
        }

        public IEnumerable<TableRowDTO> GetTable(int competitionId, CompetitionTableType tableType)
        {
            var games = gamesService.GetFinishedCompetitionGames(competitionId);
            ITableBuilder builder = TableBuilderFactory.CreateTableBuilder(tableType);
            return builder.Build(games);
        }

        public IEnumerable<TableRowDTO> GetTable(string competitioName, CompetitionTableType tableType)
        {
            var games = gamesService.GetFinishedCompetitionGames(competitioName);
            ITableBuilder builder = TableBuilderFactory.CreateTableBuilder(tableType);
            return builder.Build(games);
        }
    }
}
