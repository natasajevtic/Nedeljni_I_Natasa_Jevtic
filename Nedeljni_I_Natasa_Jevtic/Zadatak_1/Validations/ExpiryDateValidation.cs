using System;
using System.Globalization;
using System.Windows.Controls;

namespace Zadatak_1.Validations
{
    class ExpiryDateValidation : ValidationRule
    {
        /// <summary>
        /// This method checks if expiry date is valid and in specific format.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="cultureInfo"></param>
        /// <returns>ValidationRule.</returns>
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string expiryDate = value as string;
            if (DateTime.TryParseExact(expiryDate, "MM/dd/yyyy", CultureInfo.CurrentCulture, DateTimeStyles.None, out DateTime date))
            {
                if (date < DateTime.Today)
                {
                    return new ValidationResult(false, "Date cannot be in the past.");
                }
                else
                {
                    return new ValidationResult(true, null);
                }
            }
            else
            {
                return new ValidationResult(false, "Invalid date. Format: MM/dd/yyyy");
            }
        }
    }
}