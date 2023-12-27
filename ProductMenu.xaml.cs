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
            SetProductName($"Товар: {_product.Name}");
            SetProductPrice($"Цена: {_product.Price.ToString()}");
            SetProductStatus($"Статус: {_product.Status}");
            SetProductDescription($"Описание: {_product.Description}");
            DefineActionButton();
        }

        private void DefineActionButton()
        {
            if (UserInfoProvider.IsClient())
            {
                SetActionButton("Заказать", Order);
            }
            else
            {
                SetActionButton("Редактировать", Edit);
            }
        }

        public void SetProductName(string productName)
        {
            ProductNameText.Text = productName;
        }

        public void SetProductPrice(string productPrice)
        {
            ProductPriceText.Text = productPrice;
        }

        public void SetProductStatus(string productStatus)
        {
            ProductStatusText.Text = productStatus;
        }

        public void SetProductDescription(string productDescription)
        {
            ProductDescriptionText.Text = productDescription;
        }

        public void SetActionButton(string buttonText, RoutedEventHandler clickHandler)
        {
            ActionButton.Click += clickHandler;
            ActionButton.Content = buttonText;
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