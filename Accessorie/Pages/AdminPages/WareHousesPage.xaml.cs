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

using System.Collections.ObjectModel;

namespace Accessorie
{
    /// <summary>
    /// Interaction logic for WareHousesPage.xaml
    /// </summary>
    public partial class WareHousesPage : Page
    {
        public ObservableCollection<Warehouse> Warehouses { get; set; }
        public WareHousesPage()
        {
            InitializeComponent();
            Warehouses = new ObservableCollection<Warehouse>(DBConnection.connection.Warehouse);

            this.DataContext = this;
        }

        private void btnAddClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddWareHousePage());

        }

        private void btnBackClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminPage());
        }

        private void btnRemoveClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var m = dgWarehouses.SelectedItem as Warehouse;
                DBConnection.connection.Warehouse.Remove(m);
                DBConnection.connection.SaveChanges();
                Warehouses = new ObservableCollection<Warehouse>(DBConnection.connection.Warehouse);
                NavigationService.Refresh();
            }
            catch
            {
                MessageBox.Show("Error", "Error");
            }
        }

        private void dgWarehousesCellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            try
            {
                var m = dgWarehouses.SelectedItem as Warehouse;
                var mm = DBConnection.connection.Warehouse.SingleOrDefault(d => d.IdWarehouse == m.IdWarehouse);
                DBConnection.connection.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Error", "Error");
            }

        }
    }
}
