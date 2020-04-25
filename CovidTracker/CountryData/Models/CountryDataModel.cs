using System;
namespace CovidTracker.CountryData.Models
{
    public class CountryDataModel
    {
        public string country { get; set; }
        public string confirmed { get; set; }
        public string recovered { get; set; }
        public string critical { get; set; }
        public string deaths { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public CountryDataModel()
        {
        }
        
    }
}
