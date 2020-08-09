using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using Zadatak_1.Commands;
using Zadatak_1.Models;
using Zadatak_1.Views;

namespace Zadatak_1.ViewModels
{
    class ManageEmployeesViewModel : BaseViewModel
    {
        ManageEmployeesView employeeView;
        Employees employees = new Employees();

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

        private List<vwEmployee> employeeList;

        public List<vwEmployee> EmployeeList
        {
            get
            {
                return employeeList;
            }
            set
            {
                employeeList = value;
                OnPropertyChanged("EmployeeList");
            }
        }

        private ICommand editEmployee;
        public ICommand EditEmployee
        {
            get
            {
                if (editEmployee == null)
                {
                    editEmployee = new RelayCommand(param => EditEmployeeExecute(), param => CanEditEmployeeExecute());
                }
                return editEmployee;
            }
        }

        private ICommand deleteEmployee;
        public ICommand DeleteEmployee
        {
            get
            {
                if (deleteEmployee == null)
                {
                    deleteEmployee = new RelayCommand(param => DeleteEmployeeExecute(), param => CanDeleteEmployeeExecute());
                }
                return deleteEmployee;
            }
        }

        public ManageEmployeesViewModel(ManageEmployeesView employeeView)
        {
            this.employeeView = employeeView;
            EmployeeList = employees.ViewAllEmployees();
        }

        public void EditEmployeeExecute()
        {
            try
            {
                if (Employee != null)
                {
                    EmployeeEditFormView form = new EmployeeEditFormView(Employee);
                    form.ShowDialog();
                    EmployeeList = employees.ViewAllEmployees();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public bool CanEditEmployeeExecute()
        {
            if (Employee != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void DeleteEmployeeExecute()
        {
            try
            {
                if (Employee != null)
                {
                    MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this employee?", "Confirmation", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        bool isDeleted = employees.DeleteEmployee(Employee);

                        if (isDeleted == true)
                        {
                            MessageBox.Show("Employee is deleted.", "Notification", MessageBoxButton.OK);
                            EmployeeList = employees.ViewAllEmployees();
                        }
                        else
                        {
                            MessageBox.Show("Employee cannot be deleted.", "Notification", MessageBoxButton.OK);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public bool CanDeleteEmployeeExecute()
        {
            if (Employee != null)
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