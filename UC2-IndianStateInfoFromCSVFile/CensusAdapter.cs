using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace UC2_IndianStateInfoFromCSVFile
{
   public abstract class CensusAdapter
    {
        protected string[] GetCensusData(string csvfilePath, string dataHeaders)
        {
            string[] censusData;
            if (!File.Exists(csvfilePath))
            {
                throw new CensusAnalyserException("File Not Found", CensusAnalyserException.ExceptionType.FILE_NOT_FOUND);
            }
            if (Path.GetExtension(csvfilePath) != ".csv")
            {
                throw new CensusAnalyserException("Invalid File Type", CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE);
            }
            censusData = File.ReadAllLines(csvfilePath);
            if (censusData[0] != dataHeaders)
            {
                throw new CensusAnalyserException("Incorrect header in Data", CensusAnalyserException.ExceptionType.INCORRECT_HEADER);
            }
            return censusData;
        }
    }
}
