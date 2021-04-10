using System;
using System.Collections.Generic;
using System.Text;
using UC1_IndianCensusInfoFromCSVFile.DTO;

namespace UC1_IndianCensusInfoFromCSVFile
{
    public class CSVAdapterFactory
    {

        public Dictionary<string, CensusDTO> LoadCsvData(CensusAnalyser.Country country, string csvfilePath, string dataHeaders)
        {
            switch (country)
            {
                case (CensusAnalyser.Country.INDIA):
                    return new IndianCensusAdapter().LoadCensusData(csvfilePath, dataHeaders);
                default:
                    throw new CensusAnalyserException("No Such Country", CensusAnalyserException.ExceptionType.NO_SUCH_COUNTTY);
            }
        }
    }
}
