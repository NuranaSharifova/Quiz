using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
   

    public class User
    {

        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime Birthday { get; set; }
        public List<int> Scores{ get; set ; }

        public void Register()  
        {
            Console.WriteLine("Enter Username");
            this.Login = Console.ReadLine();
            Console.WriteLine("Enter Password");
            this.Password = Console.ReadLine();
            Console.WriteLine("Enter Birthday");
            this.Birthday = Convert.ToDateTime(Console.ReadLine());
        }
        public void UserSettings() {

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine("SETTINGS");
            Console.WriteLine("Press 1 to change password\nPress 2 to change birhdate ");
   
            int choose = Convert.ToInt32(Console.ReadLine());
            switch (choose)
            {
                case 1:
                    ChangePassword();
                    break;
                case 2:
                    ChangeBirthday();
                    break;
                default:
                    break;
            }

        }
        public void ChangePassword() {
            Console.WriteLine("Enter new password");
            string password = Console.ReadLine();
            this.Password = password;
          
        }
        public void ChangeBirthday() {
            Console.WriteLine("Enter Birthday");
            DateTime date = Convert.ToDateTime(Console.ReadLine());
            Birthday = date;
        
        }
        public void UserResults()
        {
            Console.WriteLine($"Username_____{this.Login}");
            int count = 0;
            foreach (var item in Scores)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;           
                Console.WriteLine($"{count + 1}________{item}");
                Console.ResetColor();
            }

        }
        public override string ToString()
        {
            return $"Login: {Login} Password:{Password}  Birthday: {Birthday}";
        }


    }
}
