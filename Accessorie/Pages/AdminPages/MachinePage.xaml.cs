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
    /// Interaction logic for MechinePage.xaml
    /// </summary>
    public partial class MachinePage : Page
    {
        public ObservableCollection<MachineType> MachineTypes { get; set; }

        public MachinePage()
        {
            InitializeComponent();
            tbDateStart.Text = DateTime.Today.ToString().Split(' ')[0];
            MachineTypes = new ObservableCollection<MachineType>(DBConnection.connection.MachineType);

            this.DataContext = this;
        }

        private void btnCreateClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var m = new Machine
                {
                    Name = tbName.Text,
                    IdType = (cbType.SelectedItem as MachineType).IdType,
                    DateStart = DateTime.Parse(tbDateStart.Text),
                    OperatingTime = int.Parse(tbOperatingTime.Text)
                };

                DBConnection.connection.Machine.Add(m);
                DBConnection.connection.SaveChanges();

                NavigationService.Navigate(new MachinesPage());
            }
            catch
            {
                MessageBox.Show("Invalid values", "Error");
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MachinesPage());
        }
    }
}
