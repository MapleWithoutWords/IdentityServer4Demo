using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Entity.Entities
{
    /// <summary>
    /// Client和APIResource的关系表
    /// </summary>
    public class ClientAPIResourceEntity:BaseEntity
    {
        /// <summary>
        /// ClientEntity类的Id
        /// </summary>
        public string ClientId { get; set; }
        /// <summary>
        /// APIResourceEntity类的Id
        /// </summary>
        public string APIResourceId { get; set; }
    }
}
