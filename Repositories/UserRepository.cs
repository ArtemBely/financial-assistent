using FinancialAssistent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialAssistent.Repositories
{
    // Repositories/UserRepository.cs
    public class UserRepository : IUserRepository
    {
        public void AddUser(User user)
        {
            // Здесь будет логика добавления пользователя в базу данных SQLite
        }

        public User GetUserByEmail(string email)
        {
            // Здесь будет логика получения пользователя по электронной почте из SQLite
            return new User(); // Пример
        }

        public bool VerifyUserCredentials(string email, string passwordHash)
        {
            throw new NotImplementedException();
        }
    }

}
