using SportsScoresAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsScoresAPI.Services.CompetitionTable
{
    public static class TableBuilderFactory
    {
        public static ITableBuilder CreateTableBuilder(CompetitionTableType type)
        {
            switch(type)
            {
                case CompetitionTableType.Away: return new AwayTableBuilder();
                case CompetitionTableType.Home: return new HomeTableBuilder();
                case CompetitionTableType.General: return new GeneralTableBuilder();
            }
            throw new ArgumentException("Invalid table type");
        }
    }
}
