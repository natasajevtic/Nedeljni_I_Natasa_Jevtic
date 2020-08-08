using System.Windows;
using Zadatak_1.Models;
using Zadatak_1.ViewModels;

namespace Zadatak_1.Views
{
    /// <summary>
    /// Interaction logic for AdministratorEditFormView.xaml
    /// </summary>
    public partial class AdministratorEditFormView : Window
    {
        public AdministratorEditFormView(vwAdministrator administratorToEdit)
        {
            InitializeComponent();
            this.DataContext = new AdministratorEditFormViewModel(this, administratorToEdit);
        }
    }
}