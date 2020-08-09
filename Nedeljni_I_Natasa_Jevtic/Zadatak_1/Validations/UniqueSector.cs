using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Controls;
using Zadatak_1.Models;

namespace Zadatak_1.Validations
{
    class UniqueSector : ValidationRule
    {
        /// <summary>
        /// This method checks if sector is unique.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="cultureInfo"></param>
        /// <returns>ValidationResult.</returns>
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string sectorName = value as string;
            Sectors sectors = new Sectors();
            List<vwSector> sectorList = sectors.GetAllSectors();
            var list = sectorList.Where(x => x.SectorName == sectorName).ToList();
            //if exists sector with forwarded name, return false
            if (list.Count() > 0)
            {
                return new ValidationResult(false, "This sector already exists.");
            }
            else
            {
                return new ValidationResult(true, null);
            }
        }
    }
}