using System;

namespace BoxOfT
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Box<string> box = new Box<string>();
            box.Add("One");
            box.Add("Two");
            box.Add("Three");
            Console.WriteLine(box.Remove());
            box.Add("Four");
            box.Add("Five");
            Console.WriteLine(box.Remove());
        }
    }
}
