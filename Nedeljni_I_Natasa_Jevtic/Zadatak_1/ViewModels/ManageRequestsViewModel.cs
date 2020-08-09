using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadatak_1.Models;
using Zadatak_1.Views;

namespace Zadatak_1.ViewModels
{
    class ManageRequestsViewModel : BaseViewModel
    {
        ManageRequestsView manageRequestsView;

        private vwEmployee employee;

        public vwEmployee Employee
        {
            get
            {
                return employee;
            }
            set
            {
                employee = value;
                OnPropertyChanged("Employee");
            }
        }

        public ManageRequestsViewModel(ManageRequestsView manageRequestsView, vwEmployee employee)
        {
            this.manageRequestsView = manageRequestsView;
            Employee = employee;            
        }
    }
}
