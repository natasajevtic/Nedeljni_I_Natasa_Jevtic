using MaterialDesignThemes.Wpf;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Zadatak_1.Models;
using Zadatak_1.ViewModels;

namespace Zadatak_1.Views
{
    /// <summary>
    /// Interaction logic for ManagerView.xaml
    /// </summary>
    public partial class ManagerView : Window
    {
        public ManagerView(vwManager manager)
        {
            InitializeComponent();
            this.DataContext = new ManagerViewModel(this, manager);

            Managers managers = new Managers();
            if (managers.CheckIfManagerHasEmployees(manager) == true)
            {
                var menuRequest = new List<SubItem>();
                menuRequest.Add(new SubItem("View all requests", new ManageRequestsView(manager)));
                var item1 = new ItemMenu("Requests", menuRequest, PackIconKind.PersonBoxOutline);
                var item0 = new ItemMenu("Dashboard", new UserControl(), PackIconKind.ViewDashboard);

                Menu.Children.Add(new UserControlMenuItem(item0, this));
                Menu.Children.Add(new UserControlMenuItem(item1, this));
            }
            else
            {
                btnExclamation.Visibility = Visibility.Collapsed;
            }
        }
        public void SwitchScreen(object sender)
        {
            var screen = ((UserControl)sender);
            if (screen != null)
            {
                StackPanelMain.Children.Clear();
                StackPanelMain.Children.Add(screen);                
            }
        }
    }
}