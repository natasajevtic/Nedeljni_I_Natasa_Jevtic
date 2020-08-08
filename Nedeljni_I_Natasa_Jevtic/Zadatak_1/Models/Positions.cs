using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Zadatak_1.Models
{
    class Positions
    {
        /// <summary>
        /// This method creates a list of data from view of all positions.
        /// </summary>
        /// <returns></returns>
        public List<vwPosition> GetAllPositions()
        {
            try
            {
                using (EmployeeManagementEntities context = new EmployeeManagementEntities())
                {
                    return context.vwPositions.ToList();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }
        /// <summary>
        /// This method adds position to DbSet and save changes in database.
        /// </summary>
        /// <param name="position">Position to be added.</param>
        /// <returns>True if added, false if not.</returns>
        public bool AddPosition(vwPosition position)
        {
            try
            {
                using (EmployeeManagementEntities context = new EmployeeManagementEntities())
                {
                    tblPosition newPosition = new tblPosition
                    {
                        PositionDescription = position.PositionDescription,
                        PositionName = position.PositionName
                    };
                    context.tblPositions.Add(newPosition);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return false;
            }
        }
    }
}