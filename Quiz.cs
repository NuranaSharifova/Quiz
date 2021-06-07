using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quiz
{
    class Quiz
    {
        User Gameuser;
        TestXml MyTests = null;
       
        public Quiz(User gameuser)
        {
            Gameuser = gameuser;
            MyTests = new TestXml();
        }
        public void LoadTest()
        {

            if (File.Exists("TestList.xml"))
                MyTests.Read();
        }

        public void SaveTest()
        {

            MyTests.Write();
        }
        public void QuizMenu() {

            Console.Clear();
            Console.WriteLine("Choose one of the below listed categories\nHistory\nBiology\nGeography\nMixed");
            string category = Console.ReadLine();
            StartGame(category);

        }

        public void StartGame(string category) {

            int correct = 0;
            int question_count = 0;
            string input = "";
            int choice = 0;
            MyTests.Read();

            Console.Clear();

            Console.WriteLine("Question 1");

            foreach (var item in MyTests.Categ)
            {
                foreach (var inner in item.Tests)
                {
                    foreach (var item2 in inner.Questions)
                    {
                        if (inner.CategorName == category&&category!="Mixed")
                        {
                            Console.WriteLine($"{question_count + 1}.{item2.NQuestion}");

                            for (int i = 0; i < item2.Answers.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}----{item2.Answers[i].Variant}");
                            }

                            Console.WriteLine("Enter you answer");
                            input = Console.ReadLine();
                            choice = Convert.ToInt32(input);

                            if (item2.Answers[choice - 1].Correct)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("True Answer");
                                correct++;
                            }
                            else
                            {

                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Wrong Answer");
                            }
                            Console.ResetColor();
                            question_count++;
                        }
                        if (category == "Mixed") {

                            Console.WriteLine($"{question_count + 1}.{item2.NQuestion}");

                            for (int i = 0; i < item2.Answers.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}----{item2.Answers[i].Variant}");
                            }

                            Console.WriteLine("Enter you answer");
                            input = Console.ReadLine();
                            choice = Convert.ToInt32(input);

                            if (item2.Answers[choice - 1].Correct)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("True Answer");
                                correct++;
                            }
                            else
                            {

                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Wrong Answer");
                            }
                            Console.ResetColor();
                            question_count++;



                        }
                    }

                   

                }
             
            }
            string result ="Result for " + category +" category is "+ Convert.ToString(correct);
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            MessageBox.Show($"Quiz is over\nYour result is   {correct} ");
           
            Gameuser.Scores.Add(result);
            Thread.Sleep(1000);
            Console.ResetColor();  
            }

        public void AddTest()
        {
            LoadTest();
          
            Console.WriteLine("Enter Category Name");
            string input = Console.ReadLine();
          
           Category c = MyTests.Categ.Find(t=> t.Text== input);
            
            if (c== null)
            {
                Console.WriteLine("There is no such category,Add?Y/N");
                string enter = Console.ReadLine();
                if (enter == "Y")
                {

                    Console.Clear();
                }
                else {
                    Environment.Exit(0);
                }
            }
          
                Category categ = new Category(input);
                categ.Add(input);

                MyTests.AddNew(categ);
                MyTests.Write();

          

           
        }
    
      
    }
}