using System;
using System.Collections.Generic;
using System.Text;

namespace TongHop
{
    class Canbo
    {
        protected string maCB, hoTen, gioiTinh, ngaySinh, queQuan;
        Transport pt;
        public virtual void input()
        {
            Console.WriteLine("- Nhập thông tin: ");

            Console.WriteLine(" + Mã cán bộ: ");
            this.maCB = Console.ReadLine();

            Console.WriteLine(" + Họ tên: ");
            this.hoTen = Console.ReadLine();

            Console.WriteLine(" + Ngày Sinh: ");
            this.ngaySinh = Console.ReadLine();
            do
            {
                Console.WriteLine(" + Giới Tính (Nam or Nữ): ");
                this.gioiTinh = Console.ReadLine();
                if (gioiTinh == "Nữ" || gioiTinh == "Nam") break;
            } while (true);
            Console.WriteLine(" + Quê quán: ");
            this.queQuan = Console.ReadLine();
            Console.WriteLine(" + Phương tiện đi lại (1. Ô tô , 2. Xe máy, 3. Tàu điện, 4. Đi bộ) : ");
            do
            {
                string key = Console.ReadLine();
                if (key == "1" || key == "2" || key == "3" || key == "4")
                {
                    switch (key)
                    {
                        case "1":
                            pt = new Car();
                            break;
                        case "2":
                            pt = new Motorcycle();
                            break;
                        case "3":
                            pt = new Train();
                            break;
                        case "4":
                            pt = new Walk();
                            break;
                    }
                    break;
                }
            } while (true);

        }
        public virtual void output()
        {
            Console.WriteLine(this.maCB + "\t" + this.hoTen + "\t" + this.gioiTinh + "\t" + this.queQuan + "\t" + this.ngaySinh + "\t" + pt.dichuyen());
        }
    }                                                                                           
}
