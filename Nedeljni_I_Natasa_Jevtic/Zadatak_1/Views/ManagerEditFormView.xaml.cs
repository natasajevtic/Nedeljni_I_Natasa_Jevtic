using System.Windows;
using Zadatak_1.Models;
using Zadatak_1.ViewModels;

namespace Zadatak_1.Views
{
    /// <summary>
    /// Interaction logic for ManagerEditFormView.xaml
    /// </summary>
    public partial class ManagerEditFormView : Window
    {
        public ManagerEditFormView(vwManager manager, vwAdministrator administrator)
        {
            InitializeComponent();
            this.DataContext = new ManagerEditFormViewModel(this, manager, administrator);
            if (administrator.TypeOfAdministrator == "Team")
            {
                cmbResponsibility.IsEnabled = false;
            }
        }
    }
}