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
    /// Логика взаимодействия для WindowAddEditProduct.xaml
    /// </summary>
    public partial class WindowAddEditProduct : Window
    {
        public WindowAddEditProduct(Product currentProduct)
        {
            InitializeComponent();
            try
            {
                this.currentProduct = currentProduct;
                tbName.Text = currentProduct.Name.ToString();
                tbEdIzm.Text = currentProduct.EdIzm.ToString();
                tbCost.Text = currentProduct.Cost.ToString();
                tbProvider.Text = currentProduct.Provider.ToString();
                cbCategory.Text = currentProduct.Category.ToString();
                tbQuantity.Text = currentProduct.Quantity.ToString();
                tbDescription.Text = currentProduct.Description.ToString();
                tbImage.Text = currentProduct.Image.ToString();
            }
            catch { }
        }
        Product currentProduct;

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                currentProduct.Name = tbName.Text;
            currentProduct.EdIzm = tbEdIzm.Text;
            currentProduct.Cost = double.Parse(tbCost.Text); 
            currentProduct.Provider = tbProvider.Text;
            currentProduct.Category = cbCategory.Text;   
            currentProduct.Quantity = int.Parse(tbQuantity.Text);
            currentProduct.Description = tbDescription.Text;
            currentProduct.Image = tbImage.Text;
            if (currentProduct.id == 0)
                App.DB.Product.Add(currentProduct);
            App.DB.SaveChanges();
            Close();
            }
            catch { }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
