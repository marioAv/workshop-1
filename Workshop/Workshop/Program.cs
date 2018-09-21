using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop
{
    public class BusinessLogic
    {
        public int Sum(int num1, int num2)
        {
            int total = 0;
            total = num1 + num2;
            return total;
        }

    }
    public class Repository
    {
        workshopEntities _context;

        public Repository()
        {

        }

        public void RegisterUser()
        {
            _context = new workshopEntities();
            user user = new user();
            var u = _context.users.ToList();

            user.Id = u.Count();

            Console.WriteLine("Please Enter Name:");
            user.FirstName = Console.ReadLine();

            Console.WriteLine("Please Enter Last Name:");
            user.LastName = Console.ReadLine();

            Console.WriteLine("Please Enter Position:");
            user.Position = Console.ReadLine();

            _context.users.Add(user);
            _context.SaveChanges();

            Console.WriteLine("Your Changes have been changed");
            Console.WriteLine("");
            }

        public List<user> GetAllUsers()
        {
            _context = new workshopEntities();
            return _context.users.ToList();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Repository _rep = new Repository();
            BusinessLogic _bl = new BusinessLogic();

            string options = "";
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("MENU");
            Console.WriteLine("1. Register a user");
            Console.WriteLine("2. Sum two numbers");
            Console.WriteLine("3. See registered users");
            Console.WriteLine("");
            Console.WriteLine("Please select an option:");
            options = Console.ReadLine();
            int option = Convert.ToInt32(options);

            switch (option)
            {
                case 1:
                    _rep.RegisterUser();
                    Console.WriteLine("Press enter to continue");
                    Console.ReadLine();
                    break;
                case 2:
                    Console.WriteLine("Please enter the first number:");
                    int num1 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Please enter the ssecond number:");
                    int num2 = Convert.ToInt32(Console.ReadLine());
                    int total=_bl.Sum(num1, num2);
                    Console.WriteLine("Result {0}", total);
                    Console.WriteLine("Press enter to continue");
                    Console.ReadLine();
                    break;

                case 3:
                    var users = _rep.GetAllUsers();
                    foreach(var user in users)
                    {
                        Console.WriteLine("Result {0} {1}", user.FirstName, user.LastName);
                        Console.WriteLine("Result {0}", user.Position);
                        Console.WriteLine("");
                        Console.WriteLine("Press enter to continue");
                        Console.ReadLine();
                    }
                    break;
                default:
                    Console.WriteLine("Please select a valid option");
                    break;
            }
        }
    }
}
