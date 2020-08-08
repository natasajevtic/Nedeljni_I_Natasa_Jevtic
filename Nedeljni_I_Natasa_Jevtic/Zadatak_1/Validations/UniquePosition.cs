using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Controls;
using Zadatak_1.Models;

namespace Zadatak_1.Validations
{
    class UniquePosition : ValidationRule
    {
        /// <summary>
        /// This methos checks if position is unique.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string positionName = value as string;
            Positions positions = new Positions();
            List<vwPosition> positionList = positions.GetAllPositions();
            var list = positionList.Where(x => x.PositionName == positionName).ToList();
            //if exists position with forwarded name, return false
            if (list.Count() > 0)
            {
                return new ValidationResult(false, "This position already exists.");
            }
            else
            {
                return new ValidationResult(true, null);
            }
        }
    }
}