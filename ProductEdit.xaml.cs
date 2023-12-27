using AZSProject;
using AZSProject.Models;
using System.Windows;

namespace AZSProject
{
    public partial class ProductEdit : Window
    {
        private IProduct _product;
        public ProductEdit(IProduct product)
        {
            InitializeComponent();
            _product = product;

            // Заполнение текстовых полей информацией о товаре
            SetProductName(_product.Name);
            SetProductPrice(_product.Price.ToString());
            SetProductStatus(_product.Status);
            SetProductDescription(_product.Description);
        }
        private void SetProductName(string productName)
        {
            ProductNameTextBox.Text = productName;
        }
        private void SetProductPrice(string productPrice)
        {
            ProductPriceTextBox.Text = productPrice;
        }
        private void SetProductStatus(string productStatus)
        {
            ProductStatusTextBox.Text = productStatus;
        }
        private void SetProductDescription(string productDescription)
        {
            ProductDescriptionTextBox.Text = productDescription;
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Сохранение изменений
            _product.Name = ProductNameTextBox.Text;
            _product.Price = (double)decimal.Parse(ProductPriceTextBox.Text);
            _product.Status = ProductStatusTextBox.Text;
            _product.Description = ProductDescriptionTextBox.Text;
            DataBaseService.UpdateProduct(_product);
            // Закрытие окна
            this.Close();
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            // Отмена изменений и закрытие окна
            this.Close();
        }
    }
}