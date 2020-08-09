using System.Windows;
using System.Windows.Input;
using Zadatak_1.Commands;
using Zadatak_1.Models;
using Zadatak_1.Views;

namespace Zadatak_1.ViewModels
{
    class AdministratorViewModel : BaseViewModel
    {
        AdministratorView administratorView;

        private vwAdministrator administrator;

        public vwAdministrator Administrator
        {
            get
            {
                return administrator;
            }
            set
            {
                administrator = value;
                OnPropertyChanged("Administrator");
            }
        }

        private ICommand logOut;
        public ICommand LogOut
        {
            get
            {
                if (logOut == null)
                {
                    logOut = new RelayCommand(param => LogOutExecute(), param => CanLogOutExecute());
                }
                return logOut;
            }
        }

        public AdministratorViewModel(AdministratorView administratorView, vwAdministrator administrator)
        {
            this.administratorView = administratorView;
            Administrator = administrator;
        }

        public bool CanLogOutExecute()
        {
            return true;
        }

        public void LogOutExecute()
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to log out?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                administratorView.Close();
            }
        }
    }
}