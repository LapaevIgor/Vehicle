using System.Linq;
using Vehicle.Constants.Enums;
using Vehicle.DAL.Entities;

namespace Vehicle.DAL
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Users.Any())
            {
                AddBasicUsers(context);
            }
        }

        public static void AddBasicUsers(AppDbContext context)
        {
            var phoneNumbers1 = new UserPhoneNumberDb[]
                {
                    new UserPhoneNumberDb
                    {
                        PhoneNumber = "+375221111111"
                    },
                    new UserPhoneNumberDb
                    {
                        PhoneNumber = "+375231111111"
                    }
                };

            var phoneNumbers2 = new UserPhoneNumberDb[]
                {
                    new UserPhoneNumberDb
                    {
                        PhoneNumber = "+375291111111"
                    }
                };

            var users = new UserDb[]
            {
                    new UserDb
                    {
                        FirstName = "Ivanna",
                        MiddleName = "Ivanovna",
                        LastName = "Ivanova",
                        Email = "ivanov@example.com",
                        UserPhoneNumbers = phoneNumbers1,
                        Sex = SexEnum.Female
                    },
                    new UserDb
                    {
                        FirstName = "Petr",
                        MiddleName = "Petrovich",
                        LastName = "Petrov",
                        Email = "petrov@example.com",
                        UserPhoneNumbers = phoneNumbers2,
                        Sex = SexEnum.Male
                    }
            };

            foreach (var user in users)
            {
                context.Users.Add(user);
            }

            context.SaveChanges();
        }
    }   
}