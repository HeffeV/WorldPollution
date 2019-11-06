using System.Collections.ObjectModel;
using WorldPollution.Model;
using System.Windows.Input;
using WorldPollution.Messengers;

namespace WorldPollution.ViewModel
{
    class CountryPollutionViewModel : BaseViewModel
    {
        //public static CountryPollutionViewModel countryPollutionViewModel;
        private Country currentCountry;

        public CountryPollutionViewModel()
        {
            LinkCommands();
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

        private CountryPollution currentCountryPollution;
        public CountryPollution CurrentCountryPollution
        {
            get
            {
                if (currentCountryPollution is null)
                {
                    CurrentCountryPollution = new CountryPollution();
                }
                return currentCountryPollution;
            }

            set
            {
                currentCountryPollution = value;
                NotifyPropertyChanged();
            }

        }

        private void LinkCommands()
        {
            DeleteCountryPollutionCommand = new BaseCommand(DeleteCountryPollution);
            ChangeCountryPollutionCommand = new BaseCommand(ChangeCountryPollution);
            AddCountryPollutionCommand = new BaseCommand(AddCountryPollution);
        }

        public ICommand DeleteCountryPollutionCommand { get; set; }
        public ICommand ChangeCountryPollutionCommand { get; set; }
        public ICommand AddCountryPollutionCommand { get; set; }

        public void ReadCountryPollution(int id)
        {
            CountryPollutionDataService countryPollutionDS = new CountryPollutionDataService();
            CountryPollution = new ObservableCollection<CountryPollution>(countryPollutionDS.GetCountryPollution(id));
        }

        public void DeleteCountryPollution()
        {
            if (CurrentCountryPollution != null)
            {
                CountryPollutionDataService countryPollutionDS = new CountryPollutionDataService();

                countryPollutionDS.DeleteCountryPollution(CurrentCountryPollution);

                ReadCountryPollution(CurrentCountryPollution.CountryId);
            }
        }

        public void ChangeCountryPollution()
        {
            if (CurrentCountryPollution != null)
            {
                CountryPollutionDataService countryPollutionDS = new CountryPollutionDataService();

                countryPollutionDS.UpdateCountryPollution(CurrentCountryPollution);

                ReadCountryPollution(CurrentCountryPollution.CountryId);
            }
        }

        public void AddCountryPollution()
        {
            if (CurrentCountryPollution != null)
            {
                CountryPollutionDataService countryPoluttionDS = new CountryPollutionDataService();

                countryPoluttionDS.InsertCountryPollution(CurrentCountryPollution);

                ReadCountryPollution(CurrentCountryPollution.CountryId);
            }
        }

        private void OnMessageReceived(Country message)
        {
            currentCountry = message;
            ReadCountryPollution(currentCountry.ID);
            ReadCountryPollution(currentCountry.ID);
        }

    }
}
