using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Test.EventScheduler.DataAccess.Models;

namespace Test.EventScheduler.DataAccess.Extensions
{
    public static class UserExtensions
    {
        public static IQueryable<User> GetActiveUsers(this IQueryable<User> users)
        {
            return users
                .Where(u => !u.IsDeleted);
        }

        public static IQueryable<User> GetActiveUserById(this IQueryable<User> users, int userId)
        {
            return users
                .GetActiveUsers()
                .Where(u => u.UserId == userId);
        }

        public static IQueryable<User> GetActiveUserByEmail(this IQueryable<User> users, string email)
        {
            return users
                .GetActiveUsers()
                .Where(u => u.Email == email);
        }
    }
}
