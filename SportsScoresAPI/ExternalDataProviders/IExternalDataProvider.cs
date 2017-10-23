using SportsScoresAPI.ExternalDataProviders.ExternalModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsScoresAPI.ExternalDataProviders
{
    interface IExternalDataProvider
    {
        IExternalData GetData(string url);
        IExternalData GetData(Stream stream);
    }
}
