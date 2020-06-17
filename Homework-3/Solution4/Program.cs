using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            string action = "y";
            List<CANBO> canbos = new List<CANBO>();
            List<SinhVien> SinhViens = new List<SinhVien>();

            while(action == "y")
            {
                string option;
                Console.WriteLine("Nhập thông tin về người : ");
                Console.WriteLine("1. Cán bộ");
                Console.WriteLine("2. Sinh viên");

                option = Console.ReadLine();
                switch(option)
                {
                    case "1":
                        CANBO canbo = new CANBO();
                        canbo.input();
                        canbos.Add(canbo);
                        break;
                    case "2":
                        SinhVien sinhvien = new SinhVien();
                        sinhvien.input();
                        SinhViens.Add(sinhvien);
                        break;
                }
                Console.WriteLine("Bạn muốn nhập tiếp (y/n) : ");
                action = Console.ReadLine();
                Console.Clear();
            }
            Console.WriteLine("Cán bộ sắp xếp theo lương giảm dần: ");
            foreach(CANBO cb in canbos.OrderByDescending(cb=>cb.luong()))
            {
                cb.output();
                cb.dichuyen();
            }

            Console.WriteLine("Sinh viên sắp xếp theo điểm trung bình giảm dần: ");

            foreach (SinhVien sv in SinhViens.OrderByDescending(sv => sv.tb()))
            {
                sv.output();
                sv.dichuyen();
            }
        }
    }
}
