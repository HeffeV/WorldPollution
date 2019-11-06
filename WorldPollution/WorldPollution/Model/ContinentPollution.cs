namespace WorldPollution.Model
{
    class ContinentPollution : BaseModel
    {

        private int continentId;
        private int year;
        private double pollution;
        private int id;

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
