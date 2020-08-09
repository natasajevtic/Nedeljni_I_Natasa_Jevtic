using System.Windows.Controls;
using Zadatak_1.Models;
using Zadatak_1.ViewModels;
using System.Windows;

namespace Zadatak_1.Views
{
    /// <summary>
    /// Interaction logic for ManageManagersView.xaml
    /// </summary>
    public partial class ManageManagersView : UserControl
    {
        public ManageManagersView(vwAdministrator administrator)
        {
            InitializeComponent();
            this.Name = "Managers";
            this.DataContext = new ManageManagersViewModel(this, administrator);
            if (administrator.TypeOfAdministrator == "Local")
            {
                btnDeleteManager.Visibility = Visibility.Collapsed;
            }
        }
    }
}
