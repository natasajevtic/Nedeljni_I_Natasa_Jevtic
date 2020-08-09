using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Controls;
using Zadatak_1.Models;

namespace Zadatak_1.Validations
{
    class JmbgValidation : ValidationRule
    {
        /// <summary>
        /// This method checks if jmbg is valid and unique.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="cultureInfo"></param>
        /// <returns>ValidationResult.</returns>
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string jmbg = value as string;
            if (jmbg.Length != 13 || !jmbg.All(Char.IsDigit))
            {
                return new ValidationResult(false, "Jmbg must contain 13 digits.");
            }
            else
            {
                try
                {
                    string day = jmbg.Substring(0, 2);
                    string month = jmbg.Substring(2, 2);
                    string year = jmbg.Substring(4, 3);
                    string validyear = "";
                    if (year[0] == '0')
                    {
                        validyear = "2" + year;
                    }
                    else
                    {
                        validyear = "1" + year;
                    }
                    bool conversionYear = Int32.TryParse(year, out int y);
                    bool conversionMonth = Int32.TryParse(month, out int m);
                    bool conversionDay = Int32.TryParse(day, out int d);
                    //checks if passed jmbg contains a valid date
                    var expectedDatetime = new DateTime(y, m, d);
                    //gets a birth date from passed jmbg
                    DateTime dateOfBirth = DateTime.Parse(validyear + "-" + month + "-" + day);
                    //calculates age 
                    int ageInDays = (DateTime.Today - dateOfBirth).Days;
                    //if age less than 15 returns false, else returns true
                    if (ageInDays < 5479)
                    {
                        return new ValidationResult(false, "The user must be at least 15 years old.");
                    }
                    else
                    {
                        Users users = new Users();
                        List<tblUser> userList = users.GetAllUsers();
                        var list = userList.Where(x => x.JMBG == jmbg).ToList();
                        //if exists user with forwarded username, return false
                        if (list.Count() > 0)
                        {
                            return new ValidationResult(false, "This jmbg already exists.");
                        }
                        else
                        {
                            return new ValidationResult(true, null);
                        }
                    }
                }
                //if cannot convert to DateTime, because jmbg doesn't contain a valid date
                catch (Exception)
                {
                    return new ValidationResult(false, "Jmbg contains invalid date.");
                }
            }
        }
    }
}