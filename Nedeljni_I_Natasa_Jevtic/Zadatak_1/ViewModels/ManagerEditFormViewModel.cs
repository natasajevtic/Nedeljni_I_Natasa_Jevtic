using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using Zadatak_1.Commands;
using Zadatak_1.Models;
using Zadatak_1.Validations;
using Zadatak_1.Views;

namespace Zadatak_1.ViewModels
{
    class ManagerEditFormViewModel : BaseViewModel
    {
        ManagerEditFormView managerFormView;
        Managers managers = new Managers();
        Genders genders = new Genders();
        MarriageStatus marriageStatus = new MarriageStatus();
        LevelsOfResponsibility level = new LevelsOfResponsibility();
        ValidationForEdit validation = new ValidationForEdit();

        public vwManager OldManager { get; set; }

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

        private List<string> responsibilityList;

        public List<string> ResponsibilityList
        {
            get
            {
                return responsibilityList;
            }
            set
            {
                responsibilityList = value;
                OnPropertyChanged("ResponsibilityList");
            }
        }

        private ICommand saveManager;
        public ICommand SaveManager
        {
            get
            {
                if (saveManager == null)
                {
                    saveManager = new RelayCommand(param => SaveManagerExecute(), param => CanSaveManagerExecute());
                }
                return saveManager;
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

        public ManagerEditFormViewModel(ManagerEditFormView managerFormView, vwManager managerToEdit, vwAdministrator loggedAdministrator)
        {
            this.managerFormView = managerFormView;
            Manager = managerToEdit;
            Administrator = loggedAdministrator;
            GenderList = genders.GetGenders();
            MarriageStatusList = marriageStatus.GetMarriageStatus();
            ResponsibilityList = level.GetLevelsOfResponsibility();
            //gets manager initial values before editing
            OldManager = new vwManager
            {                
                Gender = managerToEdit.Gender,
                MarriageStatus = managerToEdit.MarriageStatus,
                Residence = managerToEdit.Residence,                
                JMBG = managerToEdit.JMBG,
                Name = managerToEdit.Name,
                Password = managerToEdit.Password,
                Surname = managerToEdit.Surname,
                Username = managerToEdit.Username,
                BackupPassword = managerToEdit.BackupPassword,
                Email = managerToEdit.Email,
                LevelOfResponsibility = managerToEdit.LevelOfResponsibility,
                OfficeNumber = managerToEdit.OfficeNumber,                
            };
        }

        public void SaveManagerExecute()
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to save the manager?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    bool isCreated = managers.EditManager(Manager);
                    if (isCreated == true)
                    {
                        MessageBox.Show("Manager is edited.", "Notification", MessageBoxButton.OK);
                        managerFormView.Close();
                    }
                    else
                    {
                        MessageBox.Show("Manager cannot be edited.", "Notification", MessageBoxButton.OK);
                        managerFormView.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public bool CanSaveManagerExecute()
        {
            if ((Manager.Name != OldManager.Name || Manager.Surname != OldManager.Surname || Manager.Gender != OldManager.Gender ||
                Manager.JMBG != OldManager.JMBG || Manager.Residence != OldManager.Residence || Manager.MarriageStatus != OldManager.MarriageStatus || Manager.Username != OldManager.Username || 
                Manager.Password != OldManager.Password || Manager.BackupPassword != OldManager.BackupPassword || Manager.Email != OldManager.Email ||
                Manager.LevelOfResponsibility != OldManager.LevelOfResponsibility || Manager.OfficeNumber != OldManager.OfficeNumber)
                      &&
                      (!String.IsNullOrEmpty(Manager.Name) && !String.IsNullOrEmpty(Manager.Surname) && !String.IsNullOrEmpty(Manager.JMBG) && !String.IsNullOrEmpty(Manager.Gender)
               && !String.IsNullOrEmpty(Manager.Residence) && !String.IsNullOrEmpty(Manager.MarriageStatus) && !String.IsNullOrEmpty(Manager.Username)
               && !String.IsNullOrEmpty(Manager.Password) && !String.IsNullOrEmpty(Manager.BackupPassword) && !String.IsNullOrEmpty(Manager.Email)
                && Int32.TryParse(Manager.OfficeNumber.ToString(), out int office)))
            {
                if (validation.JmbgValidation(Manager.JMBG, OldManager.JMBG) && validation.UniqueUsername(Manager.Username, OldManager.Username) &&
                    validation.EmailValidation(Manager.Email, OldManager.Email))
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

        public void CancelManagerExecute()
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to cancel editing the manager?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    managerFormView.Close();
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
