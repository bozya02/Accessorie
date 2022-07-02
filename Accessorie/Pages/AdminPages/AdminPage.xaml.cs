﻿using System;
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

namespace Accessorie
{
    /// <summary>
    /// Interaction logic for AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public AdminPage()
        {
            InitializeComponent();
        }

        private void btnLogOutClick(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btnMechineClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MachinesPage());            
        }

        private void Detail_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DetailAdminPage());
        }
        private void WareHouse_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new WareHousesPage());
        }

        private void Repairer_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.AdminPages.RepairerPage());
        }
    }
}
