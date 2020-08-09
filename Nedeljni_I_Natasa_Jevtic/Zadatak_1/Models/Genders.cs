using System.Collections.Generic;

namespace Zadatak_1.Models
{
    class Genders
    {
        /// <summary>
        /// This method created list of genders.
        /// </summary>
        /// <returns>List of genders.</returns>
        public List<string> GetGenders()
        {
            return new List<string> { "F", "M", "N", "X" };
        }
    }
}