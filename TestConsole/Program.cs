using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using TestConsole.decorator;
using TestConsole.Factory;
using TestConsole.Factory.FactoryInter;
using TestConsole.Factory.FactoryStances;
using TestConsole.Factory.interfaces;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            foreach (var item in ReturnList())
            {
                Console.WriteLine(item);
            }

            Cards cards = new Cards();
            cards["1"]="123";
            cards["2"]="234";
            cards["3"] = "345";
            foreach (var item in cards)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
        static IEnumerable<string> ReturnList()
        {
            return new string[3] {"1","2","3" };
        }
    }

    public class Cards:DictionaryBase
    {
        public new IEnumerator GetEnumerator()
        {
            foreach (var item in Dictionary.Values)
            {
                yield return item;
            }
        }
        public object this[object index]
        {
            get { return Dictionary[index]; }
            set { Dictionary[index] = value; }
        }
    }

}
