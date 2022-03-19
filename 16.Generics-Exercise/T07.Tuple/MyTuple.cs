using System;
using System.Collections.Generic;
using System.Text;

namespace T07.Tuple
{
    public class MyTuple<T1, T2>
    {
        public MyTuple(T1 value1, T2 value2)
        {
            Value1 = value1;
            Value2 = value2;
        }

        public T1 Value1 { get; set; }

        public T2 Value2 { get; set; }

        public override string ToString()
          => $"{Value1} -> {Value2}";
    }
}
