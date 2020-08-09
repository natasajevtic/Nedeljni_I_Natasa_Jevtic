using MaterialDesignThemes.Wpf;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Zadatak_1.Models;
using Zadatak_1.ViewModels;

namespace Zadatak_1.Views
{
    /// <summary>
    /// Interaction logic for EmployeeView.xaml
    /// </summary>
    public partial class EmployeeView : Window
    {
        public EmployeeView(vwEmployee employee)
        {
            InitializeComponent();
            this.DataContext = new EmployeeViewModel(this, employee);
            var menuAccount = new List<SubItem>();
            menuAccount.Add(new SubItem("Edit account", new EmployeeAccountView(employee)));
            var item1 = new ItemMenu("My account", menuAccount, PackIconKind.PersonBoxOutline);

            var menuRequest = new List<SubItem>();
            menuRequest.Add(new SubItem("View all requests", new ManageRequestsView(employee)));
            var item2 = new ItemMenu("Requests", menuRequest, PackIconKind.PersonBoxOutline);
            var item0 = new ItemMenu("Dashboard", new UserControl(), PackIconKind.ViewDashboard);

            Menu.Children.Add(new UserControlMenuItem(item0, this));
            Menu.Children.Add(new UserControlMenuItem(item1, this));
            Menu.Children.Add(new UserControlMenuItem(item2, this));
        }
        public void SwitchScreen(object sender)
        {
            var screen = ((UserControl)sender);
            if (screen != null)
            {
                StackPanelMain.Children.Clear();
                StackPanelMain.Children.Add(screen);

                //if (screen.Name == "Sectors")
                //{
                //    ManageSectorsView sectorsView = new ManageSectorsView();
                //}
                //else if (screen.Name == "Positions")
                //{
                //    ManagePositionView positionView = new ManagePositionView();
                //    StackPanelMain.Children.Clear();
                //    StackPanelMain.Children.Add(positionView);
                //}
            }
        }
    }
}