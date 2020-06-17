using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4
{
    class ConNguoi
    {
        protected string hoTen, gioiTinh, queQuan, phuongTien;
        protected int tuoi;
        public ConNguoi() { }
        public ConNguoi(string hoTen, string gioiTinh, int tuoi, string queQuan, string phuongTien)
        {
            this.hoTen = hoTen;
            this.tuoi = tuoi;
            this.gioiTinh = gioiTinh;
            this.queQuan = queQuan;
            this.phuongTien = phuongTien;
        }
        public virtual void input()
        {
            Console.WriteLine("- Nhập thông tin: ");
            Console.WriteLine(" + Họ tên: ");
            this.hoTen = Console.ReadLine();
            Console.WriteLine(" + Tuổi: ");
            this.tuoi = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(" + Giới Tính: ");
            this.gioiTinh = Console.ReadLine();
            Console.WriteLine(" + Quê quán: ");
            this.queQuan = Console.ReadLine();
            Console.WriteLine(" + Phương tiện đi lại: ");
            this.phuongTien = Console.ReadLine();

        }
        public virtual void output()
        {
            Console.WriteLine("- Thông tin: " );
            Console.WriteLine(" + Họ tên: " + this.hoTen);
            Console.WriteLine(" + Tuổi: " + this.tuoi);
            Console.WriteLine(" + Giới Tính: " + this.gioiTinh);
            Console.WriteLine(" + Quê quán: " + this.queQuan);
            Console.WriteLine(" + Phương tiện đi lại: " + this.phuongTien);
        }
        public virtual void dichuyen()
        {

            string answer = this.phuongTien == "ô tô" ? "đường bộ, ô tô" : this.phuongTien == "Xe đạp" ? "đường bộ , xe đạp" : "Đị Bộ";
            Console.WriteLine(" + Hình thức di chuyển: " + answer);

        }
    }
    class CANBO:ConNguoi
    {
        private double heSoLuong;
        private int thamnien;
        public CANBO() { }
        public CANBO(string hoTen, string gioiTinh, int tuoi, string queQuan, string phuongTien, double hsl, int tn) : base(hoTen, gioiTinh, tuoi, queQuan,phuongTien)
        {
            heSoLuong = hsl;
            thamnien = tn;
        }
        public override void input()
        {
            base.input();
            Console.WriteLine(" + Hệ số lương: ");
            this.heSoLuong = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(" + Thâm niên công tác: ");
            this.thamnien = Convert.ToInt32(Console.ReadLine());
        }
        public override void output()
        {
            base.output();
            Console.WriteLine(" + Hệ số lương: " + this.heSoLuong);
            Console.WriteLine(" + Thâm niên: " + this.thamnien);
        }
        public double luong ()
        {
            return heSoLuong * 1300 + thamnien * 100;
        }
      
    }
    class SinhVien : ConNguoi
    {
        private double toan,van,anh;
        public SinhVien() { }
        public SinhVien(string hoTen, string gioiTinh, int tuoi, string queQuan, string phuongTien, double toan, double van, double anh) : base(hoTen, gioiTinh, tuoi, queQuan, phuongTien)
        {
            this.toan = toan;
            this.van = van;
            this.anh = anh;
        }
        public override void input()
        {
            base.input();
            Console.WriteLine(" + Điểm toán: ");
            this.toan = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(" + Điểm văn: ");
            this.van = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(" + Điểm anh: ");
            this.anh = Convert.ToInt32(Console.ReadLine());
        }
        public override void output()
        {
            base.output();
            Console.WriteLine(" + Điểm toán: " + this.toan);
            Console.WriteLine(" + Điểm văn: " + this.van);
            Console.WriteLine(" + Điểm anh: " + this.anh);
            Console.WriteLine(" + Điểm trung bình: " + this.tb());

        }
        public double tb()
        {
            return (toan + van + anh)/3.0;
        }
    }
}
