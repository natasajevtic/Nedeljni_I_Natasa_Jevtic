using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Zadatak_1.Models;

namespace Zadatak_1.Validations
{
    class ValidationForEdit
    {
        public bool JmbgValidation(string jmbg, string oldJmbg)
        {
            if (jmbg.Length != 13 || !jmbg.All(Char.IsDigit))
            {
                return false;
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
                        return false;
                    }
                    else
                    {
                        if (jmbg != oldJmbg)
                        {
                            Users users = new Users();
                            List<tblUser> userList = users.GetAllUsers();
                            var list = userList.Where(x => x.JMBG == jmbg).ToList();
                            //if exists employee with forwarded jmbg, return false
                            if (list.Count() > 0)
                            {
                                return false;
                            }
                            else
                            {
                                return true;
                            }
                        }
                        else
                        {
                            return true;
                        }
                    }
                }
                //if cannot convert to DateTime, because jmbg doesn't contain a valid date
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public bool UniqueUsername(string username, string oldUsername)
        {
            Users users = new Users();
            List<tblUser> userList = users.GetAllUsers();
            if (username != oldUsername)
            {
                var list = userList.Where(x => x.Username == username).ToList();
                //if exists employee with forwarded username, return false
                if (list.Count() > 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }

        public bool EmailValidation(string email, string oldEmail)
        {
            if ( new EmailAddressAttribute().IsValid(email)==true)
            {
                Managers managers = new Managers();
                List<tblManager> managerList = managers.GetAllManagers();
                if (email != oldEmail)
                {
                    var list = managerList.Where(x => x.Email == email).ToList();
                    //if exists manager with forwarded email, return false
                    if (list.Count() > 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }            
        }
    }
}