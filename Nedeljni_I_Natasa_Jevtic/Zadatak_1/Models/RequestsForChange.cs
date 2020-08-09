using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Zadatak_1.Models
{
    class RequestsForChange
    {
        public bool AddRequest(vwEmployee employee)
        {
            try
            {
                using (EmployeeManagementEntities context = new EmployeeManagementEntities())
                {
                    tblRequestForChange request = new tblRequestForChange
                    {
                        DateAndTimeOfCreation = DateTime.Now,
                        EmployeeId = employee.EmployeeId,
                        NewEducationDegree = employee.EducationDegree,
                        NewPositionId = employee.PositionId,
                        NewSectorId = employee.SectorId,
                        NewWorkExperience = employee.WorkExperience,
                        Status = "on hold"
                    };
                    context.tblRequestForChanges.Add(request);
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

        public bool DeleteRequest(vwRequestForChange request)
        {
            try
            {
                using (EmployeeManagementEntities context = new EmployeeManagementEntities())
                {
                    tblRequestForChange requestToDelete = context.tblRequestForChanges.Where(x => x.RequestId == request.RequestId).FirstOrDefault();
                    context.tblRequestForChanges.Remove(requestToDelete);
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

        public List<vwRequestForChange> GetEmployeeRequest(vwEmployee employee)
        {
            try
            {
                using (EmployeeManagementEntities context = new EmployeeManagementEntities())
                {
                    return context.vwRequestForChanges.Where(x => x.EmployeeId == employee.EmployeeId).ToList();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public List<vwRequestForChange> GetManagerRequest(vwManager manager)
        {
            try
            {
                using (EmployeeManagementEntities context = new EmployeeManagementEntities())
                {
                    return context.vwRequestForChanges.Where(x => x.SuperiorManagerId == manager.ManagerId).ToList();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public bool RejectRequest(vwRequestForChange request)
        {
            try
            {
                using (EmployeeManagementEntities context = new EmployeeManagementEntities())
                {
                    tblRequestForChange requestToReject = context.tblRequestForChanges.Where(x => x.RequestId == request.RequestId).FirstOrDefault();
                    requestToReject.Status = "rejected";
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

        public bool ApproveRequest(vwRequestForChange request)
        {
            try
            {
                using (EmployeeManagementEntities context = new EmployeeManagementEntities())
                {
                    tblRequestForChange requestToApprove = context.tblRequestForChanges.Where(x => x.RequestId == request.RequestId).FirstOrDefault();
                    requestToApprove.Status = "approved";
                    context.SaveChanges();
                    tblEmployee employeeToEdit = context.tblEmployees.Where(x => x.EmployeeId == requestToApprove.EmployeeId).FirstOrDefault();
                    employeeToEdit.EducationDegree = request.NewEducationDegree;
                    employeeToEdit.WorkExperience = request.NewWorkExperience;
                    employeeToEdit.PositionId = request.NewPositionId;
                    employeeToEdit.SectorID = request.NewSectorId;
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