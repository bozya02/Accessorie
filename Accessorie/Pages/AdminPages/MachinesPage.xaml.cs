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
    /// Interaction logic for MachinesPage.xaml
    /// </summary>
    public partial class MachinesPage : Page
    {
        public ObservableCollection<Machine> Machines { get; set; }
        public MachinesPage()
        {
            InitializeComponent();
            Machines = new ObservableCollection<Machine>(DBConnection.connection.Machine);

            this.DataContext = this;
        }

        private void btnAddClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MachinePage());

        }

        private void btnBackClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminPage());
        }

        private void btnRemoveClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var m = dgMachines.SelectedItem as Machine;
                DBConnection.connection.Machine.Remove(m);
                DBConnection.connection.SaveChanges();
                Machines = new ObservableCollection<Machine>(DBConnection.connection.Machine);
                NavigationService.Refresh();
            }
            catch
            {
                MessageBox.Show("Error", "Error");
            }
        }

        private void dgMachinesCellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            try
            {
                var m = dgMachines.SelectedItem as Machine;
                var mm = DBConnection.connection.Machine.SingleOrDefault(d => d.IdMachine == m.IdMachine);
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
            workbook.AddWorksheet("Machines");
            var first = workbook.Worksheet("Machines");

            first.Cell("A1").Value = "Name";
            first.Cell("B1").Value = "MachineType";
            first.Cell("C1").Value = "OperatingTime";
            first.Cell("D1").Value = "DateStart";
            first.Cell("E1").Value = "DateSpeech";

            int row = 2;
            foreach (var item in Machines)
            {
                first.Cell("A" + row.ToString()).Value = item.Name;
                first.Cell("B" + row.ToString()).Value = item.MachineType.Name;
                first.Cell("C" + row.ToString()).Value = item.OperatingTime;
                first.Cell("D" + row.ToString()).Value = item.DateStart;
                first.Cell("E" + row.ToString()).Value = item.DateSpeech;
                row++;
            }

            workbook.SaveAs(@"C:\Users\USER\Desktop\machines.xlsx");

            MessageBox.Show("Excell book is successfully created in a Desktop");
        }
    }
}
