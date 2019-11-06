using System.Collections.ObjectModel;
using WorldPollution.Model;
using System.Windows.Input;
using WorldPollution.Messengers;

namespace WorldPollution.ViewModel
{
    class ContinentPollutionViewModel : BaseViewModel
    {

        private Continent currentContinent;

        public ContinentPollutionViewModel()
        {
            LinkCommands();
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

        private ContinentPollution currentContinentPollution;
        public ContinentPollution CurrentContinentPollution
        {
            get
            {
                if (currentContinentPollution is null)
                {
                    CurrentContinentPollution = new ContinentPollution();
                }
                return currentContinentPollution;
            }

            set
            {
                currentContinentPollution = value;
                NotifyPropertyChanged();
            }

        }

        private void LinkCommands()
        {
            DeleteContinentPollutionCommand = new BaseCommand(DeleteContinentPollution);
            ChangeContinentPollutionCommand = new BaseCommand(ChangeContinentPollution);
            AddContinentPollutionCommand = new BaseCommand(AddContinentPollution);
        }

        public ICommand DeleteContinentPollutionCommand { get; set; }
        public ICommand ChangeContinentPollutionCommand { get; set; }
        public ICommand AddContinentPollutionCommand { get; set; }

        public void ReadContinentPollution(int id)
        {
            ContinentPollutionDataService continentPollutionDS = new ContinentPollutionDataService();
            ContinentPollution = new ObservableCollection<ContinentPollution>(continentPollutionDS.GetContinentPollution(id));
        }

        public void DeleteContinentPollution()
        {
            if (CurrentContinentPollution != null)
            {
                ContinentPollutionDataService continentPollutionDS = new ContinentPollutionDataService();

                continentPollutionDS.DeleteContinentPollution(CurrentContinentPollution);

                ReadContinentPollution(CurrentContinentPollution.ContinentId);
            }
        }

        public void ChangeContinentPollution()
        {
            if (CurrentContinentPollution != null)
            {
                ContinentPollutionDataService continentPollutionDS = new ContinentPollutionDataService();

                continentPollutionDS.UpdateContinentPollution(CurrentContinentPollution);

                ReadContinentPollution(CurrentContinentPollution.ContinentId);
            }
        }

        public void AddContinentPollution()
        {
            if (CurrentContinentPollution != null)
            {
                ContinentPollutionDataService continentPollutionDS = new ContinentPollutionDataService();

                continentPollutionDS.InsertContinentPollution(CurrentContinentPollution);

                ReadContinentPollution(CurrentContinentPollution.ContinentId);
            }
        }

       private void OnMessageReceived(Continent message)
        {
            currentContinent = message;
            ReadContinentPollution(currentContinent.ID);
            ReadContinentPollution(currentContinent.ID);
        }

    }
}
