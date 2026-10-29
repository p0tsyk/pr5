using pr5.Models;
using PasswordSecurity;
using System;
using System.Linq;
using System.Text;

namespace pr5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Helper dataHelper = new Helper();
            PasswordHasher passwordHasher = new PasswordHasher();

            Console.WriteLine("Создание новой учетной записи для пользователя");
            Console.Write("Введите имя пользователя: ");
            string firstName = Console.ReadLine();
            Console.Write("Введите фамилию пользователя: ");
            string lastName = Console.ReadLine();
            Console.Write("Введите логин пользователя: ");
            string login = Console.ReadLine();
            Console.Write("Введите пароль пользователя: ");
            string password = Console.ReadLine();
            Console.Write("Введите телефон пользователя: ");
            string phone = Console.ReadLine();
            Console.Write("Введите адрес пользователя: ");
            string address = Console.ReadLine();

            var context = Helper.GetContext();
            if (context.user_account.Any(account => account.login == login))
            {
                Console.WriteLine("Ошибка: такой логин уже зарегистрирован");
                Console.ReadKey();
                return;
            }

            string passwordHash = passwordHasher.GetPasswordHash(password);
            Console.WriteLine("Хешированный пароль пользователя: " + passwordHash);

            var newAccount = new user_account { login = login, password_hash = passwordHash };
            context.user_account.Add(newAccount);
            context.SaveChanges();

            var newClient = new client
            {
                first_name = firstName,
                last_name = lastName,
                phone = phone,
                address = address,
                user_id = newAccount.user_id
            };
            dataHelper.CreateClient(newClient);

            Console.WriteLine("Учетная запись добавлена");
            Console.ReadKey();
        }
    }
}