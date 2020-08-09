using System.Windows.Controls;
using Zadatak_1.Models;
using Zadatak_1.ViewModels;

namespace Zadatak_1.Views
{
    /// <summary>
    /// Interaction logic for EmployeeAccountView.xaml
    /// </summary>
    public partial class EmployeeAccountView : UserControl
    {
        public EmployeeAccountView(vwEmployee employee)
        {
            InitializeComponent();
            this.DataContext = new EmployeeAccountViewModel(this, employee);
        }
    }
}
