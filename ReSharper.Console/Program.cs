using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReSharper.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            new TestGenericOuter<int>();
        }
    }

    public class TestGeneric<T>
    {

    }

    public class TestGenericOuter<T> : TestGeneric<TestGenericOuter<TestGenericOuter<T>>>
    {

    }
}
