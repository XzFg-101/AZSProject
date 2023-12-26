using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AZSProject.Models;
using SQLite;

namespace AZSProject
{
    public class DataBaseService
    {
        private SQLite.SQLiteConnection _userConnection;
        private SQLite.SQLiteConnection _productConnection;

        public void InitalizeConnections()
        {
            //Надо закрыть свзяи воизбежании ошибок
            _userConnection?.Close();
            _productConnection?.Close();

            _userConnection = new SQLiteConnection("UserData.db");
            _userConnection.CreateTable<User>();
            _productConnection = new SQLiteConnection("ProductData.db");
            _productConnection.CreateTable<Fuel>();
            _productConnection.CreateTable<Service>();
        }
        public void CreateUser(User user)
        {
            _userConnection.Insert(user);
        }
        public User GetUser(string phoneNumber)
        {
            return _userConnection.Table<User>().FirstOrDefault(u => u.PhoneNumber == phoneNumber);
        }
        /// <summary>
        /// Проверяет на возможность входа  
        /// </summary>
        /// <param name="login">Логин</param>
        /// <param name="password">Пароль</param>
        /// <returns>User если вход успешный, Null если нет</returns>
        public User LoginUser(string login, string password)
        {
            var user = _userConnection.Table<User>().FirstOrDefault(u => u.PhoneNumber == login);

            if (user != null)
            {
                if (password == user.Password) return user;
                else
                {
                    return null;
                }
            }
            else
            {
                return null; 
            }
        }
        /// <summary>
        /// регистрирует пользователся в базе данных
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <param name="isClient"></param>
        /// <returns>True - еслия успешная регистрация, False - если нет</returns>
        public bool RegistrateUser(string login, string password)
        {
            var user = GetUser(login);
            if (user != null)
            {
                return false;
            }
            else
            {
                CreateUser(new User { PhoneNumber = login, Password = password, IsClient = true });
                return true;
            }
        }
        public IProduct[] GetProductByType(Type type)
        {
            if (type == typeof(Fuel))
            {
                return _productConnection.Table<Fuel>().ToArray();
            }
            else if (type == typeof(Service))
            {
                return _productConnection.Table<Service>().ToArray();
            }
            else
            {
                return new IProduct[0];
            }
        }
        public void AddProduct(IProduct product)
        {
            if (product is Fuel)
            {
                _productConnection.Insert((Fuel)product);
            }
            else if (product is Service)
            {
                _productConnection.Insert((Service)product);
            }
        }
        public void CloseConnections()
        {
            _userConnection.Close();
            _productConnection.Close();
        }
        public void UpdateProduct(IProduct product)
        {
            if (product is Fuel)
            {
                _productConnection.Update((Fuel)product);
            }
            else if (product is Service)
            {
                _productConnection.Update((Service)product);
            }
            // Добавьте другие типы товаров по необходимости

            // Пример: _productConnection.Update(product);
        }
    }
}
