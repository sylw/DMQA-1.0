using System.Collections.Generic;

namespace Scuec.Infrastructure.Web
{
    public interface IWebExceptionMap
    {
        /// <summary>服务名称</summary>
        string ServiceName { get; }
        /// <summary>配置</summary>
        IDictionary<string, WebExceptionModel> Config();
    }
}
