using System.Collections.Generic;
using System.Linq;

namespace Zadatak_1.Models
{
    class EducationDegree
    {
        /// <summary>
        /// This method creates a dictionary of education degrees.
        /// </summary>
        /// <returns>Dictionary of education degrees.</returns>       
        public Dictionary<string, int> CreateEducationDegrees()
        {
            Dictionary<string, int> levels = new Dictionary<string, int>
            {
                { "I", 1 },
                { "II", 2 },
                { "III", 3 },
                { "IV", 4 },
                { "V", 5 },
                { "VI", 6 },
                { "VII", 7 }
            };
            return levels;
        }
        /// <summary>
        /// This method created list of levels of education degree.
        /// </summary>
        /// <returns>List of education degree.</returns>
        public List<string> GetEducationDegrees()
        {
            var levels = CreateEducationDegrees();
            return levels.Keys.ToList();
        }
    }
}