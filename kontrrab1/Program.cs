using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kontrrab1
{ //2
    public interface ICloneable
    {
        object Clone();
    }
    class Car:ICloneable
    {
        public int Volume
        {
            get; set;
        }
        public string Color
        {
            get; set;
        }
        public string Model
        {
            get; set;
        }
        public int Number
        {
            get; set;
        }
        public object Clone()
        {
            return new Car { Volume = this.Volume, Color = this.Color, Model = this.Model, Number = this.Number };
        }
        public static Car operator *(Car c1, Car c2)
        {
            return new Car { Volume = c1.Volume * c2.Volume };
        }
    }
    class SuperCar : Car
    {
        public virtual void go()
        {
            Console.WriteLine("SuperCar GO");
        }

    }
    class VipCar : SuperCar
    {
        public override void go()
        {
            Console.WriteLine("VipCar GO");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //1a упаковка распаковка
            int i = 123;
            object o = (object)i;

            //1б  двумерный массив инт инициализация и кол эл
            int[,] num = { { 1, 2, 3 }, { 4, 5, 6 } };
            Console.WriteLine(num.GetLength(0) + " " + num.GetLength(1));
           
            //2
            Car c1 = new Car{ Volume = 210, Color = "red", Model = "ferary", Number = 505 };
            Car c2 = (Car)c1.Clone();
            c2.Color = "green";
            c2.Volume = 55;
            Car c3 = (Car)c1.Clone();
            c3.Color = "pink";
            Console.WriteLine(c1.Color);
            Console.WriteLine(c2.Color);
            Console.WriteLine(c3.Color);
            c3 = c1 * c2;
            Console.WriteLine(c3.Volume);

            //3
            Car car = new Car();
            VipCar vipCar = new VipCar();
            SuperCar superCar = new SuperCar();
            object[] obj = { car, vipCar, superCar };
            foreach (Car c in obj)
            {
                if (c is VipCar)
                {
                    (c as VipCar).go();
                }
            }
            Console.ReadKey();
        }
    }
}
