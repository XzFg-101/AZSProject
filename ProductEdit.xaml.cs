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
            ProductName = _product.Name;
            ProductPrice = _product.Price.ToString();
            ProductStatus = _product.Status;
            ProductDescription = _product.Description;
        }

        public string ProductName
        {
            get => ProductNameTextBox.Text;
            set => ProductNameTextBox.Text = value;
        }

        public string ProductPrice
        {
            get => ProductPriceTextBox.Text;
            set => ProductPriceTextBox.Text = value;
        }

        public string ProductStatus
        {
            get => ProductStatusTextBox.Text;
            set => ProductStatusTextBox.Text = value;
        }

        public string ProductDescription
        {
            get => ProductDescriptionTextBox.Text;
            set => ProductDescriptionTextBox.Text = value;
        }

        public void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Сохранение изменений
            _product.Name = ProductName;
            _product.Price = (double)decimal.Parse(ProductPrice);
            _product.Status = ProductStatus;
            _product.Description = ProductDescription;
            DataBaseService.UpdateProduct(_product);
            // Закрытие окна
            this.Close();
        }

        public void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            // Отмена изменений и закрытие окна
            this.Close();
        }
    }

}