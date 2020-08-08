using System.Windows.Controls;
using Zadatak_1.ViewModels;

namespace Zadatak_1.Views
{
    /// <summary>
    /// Interaction logic for ManagePositionView.xaml
    /// </summary>
    public partial class ManagePositionView : UserControl
    {
        public ManagePositionView()
        {
            InitializeComponent();
            this.Name = "Positions";
            this.DataContext = new ManagePositionViewModel(this);
        }
    }
}