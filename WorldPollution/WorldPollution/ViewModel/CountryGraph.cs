using LiveCharts;
using LiveCharts.Wpf;
using System.Collections.Generic;
using WorldPollution.Model;
using System.Collections.ObjectModel;
using WorldPollution.Messengers;

namespace WorldPollution.ViewModel
{
    class CountryGraph : BaseViewModel
    {

        public CountryGraph()
        {
            Messenger.Default.Register<Country>(this, OnMessageReceived);
        }

        private ObservableCollection<CountryPollution> countryPollution;
        public ObservableCollection<CountryPollution> CountryPollution
        {
            get
            {
                return countryPollution;
            }

            set
            {
                countryPollution = value;
                NotifyPropertyChanged();
            }
        }

        private SeriesCollection countryPollutionData;
        public SeriesCollection CountryPollutionData
        {
            get { return countryPollutionData; }
            set
            {
                countryPollutionData = value;
                NotifyPropertyChanged();
            }
        }

        private string[] labels;
        public string[] Labels
        {
            get
            {
                return labels;
            }
            set
            {
                labels = value;
                NotifyPropertyChanged();
            }
        }

        public void GetCountryPollution(int id)
        {
            CountryPollutionDataService countryPollutionDS = new CountryPollutionDataService();
            CountryPollution = new ObservableCollection<CountryPollution>(countryPollutionDS.GetCountryPollution(id));
            ConvertData(CountryPollution);
        }

        private void ConvertData(ObservableCollection<CountryPollution> countryPollutions)
        {
            List<double> tempPollution = new List<double>();
            List<string> tempYears = new List<string>();

            for (int i = 0; i < countryPollutions.Count; i++)
            {
                tempPollution.Add(countryPollutions[i].Pollution);
                tempYears.Add(countryPollutions[i].Year.ToString());
            }

            var tempP = new ChartValues<double>();
            tempP.AddRange(tempPollution);

            SeriesCollection sc = new SeriesCollection
            {
                new LineSeries
                {
                Title = "Pollution",
                Values = tempP
                }
            };

            Labels = null;
            Labels = tempYears.ToArray();

            CountryPollutionData = sc;
        }

        private void OnMessageReceived(Country message)
        {
            GetCountryPollution(message.ID);
        }

    }
}
