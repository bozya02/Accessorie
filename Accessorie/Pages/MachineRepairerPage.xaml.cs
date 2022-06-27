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
    /// Interaction logic for MachineRepairerPage.xaml
    /// </summary>
    public partial class MachineRepairerPage : Page
    {
        public ObservableCollection<Machine> Machines { get; set; }
        public ObservableCollection<Detail> Details { get; set; }
        public MachineRepairerPage()
        {
            InitializeComponent();
            Machines = new ObservableCollection<Machine>(DBConnection.connection.Machine);
            this.DataContext = this;
        }

        private void btnBackClick(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void cbSelectDetailSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var m = (cbSelectMachine.SelectedItem as Machine);
            Details = new ObservableCollection<Detail>(m.Detail.ToList());


            lvDetails.ItemsSource = Details;
        }
    }
}
