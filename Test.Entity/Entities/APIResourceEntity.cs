using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Entity.Entities
{
    /// <summary>
    /// IdentityServer4的APIResource
    /// </summary>
    public class APIResourceEntity:BaseEntity
    {
        /// <summary>
        /// API名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 别名
        /// </summary>
        public string DisplayName { get; set; }
    }
}
