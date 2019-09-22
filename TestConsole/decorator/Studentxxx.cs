using System;
using System.Collections.Generic;
using System.Text;

namespace TestConsole.decorator
{
    public class Studentxxx : StudentPay
    {
        public Studentxxx(IStudy Learn) : base(Learn)
        {
        }

        public override void Study()
        {
            Console.WriteLine("zhunbei");
            Learn.Study();
        }
    }
}
