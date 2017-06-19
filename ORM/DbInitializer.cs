using System.Data.Entity;
using System.Web.Helpers;
using ORM.Entities;

namespace ORM
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<EntityModel>
    {
        protected override void Seed(EntityModel context)
        {
            var commonUserRole = AddRole("User");
            var adminRole = AddRole("Admin");
            context.Roles.Add(commonUserRole);
            context.Roles.Add(adminRole);
            context.SaveChanges();

            var user1 = AddUser("yulia.poganyuko@gmail.com", "Admin", Crypto.HashPassword("qwerty"), adminRole);
            var user2 = AddUser("yulia.poganyuko@yandex.ru", "Poganyuko", Crypto.HashPassword("qwerty"), commonUserRole);
            context.Users.Add(user1);
            context.Users.Add(user2);
            context.SaveChanges();

            var personalPage1 = AddProfile(user1);
            var personalPage2 = AddProfile(user2);
            context.PersonalPages.Add(personalPage1);
            context.PersonalPages.Add(personalPage2);
            context.SaveChanges();
        }

        private Role AddRole(string name)
        {
            return new Role
            {
                Name = name
            };
        }

        private User AddUser(string email, string login, string password, Role role)
        {
            return new User
            {
                Email = email,
                Login = login,
                Password = Crypto.HashPassword(password),
                Role = role,
            };
        }

        private Profile AddProfile(User user)
        {
            return new Profile
            {
                User = user
            };
        }
    }
}
