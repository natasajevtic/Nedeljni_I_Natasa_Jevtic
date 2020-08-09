using System.Windows;
using Zadatak_1.Models;
using Zadatak_1.ViewModels;

namespace Zadatak_1.Views
{
    /// <summary>
    /// Interaction logic for EmployeeEditFormView.xaml
    /// </summary>
    public partial class EmployeeEditFormView : Window
    {
        public EmployeeEditFormView(vwEmployee employee)
        {
            InitializeComponent();
            this.DataContext = new EmployeeEditFormViewModel(this, employee);
        }
    }
}
