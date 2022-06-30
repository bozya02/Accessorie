using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for AddWareHousePage.xaml
    /// </summary>
    public partial class AddWareHousePage : Page
    {
        Regex regex = new Regex(@"\d+[а-д/\d]*");
        public AddWareHousePage()
        {
            InitializeComponent();
        }

        private void btnCreateClick(object sender, RoutedEventArgs e)
        {
            if (regex.IsMatch(tbHouse.Text))
            {
                try
                {
                    var m = new Warehouse
                    {
                        Street = tbStreet.Text,
                        HouseNumber = tbHouse.Text, 
                        Area = int.Parse(tbArea.Text)
                    };

                    DBConnection.connection.Warehouse.Add(m);
                    DBConnection.connection.SaveChanges();

                    NavigationService.GoBack();
                }
                catch
                {
                    MessageBox.Show("Invalid values", "Error");
                }
            }
            else
            {
                MessageBox.Show("Housenumber is not valid");
                tbHouse.Text = "";
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void TextBlock_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }
    }
}
