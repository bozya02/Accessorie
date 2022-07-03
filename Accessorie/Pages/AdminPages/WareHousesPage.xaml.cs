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
using ClosedXML.Excel;

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

        private void Export_Click(object sender, RoutedEventArgs e)
        {
            var workbook = new XLWorkbook();
            workbook.AddWorksheet("Warehouses");
            var first = workbook.Worksheet("Warehouses");

            first.Cell("A1").Value = "Street";
            first.Cell("B1").Value = "HouseNumber";
            first.Cell("C1").Value = "Area";

            int row = 2;
            foreach (var item in Warehouses)
            {
                first.Cell("A" + row.ToString()).Value = item.Street;
                first.Cell("B" + row.ToString()).Value = item.HouseNumber;
                first.Cell("C" + row.ToString()).Value = item.Area;
                row++;
            }

            workbook.SaveAs(@"C:\Users\USER\Desktop\warehouses.xlsx");

            MessageBox.Show("Excell book is successfully created in a Desktop");
        }
    }
}
