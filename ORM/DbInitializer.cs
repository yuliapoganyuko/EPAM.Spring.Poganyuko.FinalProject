using System.Data.Entity;
using System.Web.Helpers;
using ORM.Entities;

namespace ORM
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<EntityModel>
    {
        protected override void Seed(EntityModel context)
        {
            var commonUserRole = new Role
            {
                Name = "User"
            };
            var adminRole = new Role
            {
                Name = "Admin"
            };
            context.Roles.Add(commonUserRole);
            context.Roles.Add(adminRole);
            context.SaveChanges();

            var user1 = new User
            {
                Email = "yulia.poganyuko@gmail.com",
                Password = Crypto.HashPassword("qwerty"),
                Role = adminRole,
                Login = "Admin"
            };
            var user2 = new User
            {
                Email = "yulia.poganyuko@yandex.ru",
                Password = Crypto.HashPassword("qwerty"),
                Role = commonUserRole,
                Login = "Poganyuko"
            };

            context.Users.Add(user1);
            context.Users.Add(user2);
            context.SaveChanges();

            var personalPage1 = new PersonalPage
            {
                User = user1
            };
            var personalPage2 = new PersonalPage
            {
                User = user2
            };
            context.PersonalPages.Add(personalPage1);
            context.PersonalPages.Add(personalPage2);
            context.SaveChanges();
        }

        //private void InitializeRoles(EntityModel context)
        //{
        //    var commonUserRole = new Role
        //    {
        //        Name = "User"
        //    };
        //    var adminRole = new Role
        //    {
        //        Name = "Admin"
        //    };
        //    context.Roles.Add(commonUserRole);
        //    context.Roles.Add(adminRole);
        //    context.SaveChanges();
        //}
    }
}
