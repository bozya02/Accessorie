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
    /// Interaction logic for AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public ObservableCollection<Repairer> Repairers { get; set; }

        public AuthorizationPage()
        {
            InitializeComponent();

            Repairers = new ObservableCollection<Repairer>(DBConnection.connection.Repairer);
        }

        private void btnLogInClick(object sender, RoutedEventArgs e)
        {
            string login = tbLogin.Text;
            string password = pbPassword.Password;

            var user = Repairers.Where(r => r.Login == login & r.Password == password).ToList();

            if (user.Count() == 1)
            {
                NavigationService.Navigate(new RepairerPage(user[0].IdRepairer));
            }
            else if (login == "admin" && password == "admin")
            {
                NavigationService.Navigate(new AdminPage());
            }
            else
            {
                MessageBox.Show("Invalid Login or Password", "Error");
            }
        }

        private void btnRegistrationClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegistrationPage());
        }
    }
}
