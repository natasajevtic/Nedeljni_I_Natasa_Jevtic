﻿using System.Windows;
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
        }
    }
}