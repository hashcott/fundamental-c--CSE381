using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Something
{
    class Helper
    {
        protected int n;
        public Helper(int x)
        {
            n = x;
        }
        public bool checkNguyenTo(int n)
        {
            for(int i = 2; i < n; i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }
        public string nguyenTo() {
            string kq = "";
            for (int i = 2; i < n; i++) {
                if(checkNguyenTo(i))
                {
                    kq += i + ", ";
                }
            }
            return kq;
        }

        public bool checkChinhPhuong(int n)
        {
            int sqr = Convert.ToInt32(Math.Sqrt(n));
            if(sqr*sqr == n)
            {
                return true;
            }
            return false;
        }
        public string chinhPhuong()
        {
            string kq = "";
            for (int i = 2; i < n; i++)
            {
                if (checkChinhPhuong(i))
                {
                    kq += i + ", ";
                }
            }
            return kq;
        }
        public bool checkHoanChinh(int n)
        {
            int TongUoc = 0;
            for(int i = 1; i<=n/2;i++)
            {
                if (n % i == 0) TongUoc += i;
            }
            if (TongUoc == n) return true;
            return false;
        }
        public string hoanChinh()
        {
            string kq = "";
            for (int i = 1; i < n; i++)
            {
                if (checkHoanChinh(i))
                {
                    kq += i + ", ";
                }
            }
            return kq;
        }
    }
}
