using System.Windows;
using System.Windows.Controls;
using WorldPollution.View;

namespace WorldPollution.Extensions
{
    class ListViewMenu:ListView
    {

        MainWindow mainWindow;
        Grid GridPrincipal,GridCursor;

        private ManageContinentsUserControl manageContinentsUserControl;
        private ManageCountriesUserControl manageCountriesUserControl;
        private ViewContinentPollutionDataUserControl viewContinentPollutionDataUser;
        private ViewCountryPollutionDataUserControl viewCountryPollutionDataUser;

        public ListViewMenu()
        {
            LoadUserControls();
            mainWindow = (MainWindow)Application.Current.MainWindow;
            GridPrincipal = (Grid)mainWindow.FindName("GridPrincipal");
            GridCursor = (Grid)mainWindow.FindName("GridCursor");
            SelectionChanged += ListViewMenu_SelectionChanged;
        }

        private void LoadUserControls()
        {
            manageContinentsUserControl = new ManageContinentsUserControl();
            manageCountriesUserControl = new ManageCountriesUserControl();
            viewCountryPollutionDataUser = new ViewCountryPollutionDataUserControl();
            viewContinentPollutionDataUser = new ViewContinentPollutionDataUserControl();
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = this.SelectedIndex;
            MoveCursorMenu(index);

            switch (index)
            {
                case 0:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(viewContinentPollutionDataUser);
                    break;
                case 1:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(viewCountryPollutionDataUser);
                    break;
                case 2:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(manageContinentsUserControl);
                    break;
                case 3:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(manageCountriesUserControl);
                    break;
            }
        }

        private void MoveCursorMenu(int index)
        {
            GridCursor.Margin = new Thickness(0, (200 + (60 * index)), 0, 0);
        }

    }
}
