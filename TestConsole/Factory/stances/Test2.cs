using System;
using System.Collections.Generic;
using System.Text;
using TestConsole.Factory.interfaces;

namespace TestConsole.Factory.stances
{
  public  class Test2 : ITest
    {
        public string Name { get; set; }
        public Test2(string name)
        {
            this.Name = name;
        }
        public void Print()
        {
            Console.WriteLine($"test2 name={this.Name}");
        }
    }
}
