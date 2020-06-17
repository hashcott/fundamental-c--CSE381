using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            TComplex sp1 = new TComplex( 1, 2);
            TComplex sp2 = new TComplex(2, 3);
            TComplex sp3 = new TComplex(4, 3);
            TComplex sp4 = new TComplex();
            TComplex sp5 = new TComplex();

            // Hien thi khoi tao
            sp1.output();
            sp2.output();
            sp3.output();
            
            //Nhap va hien thi
            sp1.input();
            sp2.input();
            sp3.input();
            sp1.output();
            sp2.output();
            sp3.output();

            //  Tinh Toan
            Console.WriteLine("sp3 = sp1 - sp2");
            sp3 = sp1 - sp2;
            sp3.output();

            Console.WriteLine("sp4 = sp1 + sp2");
            sp4 = sp1 + sp2;
            sp4.output();

            Console.WriteLine("sp5 = sp4 * sp3");
            sp5 = sp4 * sp3;
            sp5.output();
        }
    }
}
