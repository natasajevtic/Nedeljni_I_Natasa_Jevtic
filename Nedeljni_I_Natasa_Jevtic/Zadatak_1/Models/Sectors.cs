using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Zadatak_1.Models
{
    class Sectors
    {
        /// <summary>
        /// This method checks if any sector exists other than the default sector.
        /// </summary>
        /// <returns>True if exist, false if not.</returns>
        public bool CheckIfAnySectorExist()
        {
            try
            {
                using (EmployeeManagementEntities context = new EmployeeManagementEntities())
                {
                    return context.tblSectors.Any(x => x.SectorId != 1);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return false;
            }
        }
        /// <summary>
        /// This method creates a list of data from view of all sectors.
        /// </summary>
        /// <returns>List of sectors, without default sector.</returns>
        public List<vwSector> GetAllSectors()
        {
            try
            {
                using (EmployeeManagementEntities context = new EmployeeManagementEntities())
                {
                    return context.vwSectors.Where(x => x.SectorId != 1).ToList();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }
        /// <summary>
        /// This method added a sector to DbSet and save changes in database.
        /// </summary>
        /// <param name="sector">Sector to be addded.</param>
        /// <returns>True if added, false if not.</returns>
        public bool AddSector(vwSector sector)
        {
            try
            {
                using (EmployeeManagementEntities context = new EmployeeManagementEntities())
                {
                    tblSector newSector = new tblSector
                    {
                        SectorDescription = sector.SectorDescription,
                        SectorName = sector.SectorName
                    };
                    context.tblSectors.Add(newSector);
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
        /// <summary>
        /// This method summarizes the number of sectors.
        /// </summary>
        /// <returns></returns>
        public int CalculateNumberOfSectors()
        {
            try
            {
                using (EmployeeManagementEntities context = new EmployeeManagementEntities())
                {
                    return context.tblSectors.Where(x => x.SectorId != 1).Count();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return 0;
            }
        }
        /// <summary>
        /// This method deletes a sector and changing sector of employees to default sector.
        /// </summary>
        /// <param name="sector">Sector to be deleted.</param>
        /// <returns>True if deleted, false if not.</returns>
        public bool DeleteSector(vwSector sector)
        {
            try
            {
                using (EmployeeManagementEntities context = new EmployeeManagementEntities())
                {
                    tblSector sectorToDelete = context.tblSectors.Where(x => x.SectorId == sector.SectorId).FirstOrDefault();
                    List<tblEmployee> employees = context.tblEmployees.Where(x => x.SectorID == sectorToDelete.SectorId).ToList();
                    //changing sector to default sector for every employee in this sector
                    foreach (var employee in employees)
                    {
                        employee.SectorID = 1;
                        context.SaveChanges();
                    }
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