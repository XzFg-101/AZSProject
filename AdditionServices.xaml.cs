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
    /// Логика взаимодействия для AdditionServices.xaml
    /// </summary>
    public partial class AdditionServices : Window
    {
        public AdditionServices()
        {
            InitializeComponent();

            DataBaseService dataBase = new DataBaseService();
            dataBase.InitalizeConnections();

            foreach (var item in dataBase.GetServiceArray())
            {
                ProductHolderButton button = new ProductHolderButton();
                button.Height = 50;
                button.Product = item;
                button.Content = $"{item.Name}    цена: {item.Price}";
                button.Click += Button_Click;
                ServicesPanel.Children.Add(button);
            } 
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
        public void Back(object sender, RoutedEventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
            this.Close();
        }
    }
}
