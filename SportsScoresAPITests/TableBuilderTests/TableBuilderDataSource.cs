using SportsScoresAPI.Models.DTO;
using SportsScoresAPI.Services.CompetitionTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TableBuilderTests.SportsScoresAPITests
{
    public static class TableBuilderDataSource
    {
        private const string TEAM_A = "TeamA";
        private const string TEAM_B = "TeamB";
        private const string TEAM_C = "TeamC";
        private const string TEAM_D = "TeamD";
        #region GameSets
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

        private static readonly List<GameDTO> gameSetC = new List<GameDTO>
        {
            new GameDTO(TEAM_A, TEAM_B, 2, 4),
        };
        #endregion
        #region GeneralResultSets
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

        private static readonly List<TableRowDTO> generalResultSetC = new List<TableRowDTO>
        {
            new TableRowDTO(TEAM_A, 0, 0, 0, 1, 1, 2, 2, 4),
            new TableRowDTO(TEAM_B, 3, 1, 0, 0, 1, 1, 4, 2),
        };
        #endregion
        #region HomeResultSets
        private static readonly List<TableRowDTO> homeResultSetA = new List<TableRowDTO>
        {
            new TableRowDTO(TEAM_A, 6, 2, 0, 0, 2, 1, 6, 2),
            new TableRowDTO(TEAM_B, 1, 0, 1, 0, 1, 2, 3, 3),
            new TableRowDTO(TEAM_C, 0, 0, 0, 0, 0, 3, 0, 0),
        };

        private static readonly List<TableRowDTO> homeResultSetB = new List<TableRowDTO>
        {
            new TableRowDTO(TEAM_A, 1, 0, 1, 1, 2, 3, 0, 1),
            new TableRowDTO(TEAM_B, 2, 0, 2, 0, 2, 2, 5, 5),
            new TableRowDTO(TEAM_C, 6, 2, 0, 0, 2, 1, 8, 0),
            new TableRowDTO(TEAM_D, 0, 0, 0, 0, 0, 4, 0, 0),
        };

        private static readonly List<TableRowDTO> homeResultSetC = new List<TableRowDTO>
        {
            new TableRowDTO(TEAM_A, 0, 0, 0, 1, 1, 2, 2, 4),
            new TableRowDTO(TEAM_B, 0, 0, 0, 0, 0, 1, 0, 0),
        };
        #endregion
        #region AwayResultSets
        private static readonly List<TableRowDTO> awayResultSetA = new List<TableRowDTO>
        {
            new TableRowDTO(TEAM_A, 0, 0, 0, 0, 0, 2, 0, 0),
            new TableRowDTO(TEAM_B, 0, 0, 0, 1, 1, 3, 1, 4),
            new TableRowDTO(TEAM_C, 1, 0, 1, 1, 2, 1, 4, 5),
        };

        private static readonly List<TableRowDTO> awayResultSetB = new List<TableRowDTO>
        {
            new TableRowDTO(TEAM_A, 0, 0, 0, 1, 1, 4, 0, 3),
            new TableRowDTO(TEAM_B, 1, 0, 1, 0, 1, 3, 0, 0),
            new TableRowDTO(TEAM_C, 1, 0, 1, 0, 1, 2, 3, 3),
            new TableRowDTO(TEAM_D, 4, 1, 1, 1, 3, 1, 3, 7),
        };

        private static readonly List<TableRowDTO> awayResultSetC = new List<TableRowDTO>
        {
            new TableRowDTO(TEAM_A, 0, 0, 0, 0, 0, 2, 0, 0),
            new TableRowDTO(TEAM_B, 3, 1, 0, 0, 1, 1, 4, 2),
        };
        #endregion

        public static IEnumerable<object[]> GetDataForGeneralBuilder()
        {
            yield return new object[] { gameSetA, generalResultSetA };
            yield return new object[] { gameSetB, generalResultSetB };
            yield return new object[] { gameSetC, generalResultSetC };
        }

        public static IEnumerable<object[]> GetDataForHomeBuilder()
        {
            yield return new object[] { gameSetA, homeResultSetA };
            yield return new object[] { gameSetB, homeResultSetB };
            yield return new object[] { gameSetC, homeResultSetC };
        }

        public static IEnumerable<object[]> GetDataForAwayBuilder()
        {
            yield return new object[] { gameSetA, awayResultSetA };
            yield return new object[] { gameSetB, awayResultSetB };
            yield return new object[] { gameSetC, awayResultSetC };
        }
    }
}
