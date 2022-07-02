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

namespace Accessorie
{
    /// <summary>
    /// Interaction logic for AddDetailPage.xaml
    /// </summary>
    public partial class AddDetailPage : Page
    {
        public AddDetailPage()
        {
            InitializeComponent();
        }

        private void btnCreateClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var m = new Detail
                {
                    Name = tbName.Text,
                    Price = int.Parse(tbPrice.Text)
                };

                DBConnection.connection.Detail.Add(m);
                DBConnection.connection.SaveChanges();

                NavigationService.Navigate(new DetailAdminPage());
            }
            catch
            {
                MessageBox.Show("Invalid values", "Error");
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DetailAdminPage());
        }

        private void tbPrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0) || (e.Text == ".")
               && (!tbPrice.Text.Contains(".")
               && tbPrice.Text.Length != 0)))
            {
                e.Handled = true;
            }
        }
    }
}
