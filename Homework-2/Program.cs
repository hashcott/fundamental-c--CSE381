using System;

namespace numbers
{
    class Program
    {
        static void square(uint n)
        {
            Console.WriteLine("so chinh phuong nho hon {0} : ",n);
            for (uint i = 1; i < n ;i++)
            {
                if (i*i < n)
                {
                    Console.Write("{0}   ",i*i);
                }
            }
        }
        static void ngTo(uint n)
        {
            // ap dung thuat tuan sang nguyen to Eratosthenes
            bool[] sangNg = new bool[n + 1];
            sangNg[0] = sangNg[1] = false;

            // Init // dau tien em dinh setup default nhung khong thay ham cua c#
            for (uint i = 2; i <= n; i++)
            {
               sangNg[i] = true;
            }

            Console.WriteLine("\nso nguyen to nho hon {0} : ", n);

            for (uint i = 2; i <= n; i++)
            {
                if (sangNg[i])
                {
                    for (uint j = i*2; j <= n; j += i)
                    {
                        sangNg[j] = false;
                    }
                }
            }
            Console.WriteLine(sangNg);

            for (uint i = 2; i <= n; i++)
            {
                if (sangNg[i]) Console.Write("{0}  ", i); ;
            }
        }
        static void doiXung(uint n)
        {
            Console.WriteLine("\nso doi xung nho hon {0} : ", n);

            for (uint i = 10; i <= n; i++)
            {
                uint copyI = i, reverse = 0, cur = 0;

                while (copyI != 0)
                {
                    cur = copyI % 10;
                    reverse = reverse * 10 + cur;
                    copyI /= 10;
                }
                if(reverse == i)
                {
                    Console.Write("{0} ", i);
                }
            }
           
        }
        static void amstrong(uint n)
        {
            Console.WriteLine("\nso amstrong nho hon {0} : ", n);

            for (uint i = 1; i <= n; i++)
            {
                uint copyI = i, cur = 0, mu =0;
                double luyThua = 0;
                while (copyI != 0)
                {
                    cur = copyI % 10;
                    mu++;
                    copyI /= 10;
                }
                copyI = i;
                while (copyI != 0)
                {
                    cur = copyI % 10;
                    luyThua += Math.Pow(cur, mu);
                    copyI /= 10;
                }
                if (luyThua == i)
                {
                    Console.Write("{0} ", i);
                }
            }
        }
        static void hoanHao(uint n)
        {
            Console.WriteLine("\nso hoan hao nho hon {0} : ", n);

            for (uint i = 1; i <= n; i++)
            { 
                uint sum = 0;//khai bao biem sum
                for (uint j = 1; j <= n / 2; j++)
                {
                    if (i % j == 0)
                        sum += j;
                }
                if (sum == n) Console.Write("{0} ", i);
            }
        }
        static void Main(string[] args)
        {
            uint n;
            Console.WriteLine("Nhap so nguyen duong n: ");
            do
            {
                n = Convert.ToUInt32(Console.ReadLine());
            } while (n < 0 || n >= 100000);

            square(n);
            ngTo(n);
            doiXung(n);
            amstrong(n);
            hoanHao(n);
        }
    }
}
