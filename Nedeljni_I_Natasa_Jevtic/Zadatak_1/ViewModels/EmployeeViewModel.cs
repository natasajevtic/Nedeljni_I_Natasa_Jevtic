using Zadatak_1.Models;
using Zadatak_1.Views;

namespace Zadatak_1.ViewModels
{
    class EmployeeViewModel : BaseViewModel
    {
        EmployeeView employeeView;

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
        public EmployeeViewModel(EmployeeView employeeView, vwEmployee employee)
        {
            this.employeeView = employeeView;
            Employee = employee;
        }
    }
}