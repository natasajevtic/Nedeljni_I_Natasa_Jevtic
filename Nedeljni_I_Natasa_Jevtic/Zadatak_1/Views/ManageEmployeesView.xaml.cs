using System.Windows.Controls;
using Zadatak_1.ViewModels;

namespace Zadatak_1.Views
{
    /// <summary>
    /// Interaction logic for ManageEmployeesView.xaml
    /// </summary>
    public partial class ManageEmployeesView : UserControl
    {
        public ManageEmployeesView()
        {
            InitializeComponent();
            this.Name = "Employees";
            this.DataContext = new ManageEmployeesViewModel(this);
        }
    }
}