using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class TComplex
    {
        private int a, i;
        public TComplex() {
            this.a = 0;
            this.i = 0;
        }
        public TComplex(int a, int i)
        {
            this.a = a;
            this.i = i;
        }
        public void input()
        {
            Console.WriteLine("- Nhập số phức : ");

            Console.WriteLine(" + Nhập phần thực : ");
            this.a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(" + Nhập phần ảo : ");
            this.i = Convert.ToInt32(Console.ReadLine());
        }
        public void output()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine(" + Số phức là : {0}i + {1}", this.a, this.i);
        }
        public static TComplex operator + (TComplex x, TComplex y)
        {
            TComplex z = new TComplex();
            z.a = x.a + y.a;
            z.i = x.i + y.i;
            return z;
        }
        public static TComplex operator -(TComplex x, TComplex y)
        {
            TComplex z = new TComplex();
            z.a = x.a - y.a;
            z.i = x.i - y.i;
            return z;
        }
        public static TComplex operator *(TComplex x, TComplex y)
        {
            TComplex z = new TComplex();
            z.a = x.a * y.a - x.i * y.i;
            z.i = x.a * y.i + y.a * z.i;
            return z;
        }
        public static TComplex operator /(TComplex x, TComplex y)
        {
            TComplex z = new TComplex();
            z.a = (x.a * y.a + x.a * (-y.i)) + (x.i * y.a + x.i * (-y.i));
            z.i = (y.a * y.a + y.a * (-y.i)) + (y.i * y.a + y.i * (-y.i));
            return z;
        }
        
    }
}
