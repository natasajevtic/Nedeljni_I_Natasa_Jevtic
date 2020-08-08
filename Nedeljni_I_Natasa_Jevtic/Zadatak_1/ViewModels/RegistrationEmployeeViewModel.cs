using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using Zadatak_1.Commands;
using Zadatak_1.Models;
using Zadatak_1.Views;

namespace Zadatak_1.ViewModels
{
    class RegistrationEmployeeViewModel : BaseViewModel
    {
        RegistrationEmployeeView registrationEmployeeView;
        Employees employees = new Employees();
        Genders genders = new Genders();
        MarriageStatus marriageStatus = new MarriageStatus();
        Sectors sectors = new Sectors();
        Positions positions = new Positions();
        EducationDegree levels = new EducationDegree();

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

        private ICommand registerEmployee;
        public ICommand RegisterEmployee
        {
            get
            {
                if (registerEmployee == null)
                {
                    registerEmployee = new RelayCommand(param => RegisterEmployeeExecute(), param => CanRegisterEmployeeExecute());
                }
                return registerEmployee;
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

        public RegistrationEmployeeViewModel(RegistrationEmployeeView registrationEmployeeView)
        {
            this.registrationEmployeeView = registrationEmployeeView;
            Employee = new vwEmployee();
            GenderList = genders.GetGenders();
            MarriageStatusList = marriageStatus.GetMarriageStatus();
            SectorList = sectors.GetAllSectors();
            PositionList = positions.GetAllPositions();
            levelPQList = levels.GetEducationDegrees();
        }

        public void RegisterEmployeeExecute()
        {
            if (String.IsNullOrEmpty(Employee.Name) || String.IsNullOrEmpty(Employee.Surname) || String.IsNullOrEmpty(Employee.JMBG) || String.IsNullOrEmpty(Employee.Gender)
               || String.IsNullOrEmpty(Employee.Residence) || String.IsNullOrEmpty(Employee.MarriageStatus) || String.IsNullOrEmpty(Employee.Username)
               || String.IsNullOrEmpty(Employee.Password) || Sector == null || !Int32.TryParse(Employee.WorkExperience.ToString(), out int year)
               || String.IsNullOrEmpty(Employee.EducationDegree))
            {
                MessageBox.Show("Please fill all fields.", "Notification");
            }
            else
            {
                try
                {
                    MessageBoxResult result = MessageBox.Show("Are you sure you want to register?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        employee.SectorId = Convert.ToInt32(Sector.SectorId);
                        if (Position != null)
                        {
                            employee.PositionId = Convert.ToInt32(Position.PositionId);
                        }
                        bool isCreated = employees.AddEmployee(Employee);
                        if (isCreated == true)
                        {
                            MessageBox.Show("Employee is registered.", "Notification", MessageBoxButton.OK);
                            registrationEmployeeView.Close();
                        }
                        else
                        {
                            MessageBox.Show("Employee cannot be registered.", "Notification", MessageBoxButton.OK);
                            registrationEmployeeView.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        public bool CanRegisterEmployeeExecute()
        {
            return true;
        }

        public void CancelEmployeeExecute()
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to cancel registration?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    registrationEmployeeView.Close();
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