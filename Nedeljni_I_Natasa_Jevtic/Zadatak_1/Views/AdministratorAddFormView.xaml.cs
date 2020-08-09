using System.Windows;
using Zadatak_1.ViewModels;

namespace Zadatak_1.Views
{
    /// <summary>
    /// Interaction logic for AdministratorAddFormView.xaml
    /// </summary>
    public partial class AdministratorAddFormView : Window
    {
        public AdministratorAddFormView()
        {
            InitializeComponent();
            InitializeComponent();
            this.DataContext = new AdministratorAddFormViewModel(this);
            //system automatically set expiry date of the administrator account, because of it button is not enabled
            btnExpiryDate.IsEnabled = false;
        }
    }
}
