using System.Windows;
using Zadatak_1.ViewModels;

namespace Zadatak_1.Views
{
    /// <summary>
    /// Interaction logic for RegistrationEmployeeView.xaml
    /// </summary>
    public partial class RegistrationEmployeeView : Window
    {
        public RegistrationEmployeeView()
        {
            InitializeComponent();
            this.DataContext = new RegistrationEmployeeViewModel(this);
        }
    }
}