using System;
using System.Text;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Meo meo = new Meo();
            Cho cho = new Cho();
            Vit vit = new Vit();
            string action = "y";
            while(action == "y")
            {
                Console.WriteLine("Chọn con vật mà bạn yêu thích: ");
                Console.WriteLine("1. Mèo");
                Console.WriteLine("2. Chó");
                Console.WriteLine("3. Vịt");
                string option = Console.ReadLine();
                switch(option)
                {
                    case "1":
                        meo.dichuyen();
                        meo.an();
                        meo.tieng();
                        break;

                    case "2":
                        cho.dichuyen();
                        cho.an();
                        cho.tieng();
                        break;

                    case "3":
                        vit.dichuyen();
                        vit.an();
                        vit.tieng();
                        break;

                }
                Console.WriteLine("Bạn muốn chọn tiếp tục (y/n): ");
                action = Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
