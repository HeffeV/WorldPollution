using System.Collections.ObjectModel;
using WorldPollution.Model;
using System.Windows.Input;
using WorldPollution.Messengers;

namespace WorldPollution.ViewModel
{
    public class ContinentViewModel : BaseViewModel
    {

        public ContinentViewModel()
        {
            ReadContinents();
            LinkCommands();
        }

        private ObservableCollection<Continent> continents;
        public ObservableCollection<Continent> Continents
        {
            get
            {
                return continents;
            }

            set
            {
                continents = value;
                NotifyPropertyChanged();
            }
        }
        
        private Continent currentContinent;
        public Continent CurrentContinent
        {
            get
            {
                return currentContinent;
            }

            set
            {
                currentContinent = value;
                Messenger.Default.Send<Continent>(CurrentContinent);
                NotifyPropertyChanged();
            }

        }

        private void LinkCommands()
        {
            DeleteContinentCommand = new BaseCommand(DeleteContinent);
            ChangeContinentCommand = new BaseCommand(ChangeContinent);
            AddContinentCommand = new BaseCommand(AddContinent);
        }

        public ICommand DeleteContinentCommand { get; set; }
        public ICommand ChangeContinentCommand { get; set; }
        public ICommand AddContinentCommand { get; set; }

        private void ReadContinents()
        {
            ContinentDataService continentDS = new ContinentDataService();
            Continents = new ObservableCollection<Continent>(continentDS.GetContinenten());
        }

        public void DeleteContinent()
        {
            if (CurrentContinent != null)
            {
                ContinentDataService continentDS =
                new ContinentDataService();
                continentDS.DeleteContinent(CurrentContinent);

                //Refresh
                ReadContinents();
            }
        }

        public void ChangeContinent()
        {
            if (CurrentContinent != null)
            {
                ContinentDataService continentDS =
                new ContinentDataService();
                continentDS.UpdateContinent(CurrentContinent);

                //Refresh
                ReadContinents();
            }
        }

        public void AddContinent()
        {
            ContinentDataService continentDS = new ContinentDataService();

            if (continentDS.FindDoubleContinent(CurrentContinent))
            {
                continentDS.InsertContinent(CurrentContinent);
                ReadContinents();
            }
            else
            {
                ApplicationViewModel.applicationViewModel.OpenWarningModal();
            }
        }
    }
}
