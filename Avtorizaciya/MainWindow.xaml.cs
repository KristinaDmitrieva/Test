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

namespace Avtorizaciya
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        WindowAdmin wa = new WindowAdmin();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnVhod_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                App.currentUser = App.DB.Users.Where
                 (users => users.login == tbLogin.Text && users.pass == tbPass.Text).First<Users>();

                if (App.currentUser.Roles.nameRole == "Администратор")
                {
                    wa.Show();
                    wa.lbName.Content = "Вы вошли как администратор!";
                    Close();
                }
                if (App.currentUser.Roles.nameRole == "Менеджер")
                {
                    
                    wa.Show();
                    wa.lbName.Content = "Вы вошли как менеджер!";
                    Close();
                }
                if (App.currentUser.Roles.nameRole == "Клиент")
                {
                    wa.btnAddProduct.IsEnabled = false;
                    wa.btnEditProduct.IsEnabled = false;
                    wa.btnDelProduct.IsEnabled = false;
                    wa.Show();
                    wa.lbName.Content = "Вы вошли как клиент!";
                    Close();
                    
                }

            }
            catch
            {

                MessageBox.Show("Неверный логин или пароль");
            }
            
        }
        private void btnVhodGost_Click(object sender, RoutedEventArgs e)
        {
            wa.btnAddProduct.IsEnabled = false;
            wa.btnEditProduct.IsEnabled = false;
            wa.btnDelProduct.IsEnabled = false;
            wa.Show();
            wa.lbName.Content = "Вы вошли как гость!";
            Close();
        }
    }
}
