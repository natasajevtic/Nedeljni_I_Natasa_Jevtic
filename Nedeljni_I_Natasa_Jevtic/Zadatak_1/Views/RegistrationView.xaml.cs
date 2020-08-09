using System.Windows;
using Zadatak_1.ViewModels;

namespace Zadatak_1.Views
{
    /// <summary>
    /// Interaction logic for RegistrationView.xaml
    /// </summary>
    public partial class RegistrationView : Window
    {
        public RegistrationView()
        {
            InitializeComponent();
            this.DataContext = new RegistrationViewModel(this);
        }

        public RegistrationView(bool isManagerAccountEnabled)
        {
            InitializeComponent();
            this.DataContext = new RegistrationViewModel(this, isManagerAccountEnabled);
        }
    }
}