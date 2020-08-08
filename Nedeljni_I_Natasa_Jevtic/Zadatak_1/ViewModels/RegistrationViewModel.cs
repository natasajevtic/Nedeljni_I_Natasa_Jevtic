using System.Windows;
using System.Windows.Input;
using Zadatak_1.Commands;
using Zadatak_1.Models;
using Zadatak_1.Views;

namespace Zadatak_1.ViewModels
{
    class RegistrationViewModel : BaseViewModel
    {
        RegistrationView registrationView;
        Sectors sectors = new Sectors();
        Managers managers = new Managers();

        private bool isCheckedManager;

        public bool IsCheckedManager
        {
            get
            {
                return isCheckedManager;
            }
            set
            {
                isCheckedManager = value;
                OnPropertyChanged("IsCheckedManager");
            }
        }

        private bool isCheckedEmployee;

        public bool IsCheckedEmployee
        {
            get
            {
                return isCheckedEmployee;
            }
            set
            {
                isCheckedEmployee = value;
                OnPropertyChanged("IsCheckedEmployee");
            }
        }

        private ICommand next;

        public ICommand Next
        {
            get
            {
                if (next == null)
                {
                    next = new RelayCommand(param => NextExecute(), param => CanNextExecute());
                }
                return next;
            }
        }

        private bool isManagerAccountEnabled = true;

        public bool IsManagerAccountEnabled
        {
            get
            {
                return isManagerAccountEnabled;
            }
            set
            {
                isManagerAccountEnabled = value;
                OnPropertyChanged("IsManagerAccountEnabled");
            }
        }

        public RegistrationViewModel(RegistrationView registrationView)
        {
            this.registrationView = registrationView;
        }

        public RegistrationViewModel(RegistrationView registrationView, bool enabledManagaerAccount)
        {
            this.registrationView = registrationView;
            IsManagerAccountEnabled = false;
        }

        public bool CanNextExecute()
        {
            if (IsCheckedManager == true || IsCheckedEmployee == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void NextExecute()
        {
            if (IsCheckedManager)
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to register as manager?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    PasswordConfirmationView confirmView = new PasswordConfirmationView();
                    confirmView.ShowDialog();
                    registrationView.Close();
                }
            }
            else
            {
                if (sectors.CheckIfAnySectorExist() == false && managers.CheckIfAnyManagerExist() == false)
                {
                    MessageBox.Show("An Employee account cannot be created because there are no sectors and managers.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else if (sectors.CheckIfAnySectorExist() == false)
                {
                    MessageBox.Show("An Employee account cannot be created because there is no sector.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else if (managers.CheckIfAnyManagerExist() == false)
                {
                    MessageBox.Show("An Employee account cannot be created because there is no manager.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    RegistrationEmployeeView employeeView = new RegistrationEmployeeView();
                    employeeView.ShowDialog();
                    //closing after registration
                    registrationView.Close();
                }
            }
        }
    }
}