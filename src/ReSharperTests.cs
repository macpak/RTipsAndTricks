using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace ResharperPresentation
{
    [TestFixture]
    public class ReSharperTests
    {
        //[Test]
        //public void TypeMismatch()
        //{
        //    object o = "23";
        //    string s = o;
        //}

        //[Test]
        //public void UndefinedVariable()
        //{
        //    s = 12345;
        //}

        //[Test]
        //public void UndefinedMethod()
        //{
        //    string s = "123";
        //    int i = 5;
        //    IEnumerable<string> collection = GetUsingParameters(s, i);
        //}

        //[Test]
        //public void ConvertToLinq()
        //{
        //    var collection = new[] {12, 3};
        //    foreach (var element in collection)
        //    {
        //        if (element > 5)
        //        {
        //            Console.WriteLine("{0} is greater", element);
        //        }
        //    }
        //}

        //[Test]
        //public void ObjectInitializer()
        //{
        //    var myClass = new MyClass();
        //    myClass.Prop1 = "qwe";
        //    myClass.Prop2 = 123;
        //}

        [Test]
        public void Using()
        {
            using (var myClass = new MyClass())
            {
            }
        }

        //[Test]
        //public void Logic()
        //{
        //    var a = DateTime.Now.Ticks%5 == 0;
        //    var b = DateTime.Now.Ticks % 2 == 0;
        //    var c = DateTime.Now.Ticks % 3 == 0;

        //    if (a == b && b == c && a == c)
        //    {
                
        //    }
        //}

        //public void NullReference()
        //{
        //    object param;
        //    if (DateTime.Now.Ticks%4 == 0)
        //    {
        //        param = "qwe";
        //    }
        //    else
        //    {
        //        param = new StringBuilder();
        //    }


        //    var builder = param as StringBuilder;
        //    Console.WriteLine(builder.Length);
        //}

        [Test]
        public void CheckWithBase()
        {
            var myClass = new MyClass();

            if (myClass is BaseClass)
            {
                
            }
        }

        [Test]
        public void VirtMethodInConstructor()
        {
            var myClass = new MyClass();

        }

        //[Test]
        //public void ArrayCovariance()
        //{
        //    var stringArray = new string[2];
        //    object[] objectArray = stringArray;
        //    objectArray[1] = 2;
        //}

        

        //[Test]
        //public void AnyInsteadOfUse()
        //{
        //    var collection = new[] {1, 2, 3};
        //    IEnumerable<int> collection2 = collection;

        //    if (collection.Count() > 0)
        //    {
        //        foreach (var i in collection)
        //        {
                    
        //        }
        //    }
        //}

        //[Test]
        //public void Params()
        //{
        //    var tab = new[] {4, 5};
        //    new MyClass().ParamsMethod(tab,1, 2);
        //}

        [Test]
        public void GenericTest()
        {
            new TestGenericOuter<int>();
        }

        [Test]
        public void Closure()
        {
            var collection = new[] { "1", "2", "3" };
            var methods = new List<Action>();

            foreach (var element in collection)
            {
                methods.Add(() => Console.WriteLine(element));
            }

            foreach (var method in methods)
            {
                method();
            }
        }

    }

    public class MyClass : BaseClass
    {
        public string Prop1 { get; set; }

        public int Prop2 { get; set; }

        private object _prop3;

        public object Prop3
        {
            get
            {
                return _prop3;
            }

            set
            {
                _prop3 = value;
            }
        }

        public void ParamsMethod(params object[] parameters)
        {
            Console.WriteLine(parameters[0]);
        }

        private int c = 10;

        public MyClass() : base()
        {
            c = 20;
        }

        public override void MyVirtualMethod()
        {
            Console.WriteLine(c);
        }
    }

    public class BaseClass : IDisposable
    {
        public BaseClass()
        {
            MyVirtualMethod();
        }

        public virtual void MyVirtualMethod(){}
        public void Dispose()
        {
            Console.WriteLine("Dispose");
        }
    }

    public class TestGeneric<T>
    {
        
    }

    public class TestGenericOuter<T> : TestGeneric<TestGenericOuter<TestGenericOuter<T>>>
    {
        
    }

}
