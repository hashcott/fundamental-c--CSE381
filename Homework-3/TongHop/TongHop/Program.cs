
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TongHop
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            string action = "y";
            List<Canbo> canbos = new List<Canbo>();

            while (action == "y")
            {
                Console.WriteLine("Nhập thông tin về cán bộ : ");
                Canbo canbo = new Canbo();
                canbo.input();
                canbos.Add(canbo);

                Console.WriteLine("Bạn muốn nhập tiếp (y/n) : ");
                action = Console.ReadLine();
                Console.Clear();
            }
            Console.WriteLine("MaCB \t Họ Tên \t Giới tính \t Quê Quán \t Ngày sinh \t Hình thức di chuyển đến công ty");
            foreach (Canbo cb in canbos)
            {
                cb.output();
            }
        }
    }
}
