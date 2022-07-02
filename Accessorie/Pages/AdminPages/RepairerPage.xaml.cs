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
    }
}
