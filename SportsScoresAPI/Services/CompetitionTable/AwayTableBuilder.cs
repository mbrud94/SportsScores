using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportsScoresAPI.Models.DTO;

namespace SportsScoresAPI.Services.CompetitionTable
{
    public class AwayTableBuilder : TableBuilderBase
    {
        public override IEnumerable<TableRowDTO> Build(IEnumerable<GameDTO> games)
        {
            this.tableRows.Clear();
            foreach (var game in games)
            {
                ParseAwayTeamResult(game);
            }
            AddMissingTeams(games);
            AssingPositions();
            return this.tableRows;
        }
    }
}
