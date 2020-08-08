using Zadatak_1.Models;
using Zadatak_1.Views;

namespace Zadatak_1.ViewModels
{
    class AdministratorViewModel : BaseViewModel
    {
        AdministratorView administratorView;

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

        public AdministratorViewModel(AdministratorView administratorView, vwAdministrator administrator)
        {
            this.administratorView = administratorView;
            Administrator = administrator;
        }
    }
}