using MaterialDesignThemes.Wpf;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Zadatak_1.ViewModels;

namespace Zadatak_1.Views
{
    /// <summary>
    /// Interaction logic for MasterView.xaml
    /// </summary>
    public partial class MasterView : Window
    {
        public MasterView()
        {
            InitializeComponent();            
            this.DataContext = new MasterViewModel();

            var menuAdministrator = new List<SubItem>();
            menuAdministrator.Add(new SubItem("View all administrators", new AdministratorsView()));
            var item1 = new ItemMenu("Administrators", menuAdministrator, PackIconKind.PersonBoxOutline);

            var menuManager = new List<SubItem>();
            menuManager.Add(new SubItem("View all managers"));
            var item2 = new ItemMenu("Managers", menuManager, PackIconKind.PersonBoxOutline);

            var menuEmployee = new List<SubItem>();
            menuEmployee.Add(new SubItem("View all employees"));
            var item3 = new ItemMenu("Employees", menuEmployee, PackIconKind.PersonBoxOutline);

            var menuProject = new List<SubItem>();
            menuProject.Add(new SubItem("View all projects"));
            var item4 = new ItemMenu("Projects", menuProject, PackIconKind.FileReport);

            var menuReport = new List<SubItem>();
            menuReport.Add(new SubItem("View all reports"));
            var item5 = new ItemMenu("Reports", menuReport, PackIconKind.FileReport);

            var item0 = new ItemMenu("Dashboard", new UserControl(), PackIconKind.ViewDashboard);

            Menu.Children.Add(new UserControlMenuItem(item0, this));
            Menu.Children.Add(new UserControlMenuItem(item1, this));
            Menu.Children.Add(new UserControlMenuItem(item2, this));
            Menu.Children.Add(new UserControlMenuItem(item3, this));
            Menu.Children.Add(new UserControlMenuItem(item4, this));
            Menu.Children.Add(new UserControlMenuItem(item5, this));
        }

        public void SwitchScreen(object sender)
        {
            var screen = ((UserControl)sender);
            if (screen != null)
            {
                StackPanelMain.Children.Clear();
                StackPanelMain.Children.Add(screen);

                if (screen.Name == "Administrators")
                {
                    AdministratorsView administratorsView = new AdministratorsView();
                }                
            }
        }
    }
}