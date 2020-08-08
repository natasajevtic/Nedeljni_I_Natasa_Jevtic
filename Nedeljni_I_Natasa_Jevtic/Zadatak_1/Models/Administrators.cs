using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Zadatak_1.Helper;

namespace Zadatak_1.Models
{
    class Administrators
    {
        /// <summary>
        /// This method creates a list of data from view of all administrators.
        /// </summary>
        /// <returns></returns>
        public List<vwAdministrator> ViewAllAdministrators()
        {
            try
            {
                using (EmployeeManagementEntities context = new EmployeeManagementEntities())
                {
                    return context.vwAdministrators.ToList();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }
        /// <summary>
        /// This method adds administrator in DbSet and save changes in database.
        /// </summary>
        /// <param name="administrator">Administrator to be added.</param>
        /// <returns>True if added, false if not.</returns>
        public bool AddAdministrator(vwAdministrator administrator)
        {
            Users users = new Users();
            try
            {
                using (EmployeeManagementEntities context = new EmployeeManagementEntities())
                {
                    tblUser user = new tblUser
                    {
                        Gender = administrator.Gender,
                        JMBG = administrator.JMBG,
                        Residence = administrator.Residence,
                        MarriageStatus = administrator.MarriageStatus,
                        Name = administrator.Name,
                        Password = Encryption.EncryptPassword(administrator.Password),
                        Surname = administrator.Surname,
                        Username = administrator.Username
                    };
                    context.tblUsers.Add(user);
                    context.SaveChanges();
                    administrator.UserId = user.UserId;
                    tblAdministrator newAdministrator = new tblAdministrator
                    {
                        UserId = user.UserId,
                        AccountExpirationDate = administrator.AccountExpirationDate,
                        TypeOfAdministrator = administrator.TypeOfAdministrator
                    };
                    context.tblAdministrators.Add(newAdministrator);
                    context.SaveChanges();
                    administrator.AdministratorId = newAdministrator.AdministratorId;
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
        /// This method edits administrator data and save changes in database.
        /// </summary>
        /// <param name="administrator">Administratot to be edited.</param>
        /// <returns>True if edited, false if not.</returns>
        public bool EditAdministrator(vwAdministrator administrator)
        {
            try
            {
                using (EmployeeManagementEntities context = new EmployeeManagementEntities())
                {

                    tblAdministrator administratorToEdit = context.tblAdministrators.Where(x => x.AdministratorId == administrator.AdministratorId).FirstOrDefault();
                    administratorToEdit.AccountExpirationDate = administrator.AccountExpirationDate;
                    administratorToEdit.TypeOfAdministrator = administrator.TypeOfAdministrator;
                    context.SaveChanges();
                    tblUser userToEdit = context.tblUsers.Where(x => x.UserId == administrator.UserId).FirstOrDefault();
                    userToEdit.Name = administrator.Name;
                    userToEdit.Surname = administrator.Surname;
                    userToEdit.JMBG = administrator.JMBG;
                    userToEdit.Gender = administrator.Gender;
                    userToEdit.Residence = administrator.Residence;
                    userToEdit.MarriageStatus = administrator.MarriageStatus;
                    userToEdit.Username = administrator.Username;
                    userToEdit.Password = administrator.Password;
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
        /// This method created list of administrator types.
        /// </summary>
        /// <returns>List of types of administrator.</returns>
        public List<string> GetAdministratorType()
        {
            return new List<string> { "Team", "System", "Local" };
        }
    }
}