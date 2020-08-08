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
        /// This method creates a list of data from view of all managers.
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
                            BackupPassword = manager.Password + "WPF",
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
                            BackupPassword = manager.Password + "WPF",
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
    }
}