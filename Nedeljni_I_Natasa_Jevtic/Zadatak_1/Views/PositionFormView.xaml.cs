using System.Windows;
using Zadatak_1.ViewModels;

namespace Zadatak_1.Views
{
    /// <summary>
    /// Interaction logic for PositionFormView.xaml
    /// </summary>
    public partial class PositionFormView : Window
    {
        public PositionFormView()
        {
            InitializeComponent();
            this.DataContext = new PositionFormViewModel(this);
        }
    }
}