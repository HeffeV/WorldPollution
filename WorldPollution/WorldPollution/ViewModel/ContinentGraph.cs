using LiveCharts;
using LiveCharts.Wpf;
using System.Collections.Generic;
using WorldPollution.Model;
using System.Collections.ObjectModel;
using WorldPollution.Messengers;

namespace WorldPollution.ViewModel
{
    class ContinentGraph : BaseViewModel
    {

        public ContinentGraph()
        {
            Messenger.Default.Register<Continent>(this, OnMessageReceived);
        }

        private ObservableCollection<ContinentPollution> continentPollution;
        public ObservableCollection<ContinentPollution> ContinentPollution
        {
            get
            {
                return continentPollution;
            }

            set
            {
                continentPollution = value;
                NotifyPropertyChanged();
            }
        }

        private SeriesCollection continentPollutionData;
        public SeriesCollection ContinentPollutionData
        {
            get { return continentPollutionData; }
            set
            {
                continentPollutionData = value;
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

        public void GetContinentPollution(int id)
        {
            ContinentPollutionDataService continentPollutionDS = new ContinentPollutionDataService();
            ContinentPollution = new ObservableCollection<ContinentPollution>(continentPollutionDS.GetContinentPollution(id));
            ConvertData(ContinentPollution);
        }

        private void ConvertData(ObservableCollection<ContinentPollution> continentPollutions)
        {
            List<double> tempPollution = new List<double>();
            List<string> tempYears = new List<string>();

            for (int i = 0; i < continentPollutions.Count; i++)
            {
                tempPollution.Add(continentPollutions[i].Pollution);
                tempYears.Add(continentPollutions[i].Year.ToString());
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

            Labels = tempYears.ToArray();

            ContinentPollutionData = sc;
        }

        private void OnMessageReceived(Continent message)
        {
            GetContinentPollution(message.ID);
        }

    }
}
