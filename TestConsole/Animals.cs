using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TestConsole
{
    public class Animals : CollectionBase
    {
        public long Id { get; set; }
        public void Add(Animals instance)
        {
            List.Add(instance);
        }
        public void Remove(Animals instance)
        {
            List.Remove(instance);
        }

        public Animals this[int index]
        {
            get { return (Animals)List[index]; }
            set { List[index] = value; }
        }
    }
}
