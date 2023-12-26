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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace AZSProject
{
    /// <summary>
    /// Логика взаимодействия для ProductCatalog.xaml
    /// </summary>
    public partial class ProductCatalog : Window
    {
        private Type _productType;
        public ProductCatalog(string Name, Type productType)
        {
            InitializeComponent();
            _productType = productType;
            Update(this, null);
        }
        public void Add(object sender, RoutedEventArgs e)
        {
            DataBaseService dataBase = new DataBaseService();
            dataBase.InitalizeConnections();
            var product = Activator.CreateInstance(_productType) as IProduct;
            dataBase.AddProduct(product);
            dataBase.CloseConnections();
            var productMenu = new ProductMenu(product);
            productMenu.Show();
        }
        public void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender is ProductHolderButton button && button.Product != null)
            {
                var productMenu = new ProductMenu(button.Product);
                productMenu.Show();
                //Close();
            }
        }
        public void Update(object sender, RoutedEventArgs e)
        {
            ProductPanel.Children.Clear();

            DataBaseService dataBase = new DataBaseService();
            dataBase.InitalizeConnections();

            foreach (var item in dataBase.GetProductByType(_productType))
            {
                ProductHolderButton button = new ProductHolderButton();
                button.Height = 30;
                button.Width = ProductPanel.Width;
                button.Content = $"{item.Name}   цена: {item.Price}";
                button.Click += Button_Click;
                button.Product = item;
                ProductPanel.Children.Add(button);
            }
            ProductTitle.Text = Name;

            if (!UserInfoProvider.IsClient())
            {
                Button addButton = new Button();
                addButton.Height = 30;
                addButton.Width = ProductPanel.Width;
                addButton.Content = $"Добавить {Name}";
                addButton.Click += Add;

                addButton.Background = Brushes.Green;

                ProductPanel.Children.Add(addButton);
            }
            dataBase.CloseConnections();
        }
        public void Back(object sender, RoutedEventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
            this.Close();
        }
    }
}
