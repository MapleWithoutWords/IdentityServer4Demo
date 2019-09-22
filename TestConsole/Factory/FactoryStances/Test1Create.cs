using System;
using System.Collections.Generic;
using System.Text;
using TestConsole.Factory.FactoryInter;
using TestConsole.Factory.interfaces;
using TestConsole.Factory.stances;

namespace TestConsole.Factory.FactoryStances
{
    public class Test1Create : ICrateFactory
    {
        public ITest Create()
        {
            return new Test1("test1");
        }
    }
}
