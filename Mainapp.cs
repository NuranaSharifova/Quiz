using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quiz
{
    public class Mainapp
    {
        private static Quiz Quiz;
       
        private UserXml Data;
        public User CurrentUser = null;
        
        public Mainapp()
        {
            Data = new UserXml();
           
        }
        public void LoadUsers() {

            if (File.Exists("userList.xml"))
                Data.Read();
           
        }
        public void  SaveChanges(){
         
            Data.Write();

        }
        public void ShowLoginMenu()
        {
            string login, password;
        
                Console.Write("Enter login: ");
                login = Console.ReadLine();
                Console.Write("Enter password: ");
                password = Console.ReadLine();
                if (TryLogin(login, password))
                {
                    Appmenu();
                   
                }
                else
                {
                    Console.WriteLine("Wrong password");
                  
                }
           

        }
        public void ShowRegisterMenu()
        {

            User newUser = new User();
            while (true)
            {
                newUser.Register();
                if (!TryReg(newUser.Login))
                {
                    Console.WriteLine("There is already such login name");
                }
                else
                    break;

            }

            Data.AddUser(newUser);
            Data.Write();


        }
       
        private bool TryReg(string login)
        {
            User user=Data.Users.Find(u => u.Login == login);

            if (user == null)
            {
               
                return true; }
            else
            {

                return false;
            }
        }
        private bool TryLogin(string login, string password)
        {
            User user = Data.Users.Find(u => u.Login == login && u.Password == password);
            if (user == null)
            {
              
                return false;
            }
            else
            {
             
                CurrentUser = user;
                return true;
            }

        }
        public void Appmenu() {

            Console.Clear();
            Quiz = new Quiz(CurrentUser);
         
                Console.WriteLine("Press 1 to start quiz\nPress 2 to see previous results\nPress 3 to see Top Results\nPress 4 to change settings\nPress 5 to add tests\n");
                int choose = Int32.Parse(Console.ReadLine());
                switch (choose)
                {
                    case 1:
                        Quiz.QuizMenu();
                        break;
                    case 2:
                        CurrentUser.UserResults();
                        break;
                    case 3:
                        TopResults();
                        break;
                    case 4:
                        CurrentUser.UserSettings();
                        break;
                    case 5:
                        Quiz.AddTest();
                    break;
                case 6:
                    default:
                        break;
                }  
          
        }
        public void TopResults()
        {
            
            int count = 0;
            foreach (User user in Data.Users)
            {
                Console.WriteLine($"{count + 1}--{user.Login}");
                foreach (var item in user.Scores)
                {
                    Console.WriteLine($"-{item}");
                }

                count++;
            }
        }


    }
} 
  
