using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            var personalCar = new PersonalCar { Make = "Hyundai", Model = "i20", HirePrice = 2100 };

            SpecialOffer specialOffer = new SpecialOffer(personalCar);
            specialOffer.DiscountPercantage = 10;


            Console.WriteLine("Concrete : {0}", personalCar.HirePrice);
            Console.WriteLine("Special offer : {0}", specialOffer.HirePrice);

            Console.ReadLine();
        }
    }

    abstract class CarBase
    {
        public abstract string Make { get; set; }
        public abstract string Model { get; set; }
        public abstract decimal HirePrice { get; set; }
    }

    class PersonalCar : CarBase
    {
        public override string Make { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice { get; set; }
    }

    class CommerialCar : CarBase
    {
        public override string Make { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice { get; set; }
    }

    abstract class CarDecoratorBase : CarBase
    {
        private CarBase _carbase;

        protected CarDecoratorBase(CarBase carBase)
        {
            _carbase = carBase;
        }
    }

    class SpecialOffer : CarDecoratorBase
    {
        public int DiscountPercantage { get; set; }
        private readonly CarBase _carBase;

        public SpecialOffer(CarBase carBase) : base(carBase)
        {
            _carBase = carBase;
        }

        public override string Make { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice {

            get {   return _carBase.HirePrice  - (_carBase.HirePrice * DiscountPercantage/100); }            
            set
            {   
            } 
        }
    }
    class RamazanOffer : CarDecoratorBase
    {

        public int DiscountPercantage { get; set; }

        private readonly CarBase _carBase;
        public RamazanOffer(CarBase carBase) : base(carBase)
        {
            _carBase = carBase;
        }

        public override string Make { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice { 
            get {   return _carBase.HirePrice - (_carBase.HirePrice * DiscountPercantage / 100); }
            set 
            {
            } 
        }
    }


}
