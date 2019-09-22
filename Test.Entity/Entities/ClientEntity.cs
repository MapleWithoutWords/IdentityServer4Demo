using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Entity.Entities
{
    /// <summary>
    /// IdentityServer4中的Client。在这里，我是用Id作为ClientId
    /// </summary>
    public class ClientEntity : BaseEntity
    {
        /// <summary>
        /// clientName
        /// </summary>
        public string Name { get; set; }
        public string Secret { get; set; }
    }
}
