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
    /// Логика взаимодействия для MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        public void ButtonService_Click(object sender, RoutedEventArgs e)
        {
            AdditionServices addition = new AdditionServices();
            addition.Show();
            Close();
        }

        public void ButtonFuel_Click(object sender, RoutedEventArgs e)
        {
            FuelMenu fuel = new FuelMenu();
            fuel.Show();
            Close();
        }

        public void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
