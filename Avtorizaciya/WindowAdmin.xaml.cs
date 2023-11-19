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
using System.Windows.Shapes;

namespace Avtorizaciya
{
    /// <summary>
    /// Логика взаимодействия для WindowAdmin.xaml
    /// </summary>
    public partial class WindowAdmin : Window
    {
        public WindowAdmin()
        {
            InitializeComponent();
            dgProduct.ItemsSource = App.DB.Product.ToList();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            Close();
        }

        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WindowAddEditProduct window = new WindowAddEditProduct(new Product());
                window.ShowDialog();
                dgProduct.ItemsSource = null;
                dgProduct.ItemsSource = App.DB.Product.ToList();
            }
            catch { }

        }

        private void btnEditProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Product product = dgProduct.SelectedItem as Product;
                WindowAddEditProduct window = new WindowAddEditProduct(product);
                window.ShowDialog();
                dgProduct.ItemsSource = null;
                dgProduct.ItemsSource = App.DB.Product.ToList();
            }
            catch { MessageBox.Show("Выберите объект для изменения"); }
        }

        private void btnDelProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Product product = dgProduct.SelectedItem as Product;
                App.DB.Product.Remove(product);
                App.DB.SaveChanges();
                dgProduct.ItemsSource = null;
                dgProduct.ItemsSource = App.DB.Product.ToList();

            }
            catch { MessageBox.Show("Выберите объект для удаления"); }
        }

        private void tbProductSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string search = tbProductSearch.Text;
            List<Product> products = App.DB.Product.Where(cat => cat.Name.Contains(search)).ToList();
            dgProduct.ItemsSource = null;
            dgProduct.ItemsSource = products;
        }

        private void cmbProductSorted_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int ind = cmbProductSorted.SelectedIndex;
            List<Product> products = App.DB.Product.ToList();
            if (ind == 0)
                products = App.DB.Product.OrderBy(cat => cat.Name).ToList();
            else
                if (ind == 1)
                products = App.DB.Product.OrderByDescending(cat => cat.Name).ToList();
            dgProduct.ItemsSource = null;
            dgProduct.ItemsSource = products;
        }

        private void btnMainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
