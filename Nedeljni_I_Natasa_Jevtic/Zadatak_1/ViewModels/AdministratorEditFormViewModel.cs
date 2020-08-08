using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadatak_1.Models;
using Zadatak_1.Views;

namespace Zadatak_1.ViewModels
{
    class AdministratorEditFormViewModel : BaseViewModel
    {
        AdministratorEditFormView administratorFormView;        

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
        public AdministratorEditFormViewModel(AdministratorEditFormView administratorFormView, vwAdministrator administratorToEdit)
        {
            this.administratorFormView = administratorFormView;
            Administrator = administratorToEdit;            
        }
    }
}