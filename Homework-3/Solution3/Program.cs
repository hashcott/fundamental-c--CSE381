using System;
using System.Text;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Car car = new Car();
            Ship ship = new Ship();
            Airplane airplane = new Airplane();
            string action = "y";
            while (action == "y")
            {
                Console.WriteLine("Chọn phương tiện giao thông bạn muốn đi: ");
                Console.WriteLine("1. Ô Tô");
                Console.WriteLine("2. Thuyền");
                Console.WriteLine("3. Máy bay");
                string option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        car.dichuyen();
                        break;

                    case "2":
                        ship.dichuyen();
                        break;

                    case "3":
                        airplane.dichuyen();
                        break;

                }
                Console.WriteLine("Bạn muốn chọn tiếp tục (y/n): ");
                action = Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
