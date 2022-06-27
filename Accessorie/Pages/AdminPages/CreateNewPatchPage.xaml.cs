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
    /// Interaction logic for CreateNewPatchPage.xaml
    /// </summary>
    public partial class CreateNewPatchPage : Page
    {
        public ObservableCollection<Detail> Details { get; set; }
        public ObservableCollection<Warehouse> Warehouses{ get; set; }
        public int repairerId { get; set; }
        public CreateNewPatchPage(int id)
        {
            InitializeComponent();
            Details = new ObservableCollection<Detail>(DBConnection.connection.Detail);
            Warehouses = new ObservableCollection<Warehouse>(DBConnection.connection.Warehouse);
            repairerId = id;
            this.DataContext = this;
        }

        private void btnCreateClick(object sender, RoutedEventArgs e)
        {
            var p = new Patch
            {
                IdDetail = (cbDetail.SelectedItem as Detail).IdDetail,
                IdRepairer = repairerId,
                IdWarehouse = (cbWarehouse.SelectedItem as Warehouse).IdWarehouse,
                ReceivingDate = DateTime.Today,
            };

            try
            {
                DBConnection.connection.Patch.Add(p);
                DBConnection.connection.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Error");
            }

            NavigationService.GoBack();
        }

        private void cbSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var d = cbDetail.SelectedItem as Detail;
            tbPrice.Text = d.Price.ToString();
        }
    }
}
