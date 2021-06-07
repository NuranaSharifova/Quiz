using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Quiz
{


   public class Program
    {
       
        static void Main(string[] args)
        {


          
            while (true)
            {
               
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Press 1 in order to Login\nPress 2 Create account\n");
                int choose = Int32.Parse(Console.ReadLine());
 
                Mainapp a = new Mainapp();
                
                a.LoadUsers();
                switch (choose)
                {
                    case 1:
                        Console.Clear();
                        a.ShowLoginMenu();
        
                     break;
                    case 2:
                        Console.Clear();
                        a.ShowRegisterMenu();
     
                        break;
               
                    default:
                        break;

                }
               a.SaveChanges();
               
            }



        }




    }
}
