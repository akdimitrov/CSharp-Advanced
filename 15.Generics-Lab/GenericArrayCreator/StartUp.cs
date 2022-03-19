using System;

namespace GenericArrayCreator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] strings = ArrayCreator.Create(5, "text");
            int[] integers = ArrayCreator.Create(5, 1);

            Console.WriteLine(string.Join(", ", strings));
            Console.WriteLine(string.Join(", ", integers));
        }
    }
}
