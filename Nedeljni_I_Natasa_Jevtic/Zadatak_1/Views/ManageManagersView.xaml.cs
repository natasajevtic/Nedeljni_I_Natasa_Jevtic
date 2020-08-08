using System.Windows.Controls;
using Zadatak_1.ViewModels;

namespace Zadatak_1.Views
{
    /// <summary>
    /// Interaction logic for ManageManagersView.xaml
    /// </summary>
    public partial class ManageManagersView : UserControl
    {
        public ManageManagersView()
        {
            InitializeComponent();
            this.Name = "Managers";
            this.DataContext = new ManageManagersViewModel(this);
        }
    }
}
