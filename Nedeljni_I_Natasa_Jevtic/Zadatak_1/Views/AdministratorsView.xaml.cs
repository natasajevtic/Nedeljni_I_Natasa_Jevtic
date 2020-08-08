using System.Windows.Controls;
using Zadatak_1.ViewModels;

namespace Zadatak_1.Views
{
    /// <summary>
    /// Interaction logic for AdministratorsView.xaml
    /// </summary>
    public partial class AdministratorsView : UserControl
    {
        public AdministratorsView()
        {
            InitializeComponent();
            this.Name = "Administrators";
            this.DataContext = new AdministratorsViewModel(this);
        }
    }
}