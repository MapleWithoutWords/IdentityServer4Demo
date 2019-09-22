using System;
using System.Collections.Generic;
using System.Text;
using TestConsole.Factory.FactoryInter;
using TestConsole.Factory.interfaces;
using TestConsole.Factory.stances;

namespace TestConsole.Factory.FactoryStances
{
    public class Test2Create : ICrateFactory
    {
        public ITest Create()
        {
            return new Test2("test2");
        }
    }
}
