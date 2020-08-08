using Zadatak_1.Models;
using Zadatak_1.Views;

namespace Zadatak_1.ViewModels
{
    class ManagerViewModel : BaseViewModel
    {
        ManagerView managerView;

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
        public ManagerViewModel(ManagerView managerView, vwManager manager)
        {
            this.managerView = managerView;
            Manager = manager;
        }
    }
}