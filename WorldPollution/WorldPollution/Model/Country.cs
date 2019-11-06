namespace WorldPollution.Model
{
    class Country : BaseModel
    {

        private int id;
        private int continentId;
        private string countryCode;
        private int population;
        private int area;
        private double industry;
        private double agriculture;
        private double popDensity;
        private double literacy;
        private string name;

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

        public int ContinentId
        {
            get
            {
                return continentId;
            }
            set
            {
                continentId = value;
                NotifyPropertyChanged();
            }
        }

        public string CountryCode
        {
            get
            {
                return countryCode;
            }
            set
            {
                countryCode = value;
                NotifyPropertyChanged();
            }
        }

        public int Population
        {
            get
            {
                return population;
            }
            set
            {
                population = value;
                NotifyPropertyChanged();
            }
        }

        public int Area
        {
            get
            {
                return area;
            }
            set
            {
                area = value;
                NotifyPropertyChanged();
            }
        }

        public double Industry
        {
            get
            {
                return industry;
            }
            set
            {
                industry = value;
                NotifyPropertyChanged();
            }
        }

        public double PopDensity
        {
            get
            {
                return popDensity;
            }
            set
            {
                popDensity = value;
                NotifyPropertyChanged();
            }
        }

        public double Agriculture
        {
            get
            {
                return agriculture;
            }
            set
            {
                agriculture = value;
                NotifyPropertyChanged();
            }
        }

        public double Literacy
        {
            get
            {
                return literacy;
            }
            set
            {
                literacy = value;
                NotifyPropertyChanged();
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                NotifyPropertyChanged();
            }

        }

        public string Flag
        {
            get
            {
                return "/Images/Flags/" + countryCode.ToLower() + ".png";
            }
        }
    }
}