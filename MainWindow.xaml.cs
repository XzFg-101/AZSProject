using System;
using System.Linq;
using System.Windows;

namespace AZSProject
{
    public partial class MainWindow : Window
    {
        public string Phone
        {
            get { return PhoneNumber.Text; }
            set { PhoneNumber.Text = value; }
        }

        public string Password
        {
            get { return PasswordField.Password; }
            set { PasswordField.Password = value; }
        }

        public string Status
        {
            get { return StatusText.Text; }
            set { StatusText.Text = value; }
        }

        public bool IsEmployeeChecked
        {
            get { return (bool)isEmployee.IsChecked; }
            set { isEmployee.IsChecked = true; }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        public void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string phoneNumber = Phone;

            if (!IsPhoneNumberValid(phoneNumber))
            {
                Status = "Неверный номер телефона";
                return;
            }

            var user = DataBaseService.LoginUser(phoneNumber, Password);
            if (user == null)
            {
                Status = "Неверные данные";
            }
            else
            {
                if (IsEmployeeChecked) user.IsClient = true;
                UserInfoProvider.SetUser(user);
                var mainMenu = new MainMenu();
                mainMenu.Show();
                Close();
            }
        }

        public void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string phoneNumber = Phone;

            if (!IsPhoneNumberValid(phoneNumber))
            {
                Status = "Неверный номер телефона";
                return;
            }

            if (!DataBaseService.RegistrateUser(phoneNumber, Password))
            {
                Status = "Неверные данные для регистрации";
            }
            else
            {
                LoginButton_Click(sender, e);
            }
        }

        public void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public bool IsPhoneNumberValid(string phoneNumber)
        {
            return phoneNumber.Length == 11 && phoneNumber.All(char.IsDigit);
        }
    }
}
