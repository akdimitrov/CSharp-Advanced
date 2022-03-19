using System;

namespace GenericScale
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            EqualityScale<int> scale1 = new EqualityScale<int>(1, 2);
            EqualityScale<int> scale2 = new EqualityScale<int>(2, 2);
            EqualityScale<string> scale3 = new EqualityScale<string>("One", "Two");
            EqualityScale<string> scale4 = new EqualityScale<string>("Two", "Two");

            Console.WriteLine(scale1.AreEqual());
            Console.WriteLine(scale2.AreEqual());
            Console.WriteLine(scale3.AreEqual());
            Console.WriteLine(scale4.AreEqual());
        }
    }
}
