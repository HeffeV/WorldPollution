namespace WorldPollution.Model
{
    class CountryPollution : BaseModel
    {

        private int countryId;
        private int year;
        private double pollution;
        private int id;

        public int CountryId
        {
            get
            {
                return countryId;
            }
            set
            {
                countryId = value;
                NotifyPropertyChanged();
            }
        }

        public int Year
        {
            get
            {
                return year;
            }
            set
            {
                year = value;
                NotifyPropertyChanged();
            }
        }

        public double Pollution
        {
            get
            {
                return pollution;
            }
            set
            {
                pollution = value;
                NotifyPropertyChanged();
            }
        }

        public int ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                NotifyPropertyChanged();
            }
        }

    }
}
