using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RestSharp;
using CovidTracker.TotalData.Models;
using CovidTracker.Common;
using System.Windows.Input;

namespace CovidTracker.TotalData.ViewModel
{
    public class TotalDataViewModel: BaseVM
    {
        private string confirmed;
        private string recovered;
        private string critical;
        private string deaths;
        private string timeUpdated;
        public ICommand UpdateTimeCommand { private set; get; }

        public TotalDataViewModel()
        {

            GetData();
            UpdateTimeCommand = new Command(
            execute: () =>
            {
                TimeUpdated = DateTime.Now.ToString();
            },
            canExecute: () =>
            {
                return true;
            });
        }

        /// <summary>
        /// Main Functionality of the page
        /// Sends GET request to the given endpoint 
        /// Deserializes JSON response into a list of  objects TotalDataModels
        /// Returns and updates UI with data from covid 19
        /// </summary>
        public void GetData()
        {

            var client = new RestClient("https://covid-19-data.p.rapidapi.com/totals?format=json");
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", "covid-19-data.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", "c5866c85dcmsh8034c295597f5b6p115014jsndb36602a5b2b");
            IRestResponse response = client.Execute(request);
            var totalsStatistics = JsonConvert.DeserializeObject<List<TotalDataModels>>(response.Content);
            Confirmed = totalsStatistics[0].confirmed;
            Recovered = totalsStatistics[0].recovered;
            Critical = totalsStatistics[0].critical;
            Deaths = totalsStatistics[0].deaths;
            if (Application.Current.Properties.ContainsKey("TimeLastUpdate")){
                TimeUpdated = Application.Current.Properties["TimeLastUpdate"].ToString();
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
        public string TimeUpdated
        {
            get
            {
                return timeUpdated;
            }
            set
            {
                if (!value.StartsWith("Last updated"))
                {
                    timeUpdated = "Last updated " + value;
                }
                else
                {
                    timeUpdated = value;
                }
                
                Application.Current.Properties["TimeLastUpdate"] = timeUpdated;
                Application.Current.SavePropertiesAsync();
                RaisePropertyChanged(nameof(TimeUpdated));
            }
        }



    }
}
