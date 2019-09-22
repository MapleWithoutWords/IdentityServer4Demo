using System;
using System.Collections.Generic;
using System.Text;
using TestConsole.Factory.interfaces;

namespace TestConsole.Factory.stances
{
    public class Test1 : ITest
    {
        public string Name { get; set; }
        public Test1(string name)
        {
            this.Name = name;
        }
        public void Print()
        {
            Console.WriteLine($"test1 name={this.Name}");
        }
    }
}
