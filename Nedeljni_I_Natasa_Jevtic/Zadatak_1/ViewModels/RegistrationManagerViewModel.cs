using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using Zadatak_1.Commands;
using Zadatak_1.Models;
using Zadatak_1.Views;

namespace Zadatak_1.ViewModels
{
    class RegistrationManagerViewModel : BaseViewModel
    {
        RegistrationManagerView registrationManagerView;
        Managers managers = new Managers();
        Genders genders = new Genders();
        MarriageStatus marriageStatus = new MarriageStatus();

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

        private List<string> genderList;

        public List<string> GenderList
        {
            get
            {
                return genderList;
            }
            set
            {
                genderList = value;
                OnPropertyChanged("GenderList");
            }
        }

        private List<string> marriageStatusList;

        public List<string> MarriageStatusList
        {
            get
            {
                return marriageStatusList;
            }
            set
            {
                marriageStatusList = value;
                OnPropertyChanged("MarriageStatusList");
            }
        }

        private ICommand registerManager;
        public ICommand RegisterManager
        {
            get
            {
                if (registerManager == null)
                {
                    registerManager = new RelayCommand(param => RegisterManagerExecute(), param => CanRegisterManagerExecute());
                }
                return registerManager;
            }
        }

        private ICommand cancelManager;
        public ICommand CancelManager
        {
            get
            {
                if (cancelManager == null)
                {
                    cancelManager = new RelayCommand(param => CancelManagerExecute(), param => CanCancelManagerExecute());
                }
                return cancelManager;
            }
        }

        public RegistrationManagerViewModel(RegistrationManagerView registrationManagerView)
        {
            this.registrationManagerView = registrationManagerView;
            Manager = new vwManager();
            GenderList = genders.GetGenders();
            MarriageStatusList = marriageStatus.GetMarriageStatus();
        }
        /// <summary>
        /// This method shows messages to user and invokes method for creating manager.
        /// </summary>
        public void RegisterManagerExecute()
        {
            if (String.IsNullOrEmpty(Manager.Name) || String.IsNullOrEmpty(Manager.Surname) || String.IsNullOrEmpty(Manager.JMBG) || String.IsNullOrEmpty(Manager.Gender)
               || String.IsNullOrEmpty(Manager.Residence) || String.IsNullOrEmpty(Manager.MarriageStatus) || String.IsNullOrEmpty(Manager.Username)
               || String.IsNullOrEmpty(Manager.Password) || String.IsNullOrEmpty(Manager.BackupPassword) || !Int32.TryParse(Manager.OfficeNumber.ToString(), out int office) || String.IsNullOrEmpty(Manager.Email))
            {
                MessageBox.Show("Please fill all fields.", "Notification");
            }
            else
            {
                try
                {
                    MessageBoxResult result = MessageBox.Show("Are you sure you want to register?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        bool isCreated = managers.AddManager(Manager);
                        if (isCreated == true)
                        {
                            MessageBox.Show("Manager is registered.", "Notification", MessageBoxButton.OK);
                            registrationManagerView.Close();
                        }
                        else
                        {
                            MessageBox.Show("Manager cannot be registered.", "Notification", MessageBoxButton.OK);
                            registrationManagerView.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        
        public bool CanRegisterManagerExecute()
        {
            return true;
        }
        /// <summary>
        /// This method shows message to user and invokes method for closing a window.
        /// </summary>
        public void CancelManagerExecute()
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to cancel registration?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    registrationManagerView.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public bool CanCancelManagerExecute()
        {
            return true;
        }
    }
}