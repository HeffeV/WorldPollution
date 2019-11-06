using System.Collections.ObjectModel;
using WorldPollution.Model;
using System.Windows.Input;
using MaterialDesignThemes.Wpf;
using WorldPollution.Messengers;

namespace WorldPollution.ViewModel
{
    class CountryViewModel : BaseViewModel
    {
        public CountryViewModel()
        {
            ReadCountries();
            LinkCommands();
        }

        private ObservableCollection<Country> countries;
        public ObservableCollection<Country> Countries
        {
            get
            {
                return countries;
            }

            set
            {
                countries = value;
                NotifyPropertyChanged();
            }
        }

        private Country currentCountry;
        public Country CurrentCountry
        {
            get
            {
                return currentCountry;
            }

            set
            {
                currentCountry= value;
                Messenger.Default.Send<Country>(CurrentCountry);
                NotifyPropertyChanged();
            }

        }

        private void LinkCommands()
        {
            DeleteCountryCommand = new BaseCommand(DeleteCountry);
            ChangeCountryCommand = new BaseCommand(ChangeCountry);
            AddCountryCommand = new BaseCommand(AddCountry);
        }

        public ICommand DeleteCountryCommand { get; set; }
        public ICommand ChangeCountryCommand { get; set; }
        public ICommand AddCountryCommand { get; set; }

        private void ReadCountries()
        {
            CountryDataService countryDS = new CountryDataService();
            Countries = new ObservableCollection<Country>(countryDS.GetCountries());
        }

        public void DeleteCountry()
        {
            if (CurrentCountry != null)
            {
                CountryDataService countryDS = new CountryDataService();

                countryDS.DeleteCountry(CurrentCountry);

                ReadCountries();
            }
        }

        public void ChangeCountry()
        {
            if (CurrentCountry != null)
            {
                CountryDataService countryDS = new CountryDataService();

                countryDS.UpdateCountry(CurrentCountry);

                ReadCountries();
            }
        }

        public void AddCountry()
        {
            CountryDataService countryDS = new CountryDataService();

            if (countryDS.FindDoubleCountry(CurrentCountry))
            {
                countryDS.InsertCountry(CurrentCountry);
                ReadCountries();
            }
            else
            {
                ApplicationViewModel.applicationViewModel.OpenWarningModal();
            }
        }



    }
}
