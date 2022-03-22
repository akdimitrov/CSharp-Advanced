using System;
using System.Collections.Generic;
using System.Linq;

namespace T02.Collection
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<string> stringList = Console.ReadLine().Split().Skip(1).ToList();
            ListyIterator<string> listyIterator = new ListyIterator<string>(stringList);
            string input = Console.ReadLine();
            try
            {
                while (input != "END")
                {
                    if (input == "Move")
                    {
                        Console.WriteLine(listyIterator.Move());
                    }
                    else if (input == "HasNext")
                    {
                        Console.WriteLine(listyIterator.HasNext());
                    }
                    else if (input == "Print")
                    {
                        listyIterator.Print();
                    }
                    else if (input == "PrintAll")
                    {
                        listyIterator.PrintAll();
                    }

                    input = Console.ReadLine();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
