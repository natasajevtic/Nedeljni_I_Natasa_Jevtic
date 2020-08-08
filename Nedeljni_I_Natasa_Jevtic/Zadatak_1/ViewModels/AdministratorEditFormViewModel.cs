using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using Zadatak_1.Commands;
using Zadatak_1.Models;
using Zadatak_1.Views;
using Zadatak_1.Validations;

namespace Zadatak_1.ViewModels
{
    class AdministratorEditFormViewModel : BaseViewModel
    {
        AdministratorEditFormView administratorFormView;
        Genders genders = new Genders();
        MarriageStatus marriageStatus = new MarriageStatus();
        Administrators administrators = new Administrators();
        ValidationForEdit validation = new ValidationForEdit();

        public vwAdministrator OldAdministrator { get; set; }

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

        public AdministratorEditFormViewModel(AdministratorEditFormView administratorFormView, vwAdministrator administratorToEdit)
        {
            this.administratorFormView = administratorFormView;
            Administrator = administratorToEdit;
            GenderList = genders.GetGenders();
            MarriageStatusList = marriageStatus.GetMarriageStatus();
            AdministratorTypeList = administrators.GetAdministratorType();
            //gets administrator initial values before editing
            OldAdministrator = new vwAdministrator
            {
                AccountExpirationDate = administratorToEdit.AccountExpirationDate,
                Gender = administratorToEdit.Gender,
                MarriageStatus = administratorToEdit.MarriageStatus,
                Residence = administrator.Residence,
                TypeOfAdministrator = administratorToEdit.TypeOfAdministrator,
                JMBG = administratorToEdit.JMBG,
                Name = administratorToEdit.Name,
                Password = administratorToEdit.Password,
                Surname = administratorToEdit.Surname,
                Username = administrator.Username
            };
        }

        public void SaveAdministratorExecute()
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to save the administrator?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    bool isCreated = administrators.EditAdministrator(Administrator);
                    if (isCreated == true)
                    {
                        MessageBox.Show("Administrator is edited.", "Notification", MessageBoxButton.OK);
                        administratorFormView.Close();
                    }
                    else
                    {
                        MessageBox.Show("Administrator cannot be edited.", "Notification", MessageBoxButton.OK);
                        administratorFormView.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public bool CanSaveAdministratorExecute()
        {
            if ((Administrator.Name != OldAdministrator.Name || Administrator.Surname != OldAdministrator.Surname || Administrator.Gender != OldAdministrator.Gender ||
                Administrator.Residence != OldAdministrator.Residence || Administrator.MarriageStatus != OldAdministrator.MarriageStatus ||
                Administrator.AccountExpirationDate != OldAdministrator.AccountExpirationDate || Administrator.TypeOfAdministrator != OldAdministrator.TypeOfAdministrator
                      || Administrator.Username != OldAdministrator.Username || Administrator.Password != OldAdministrator.Password)
                      &&
                      (!String.IsNullOrEmpty(Administrator.Name) && !String.IsNullOrEmpty(Administrator.Surname) && !String.IsNullOrEmpty(Administrator.JMBG) && !String.IsNullOrEmpty(Administrator.Gender)
               && !String.IsNullOrEmpty(Administrator.Residence) && !String.IsNullOrEmpty(Administrator.MarriageStatus) && !String.IsNullOrEmpty(Administrator.Username)
               && !String.IsNullOrEmpty(Administrator.Password) && !String.IsNullOrEmpty(Administrator.AccountExpirationDate.ToString()) && !String.IsNullOrEmpty(Administrator.TypeOfAdministrator)))
            {
                if (validation.JmbgValidation(Administrator.JMBG, OldAdministrator.JMBG) && validation.UniqueUsername(Administrator.JMBG, OldAdministrator.JMBG))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
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