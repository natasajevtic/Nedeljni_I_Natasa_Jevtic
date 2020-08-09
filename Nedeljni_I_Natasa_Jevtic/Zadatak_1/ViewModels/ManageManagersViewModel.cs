using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;
using Zadatak_1.Commands;
using Zadatak_1.Models;
using Zadatak_1.Views;

namespace Zadatak_1.ViewModels
{
    class ManageManagersViewModel : BaseViewModel
    {
        ManageManagersView managersView;
        Managers managers = new Managers();

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

        private List<vwManager> managerList;

        public List<vwManager> ManagerList
        {
            get
            {
                return managerList;
            }
            set
            {
                managerList = value;
                OnPropertyChanged("ManagerList");
            }
        }        

        private ICommand editManager;
        public ICommand EditManager
        {
            get
            {
                if (editManager == null)
                {
                    editManager = new RelayCommand(param => EditManagerExecute(), param => CanEditManagerExecute());
                }
                return editManager;
            }
        }

        private ICommand deleteManager;
        public ICommand DeleteManager
        {
            get
            {
                if (deleteManager == null)
                {
                    deleteManager = new RelayCommand(param => DeleteManagerExecute(), param => CanDeleteManagerExecute());
                }
                return deleteManager;
            }
        }

        public ManageManagersViewModel(ManageManagersView managersView, vwAdministrator administrator)
        {
            this.managersView = managersView;
            ManagerList = managers.ViewAllManagers();
            Administrator = administrator;
        }        

        public void EditManagerExecute()
        {
            try
            {
                if (Manager != null)
                {
                    ManagerEditFormView form = new ManagerEditFormView(Manager, Administrator);
                    form.ShowDialog();
                    ManagerList = managers.ViewAllManagers();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public bool CanEditManagerExecute()
        {
            if (Manager != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void DeleteManagerExecute()
        {
            try
            {
                if (Manager != null)
                {
                    MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this manager?", "Confirmation", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        bool isDeleted = managers.DeleteManager(Manager, out List<string> employeeList);

                        if (isDeleted == true)
                        {
                            MessageBox.Show("Manager is deleted.", "Notification", MessageBoxButton.OK);
                            ManagerList = managers.ViewAllManagers();
                        }
                        else
                        {
                            if (employeeList != null)
                            {
                                StringBuilder message = new StringBuilder();
                                foreach (var employeeData in employeeList)
                                {
                                    message.Append(employeeData + "\n");
                                }
                                MessageBox.Show($"Manager cannot be deleted. Please first delete employees:\n{message}", "Notification", MessageBoxButton.OK);
                            }                            
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public bool CanDeleteManagerExecute()
        {
            if (Manager != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}