using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            _userConnection.CreateTable<Fuel>();
            _userConnection.CreateTable<Service>();
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
        public bool RegistrateUser(string login, string password, bool isClient)
        {
            var user = GetUser(login);
            if (user != null)
            {
                return false;
            }
            else
            {
                CreateUser(new User { PhoneNumber = login, Password = password, IsClient = isClient });
                return true;
            }
        }
        public Fuel[] GetFuelArray()
        {
            return _productConnection.Table<Fuel>().ToList().ToArray();
        }
        public Service[] GetServiceArray()
        {
            return _productConnection.Table<Service>().ToList().ToArray();
        }
    }
}
