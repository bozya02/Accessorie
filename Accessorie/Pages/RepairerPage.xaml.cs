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
    /// Interaction logic for RepairerPage.xaml
    /// </summary>
    public partial class RepairerPage : Page
    {
        public ObservableCollection<Repairer> Repairers { get; set; }
        public Repairer repairer { get; set; }
        public RepairerPage(int rId)
        {
            InitializeComponent();
            Repairers = new ObservableCollection<Repairer>(DBConnection.connection.Repairer);

            repairer = Repairers.Where(r => r.IdRepairer == rId).FirstOrDefault();

            this.DataContext = this;
        }

        private void btnMyPatchesClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ViewMyPatches(repairer.IdRepairer));
        }

        private void btnCreatePatchClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CreateNewPatchPage(repairer.IdRepairer));
        }

        private void btnLogOutClick(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btnDetailsClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DetailPage());
        }

        private void btnMachinesClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MachineRepairerPage());
        }
    }
}
