using AZSProject.Models;
using System.Windows;

namespace AZSProject
{
    /// <summary>
    /// Логика взаимодействия для ProductEdit.xaml
    /// </summary>
    public partial class ProductEdit : Window
    {
        private Product _product;
        private DataBaseService _dataBaseService;

        public ProductEdit(Product product)
        {
            InitializeComponent();
            _product = product;
            _dataBaseService = new DataBaseService();
            // Заполнение текстовых полей информацией о товаре
            ProductNameTextBox.Text = _product.Name;
            ProductPriceTextBox.Text = _product.Price.ToString();
            ProductStatusTextBox.Text = _product.Status;
            ProductDescriptionTextBox.Text = _product.Description;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Сохранение изменений
            _product.Name = ProductNameTextBox.Text;
            _product.Price = (double)decimal.Parse(ProductPriceTextBox.Text);
            _product.Status = ProductStatusTextBox.Text;
            _product.Description = ProductDescriptionTextBox.Text;
            _dataBaseService.InitalizeConnections();
            // Дополнительный код для сохранения изменений в базе данных
            _dataBaseService.UpdateProduct( _product );
            _dataBaseService.CloseConnections();
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
