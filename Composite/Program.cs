using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee alikaan = new Employee() { Name = "Ali Kaan", Title = "Senior Software Engineer" };

            Employee merve = new Employee() { Name = "Merve", Title = "Junior Software Developer" };
            
            Employee duru = new Employee { Name = "Duru", Title = "Inter Developer" };            

            Employee ender = new Employee { Name = "Ender", Title = "Inter Developer" };

            Contractor yesim = new Contractor { Name = "Yesim", Title = "Outsource Person" };
            duru.AddSubordinate(yesim);            
            
            alikaan.AddSubordinate(merve);
            alikaan.AddSubordinate(duru);
            merve.AddSubordinate(ender);

            Console.WriteLine("{0} - {1}", alikaan.Name, alikaan.Title);
            foreach (Employee manager in alikaan)
            {
                Console.WriteLine("  {0} - {1}", manager.Name, manager.Title);
                foreach (IPerson employee in manager)
                {
                    Console.WriteLine("    {0} - {1}", employee.Name, employee.Title);
                }
            }
            Console.ReadLine();
        }
    }

    interface IPerson
    {
        string Name { get; set; }
        string Title { get; set; }
    }

    class Contractor : IPerson
    {
        public string Name { get; set; }
        public string Title { get; set; }
    }

    class Employee : IPerson, IEnumerable<IPerson>
    {
        List<IPerson> _subordinates = new List<IPerson>();

        public void AddSubordinate(IPerson person)
        {
            _subordinates.Add(person);
        }

        public void RemoveSubordinate(IPerson person)
        {
            _subordinates.Remove(person);
        }

        public IPerson GetSubordinate(int index)
        {
            return _subordinates[index];
        }
        public string Name { get; set; }
        public string Title { get; set ; }

        public IEnumerator<IPerson> GetEnumerator()
        {
            foreach (var subordinate in _subordinates)
            {
                yield return subordinate;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
