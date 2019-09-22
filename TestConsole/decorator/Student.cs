using System;
using System.Collections.Generic;
using System.Text;

namespace TestConsole.decorator
{
    public class Student : IStudy
    {
        public void Study()
        {
            Console.WriteLine("study source!");
        }
    }
}
