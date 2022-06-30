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
    /// Interaction logic for RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void btnRegistrationClick(object sender, RoutedEventArgs e)
        {
            var r = new Repairer
            {
                FirstName = tbFirstName.Text,
                LastName = tbLastName.Text,
                Login = tbLogin.Text,
                Password = tbPassword.Text
            };

            DBConnection.connection.Repairer.Add(r);
            DBConnection.connection.SaveChanges();

            NavigationService.GoBack();
        }

        private void tb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsLetter(e.Text, 0))
            {
                e.Handled = true;
            }
        }

    }
}
