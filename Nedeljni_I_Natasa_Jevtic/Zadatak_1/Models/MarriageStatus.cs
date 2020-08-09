using System.Collections.Generic;

namespace Zadatak_1.Models
{
    class MarriageStatus
    {
        /// <summary>
        /// This method created list of marriage status.
        /// </summary>
        /// <returns>List of marriage status.</returns>
        public List<string> GetMarriageStatus()
        {
            return new List<string> { "single", "married", "divorced" };
        }
    }
}