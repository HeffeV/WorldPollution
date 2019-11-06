using System.Collections.ObjectModel;
using WorldPollution.Model;
using System.Windows.Input;
using System.Windows;

namespace WorldPollution.ViewModel
{
    class ApplicationViewModel : BaseViewModel
    {
        public static ApplicationViewModel applicationViewModel;

        public ApplicationViewModel()
        {
            applicationViewModel = this;
            LinkCommands();
        }

        private void LinkCommands()
        {
            CloseApplicationCommand = new BaseCommand(CloseApplication);
            OpenErrorModalCommand = new BaseCommand(OpenWarningModal);
            CloseErrorModalCommand = new BaseCommand(CloseWarningModal);
        }

        public ICommand CloseApplicationCommand { get; set; }
        public ICommand OpenErrorModalCommand { get; set; }
        public ICommand CloseErrorModalCommand { get; set; }

        public void CloseApplication()
        {
            Application.Current.Shutdown();
        }

        private bool _isWarningDialogOpen;

        public bool IsWarningDialogOpen
        {
            get { return _isWarningDialogOpen; }
            set
            {
                if (_isWarningDialogOpen == value) return;
                _isWarningDialogOpen = value;
                NotifyPropertyChanged();
            }
        }

        public void OpenWarningModal()
        {
            IsWarningDialogOpen = true;
        }

        private void CloseWarningModal()
        {
            IsWarningDialogOpen = false;
        }

    }
}
