using BLL.Interface.Entities;
using BLL.Interface.Services;
using DependencyResolver;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePL
{
    class Program
    {
        private static readonly IKernel resolver;
        private static IUserService userService;
        private static IProfileService profileService;
        private static IRoleService roleService;
        private static IPhotoService _photoService;

        static Program()
        {
            resolver = new StandardKernel();
            resolver.ConfigurateResolverConsole();

        }

        static void Main(string[] args)
        {
            userService = resolver.Get<IUserService>();
            profileService = resolver.Get<IProfileService>();
            roleService = resolver.Get<IRoleService>();
            _photoService = resolver.Get<IPhotoService>();

            Start();
        }

        static void Start()
        {
            while (true)
            {
                Console.WriteLine(" Press 1 to log in or 2 to register");
                switch (Console.ReadLine())
                {
                    case "1":
                        {
                            Login();
                            break;
                        }
                    case "2":
                        {
                            Register();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("\nSomething went wrong\n");
                            break;
                        }
                }
            }
        }

        static void Login()
        {
            bool guest = true;
            do
            {
                Console.WriteLine("Enter login");
                var login = Console.ReadLine();
                Console.WriteLine("Enter password");
                var password = Console.ReadLine();

                var user = userService.GetByPredicate(u => u.Login == login);

                if ((user != null) && (VerifyHashedPassword(user.Password, password)))
                {
                    Console.WriteLine("\nYou are autorized.\n");
                    guest = false;
                }
                else
                {
                    Console.WriteLine("\nWrong login or password\n");
                }
            } while (guest);

        }

        static void Register()
        {
            string login, email, password;
            bool notvalid = true;
            do
            {
                Console.WriteLine("Enter login");
                login = Console.ReadLine();
                Console.WriteLine("Enter email");
                email = Console.ReadLine();
                var notconfirm = true;

                do
                {
                    Console.WriteLine("Enter password");
                    password = Console.ReadLine();
                    Console.WriteLine("Confirm password");
                    var confirmPassword = Console.ReadLine();
                    if (password == confirmPassword)
                    {
                        notconfirm = false;
                    }
                    else
                    {
                        Console.WriteLine("Passwords are diffetent");
                    }
                } while (notconfirm);

                notvalid = false;

                var membershipUser = userService.GetByPredicate(u => u.Login == login);

                if (membershipUser != null)
                {
                    Console.WriteLine("User with this login is exist");
                    notvalid = true;
                }

                var sameEmailUser = userService.GetByPredicate(u => u.Email == email);

                if (sameEmailUser != null)
                {
                    Console.WriteLine("User with this email is exist");
                    notvalid = true;
                }
            } while (notvalid);

            userService.Create(new BllUser()
            {
                Email = email,
                Login = login,
                Password = HashPassword(password),
                RoleId = roleService.GetByPredicate(role => role.Name == "User").Id
            }); ;

            var user = userService.GetByPredicate(u => u.Login == login);
            profileService.Create(new BllProfile()
            {
                Id = user.Id
            });

        }
        
        public static string HashPassword(string password)
        {
            if (password == null)
                throw new ArgumentNullException("password");
            byte[] salt;
            byte[] bytes;
            using (Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, 16, 1000))
            {
                salt = rfc2898DeriveBytes.Salt;
                bytes = rfc2898DeriveBytes.GetBytes(32);
            }
            byte[] inArray = new byte[49];
            Buffer.BlockCopy((Array)salt, 0, (Array)inArray, 1, 16);
            Buffer.BlockCopy((Array)bytes, 0, (Array)inArray, 17, 32);
            return Convert.ToBase64String(inArray);
        }

        public static bool VerifyHashedPassword(string hashedPassword, string password)
        {
            if (hashedPassword == null)
                throw new ArgumentNullException("hashedPassword");
            if (password == null)
                throw new ArgumentNullException("password");
            byte[] numArray = Convert.FromBase64String(hashedPassword);
            if (numArray.Length != 49 || (int)numArray[0] != 0)
                return false;
            byte[] salt = new byte[16];
            Buffer.BlockCopy((Array)numArray, 1, (Array)salt, 0, 16);
            byte[] a = new byte[32];
            Buffer.BlockCopy((Array)numArray, 17, (Array)a, 0, 32);
            byte[] bytes;
            using (Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, salt, 1000))
                bytes = rfc2898DeriveBytes.GetBytes(32);
            return ByteArraysEqual(a, bytes);
        }

        private static bool ByteArraysEqual(byte[] a, byte[] b)
        {
            if (ReferenceEquals(a, b))
                return true;
            if (a == null || b == null || a.Length != b.Length)
                return false;
            bool flag = true;
            for (int index = 0; index < a.Length; ++index)
                flag &= (int)a[index] == (int)b[index];
            return flag;
        }
    }
}
