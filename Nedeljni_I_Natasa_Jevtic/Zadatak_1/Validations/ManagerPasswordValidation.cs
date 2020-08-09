using System.Globalization;
using System.Windows.Controls;

namespace Zadatak_1.Validations
{
    class ManagerPasswordValidation : ValidationRule
    {
        /// <summary>
        /// This method checks if the length of the manager password higher then 5.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="cultureInfo"></param>
        /// <returns>ValidationResult.</returns>
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string password = value as string;
            if (password.Length < 5)
            {
                return new ValidationResult(false, "Password must contain minimum 5 characters.");
            }
            else
            {
                return new ValidationResult(true, null);
            }
        }
    }
}