using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    public class Answer
    {
        public string Variant { get; set; }
        public bool Correct { get; set; }
    }
    public class Question
    {
        public string NQuestion   { get; set; }
        public List<Answer> Answers { get; set; }
        public Question()
        {

        }
        public Question(string text)
        {
            NQuestion = text;
            Answers = new List<Answer>();

        }

    }
    public class Tests 
    {
        
        public string CategorName { get; set; }
        public List<Question> Questions { get; set; }
        public Tests()
        {

        }
        public Tests(string name)
        {
            CategorName = name;
            Questions = new List<Question>();
        }
       
        public void Add()
        {
            Console.WriteLine("Enter new question:");
            string input = Console.ReadLine();
            Question  question= new Question(input);
         
            for (int i = 0; i < 4; i++)
            {
                Answer answer= new Answer();
                answer.Variant = Console.ReadLine();
               
                Console.WriteLine("Is it true answer? Y/N");
                string choice = Console.ReadLine();
                if (choice == "Y")
                {
                    answer.Correct = true;
                }
                else {
                    answer.Correct = false;
                }
                question.Answers.Add(answer);
            }
            Questions.Add(question);
           
        }

      
    }
    public class Category
    {

        public string Text { get; set; }
        public List<Tests> Tests { get; set; }
        public Category()
        {

        }
        public Category(string name)
        {
            Text = name;
            Tests = new List<Tests>();
        }

        public void Add(string input)
        {

            Tests t = new Tests(input);
            t.Add();
            Tests.Add(t);
        }

     


    }

}
