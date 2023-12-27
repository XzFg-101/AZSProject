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
    public static class DataBaseService
    {
        private static SQLiteConnection _userConnection;
        private static SQLiteConnection _productConnection;
        private static string _userConnectionRoute = "UserData.db";
        private static string _productConnectionRoute = "ProductData.db";

        private static void InitalizeConnections()
        {
            //Надо закрыть свзяи воизбежании ошибок
            _userConnection?.Close();
            _productConnection?.Close();

            _userConnection = new SQLiteConnection(_userConnectionRoute);
            _userConnection.CreateTable<User>();
            _productConnection = new SQLite.SQLiteConnection(_productConnectionRoute);
            _productConnection.CreateTable<Fuel>();
            _productConnection.CreateTable<Service>();
        }
        private static void CloseConnections()
        {
            _userConnection.Close();
            _productConnection.Close();
        }

        public static void SetCustomConnectionsRoutes(string customUserConnectionRoute, string customProductConnectionRoute)
        {
            _userConnectionRoute = customUserConnectionRoute;
            _productConnectionRoute = customProductConnectionRoute;
        }
        
        public static void CreateUser(User user)
        {
            InitalizeConnections();
            _userConnection.Insert(user);
            CloseConnections();
        }
        public static User GetUser(string phoneNumber)
        {
            InitalizeConnections();
            var result = _userConnection.Table<User>().FirstOrDefault(u => u.PhoneNumber == phoneNumber);
            CloseConnections();
            return result;
            
        }
        /// <summary>
        /// Проверяет на возможность входа  
        /// </summary>
        /// <param name="login">Логин</param>
        /// <param name="password">Пароль</param>
        /// <returns>User если вход успешный, Null если нет</returns>
        public static User LoginUser(string login, string password)
        {
            InitalizeConnections();
            var user = _userConnection.Table<User>().FirstOrDefault(u => u.PhoneNumber == login);
            if (user != null)
            {
                if (password == user.Password) return user;
                else
                {
                    CloseConnections();
                    return null;
                }
            }
            else
            {
                CloseConnections();
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
        public static bool RegistrateUser(string login, string password)
        {
            var user = GetUser(login);
            InitalizeConnections();
            if (user != null)
            {
                CloseConnections();
                return false;
            }
            else
            {
                CreateUser(new User { PhoneNumber = login, Password = password, IsClient = true });
                CloseConnections();
                return true;
            }
        }
        public static IProduct[] GetProductByType(Type type)
        {
            InitalizeConnections();
            if (type == typeof(Fuel))
            {
                var result = _productConnection.Table<Fuel>().ToArray();
                CloseConnections();
                return result;
            }
            else if (type == typeof(Service))
            {
                var result = _productConnection.Table<Service>().ToArray();
                CloseConnections();
                return result;
            }
            else
            {
                CloseConnections();
                return new IProduct[0];
            }
        }
        public static void AddProduct(IProduct product)
        {
            InitalizeConnections();
            if (product is Fuel)
            {
                _productConnection.Insert((Fuel)product);
            }
            else if (product is Service)
            {
                _productConnection.Insert((Service)product);
            }
            CloseConnections();
        }
        public static void UpdateProduct(IProduct product)
        {
            InitalizeConnections();
            if (product is Fuel)
            {
                _productConnection.Update(product);
            }
            else if (product is Service)
            {
                _productConnection.Update(product);
            }
            CloseConnections();
        }
    }
}
