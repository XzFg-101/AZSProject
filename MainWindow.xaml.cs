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
        private bool IsPhoneNumberValid(string phoneNumber)
        {
            return phoneNumber.Length == 11 && phoneNumber.All(char.IsDigit);
        }
        public void Login(object sender, RoutedEventArgs e)
        {
            string phoneNumber = PhoneNumber.Text;

            if (!IsPhoneNumberValid(phoneNumber))
            {
                StatusText.Text = "Неверный номер телефона";
                return;
            }

            var user = dataBaseService.LoginUser(phoneNumber, Password.Password);
            if (user == null)
            {
                StatusText.Text = "Неверные данные";
            }
            else
            {
                if ((bool)isEmployee.IsChecked) user.IsClient = true; 
                UserInfoProvider.SetUser(user);
                var mainMenu = new MainMenu();
                mainMenu.Show();
                dataBaseService.CloseConnections();
                this.Close();
            }
        }
        public void Register(object sender, RoutedEventArgs e)
        {
            string phoneNumber = PhoneNumber.Text;

            if (!IsPhoneNumberValid(phoneNumber))
            {
                StatusText.Text = "Неверный номер телефона";
                return;
            }

            if (!dataBaseService.RegistrateUser(phoneNumber, Password.Password))
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
