using System.Collections.Generic;
using System.Globalization;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows.Controls;
using Zadatak_1.Models;

namespace Zadatak_1.Validations
{
    class EmailValidation : ValidationRule
    {
        /// <summary>
        /// This method checks if email is valid and unique.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="cultureInfo"></param>
        /// <returns>ValidationResult.</returns>
        public override System.Windows.Controls.ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string email = value as string;
            if (new EmailAddressAttribute().IsValid(email) == false)
            {
                return new System.Windows.Controls.ValidationResult(false, "Invalid email.");
            }
            else
            {
                Managers managers = new Managers();
                List<tblManager> managerList = managers.GetAllManagers();
                var list = managerList.Where(x => x.Email == email).ToList();
                //if exists manager with forwarded email, return false
                if (list.Count() > 0)
                {
                    return new System.Windows.Controls.ValidationResult(false, "This email already exists.");
                }
                else
                {
                    return new System.Windows.Controls.ValidationResult(true, null);
                }
            }
        }
    }
}