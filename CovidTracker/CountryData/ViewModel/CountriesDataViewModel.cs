using System;
using System.Collections.Generic;
using System.Windows.Input;
using CovidTracker.Common;
using CovidTracker.CountryData.Models;
using Newtonsoft.Json;
using RestSharp;

namespace CovidTracker.CountryData.ViewModel
{
    public class CountriesDataViewModel : BaseVM
    {
        private string confirmed;
        private string recovered;
        private string critical;
        private string deaths;
        private string selectedCountry;
        List<string> countries;
        public ICommand UpdateTimeCommand { private set; get; }

        public CountriesDataViewModel()
        {
            countries = new List<string>()
        {
            "USA", "Australia", "Canada", "China", "France", "Germany", "Italy", "Iran", "North Macedonia", "Russia","Spain", "Turkey"
        };
        }

        /// <summary>
        /// Main Functionality of the page
        /// Sends GET request to the given endpoint
        /// Deserializes JSON response into a list of CountryDataModel
        /// Returns and updates UI with data from covid 19
        /// </summary>
        /// <param name="country">Name of the country to serach which is obtained from Picker in UI </param>
        public void GetData(string country)
        {
            var client = new RestClient("https://covid-19-data.p.rapidapi.com/country?format=json&name="+country);
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", "covid-19-data.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", "c5866c85dcmsh8034c295597f5b6p115014jsndb36602a5b2b");
            IRestResponse response = client.Execute(request);
            var totalsStatistics = JsonConvert.DeserializeObject<List<CountryDataModel>>(response.Content);
            Confirmed = totalsStatistics[0].confirmed;
            Recovered = totalsStatistics[0].recovered;
            Critical = totalsStatistics[0].critical;
            Deaths = totalsStatistics[0].deaths;
        }

 
        public List<string> Countries
        {
            get
            {
                return countries;
            }

            set
            {
                countries = value;
                RaisePropertyChanged(nameof(Countries));
            }
        }
        public string Confirmed
        {
            get
            {
                return confirmed;
            }
            set
            {
                confirmed = value;
                RaisePropertyChanged(nameof(Confirmed));
            }
        }
        public string Recovered
        {
            get
            {
                return recovered;
            }
            set
            {
                recovered = value;
                RaisePropertyChanged(nameof(Recovered));
            }
        }

        public string Critical
        {
            get
            {
                return critical;
            }
            set
            {
                critical = value;
                RaisePropertyChanged(nameof(Critical));
            }
        }

        public string Deaths
        {
            get
            {
                return deaths;
            }
            set
            {
                deaths = value;
                RaisePropertyChanged(nameof(Deaths));
            }
        }

        public string SelectedCountry
        {
            get { return selectedCountry; }
            set
            {
                selectedCountry = value;
                GetData(value);
                RaisePropertyChanged(nameof(SelectedCountry));

            }
        }

    }
}
