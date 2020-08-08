using System.Windows.Controls;
using Zadatak_1.ViewModels;

namespace Zadatak_1.Views
{
    /// <summary>
    /// Interaction logic for ManageSectorsView.xaml
    /// </summary>
    public partial class ManageSectorsView : UserControl
    {
        public ManageSectorsView()
        {
            InitializeComponent();
            this.Name = "Sectors";
            this.DataContext = new ManageSectorsViewModel(this);
        }
    }
}