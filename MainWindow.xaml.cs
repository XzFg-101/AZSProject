﻿using System;
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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DataBaseService dataBaseService;
        public MainWindow()
        {
            InitializeComponent();

            dataBaseService = new DataBaseService();
            dataBaseService.InitalizeConnections();
        }
        public void Login(object sender, RoutedEventArgs e)
        {
            var user = dataBaseService.LoginUser(PhoneNumber.Text, Password.Password);
            if (user == null)
            {
                StatusText.Text = "Неверные данные";
            }
            else
            {
                UserInfoProvider.SetUser(user);
                var mainMenu = new MainMenu();
                mainMenu.Show();
                this.Close();
            }
        }
        public void Register(object sender, RoutedEventArgs e)
        {
            if (!dataBaseService.RegistrateUser(PhoneNumber.Text, Password.Password, !isEmployee.IsChecked.Value))
            {
                StatusText.Text = "Неверные данные для регистрации";
            }
            else
            {
                Login(sender, e);
            }
        }
    }
}
