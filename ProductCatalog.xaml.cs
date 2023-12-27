using AZSProject;
using AZSProject.Models;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;

namespace AZSProject
{
    public partial class ProductCatalog : Window
    {
        public Type ProductType { get; }

        public string ProductTitle
        {
            get { return ProductTitleText.Text; }
            set { ProductTitleText.Text = value; }
        }

        public ProductCatalog(string name, Type productType)
        {
            InitializeComponent();
            ProductType = productType;
            ProductTitle = name;
            UpdateButton_Click(this, null);
        }
        public StackPanel ProductPanelElement {
            get => ProductPanel;
                }

        public void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var product = Activator.CreateInstance(ProductType) as IProduct;
            DataBaseService.AddProduct(product);

            var productMenu = new ProductMenu(product);
            productMenu.Show();
        }

        public void ProductButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is ProductHolderButton button && button.Product != null)
            {
                var productMenu = new ProductMenu(button.Product);
                productMenu.Show();
            }
        }

        public void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            ClearProductPanel();
            foreach (var item in DataBaseService.GetProductByType(ProductType))
            {
                AddProductHolderButton($"{item.Name}   цена: {item.Price}", ProductButton_Click, item);
            }

            if (!UserInfoProvider.IsClient())
            {
                AddProductButton($"Добавить {ProductTitle}", AddButton_Click);
            }
        }

        public void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
            Close();
        }

        public void AddProductButton(string buttonText, RoutedEventHandler clickHandler)
        {
            Button addButton = new Button();
            addButton.Height = 30;
            addButton.Width = ProductPanel.Width;
            addButton.Content = buttonText;
            addButton.Click += clickHandler;

            addButton.Background = Brushes.Green;

            ProductPanel.Children.Add(addButton);
        }

        public void AddProductHolderButton(string buttonText, RoutedEventHandler clickHandler, IProduct product)
        {
            ProductHolderButton button = new ProductHolderButton();
            button.Height = 30;
            button.Width = ProductPanel.Width;
            button.Content = buttonText;
            button.Click += clickHandler;
            button.Product = product;
            ProductPanel.Children.Add(button);
        }

        public void ClearProductPanel()
        {
            ProductPanel.Children.Clear();
        }
    }
}
