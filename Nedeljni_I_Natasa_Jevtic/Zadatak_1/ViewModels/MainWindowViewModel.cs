using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Zadatak_1.Commands;
using Zadatak_1.Models;
using Zadatak_1.Views;

namespace Zadatak_1.ViewModels
{
    class MainWindowViewModel : BaseViewModel
    {
        MainWindow main;
        delegate void Generator();
        event Generator OnGenerator;
        Users users = new Users();
        public vwAdministrator Administrator { get; set; }
        public vwManager Manager { get; set; }
        public vwEmployee Employee { get; set; }

        private string username;

        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
                OnPropertyChanged("Username");
            }
        }

        private string password;

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }

        private ICommand logIn;

        public ICommand LogIn
        {
            get
            {
                if (logIn == null)
                {
                    logIn = new RelayCommand(LogInExecute, CanLogInExecute);
                }
                return logIn;
            }
        }

        private ICommand signUp;

        public ICommand SignUp
        {
            get
            {
                if (signUp == null)
                {
                    signUp = new RelayCommand(param => SignUpExecute(), param => CanSignUpExecute());
                }
                return signUp;
            }
        }

        public MainWindowViewModel(MainWindow main)
        {
            this.main = main;
            OnGenerator += GeneratePasswordForManagerAccount;
            OnGenerator();
        }
        /// <summary>
        /// This method checks if username and password valid.
        /// </summary>
        /// <param name="password">User input for password.</param>
        public void LogInExecute(object password)
        {
            Password = (password as PasswordBox).Password;
            if (Username == "WPFMaster" && Password == "WPFAccess")
            {
                MasterView masterView = new MasterView();
                masterView.ShowDialog();
            }
            else if (users.FindAdministrator(Username, Password) != null)
            {
                Administrator = users.FindAdministrator(Username, Password);
                AdministratorView administratorView = new AdministratorView(Administrator);
                administratorView.ShowDialog();
            }
            else if (users.FindManager(Username, Password) != null)
            {
                Manager = users.FindManager(Username, Password);
                if (Manager.LevelOfResponsibility == null)
                {
                    MessageBox.Show("Please wait until the competent administrator assigns you a level of responsibility.", "Notification", MessageBoxButton.OK);
                }
                else
                {
                    ManagerView managerView = new ManagerView(Manager);
                    managerView.ShowDialog();
                }
            }
            else if (users.FindEmployee(Username, Password) != null)
            {
                EmployeeView employeeView = new EmployeeView(Employee);
                employeeView.ShowDialog();
            }
            else
            {
                MessageBox.Show("Wrong username or password. Please, try again.", "Notification");
            }
        }
        /// <summary>
        /// This method ensures that the login can only be executed when the login fields are not empty.
        /// </summary>
        /// <param name="password">User input for password.</param>
        /// <returns>True if login can execute, false if not.</returns>
        public bool CanLogInExecute(object password)
        {
            Password = (password as PasswordBox).Password;
            if (!String.IsNullOrEmpty(Username) && !String.IsNullOrEmpty(Password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CanSignUpExecute()
        {
            return true;
        }

        public void SignUpExecute()
        {
            RegistrationView registrationView = new RegistrationView();
            registrationView.ShowDialog();
        }
        void GeneratePasswordForManagerAccount()
        {
            string source = @"../../ManagerAccess.txt";
            StreamWriter str = new StreamWriter(source);
            //generating 8 random characters for password
            string password = "";
            Random random = new Random();
            for (int i = 0; i < 8; i++)
            {
                password += ((char)(random.Next(1, 26) + 64)).ToString().ToLower();
            }
            str.WriteLine(password);
            str.Close();
        }
    }
}