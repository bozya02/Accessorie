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

namespace Accessorie.Pages.AdminPages
{
    /// <summary>
    /// Interaction logic for RepairerPage.xaml
    /// </summary>
    public partial class RepairerPage : Page
    {
        public ObservableCollection<Repairer> Repairers { get; set; }

        public RepairerPage()
        {
            InitializeComponent();

            Repairers = new ObservableCollection<Repairer>(DBConnection.connection.Repairer);

            this.DataContext = this;
        }
        private void dgRepairersCellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            try
            {
                var m = dgRepairers.SelectedItem as Repairer;
                var mm = DBConnection.connection.Repairer.SingleOrDefault(d => d.IdRepairer == m.IdRepairer);
                DBConnection.connection.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Error", "Error");
            }

        }

        private void btnBackClick(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Export_Click(object sender, RoutedEventArgs e)
        {
            var workbook = new XLWorkbook();
            workbook.AddWorksheet("Repairers");
            var first = workbook.Worksheet("Repairers");

            first.Cell("A1").Value = "FirstName";
            first.Cell("B1").Value = "LastName";
            first.Cell("C1").Value = "Login";
            first.Cell("D1").Value = "Patches";

            int row = 2;
            foreach (var item in Repairers)
            {
                first.Cell("A" + row.ToString()).Value = item.FirstName;
                first.Cell("B" + row.ToString()).Value = item.LastName;
                first.Cell("C" + row.ToString()).Value = item.Login;
                first.Cell("D" + row.ToString()).Value = item.Patch.Count;
                row++;
            }

            workbook.SaveAs(@"C:\Users\USER\Desktop\repairers.xlsx");

            MessageBox.Show("Excell book is successfully created in a Desktop");

        }
    }
}
