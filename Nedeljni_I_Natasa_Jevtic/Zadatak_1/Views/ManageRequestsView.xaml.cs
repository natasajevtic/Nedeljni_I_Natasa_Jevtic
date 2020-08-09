using System.Windows.Controls;
using Zadatak_1.Models;
using Zadatak_1.ViewModels;
using System.Windows;

namespace Zadatak_1.Views
{
    /// <summary>
    /// Interaction logic for ManageRequestsView.xaml
    /// </summary>
    public partial class ManageRequestsView : UserControl
    {
        public ManageRequestsView(vwEmployee employee)
        {
            InitializeComponent();
            this.DataContext = new ManageRequestsViewModel(this, employee);
            btnApprove.Visibility = Visibility.Collapsed;
            btnReject.Visibility = Visibility.Collapsed;
        }
        public ManageRequestsView(vwManager manager)
        {
            InitializeComponent();
            this.Name = "Requests";
            this.DataContext = new ManageRequestsViewModel(this, manager);
        }
    }
}
