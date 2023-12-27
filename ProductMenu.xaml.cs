using AZSProject;
using AZSProject.Models;
using System.Windows;

namespace AZSProject
{
    public partial class ProductMenu : Window
    {
        private IProduct _product;

        public ProductMenu(IProduct product)
        {
            InitializeComponent();
            _product = product;

            // Заполнение текстовых полей информацией о товаре
            ProductName = $"Товар: {_product.Name}";
            ProductPrice = $"Цена: {_product.Price.ToString()}";
            ProductStatus = $"Статус: {_product.Status}";
            ProductDescription = $"Описание: {_product.Description}";
            DefineActionButton();
        }

        private void DefineActionButton()
        {
            if (UserInfoProvider.IsClient())
            {
                ActionButtonContent = "Заказать";
                ActionButtonClickHandler = Order;
            }
            else
            {
                ActionButtonContent = "Редактировать";
                ActionButtonClickHandler = Edit;
            }
        }

        public string ProductName
        {
            get => ProductNameText.Text;
            set => ProductNameText.Text = value;
        }

        public string ProductPrice
        {
            get => ProductPriceText.Text;
            set => ProductPriceText.Text = value;
        }

        public string ProductStatus
        {
            get => ProductStatusText.Text;
            set => ProductStatusText.Text = value;
        }

        public string ProductDescription
        {
            get => ProductDescriptionText.Text;
            set => ProductDescriptionText.Text = value;
        }

        public string ActionButtonContent
        {
            get => ActionButton.Content.ToString();
            set => ActionButton.Content = value;
        }

        public RoutedEventHandler ActionButtonClickHandler
        {
            set => ActionButton.Click += value;
        }

        public void Order(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("В данный момент эта функция недоступна");
        }

        public void Edit(object sender, RoutedEventArgs e)
        {
            ProductEdit productEdit = new ProductEdit(_product);
            productEdit.Show();
            Close();
        }
    }

}