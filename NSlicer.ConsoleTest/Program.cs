using NSlicer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSlicer.ConsoleTest
{
    class Program
    {
        class A
        {
            public string SomeInt { get; set; }
            public string SomeString { get; set; }
            public string SomeString12 { get; set; }
        }

        class B
        {
            public int SomeInt { get; set; }
            public string SomeString { get; set; }
            public string SomeString14 { get; set; }
        }

        class C
        {
            public int SomeInt { get; set; }
            public int SomeString { get; set; }
        }

        static void Main(string[] args)
        {
            var a = new A { SomeInt = "123sdf", SomeString = "Hello World" };

            var mapper = NSliceFactory.MapperFor<A, B>()
                .AddPropertyBinding("jashdk", "aksjd")
                .AddPropertyBinding("", "");

            var b = mapper.Map(a);
            Console.WriteLine("< NSlicer >\n");
            Console.WriteLine($"> Created: A {{SomeInt = {a.SomeInt}, SomeString = {a.SomeString}}} \n" +
                              $"> Mapped: B {{SomeInt = {b.SomeInt}, SomeString = {b.SomeString}}}");

            Console.ReadKey();
        }
    }
}
