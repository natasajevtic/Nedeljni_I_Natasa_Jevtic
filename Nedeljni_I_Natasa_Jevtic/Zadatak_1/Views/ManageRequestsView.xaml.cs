using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Zadatak_1.Models;
using Zadatak_1.ViewModels;

namespace Zadatak_1.Views
{
    /// <summary>
    /// Interaction logic for ManageRequestsView.xaml
    /// </summary>
    public partial class ManageRequestsView : UserControl
    {
        public ManageRequestsView(vwEmployee employee)
        {
            InitializeComponent();
            this.Name = "Requests";
            this.DataContext = new ManageRequestsViewModel(this, employee);            
        }
    }
}
