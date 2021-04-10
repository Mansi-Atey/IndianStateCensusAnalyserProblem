﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UC2_IndianStateInfoFromCSVFile.DTO;
using UC2_IndianStateInfoFromCSVFile.POCO;

namespace UC2_IndianStateInfoFromCSVFile
{
    public class IndianCensusAdapter : CensusAdapter
    {
        string[] censusData;
        Dictionary<string, CensusDTO> dataMap;
        public Dictionary<string, CensusDTO> LoadCensusData(string csvfilePath, string dataHeaders)
        {
            dataMap = new Dictionary<string, CensusDTO>();
            censusData = GetCensusData(csvfilePath, dataHeaders);
            foreach (string data in censusData.Skip(1))
            {
                if (!data.Contains(","))
                {
                    throw new CensusAnalyserException("File Contains wrong Delimeter", CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER);
                }
                string[] column = data.Split(",");
                if (csvfilePath.Contains("IndianStateCode.csv"))
                {
                    dataMap.Add(column[0], new CensusDTO(new StateCodeDAO(column[0], column[1], column[2], column[3])));
                }
                if (csvfilePath.Contains("IndianStateCensusData.csv"))
                {
                    dataMap.Add(column[1], new CensusDTO(new CensusDataDAO(column[0], column[1], column[2], column[3])));
                }
            }
            return dataMap.ToDictionary(p => p.Key, p => p.Value);
        }

    }
}
