using System;

namespace date
{
    class Program
    {
        static void ktNgay(int dd, int mm, int yyyy)
        {
            int ddMax = -1;
            if( mm >=1 || mm <= 12 )
            {
                switch(mm)
                {
                    case 1:
                    case 3:
                    case 5:
                    case 7:
                    case 8:
                    case 10:
                    case 12:
                        ddMax = 31;
                        break;
                    case 2:
                        ddMax = 28;
                        if (yyyy % 4 == 0 && yyyy % 100 != 0) ddMax = 29;
                        break;

                    default:
                        ddMax = 30;
                        break;
                }
            }
            //Console.WriteLine(ddMax);
            if (dd >= 1 && dd <= ddMax) {
                Console.WriteLine("Ngay {0}/{1}/{2} la ngay hop le", dd, mm, yyyy);
                if (dd >= 1 && dd < ddMax) Console.WriteLine("Ngay tiep theo la {0}/{1}/{2}", dd + 1, mm, yyyy);
                else if (dd == ddMax && mm < 12) Console.WriteLine("Ngay tiep theo la {0}/{1}/{2}", 1, mm + 1, yyyy);
                else if (dd == 31 & mm == 12) Console.WriteLine("Ngay tiep theo la {0}/{1}/{2}", 1, 1, yyyy+1);
            }  else Console.WriteLine("Ngay {0}/{1}/{2} la ngay khong hop le", dd, mm, yyyy);

          
        }
        static void Main(string[] args)
        {
            short dd, mm, yyyy;
            Console.WriteLine("Day: ");
            dd = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Month: ");
            mm = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Year: ");
            yyyy = Convert.ToInt16(Console.ReadLine());
            ktNgay(dd, mm, yyyy);
        }
    }
}
