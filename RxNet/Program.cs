using System;
using System.Reactive.Linq;

namespace RxNet
{
    class Program
    {
        static void Main(string[] args)
        {

            var test = new Test();
            Console.WriteLine("Hello World!");
        }
    }

    class Test
    {
        public string Hello { get; set; }

        public Test()
        {
            Hello = "World";
        }

    }
}
