using System;
using System.Diagnostics;
using System.Linq;
using Zadatak_1.Helper;

namespace Zadatak_1.Models
{
    class Employees
    {
        /// <summary>
        /// This method adds employee to DbSeta nd save changes in database.
        /// </summary>
        /// <param name="employee">Employee to be edited.</param>
        /// <returns>True if added, false if not.</returns>
        public bool AddEmployee(vwEmployee employee)
        {
            Managers managers = new Managers();
            try
            {
                using (EmployeeManagementEntities context = new EmployeeManagementEntities())
                {
                    tblUser user = new tblUser
                    {
                        Gender = employee.Gender,
                        JMBG = employee.JMBG,
                        Residence = employee.Residence,
                        MarriageStatus = employee.MarriageStatus,
                        Name = employee.Name,
                        Password = Encryption.EncryptPassword(employee.Password),
                        Surname = employee.Surname,
                        Username = employee.Username
                    };
                    context.tblUsers.Add(user);
                    context.SaveChanges();
                    employee.UserId = user.UserId;
                    tblEmployee newEmployee = new tblEmployee
                    {
                        UserId = user.UserId,
                        PositionId = employee.PositionId,
                        EducationDegree = employee.EducationDegree,
                        Salary = null,
                        SectorID = employee.SectorId,
                        WorkExperience = employee.WorkExperience,
                        SuperiorManagerId = managers.GetRandomManager()
                    };
                    context.tblEmployees.Add(newEmployee);
                    context.SaveChanges();
                    employee.EmployeeId = newEmployee.EmployeeId;
                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return false;
            }
        }
        /// <summary>
        /// This method edits employee data and save changes in database.
        /// </summary>
        /// <param name="employee">Employee to de edited.</param>
        /// <returns>True if edited, false if not.</returns>
        public bool EditEmployee(vwEmployee employee)
        {
            Managers managers = new Managers();
            try
            {
                using (EmployeeManagementEntities context = new EmployeeManagementEntities())
                {
                    tblEmployee employeeToEdit = context.tblEmployees.Where(x => x.EmployeeId == employee.EmployeeId).FirstOrDefault();
                    employeeToEdit.EducationDegree = employee.EducationDegree;
                    employeeToEdit.Salary = employee.Salary;
                    employeeToEdit.WorkExperience = employee.WorkExperience;
                    employeeToEdit.PositionId = employee.PositionId;
                    employeeToEdit.SectorID = employee.SectorId;
                    context.SaveChanges();
                    tblUser userToEdit = context.tblUsers.Where(x => x.UserId == employee.UserId).FirstOrDefault();
                    userToEdit.Name = employee.Name;
                    userToEdit.Surname = employee.Surname;
                    userToEdit.JMBG = employee.JMBG;
                    userToEdit.Gender = employee.Gender;
                    userToEdit.Residence = employee.Residence;
                    userToEdit.MarriageStatus = employee.MarriageStatus;
                    userToEdit.Username = employee.Username;
                    userToEdit.Password = employee.Password;
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return false;
            }
        }
    }
}