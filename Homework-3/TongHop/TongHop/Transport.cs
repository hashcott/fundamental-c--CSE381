using System;
using System.Collections.Generic;
using System.Text;

namespace TongHop
{
    abstract class Transport
    {
        public abstract string dichuyen();
    }

    class Train : Transport
    {
        public override string dichuyen()
        {
            return "Tàu điện trên cao";
        }
    }
    class Motorcycle : Transport
    {
        public override string dichuyen()
        {
            return "Mô tô hai bánh";
        }
    }
    class Car : Transport
    {
        public override string dichuyen()
        {
            return "Xe hơi";
        }
    }
    class Walk : Transport
    {
        public override string dichuyen()
        {
            return "Đôi bàn chân xinh";
        }
    }
}
