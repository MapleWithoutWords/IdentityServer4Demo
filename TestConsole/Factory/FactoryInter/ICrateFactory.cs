using System;
using System.Collections.Generic;
using System.Text;
using TestConsole.Factory.interfaces;

namespace TestConsole.Factory.FactoryInter
{
    public interface ICrateFactory
    {
        ITest Create();
    }
}
