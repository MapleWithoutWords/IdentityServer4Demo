using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Entity.Entities
{
    public class UserEntity:BaseEntity
    {
        public string Name { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }

    }
}
