using SportsScoresAPI.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsScoresAPI.Services.CompetitionTable
{
    public interface ITableBuilder
    {
        IEnumerable<TableRowDTO> Build(IEnumerable<GameDTO> games);
    }
}
