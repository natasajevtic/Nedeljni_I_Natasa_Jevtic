using System.Windows;
using Zadatak_1.ViewModels;

namespace Zadatak_1.Views
{
    /// <summary>
    /// Interaction logic for SectorFormView.xaml
    /// </summary>
    public partial class SectorFormView : Window
    {
        public SectorFormView()
        {
            InitializeComponent();
            this.DataContext = new SectorFormViewModel(this);
        }
    }
}