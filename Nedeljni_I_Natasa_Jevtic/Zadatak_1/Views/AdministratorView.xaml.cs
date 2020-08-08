using System.Windows;
using Zadatak_1.Models;
using Zadatak_1.ViewModels;

namespace Zadatak_1.Views
{
    /// <summary>
    /// Interaction logic for AdministratorView.xaml
    /// </summary>
    public partial class AdministratorView : Window
    {
        public AdministratorView(vwAdministrator administrator)
        {
            InitializeComponent();
            this.DataContext = new AdministratorViewModel(this, administrator);
        }
    }
}