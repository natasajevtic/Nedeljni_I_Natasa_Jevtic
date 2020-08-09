using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using Zadatak_1.Commands;
using Zadatak_1.Models;
using Zadatak_1.Views;

namespace Zadatak_1.ViewModels
{
    class AdministratorsViewModel : BaseViewModel
    {
        AdministratorsView administratorsView;
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

        private List<vwAdministrator> administratorList;

        public List<vwAdministrator> AdministratorList
        {
            get
            {
                return administratorList;
            }
            set
            {
                administratorList = value;
                OnPropertyChanged("AdministratorList");
            }
        }

        private ICommand addAdministrator;
        public ICommand AddAdministrator
        {
            get
            {
                if (addAdministrator == null)
                {
                    addAdministrator = new RelayCommand(param => AddAdministratorExecute(), param => CanAddAdministratorExecute());
                }
                return addAdministrator;
            }
        }

        private ICommand editAdministrator;
        public ICommand EditAdministrator
        {
            get
            {
                if (editAdministrator == null)
                {
                    editAdministrator = new RelayCommand(param => EditAdministratorExecute(), param => CanEditAdministratorExecute());
                }
                return editAdministrator;
            }
        }

        public AdministratorsViewModel(AdministratorsView administratorsView)
        {
            this.administratorsView = administratorsView;
            AdministratorList = administrators.ViewAllAdministrators();
        }

        public void AddAdministratorExecute()
        {
            try
            {
                AdministratorAddFormView form = new AdministratorAddFormView();
                form.ShowDialog();
                AdministratorList = administrators.ViewAllAdministrators();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public bool CanAddAdministratorExecute()
        {
            return true;
        }

        public void EditAdministratorExecute()
        {
            try
            {
                if (Administrator != null)
                {
                    AdministratorEditFormView form = new AdministratorEditFormView(Administrator);
                    form.ShowDialog();
                    AdministratorList = administrators.ViewAllAdministrators();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public bool CanEditAdministratorExecute()
        {
            if (Administrator != null)
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