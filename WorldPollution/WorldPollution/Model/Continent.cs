namespace WorldPollution.Model
{
    public class Continent: BaseModel
    {
        private int id;
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

    }
}
