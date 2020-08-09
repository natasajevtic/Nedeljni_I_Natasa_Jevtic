using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Zadatak_1.Helper;

namespace Zadatak_1.Models
{
    class Managers
    {
        /// <summary>
        /// This method checks if any manager exists..
        /// </summary>
        /// <returns>True if exist, false if not.</returns>
        public bool CheckIfAnyManagerExist()
        {
            try
            {
                using (EmployeeManagementEntities context = new EmployeeManagementEntities())
                {
                    return context.tblManagers.Any();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return false;
            }
        }
        /// <summary>
        /// This method creates a list of data from table of all managers.
        /// </summary>
        /// <returns>List of managers.</returns>
        public List<tblManager> GetAllManagers()
        {
            try
            {
                using (EmployeeManagementEntities context = new EmployeeManagementEntities())
                {
                    return context.tblManagers.ToList();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }
        /// <summary>
        /// This method adds manager to DbSet and save changes in database.
        /// </summary>
        /// <param name="manager">Manager to be added.</param>
        /// <returns>True if added, false if not.</returns>
        public bool AddManager(vwManager manager)
        {            
            try
            {
                using (EmployeeManagementEntities context = new EmployeeManagementEntities())
                {                    
                        tblUser user = new tblUser
                        {
                            Gender = manager.Gender,
                            JMBG = manager.JMBG,
                            Residence = manager.Residence,
                            MarriageStatus = manager.MarriageStatus,
                            Name = manager.Name,
                            Password = Encryption.EncryptPassword(manager.Password),
                            Surname = manager.Surname,
                            Username = manager.Username
                        };
                        context.tblUsers.Add(user);
                        context.SaveChanges();
                        manager.UserId = user.UserId;
                        tblManager newManager = new tblManager
                        {
                            UserId = user.UserId,
                            BackupPassword = Encryption.EncryptPassword(manager.BackupPassword + "WPF"),
                            Email = manager.Email,
                            LevelOfResponsibility = null,
                            OfficeNumber = manager.OfficeNumber,
                            Salary = null
                        };
                        context.tblManagers.Add(newManager);
                        context.SaveChanges();
                        manager.ManagerId = newManager.ManagerId;
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
        /// This method edits data about manager and save changes in database.
        /// </summary>
        /// <param name="manager">manager to be edited.</param>
        /// <returns>True if edited, false if not.</returns>
        public bool EditManager(vwManager manager)
        {            
            try
            {
                using (EmployeeManagementEntities context = new EmployeeManagementEntities())
                {
                    tblManager managerToEdit = context.tblManagers.Where(x => x.ManagerId == manager.ManagerId).FirstOrDefault();
                    managerToEdit.LevelOfResponsibility = manager.LevelOfResponsibility;
                    managerToEdit.NumberOfSuccessfulProjects = manager.NumberOfSuccessfulProjects;
                    managerToEdit.OfficeNumber = manager.OfficeNumber;
                    managerToEdit.Salary = manager.Salary;
                    managerToEdit.Email = manager.Email;
                    managerToEdit.BackupPassword = manager.BackupPassword;
                    context.SaveChanges();
                    tblUser userToEdit = context.tblUsers.Where(x => x.UserId == manager.UserId).FirstOrDefault();
                    userToEdit.Name = manager.Name;
                    userToEdit.Surname = manager.Surname;
                    userToEdit.JMBG = manager.JMBG;
                    userToEdit.Gender = manager.Gender;
                    userToEdit.Residence = manager.Residence;
                    userToEdit.MarriageStatus = manager.MarriageStatus;
                    userToEdit.Username = manager.Username;
                    userToEdit.Password = manager.Password;
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
        /// <summary>
        /// This method returns random manager from DbSet.
        /// </summary>
        /// <returns>Manager id.</returns>
        public int GetRandomManager()
        {
            try
            {
                using (EmployeeManagementEntities context = new EmployeeManagementEntities())
                {
                    Random random = new Random();
                    var managers = context.tblManagers.Select(x => x.ManagerId).ToList();
                    return managers[random.Next(0, managers.Count)];
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return 0;
            }
        }
        /// <summary>
        /// This method creates a list of data from view of all managers.
        /// </summary>
        /// <returns>List of managers.</returns>
        public List<vwManager> ViewAllManagers()
        {
            try
            {
                using (EmployeeManagementEntities context = new EmployeeManagementEntities())
                {
                    return context.vwManagers.ToList();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public bool DeleteManager(vwManager manager, out List<string> employeeList)
        {
            try
            {
                using (EmployeeManagementEntities context = new EmployeeManagementEntities())
                {
                    Random r = new Random();
                    //finding manager to be deleted
                    tblManager managerToDelete = context.tblManagers.Where(x => x.ManagerId == manager.ManagerId).FirstOrDefault();
                    //finding employees of this manager
                    List<tblEmployee> employees = context.tblEmployees.Where(x => x.SuperiorManagerId == managerToDelete.ManagerId).ToList();
                    List<vwEmployee> viewEmployees = context.vwEmployees.Where(x => x.SuperiorManagerId == managerToDelete.ManagerId).ToList();
                    //finding other managers and their ids
                    var remainingManagers = context.tblManagers.Where(x => x.ManagerId != managerToDelete.ManagerId).ToList();
                    var idOfManagers = remainingManagers.Select(x => x.ManagerId).ToList();                    
                    //if other managers exist, changing superior managers of employees
                    if (remainingManagers.Count > 0)
                    {
                        foreach (var employee in employees)
                        {
                            employee.SuperiorManagerId = idOfManagers[r.Next(0, idOfManagers.Count)];
                            context.SaveChanges();
                        }
                        context.tblManagers.Remove(managerToDelete);
                        context.SaveChanges();
                        employeeList = null;
                        return true;
                    }
                    else
                    {
                        employeeList = new List<string>(employees.Count);
                        foreach (var employee in viewEmployees)
                        {
                            employeeList.Add("Employee: " + employee.Name + " " + employee.Surname + " JMBG: " + employee.JMBG);
                        }
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                employeeList = null;
                return false;
            }
        }

        public bool CheckIfManagerHasEmployees(vwManager manager)
        {
            try
            {
                using (EmployeeManagementEntities context = new EmployeeManagementEntities())
                {
                    var employees = context.tblEmployees.Where(x => x.SuperiorManagerId == manager.ManagerId).ToList();
                    if (employees.Count > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return false;
            }
        }

        public bool CheckIfManagerHasRequest(vwManager manager)
        {
            try
            {
                using (EmployeeManagementEntities context = new EmployeeManagementEntities())
                {
                    var requests = context.vwRequestForChanges.Where(x => x.SuperiorManagerId == manager.ManagerId && x.Status == "on hold").ToList();
                    if (requests.Count > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
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