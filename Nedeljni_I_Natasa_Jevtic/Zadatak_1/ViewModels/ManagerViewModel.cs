using System.Windows;
using System.Windows.Input;
using Zadatak_1.Commands;
using Zadatak_1.Models;
using Zadatak_1.Views;

namespace Zadatak_1.ViewModels
{
    class ManagerViewModel : BaseViewModel
    {
        ManagerView managerView;
        Managers managers = new Managers();

        private vwManager manager;

        public vwManager Manager
        {
            get
            {
                return manager;
            }
            set
            {
                manager = value;
                OnPropertyChanged("Manager");
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

        public bool CanLogOutExecute()
        {
            return true;
        }

        public void LogOutExecute()
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to log out?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                managerView.Close();
            }
        }

        private Visibility hasEmployees;

        public Visibility HasEmployees
        {
            get
            {
                return hasEmployees;
            }
            set
            {
                hasEmployees = value;
                OnPropertyChanged("HasEmployees");
            }
        }

        private string color;

        public string Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
                OnPropertyChanged("Color");
            }
        }

        public ManagerViewModel(ManagerView managerView, vwManager manager)
        {
            this.managerView = managerView;
            Manager = manager;
            if (managers.CheckIfManagerHasEmployees(manager))
            {
                HasEmployees = Visibility.Visible;
            }
            if (managers.CheckIfManagerHasRequest(manager))
            {
                Color = "Red";
            }
            else
            {
                Color = "Green";
            }
        }
    }
}