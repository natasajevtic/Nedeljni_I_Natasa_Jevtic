using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Zadatak_1.Commands;
using Zadatak_1.Models;
using Zadatak_1.Validations;
using Zadatak_1.Views;

namespace Zadatak_1.ViewModels
{
    class EmployeeEditFormViewModel : BaseViewModel
    {
        EmployeeEditFormView employeeFormView;
        Employees employees = new Employees();
        Genders genders = new Genders();
        MarriageStatus marriageStatus = new MarriageStatus();
        EducationDegree levels = new EducationDegree();
        Sectors sectors = new Sectors();
        Positions positions = new Positions();
        ValidationForEdit validation = new ValidationForEdit();

        public vwEmployee OldEmployee { get; set; }

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

        private vwSector sector;

        public vwSector Sector
        {
            get
            {
                return sector;
            }
            set
            {
                sector = value;
                OnPropertyChanged("Sector");
            }
        }

        private vwPosition position;

        public vwPosition Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
                OnPropertyChanged("Position");
            }
        }

        private List<vwSector> sectorList;

        public List<vwSector> SectorList
        {
            get
            {
                return sectorList;
            }
            set
            {
                sectorList = value;
                OnPropertyChanged("SectorList");
            }
        }

        private List<vwPosition> positionList;

        public List<vwPosition> PositionList
        {
            get
            {
                return positionList;
            }
            set
            {
                positionList = value;
                OnPropertyChanged("PositionList");
            }
        }

        private List<string> levelPQList;

        public List<string> LevelPQList
        {
            get
            {
                return levelPQList;
            }
            set
            {
                levelPQList = value;
                OnPropertyChanged("LevelPQList");
            }
        }

        private ICommand saveEmployee;
        public ICommand SaveEmployee
        {
            get
            {
                if (saveEmployee == null)
                {
                    saveEmployee = new RelayCommand(param => SaveEmployeeExecute(), param => CanSaveEmployeeExecute());
                }
                return saveEmployee;
            }
        }

        private ICommand cancelEmployee;
        public ICommand CancelEmployee
        {
            get
            {
                if (cancelEmployee == null)
                {
                    cancelEmployee = new RelayCommand(param => CancelEmployeeExecute(), param => CanCancelEmployeeExecute());
                }
                return cancelEmployee;
            }
        }

        public EmployeeEditFormViewModel(EmployeeEditFormView employeeFormView, vwEmployee employeeToEdit)
        {
            this.employeeFormView = employeeFormView;
            Employee = employeeToEdit;
            GenderList = genders.GetGenders();
            MarriageStatusList = marriageStatus.GetMarriageStatus();
            SectorList = sectors.GetAllSectors();
            PositionList = positions.GetAllPositions();
            levelPQList = levels.GetEducationDegrees();
            //gets employee initial values before editing
            OldEmployee = new vwEmployee
            {
                Gender = employeeToEdit.Gender,
                MarriageStatus = employeeToEdit.MarriageStatus,
                Residence = employeeToEdit.Residence,
                JMBG = employeeToEdit.JMBG,
                Name = employeeToEdit.Name,
                Password = employeeToEdit.Password,
                Surname = employeeToEdit.Surname,
                Username = employeeToEdit.Username,
                EducationDegree = employeeToEdit.EducationDegree,
                PositionName = employeeToEdit.PositionName,
                SectorName = employeeToEdit.SectorName,
                WorkExperience = employeeToEdit.WorkExperience                
            };
        }

        public void SaveEmployeeExecute()
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to save the employee?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    employee.SectorId = Convert.ToInt32(Sector.SectorId);
                    if (Position != null)
                    {
                        employee.PositionId = Convert.ToInt32(Position.PositionId);
                    }
                    bool isCreated = employees.EditEmployee(Employee);
                    if (isCreated == true)
                    {
                        MessageBox.Show("Employee is edited.", "Notification", MessageBoxButton.OK);
                        employeeFormView.Close();
                    }
                    else
                    {
                        MessageBox.Show("Employee cannot be edited.", "Notification", MessageBoxButton.OK);
                        employeeFormView.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public bool CanSaveEmployeeExecute()
        {
            if ((Employee.Name != OldEmployee.Name || Employee.Surname != OldEmployee.Surname || Employee.Gender != OldEmployee.Gender ||
                Employee.JMBG != OldEmployee.JMBG || Employee.Residence != OldEmployee.Residence || Employee.MarriageStatus != OldEmployee.MarriageStatus || Employee.Username != OldEmployee.Username ||
                Employee.Password != OldEmployee.Password || Employee.WorkExperience != OldEmployee.WorkExperience || Employee.EducationDegree != OldEmployee.EducationDegree ||
                Employee.SectorName != OldEmployee.SectorName || Employee.PositionName != OldEmployee.PositionName)
                      &&
                      (!String.IsNullOrEmpty(Employee.Name) && !String.IsNullOrEmpty(Employee.Surname) && !String.IsNullOrEmpty(Employee.JMBG) && !String.IsNullOrEmpty(Employee.Gender)
               && !String.IsNullOrEmpty(Employee.Residence) && !String.IsNullOrEmpty(Employee.MarriageStatus) && !String.IsNullOrEmpty(Employee.Username)
               && !String.IsNullOrEmpty(Employee.Password) && !String.IsNullOrEmpty(Employee.EducationDegree) && Sector != null
                && Int32.TryParse(Employee.WorkExperience.ToString(), out int year)))
            {
                if (validation.JmbgValidation(Employee.JMBG, OldEmployee.JMBG) && validation.UniqueUsername(Employee.Username, OldEmployee.Username))
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

        public void CancelEmployeeExecute()
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to cancel editing the employee?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    employeeFormView.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public bool CanCancelEmployeeExecute()
        {
            return true;
        }
    }
}