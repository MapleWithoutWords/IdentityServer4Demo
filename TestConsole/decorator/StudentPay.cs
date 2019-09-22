using System;
using System.Collections.Generic;
using System.Text;

namespace TestConsole.decorator
{
    public class StudentPay : IStudy
    {
        public IStudy Learn { get; set; }
        public StudentPay(IStudy Learn)
        {
            this.Learn = Learn;
        }
        public virtual void Study()
        {
            Console.WriteLine("pay");
            this.Learn.Study();
        }
    }
}
