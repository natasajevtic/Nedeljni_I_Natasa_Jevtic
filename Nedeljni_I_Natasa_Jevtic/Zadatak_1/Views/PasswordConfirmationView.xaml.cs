using System.Windows;
using Zadatak_1.ViewModels;

namespace Zadatak_1.Views
{
    /// <summary>
    /// Interaction logic for PasswordConfirmationView.xaml
    /// </summary>
    public partial class PasswordConfirmationView : Window
    {
        public PasswordConfirmationView()
        {
            InitializeComponent();
            this.DataContext = new PasswordConfirmationViewModel(this);
        }
    }
}