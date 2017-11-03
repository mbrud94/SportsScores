using SportsScoresAPI.Models.DTO;
using SportsScoresAPI.Services.CompetitionTable;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TableBuilderTests.SportsScoresAPITests
{
    public class HomeTableBuilderTests : TableBuilderTestsBase
    {
        [Theory]
        [MemberData(nameof(TableBuilderDataSource.GetDataForHomeBuilder), MemberType = typeof(TableBuilderDataSource))]
        public void TestGeneralTableContent(IEnumerable<GameDTO> gameSet, IEnumerable<TableRowDTO> expectedTable)
        {
            var buildTable = new HomeTableBuilder().Build(gameSet);
            TestBuildTableContent(buildTable, expectedTable);
        }
    }
}
