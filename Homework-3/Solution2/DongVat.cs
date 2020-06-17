using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    abstract class DongVat
    {
        public abstract void dichuyen();
        public abstract void an();
        public abstract void tieng();

    }
    
    class Cho : DongVat
    {
        public override void dichuyen()
        {
            Console.WriteLine("Con chó đi bằng bốn chân");
        }
        public override void an() {
            Console.WriteLine("Con chó ăn tạp");
        }
        public override void tieng() {
            Console.WriteLine("Con chó sủa gâu gâu...");
        }
    }
    class Vit : DongVat
    {
        public override void dichuyen()
        {
            Console.WriteLine("Con chó đi bằng hai chân");
        }
        public override void an()
        {
            Console.WriteLine("Con chó ăn cua, ăn tôm, ăn ốc,...");
        }
        public override void tieng()
        {
            Console.WriteLine("Con chó sủa quack quack...");
        }
    }

    class Meo : DongVat
    {
        public override void dichuyen()
        {
            Console.WriteLine("Con chó đi bằng bốn chân");
        }
        public override void an()
        {
            Console.WriteLine("Con chó ăn chuột");
        }
        public override void tieng()
        {
            Console.WriteLine("Con chó sủa meow meow...");
        }
    }
}
