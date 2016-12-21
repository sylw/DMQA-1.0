using System;
using System.Runtime.Serialization;

namespace Scuec.Infrastructure
{
    /// <summary>异常数据</summary>
    [Serializable]
    [DataContract]
    public class ExceptionModel
    {
        /// <summary>异常编码</summary>
        [DataMember(Name = "exceptioncode")]
        public string Code { get; set; }
        /// <summary>异常信息(面向用户)</summary>
        [DataMember(Name = "message")]
        public string Message { get; set; }
        /// <summary>异常明细(面向调用者)</summary>
        [DataMember(Name = "details")]
        public string Detail { get; set; }
    }
}
