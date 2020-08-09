using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Zadatak_1.Commands;
using Zadatak_1.Views;

namespace Zadatak_1.ViewModels
{
    class PasswordConfirmationViewModel : BaseViewModel
    {
        PasswordConfirmationView passwordConfirmationView;
        int numberOfAttempts = 2;

        private string confirmationPassword;

        public string ConfirmationPassword
        {
            get
            {
                return confirmationPassword;
            }
            set
            {
                confirmationPassword = value;
                OnPropertyChanged("ConfirmationPassword");
            }
        }

        private ICommand confirm;
        public ICommand Confirm
        {
            get
            {
                if (confirm == null)
                {
                    confirm = new RelayCommand(ConfirmExecute, CanConfirmExecute);
                }
                return confirm;
            }
        }

        public PasswordConfirmationViewModel(PasswordConfirmationView passwordConfirmationView)
        {
            this.passwordConfirmationView = passwordConfirmationView;
        }
        /// <summary>
        /// Thsi method checks if user can confirm password.
        /// </summary>
        /// <param name="password"></param>
        /// <returns>True if can, false if not.</returns>
        public bool CanConfirmExecute(object password)
        {
            ConfirmationPassword = (password as PasswordBox).Password;
            if (!String.IsNullOrEmpty(ConfirmationPassword))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// This method shows messages to user about number of attempts and if password is equal to password from file shows windoe for registration.
        /// </summary>
        /// <param name="password">Password.</param>
        public void ConfirmExecute(object password)
        {
            ConfirmationPassword = (password as PasswordBox).Password;
            string source = @"../../ManagerAccess.txt";
            if (File.Exists(source))
            {
                string[] lines = File.ReadAllLines(source);
                string passwordFromFile = lines[0];
                if (ConfirmationPassword == passwordFromFile)
                {
                    RegistrationManagerView managerView = new RegistrationManagerView();
                    managerView.ShowDialog();
                    passwordConfirmationView.Close();
                }
                else if (numberOfAttempts == 0)
                {
                    MessageBox.Show("You cannot create a manager account, continue creating an employee account.", "Notification", MessageBoxButton.OK);
                    passwordConfirmationView.Close();
                    RegistrationView registrationView = new RegistrationView(false);
                    registrationView.ShowDialog();
                }
                else
                {
                    MessageBox.Show($"You entered an incorrect password. You have {numberOfAttempts--} more attempts.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }            
        }
    }
}