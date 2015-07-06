using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OBear.ApplicationServices
{
    /// <summary>
    /// 数据传输对象
    /// </summary>
    [DataContract]
    public abstract class DtoBase : IDto
    {
        /// <summary>
        /// 标识
        /// </summary>
        [DataMember]
        public string Id { get; set; }
    }
}

