using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Zadatak_1.Helper;

namespace Zadatak_1.Models
{
    class Users
    {
        /// <summary>
        /// This methods finds employee based on forwarded username and password.
        /// </summary>
        /// <param name="username">Employee username.</param>
        /// <param name="password">Employee password.</param>
        /// <returns>Employee if finded, false if not.</returns>
        public vwEmployee FindEmployee(string username, string password)
        {
            string encryptedPassword = Encryption.EncryptPassword(password);
            try
            {
                using (EmployeeManagementEntities context = new EmployeeManagementEntities())
                {
                    return context.vwEmployees.Where(x => x.Username == username && x.Password == encryptedPassword).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }
        /// <summary>
        /// This method finds manager in DbSet with forwarded username and password.
        /// </summary>
        /// <param name="username">Username.</param>
        /// <param name="password">Password.</param>
        /// <returns>Manager if finded, null if not.</returns>
        public vwManager FindManager(string username, string password)
        {
            string encryptedPassword = Encryption.EncryptPassword(password);
            try
            {
                using (EmployeeManagementEntities context = new EmployeeManagementEntities())
                {
                    return context.vwManagers.Where(x => x.Username == username && x.Password == encryptedPassword).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }
        /// <summary>
        /// This method finds administrator in DbSet with forwarded username and password.
        /// </summary>
        /// <param name="username">Username.</param>
        /// <param name="password">Password.</param>
        /// <returns>Administrator if finded, null if not.</returns>
        public vwAdministrator FindAdministrator(string username, string password)
        {
            string encryptedPassword = Encryption.EncryptPassword(password);
            try
            {
                using (EmployeeManagementEntities context = new EmployeeManagementEntities())
                {
                    return context.vwAdministrators.Where(x => x.Username == username && x.Password == encryptedPassword).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        /// <summary>
        /// This method creates a list of data from table of all users.
        /// </summary>
        /// <returns>List of users.</returns>
        public List<tblUser> GetAllUsers()
        {
            try
            {
                using (EmployeeManagementEntities context = new EmployeeManagementEntities())
                {
                    return context.tblUsers.ToList();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        } 
    }
}