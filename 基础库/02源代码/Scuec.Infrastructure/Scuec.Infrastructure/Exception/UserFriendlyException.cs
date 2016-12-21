using System;
using System.Runtime.Serialization;

namespace Scuec.Infrastructure
{
    /// <summary>用户友好异常</summary>
    /// <remarks>可显示给用户的异常</remarks>
    [Serializable]
    [DataContract]
    public class UserFriendlyException : ApplicationException
    {
        /// <summary>构造函数 </summary>
        public UserFriendlyException()
        {
        }

        /// <summary>
        /// 构造函数，用序列化数据初始化类的新实例
        /// </summary>
        /// <param name="info">承载序列化对象数据的对象</param>
        /// <param name="context">关于来源和目标的上下文信息</param>
        public UserFriendlyException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {            
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="code">异常编码</param>
        /// <param name="message">描述错误的消息</param>
        /// <param name="friendlyMessage">给用户参考的异常信息</param>
        public UserFriendlyException(string code, string message, string friendlyMessage)
            : base(message)
        {
            this.Code = code;
            this.FriendlyMessage = friendlyMessage;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="innerException">导致当前异常的异常。 如果 innerException 参数不为空引用，则在处理内部异常的 catch 块中引发当前异常。</param>
        /// <param name="code">描述错误的消息</param>
        /// <param name="message">解释异常原因的错误信息</param>
        /// <param name="friendlyMessage">给用户参考的异常信息</param>
        public UserFriendlyException(Exception innerException, string code, string message, string friendlyMessage)
            : base(message, innerException)
        {
            this.Code = code;
            this.FriendlyMessage = friendlyMessage;
        }

        /// <summary>异常编码</summary>
        public string Code { get; set; }

        /// <summary>给用户参考的异常信息 </summary>
        public string FriendlyMessage { get; set; }
    }
}
