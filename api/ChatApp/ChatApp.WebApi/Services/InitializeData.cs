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
                new User(){Id=0,Username="MikeRoss",FirstName="Mike",LastName="Ross",Email="MikeRoss@gmail.com"},
                new User(){Id=1,Username="LouisLitt",FirstName="Louis",LastName="Litt",Email="LouisLitt@gmail.com"},
                new User(){Id=2,Username="HarveySpecter",FirstName="Harvey",LastName="Specter",Email="HarveySpecter@gmail.com"},
                new User(){Id=3,Username="RachelZane",FirstName="Rachel",LastName="Zane",Email="RachelZane@gmail.com"},
                new User(){Id=4,Username="DonnaPaulsen",FirstName="Donna",LastName="Paulsen",Email="DonnaPaulsen@gmail.com"},
                new User(){Id=5,Username="JessicaPearson",FirstName="Jessica",LastName="Pearson",Email="JessicaPearson@gmail.com"},
                new User(){Id=6,Username="HaroldGunderson",FirstName="Harold",LastName="Gunderson",Email="HaroldGunderson@gmail.com"},
                new User(){Id=7,Username="DanielHardman",FirstName="Daniel",LastName="Hardman",Email="DanielHardman@gmail.com"},
                new User(){Id=8,Username="KatrinaBennett",FirstName="Katrina",LastName="Bennett",Email="KatrinaBennett@gmail.com"},
                new User(){Id=9,Username="CharlesForstman",FirstName="Charles",LastName="Forstman",Email="CharlesForstman@gmail.com"},
                new User(){Id=10,Username="JonathanSidwell",FirstName="Jonathan",LastName="Sidwell",Email="JonathanSidwell@gmail.com"}
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
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

    }
}
