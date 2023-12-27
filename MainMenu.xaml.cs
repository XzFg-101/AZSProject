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
    public partial class MainMenu : Window
    {
        public string Status { get => StatusText.Text; } 
        public MainMenu()
        {
            InitializeComponent();
            StatusText.Text = UserInfoProvider.IsClient() ? "Авторизован как КЛИЕНТ" : "Авторизован как СОТРУДНИК";
        }

        public void ButtonService_Click(object sender, RoutedEventArgs e)
        {
            ProductCatalog additionService = new ProductCatalog("Дополнительные услуги", typeof(Service));
            additionService.Show();
            Close();
        }

        public void ButtonFuel_Click(object sender, RoutedEventArgs e)
        {
            ProductCatalog fuel = new ProductCatalog("Топливо", typeof(Fuel));
            fuel.Show();
            Close();
        }

        public void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        public void ButtonSupport_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Номер телефона тех. поддержки: 8(123)-123-12-12");
        }
    }
}
