using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    abstract class Transport
    {
        public abstract void dichuyen();
    }

    class Car : Transport
    {
        public override void dichuyen()
        {
            Console.WriteLine("Ô tô đi đường bộ");
        }
    }
    class Airplane : Transport
    {
        public override void dichuyen()
        {
            Console.WriteLine("Máy bay đi đường hàng không");
        }
    }
    class Ship : Transport
    {
        public override void dichuyen()
        {
            Console.WriteLine("Thuyền đi đường thủy");
        }
    }
}
