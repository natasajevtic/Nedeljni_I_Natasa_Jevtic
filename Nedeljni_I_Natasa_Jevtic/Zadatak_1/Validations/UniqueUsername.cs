using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Controls;
using Zadatak_1.Models;

namespace Zadatak_1.Validations
{
    class UniqueUsername : ValidationRule
    {
        /// <summary>
        /// This method checks if username is unique.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="cultureInfo"></param>
        /// <returns>ValidationResult.</returns>
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string username = value as string;
            Users users = new Users();
            List<tblUser> userList = users.GetAllUsers();
            var list = userList.Where(x => x.Username != username).ToList();
            //if exists employee with forwarded username, return false
            if (list.Count() > 0)
            {
                return new ValidationResult(false, "This username already exists.");
            }
            else
            {
                return new ValidationResult(true, null);
            }
        }
    }
}