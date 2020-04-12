using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            var customerManager = CustomManager.CreateAsSingleton();            
            customerManager.Save();

            customerManager = CustomManager.CreateAsSingleton();            
            customerManager.Save();

            Console.ReadLine();
        }
    }
    
    class CustomManager
    {
        private static CustomManager _customManager;    // define as static to make it singleton
        static object _lockObject = new object();
        private CustomManager()     // private constructer, so can't new this 
        {

        }

        public static CustomManager CreateAsSingleton()
        {            
            lock(_lockObject)
            {
                if(_customManager == null)
                {
                    _customManager = new CustomManager();
                }
            }
            return _customManager;
        }

        public void Save()
        {
            Console.WriteLine("Saved");
        }
    }

}
