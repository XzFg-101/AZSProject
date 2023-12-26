using AZSProject.Models;
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

namespace AZSProject
{
    /// <summary>
    /// Логика взаимодействия для ProductMenu.xaml
    /// </summary>
    public partial class ProductMenu : Window
    {
        private IProduct _product;
        public ProductMenu(IProduct product)
        {
            InitializeComponent();
            _product = product;
            ProductNameText.Text = $"Товар: {_product.Name}";
            ProductPriceText.Text = $"Цена: {_product.Price.ToString()}";
            ProductStatusText.Text = $"Статус: {_product.Status}";
            ProductDescriptionText.Text = $"Описание: {_product.Description}";
            DefineActionButton();
        }
        private void DefineActionButton()
        {
            if (UserInfoProvider.IsClient())
            {
                ActionButton.Click += Order;
                ActionButton.Content = "Заказать";
            }
            else
            {
                ActionButton.Click += Edit;
                ActionButton.Content = "Редактировать";
            }
        }
        public void Order(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("В данный момент эта функция недоступна");
        }
        public void Edit(object sender, RoutedEventArgs e)
        {
            ProductEdit productEdit = new ProductEdit(_product);
            productEdit.Show();
            this.Close();
        }
    }
}
