using SportsScoresAPI.Models.DTO;
using SportsScoresAPI.Services.CompetitionTable;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TableBuilderTests.SportsScoresAPITests
{
    public class GeneralTableBuilderTests : TableBuilderTestsBase
    {
        [Theory]
        [MemberData(nameof(TableBuilderDataSource.GetDataForGeneralBuilder), MemberType = typeof(TableBuilderDataSource))]
        public void TestGeneralTableContent(IEnumerable<GameDTO> gameSet, IEnumerable<TableRowDTO> expectedTable)
        {
            var buildTable = new GeneralTableBuilder().Build(gameSet);
            TestBuildTableContent(buildTable, expectedTable);
        }
    }
}
