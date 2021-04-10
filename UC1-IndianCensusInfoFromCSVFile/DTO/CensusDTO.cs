﻿using System;
using System.Collections.Generic;
using System.Text;
using UC1_IndianCensusInfoFromCSVFile.POCO;

namespace UC1_IndianCensusInfoFromCSVFile.DTO
{
    public class CensusDTO
    {
        public string state;
        public long population;
        public long area;
        public long density;
        public long housingUnits;
        public double totalArea;
        public double waterArea;
        public double landArea;
        public double housingDensity;

        public CensusDTO(CensusDataDAO censusDataDAO)
        {
            this.state = censusDataDAO.state;
            this.population = censusDataDAO.population;
            this.area = censusDataDAO.area;
            this.density = censusDataDAO.density;
        }
    }
}
