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

namespace AZSProject
{
    /// <summary>
    /// Логика взаимодействия для Fuel.xaml
    /// </summary>
    /// 
    public partial class FuelMenu : Window
    {
        public FuelMenu()
        {
            InitializeComponent();

            DataBaseService dataBase = new DataBaseService();
            dataBase.InitalizeConnections();

            foreach(var item in dataBase.GetFuelArray())
            {
                ProductHolderButton button = new ProductHolderButton();
                button.Height = 50;
                button.Content = $"{item.Name}   цена: {item.Price}";
                button.Click += Button_Click;
                button.Product = item;
                FuelPanel.Children.Add(button);
            }
            dataBase.CloseConnections();
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
