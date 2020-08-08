using System;
using System.Collections.Generic;
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

        public ManageManagersViewModel(ManageManagersView managersView)
        {
            this.managersView = managersView;
            ManagerList = managers.ViewAllManagers();
        }        

        public void EditManagerExecute()
        {
            try
            {
                if (Manager != null)
                {
                    ManagerEditFormView form = new ManagerEditFormView(Manager);
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
    }
}