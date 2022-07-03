using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for DetailAdminPage.xaml
    /// </summary>
    public partial class DetailAdminPage : Page
    {
        public ObservableCollection<Detail> Details { get; set; }

        public DetailAdminPage()
        {
            InitializeComponent();
            Details = new ObservableCollection<Detail>(DBConnection.connection.Detail);

            this.DataContext = this;
        }

        private void btnAddClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddDetailPage());

        }

        private void btnBackClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminPage());
        }

        private void btnRemoveClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var m = dgDetails.SelectedItem as Detail;
                DBConnection.connection.Detail.Remove(m);
                DBConnection.connection.SaveChanges();
                Details = new ObservableCollection<Detail>(DBConnection.connection.Detail);
                NavigationService.Refresh();
            }
            catch
            {
                MessageBox.Show("Error", "Error");
            }
        }

        private void dgDetailsCellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            try
            {
                var m = dgDetails.SelectedItem as Detail;
                var mm = DBConnection.connection.Detail.SingleOrDefault(d => d.IdDetail == m.IdDetail);
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
            workbook.AddWorksheet("Details");
            var first = workbook.Worksheet("Details");

            first.Cell("A1").Value = "Name";
            first.Cell("B1").Value = "Price";

            int row = 2;
            foreach (var item in Details)
            {
                first.Cell("A" + row.ToString()).Value = item.Name;
                first.Cell("B" + row.ToString()).Value = item.Price;
                row++;
            }

            workbook.SaveAs(@"C:\Users\USER\Desktop\details.xlsx");

            MessageBox.Show("Excell book is successfully created in a Desktop");
        }


    }
}
