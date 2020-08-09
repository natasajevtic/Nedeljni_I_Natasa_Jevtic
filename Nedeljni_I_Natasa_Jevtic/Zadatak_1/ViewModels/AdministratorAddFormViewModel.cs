using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using Zadatak_1.Commands;
using Zadatak_1.Models;
using Zadatak_1.Views;

namespace Zadatak_1.ViewModels
{
    class AdministratorAddFormViewModel : BaseViewModel
    {
        AdministratorAddFormView administratorFormView;
        Genders genders = new Genders();
        MarriageStatus marriageStatus = new MarriageStatus();
        Administrators administrators = new Administrators();

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

        private List<string> administratorTypeList;

        public List<string> AdministratorTypeList
        {
            get
            {
                return administratorTypeList;
            }
            set
            {
                administratorTypeList = value;
                OnPropertyChanged("AdministratorTypeList");
            }
        }        

        private ICommand saveAdministrator;
        public ICommand SaveAdministrator
        {
            get
            {
                if (saveAdministrator == null)
                {
                    saveAdministrator = new RelayCommand(param => SaveAdministratorExecute(), param => CanSaveAdministratorExecute());
                }
                return saveAdministrator;
            }
        }

        private ICommand cancelAdministrator;
        public ICommand CancelAdministrator
        {
            get
            {
                if (cancelAdministrator == null)
                {
                    cancelAdministrator = new RelayCommand(param => CancelAdministratorExecute(), param => CanCancelAdministratorExecute());
                }
                return cancelAdministrator;
            }
        }

        public AdministratorAddFormViewModel(AdministratorAddFormView administratorFormView)
        {
            this.administratorFormView = administratorFormView;
            Administrator = new vwAdministrator();
            Administrator.AccountExpirationDate = DateTime.Today.AddDays(7);
            GenderList = genders.GetGenders();
            MarriageStatusList = marriageStatus.GetMarriageStatus();
            AdministratorTypeList = administrators.GetAdministratorType();

        }        

        public void SaveAdministratorExecute()
        {
            if (String.IsNullOrEmpty(Administrator.Name) || String.IsNullOrEmpty(Administrator.Surname) || String.IsNullOrEmpty(Administrator.JMBG) || String.IsNullOrEmpty(Administrator.Gender)
               || String.IsNullOrEmpty(Administrator.Residence) || String.IsNullOrEmpty(Administrator.MarriageStatus) || String.IsNullOrEmpty(Administrator.Username)
               || String.IsNullOrEmpty(Administrator.Password) || String.IsNullOrEmpty(Administrator.AccountExpirationDate.ToString()) || String.IsNullOrEmpty(Administrator.TypeOfAdministrator))
            {
                MessageBox.Show("Please fill all fields.", "Notification");
            }
            else
            {
                try
                {
                    MessageBoxResult result = MessageBox.Show("Are you sure you want to save the administrator?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        bool isCreated = administrators.AddAdministrator(Administrator);
                        if (isCreated == true)
                        {
                            MessageBox.Show("Administrator is created.", "Notification", MessageBoxButton.OK);
                            administratorFormView.Close();
                        }                        
                        else
                        {
                            MessageBox.Show("Administrator cannot be created.", "Notification", MessageBoxButton.OK);
                            administratorFormView.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        public bool CanSaveAdministratorExecute()
        {
            return true;
        }

        public void CancelAdministratorExecute()
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to cancel creating the administrator?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    administratorFormView.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public bool CanCancelAdministratorExecute()
        {
            return true;
        }
    }
}