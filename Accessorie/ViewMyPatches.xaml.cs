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
    /// Interaction logic for ViewMyPathes.xaml
    /// </summary>
    public partial class ViewMyPatches : Page
    {
        public ObservableCollection<Patch> Patches { get; set; }

        public IEnumerable<MyPatch> MyPatches { get; set; }
        public int Id { get; set; }
        public ViewMyPatches(int rId)
        {
            InitializeComponent();

            Id = rId;

            Patches = new ObservableCollection<Patch>(DBConnection.connection.Patch);

            var patch = Patches.Where(r => r.IdRepairer == Id).ToList();
            List<MyPatch> temp = new List<MyPatch>();
            foreach (var p in patch)
            {
                temp.Add(new MyPatch
                    {
                        DetailName = p.Detail.Name,
                        RepairerFullName = $"{p.Repairer.FirstName} {p.Repairer.LastName}",
                        ReceivingDate = (DateTime)p.ReceivingDate,
                        Address = $"{p.Warehouse.Street} {p.Warehouse.HouseNumber}",
                        Price = (int)p.Detail.Price
                    });
            }
            MyPatches = temp;

            this.DataContext = this;
        }

        private void btnBackClick(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
