using MaterialDesignThemes.Wpf;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Zadatak_1.Models;
using Zadatak_1.ViewModels;

namespace Zadatak_1.Views
{
    /// <summary>
    /// Interaction logic for AdministratorView.xaml
    /// </summary>
    public partial class AdministratorView : Window
    {
        public AdministratorView(vwAdministrator administrator)
        {
            InitializeComponent();
            this.DataContext = new AdministratorViewModel(this, administrator);

            if (administrator.TypeOfAdministrator == "System")
            {
                var menuSector = new List<SubItem>();
                menuSector.Add(new SubItem("View all sectors", new ManageSectorsView()));
                var item1 = new ItemMenu("Sectors", menuSector, PackIconKind.PersonBoxOutline);

                var menuPosition = new List<SubItem>();
                menuPosition.Add(new SubItem("View all position", new ManagePositionView()));
                var item2 = new ItemMenu("Position", menuPosition, PackIconKind.PersonBoxOutline);
                var item0 = new ItemMenu("Dashboard", new UserControl(), PackIconKind.ViewDashboard);

                Menu.Children.Add(new UserControlMenuItem(item0, this));
                Menu.Children.Add(new UserControlMenuItem(item1, this));
                Menu.Children.Add(new UserControlMenuItem(item2, this));
            }

        }

        public void SwitchScreen(object sender)
        {
            var screen = ((UserControl)sender);
            if (screen != null)
            {
                StackPanelMain.Children.Clear();
                StackPanelMain.Children.Add(screen);

                if (screen.Name == "Sectors")
                {
                    ManageSectorsView sectorsView = new ManageSectorsView();
                }
                else if (screen.Name == "Positions")
                {
                    ManagePositionView positionView = new ManagePositionView();
                    StackPanelMain.Children.Clear();
                    StackPanelMain.Children.Add(positionView);
                }                
            }
        }
    }
}