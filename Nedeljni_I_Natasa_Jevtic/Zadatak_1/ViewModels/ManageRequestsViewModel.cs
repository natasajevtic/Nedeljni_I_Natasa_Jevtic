using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using Zadatak_1.Commands;
using Zadatak_1.Models;
using Zadatak_1.Views;

namespace Zadatak_1.ViewModels
{
    class ManageRequestsViewModel : BaseViewModel
    {
        ManageRequestsView manageRequestsView;
        RequestsForChange requests = new RequestsForChange();

        private vwEmployee employee;

        public vwEmployee Employee
        {
            get
            {
                return employee;
            }
            set
            {
                employee = value;
                OnPropertyChanged("Employee");
            }
        }

        private vwManager manager;

        public vwManager Manager
        {
            get
            {
                return manager;
            }
            set
            {
                manager = value;
                OnPropertyChanged("Manager");
            }
        }

        private vwRequestForChange request;

        public vwRequestForChange Request
        {
            get
            {
                return request;
            }
            set
            {
                request = value;
                OnPropertyChanged("Request");
            }
        }

        private List<vwRequestForChange> requestList;

        public List<vwRequestForChange> RequestList
        {
            get
            {
                return requestList;
            }
            set
            {
                requestList = value;
                OnPropertyChanged("RequestList");
            }
        }

        private ICommand deleteRequest;
        public ICommand DeleteRequest
        {
            get
            {
                if (deleteRequest == null)
                {
                    deleteRequest = new RelayCommand(param => DeleteRequestExecute(), param => CanDeleteRequestExecute());
                }
                return deleteRequest;
            }
        }

        private ICommand approveRequest;
        public ICommand ApproveRequest
        {
            get
            {
                if (approveRequest == null)
                {
                    approveRequest = new RelayCommand(param => ApproveRequestExecute(), param => CanApproveRequestExecute());
                }
                return approveRequest;
            }
        }

        private ICommand rejectRequest;
        public ICommand RejectRequest
        {
            get
            {
                if (rejectRequest == null)
                {
                    rejectRequest = new RelayCommand(param => RejectRequestExecute(), param => CanRejectRequestExecute());
                }
                return rejectRequest;
            }
        }

        public ManageRequestsViewModel(ManageRequestsView manageRequestsView, vwEmployee employee)
        {
            this.manageRequestsView = manageRequestsView;
            Employee = employee;
            RequestList = requests.GetEmployeeRequest(Employee);
        }

        public ManageRequestsViewModel(ManageRequestsView manageRequestsView, vwManager manager)
        {
            this.manageRequestsView = manageRequestsView;
            Manager = manager;
            RequestList = requests.GetManagerRequest(Manager);
        }

        public void DeleteRequestExecute()
        {
            try
            {
                if (Request != null)
                {
                    MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this request?", "Confirmation", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        bool isDeleted = requests.DeleteRequest(Request);

                        if (isDeleted == true)
                        {
                            MessageBox.Show("Request is deleted.", "Notification", MessageBoxButton.OK);
                            RequestList = requests.GetEmployeeRequest(Employee);
                        }
                        else
                        {
                            MessageBox.Show("Request cannot be deleted.", "Notification", MessageBoxButton.OK);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public bool CanDeleteRequestExecute()
        {
            if (Request != null)
            {
                if (Request.Status == "approved" || Request.Status == "rejected")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public void RejectRequestExecute()
        {
            try
            {
                if (Request != null)
                {
                    MessageBoxResult result = MessageBox.Show("Are you sure you want to reject this request?", "Confirmation", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        bool isRejected = requests.RejectRequest(Request);
                        if (isRejected == true)
                        {
                            MessageBox.Show("Request is rejected.", "Notification", MessageBoxButton.OK);
                            RequestList = requests.GetManagerRequest(Manager);
                        }
                        else
                        {
                            MessageBox.Show("Request cannot be rejected.", "Notification", MessageBoxButton.OK);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public bool CanRejectRequestExecute()
        {
            if (Request != null)
            {
                if (Request.Status == "on hold")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public void ApproveRequestExecute()
        {
            try
            {
                if (Request != null)
                {
                    MessageBoxResult result = MessageBox.Show("Are you sure you want to approve this request?", "Confirmation", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        bool isApproved = requests.ApproveRequest(Request);
                        if (isApproved == true)
                        {
                            MessageBox.Show("Request is approved.", "Notification", MessageBoxButton.OK);
                            RequestList = requests.GetManagerRequest(Manager);
                        }
                        else
                        {
                            MessageBox.Show("Request cannot be approved.", "Notification", MessageBoxButton.OK);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public bool CanApproveRequestExecute()
        {
            if (Request != null)
            {
                if (Request.Status == "on hold")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
