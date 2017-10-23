using SportsScoresAPI.ExternalDataProviders.ExternalModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsScoresAPI.ExternalDataProviders
{
    public class DataReaderBuilder
    {
        private DataReader dataReader = new DataReader();


        public DataReaderBuilder ReadCompetition(int id)
        {
            dataReader.readCompetition = true;
            dataReader.startId = id;
            return this;
        }

        public DataReaderBuilder WithTeams()
        {
            dataReader.readTeams = true;
            return this;
        }

        public DataReaderBuilder WithPlayers()
        {
            dataReader.readPlayers = true;
            return this;
        }

        public DataReaderBuilder WithGames()
        {
            dataReader.readGames = true;
            return this;
        }

        public DataReader Build()
        {
            return dataReader;
        }


    }

    public static  class TopLeauges
    {
        public const int PremierLeauge = 445;
        public const int SerieA = 456;
        public const int PrimeraDivision = 455;
        public const int Bundesliga = 452;
        public const int Ligue1 = 450;
    }
}


