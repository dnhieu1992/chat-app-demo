using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApp.WebApi.Services
{
    public static class InitializeData
    {
        public static List<User> GetUsers()
        {
            return new List<User>()
            {
                new User(){Id=0,Name="Mike Ross"},
                new User(){Id=1,Name="Louis Litt"},
                new User(){Id=2,Name="Harvey Specter"},
                new User(){Id=3,Name="Rachel Zane"},
                new User(){Id=4,Name="Donna Paulsen"},
                new User(){Id=5,Name="Jessica Pearson"},
                new User(){Id=6,Name="Harold Gunderson"},
                new User(){Id=7,Name="Daniel Hardman"},
                new User(){Id=8,Name="Katrina Bennett"},
                new User(){Id=9,Name="Charles Forstman"},
                new User(){Id=10,Name="Jonathan Sidwell"}
            };
        }

        public static User GetById(int id)
        {
            return GetUsers().FirstOrDefault(a => a.Id == id);
        }
    }
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
