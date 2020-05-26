using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            Mediator mediator = new Mediator();

            Teacher alikaan = new Teacher(mediator)
            {
                Name = "Ali Kaan"
            };

            mediator.Teacher = alikaan;

            Student kivanc = new Student(mediator)
            {
                Name = "Kıvanç"
            };

            Student merve = new Student(mediator)
            {
                Name = "Merve"
            };
            

            mediator.Students = new List<Student> { merve, kivanc };

            alikaan.SendNewImageUrl("slide1.jpg");

            merve.SendQuestion("is it true?");

            alikaan.AnswerQuestion("yes, it is true.", merve);

            Console.ReadLine();

        }
    }

    abstract class CourseMember
    {
        protected Mediator Mediator;
        public string Name { get; set; }

        protected CourseMember(Mediator mediator)
        {
            Mediator = mediator;
        }
    }

    class Teacher : CourseMember
    {
        public Teacher(Mediator mediator) : base(mediator)
        {
        }

        public void ReceiveQuestion(string question, Student student)
        {
            Console.WriteLine("Teacher received a question from {0}, {1}", student.Name, question);
        }

        public void SendNewImageUrl(string url)
        {
            Console.WriteLine("Teacher changed slide : {0}", url);
            Mediator.UpdateImage(url);
        }

        public void AnswerQuestion(string answer, Student student)
        {
            Console.WriteLine("Teacher asnwer to {0}, {1}", student.Name, answer);
            Mediator.SendAnswer(answer, student);
        }
    }

    class Student : CourseMember
    {
        public Student(Mediator mediator) : base(mediator)
        {
        }        

        public void ReceiveImage(string url)
        {
            Console.WriteLine("{1} received image : {0},",url, this.Name);
        }

        public void ReceiveAnswer(string answer)
        {
            Console.WriteLine("{1} received answer : {0}", answer, this.Name);
        }
        public void SendQuestion(string question)
        {
            Console.WriteLine("{1} sent question : {0}", question, this.Name);
            Mediator.SendQuestion(question, this);
        }
    }

    class Mediator
    {
        public Teacher Teacher { get; set; }
        public List<Student> Students { get; set; }

        public void UpdateImage(string url)
        {
            foreach (var student in Students)
            {
                student.ReceiveImage(url);
            }
        }

        public void SendQuestion(string question, Student student)
        {
            Teacher.ReceiveQuestion(question, student);
        }

        public void SendAnswer(string answer, Student student)
        {
            student.ReceiveAnswer(answer);
        }

    }
}
