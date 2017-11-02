using SportsScoresAPI.Models.DTO;
using SportsScoresAPI.Services.CompetitionTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SportsScoresAPITests
{
    public static class TableBuilderDataSource
    {
        private const string TEAM_A = "TeamA";
        private const string TEAM_B = "TeamB";
        private const string TEAM_C = "TeamC";
        private const string TEAM_D = "TeamD";

        private static readonly List<GameDTO> gameSetA = new List<GameDTO>
        {
            new GameDTO(TEAM_A, TEAM_B, 4, 1),
            new GameDTO(TEAM_A, TEAM_C, 2, 1),
            new GameDTO(TEAM_B, TEAM_C, 3, 3)
        };

        private static readonly List<GameDTO> gameSetB = new List<GameDTO>
        {
            new GameDTO(TEAM_A, TEAM_B, 0, 0),
            new GameDTO(TEAM_A, TEAM_D, 0, 1),
            new GameDTO(TEAM_B, TEAM_C, 3, 3),
            new GameDTO(TEAM_B, TEAM_D, 2, 2),
            new GameDTO(TEAM_C, TEAM_D, 5, 0),
            new GameDTO(TEAM_C, TEAM_A, 3, 0),
        };

        private static readonly List<TableRowDTO> generalResultSetA = new List<TableRowDTO>
        {
            new TableRowDTO(TEAM_A, 6, 2, 0, 0, 2, 1, 6, 2),
            new TableRowDTO(TEAM_B, 1, 0, 1, 1, 2, 3, 4, 7),
            new TableRowDTO(TEAM_C, 1, 0, 1, 1, 2, 2, 4, 5),
        };

        private static readonly List<TableRowDTO> generalResultSetB = new List<TableRowDTO>
        {
            new TableRowDTO(TEAM_A, 1, 0, 1, 2, 3, 4, 0, 4),
            new TableRowDTO(TEAM_B, 3, 0, 3, 0, 3, 3, 5, 5),
            new TableRowDTO(TEAM_C, 7, 2, 1, 0, 3, 1, 11, 3),
            new TableRowDTO(TEAM_D, 4, 1, 1, 1, 3, 2, 3, 7),
        };

        private static IEnumerable<TableRowDTO> generalTableA = null;
        private static IEnumerable<TableRowDTO> generalTableB = null;

        private static IEnumerable<TableRowDTO> GeneralTableA
        {
            get
            {
                if (generalTableA == null)
                {
                    generalTableA = new GeneralTableBuilder().Build(gameSetA);
                }
                return generalTableA;
            }
        }

        private static IEnumerable<TableRowDTO> GeneralTableB
        {
            get
            {
                if (generalTableB == null)
                {
                    generalTableB = new GeneralTableBuilder().Build(gameSetB);
                }
                return generalTableB;
            }
        }

        public static IEnumerable<object[]> GetDataForGeneralBuilder()
        {
            return new List<object[]>
            {
                new object[] { GeneralTableA, generalResultSetA },
                new object[] { GeneralTableB, generalResultSetB }
            };
        }
    }
}
