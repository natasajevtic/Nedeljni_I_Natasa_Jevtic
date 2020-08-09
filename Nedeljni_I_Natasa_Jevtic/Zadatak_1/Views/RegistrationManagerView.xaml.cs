using System.Windows;
using Zadatak_1.ViewModels;

namespace Zadatak_1.Views
{
    /// <summary>
    /// Interaction logic for RegistrationManagerView.xaml
    /// </summary>
    public partial class RegistrationManagerView : Window
    {
        public RegistrationManagerView()
        {
            InitializeComponent();
            this.DataContext = new RegistrationManagerViewModel(this);
        }
    }
}