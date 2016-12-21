using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Security.Authentication;

namespace Scuec.Infrastructure.Web
{
    /// <summary>WEB异常配置</summary>
    public class WebExceptionConfig
    {
        /// <summary>异常类型映射</summary>
        private Dictionary<Type, ExceptionModel> TypeMappers { get; set; }
        /// <summary>WEB异常类型映射</summary>
        private Dictionary<Type, WebExceptionModel> WebTypeMappers { get; set; }
        /// <summary>WEB异常代码映射</summary>
        private Dictionary<string, Dictionary<string, WebExceptionModel>> WebCodeMappers { get; set; }

        /// <summary>初始化</summary>
        private void Initialize()
        {
            InitTypeMappers();
            InitCodeMappers();
        }

        /// <summary>配置异常类型映射</summary>
        private void InitTypeMappers()
        {
            TypeMappers = new Dictionary<Type, ExceptionModel>();
            TypeMappers.Add(typeof(Exception), new ExceptionModel
            {
                Code = ExceptionCodes.OperationProcessingFailed.ToString(),
                Message = "操作处理失败！",
                Details = "操作处理失败"
            });
            TypeMappers.Add(typeof(ArgumentException), new ExceptionModel
            {
                Code = ExceptionCodes.MissingParameterValue.ToString(),
                Message = "请求参数无效！",
                Details = "缺少请求参数！"
            });
            TypeMappers.Add(typeof(ArgumentNullException), new ExceptionModel
            {
                Code = ExceptionCodes.MissingParameterValue.ToString(),
                Message = "请求参数无效！",
                Details = "请求参数不能为null！"
            });
            TypeMappers.Add(typeof(InvalidEnumArgumentException), new ExceptionModel
            {
                Code = ExceptionCodes.ParameterParsingFailed.ToString(),
                Message = "请求参数无效！",
                Details = "请求参数为枚举类型，参数值不合法！"
            });
            TypeMappers.Add(typeof(InvalidOperationException), new ExceptionModel
            {
                Code = ExceptionCodes.OperationProcessingFailed.ToString(),
                Message = "操作处理失败！",
                Details = "操作处理失败！"
            });
            TypeMappers.Add(typeof(AuthenticationException), new ExceptionModel
            {
                Code = ExceptionCodes.OperationUnauthorized.ToString(),
                Message = "操作未授权！",
                Details = "操作未授权！"
            });

            WebTypeMappers = new Dictionary<Type, WebExceptionModel>();
            WebTypeMappers.Add(typeof(Exception), WebExceptionModel.ServerProcessingFailed);
            WebTypeMappers.Add(typeof(ArgumentException), WebExceptionModel.BadRequest);
            WebTypeMappers.Add(typeof(ArgumentNullException), WebExceptionModel.BadRequest);
            WebTypeMappers.Add(typeof(InvalidEnumArgumentException), WebExceptionModel.BadRequest);
            WebTypeMappers.Add(typeof(InvalidOperationException), WebExceptionModel.ServerProcessingFailed);
            WebTypeMappers.Add(typeof(AuthenticationException), WebExceptionModel.Unauthorized);
        }

        /// <summary>配置异常代码映射</summary>
        private void InitCodeMappers()
        {
            WebCodeMappers = new Dictionary<string, Dictionary<string, WebExceptionModel>>(StringComparer.OrdinalIgnoreCase);
            var codeMappers = new Dictionary<string, WebExceptionModel>(StringComparer.OrdinalIgnoreCase);
            codeMappers.Add(ExceptionCodes.MissingParameterValue.ToString(), WebExceptionModel.BadRequest);
            codeMappers.Add(ExceptionCodes.InvalidEnumValue.ToString(), WebExceptionModel.BadRequest);
            codeMappers.Add(ExceptionCodes.ParameterParsingFailed.ToString(), WebExceptionModel.BadRequest);
            codeMappers.Add(ExceptionCodes.OperationProcessingFailed.ToString(), WebExceptionModel.ServerProcessingFailed);          
            codeMappers.Add(ExceptionCodes.OperationUnauthorized.ToString(), WebExceptionModel.Unauthorized);
            WebCodeMappers.Add("", codeMappers);
        }

        public void LoadConfig(string sectionName = "WebExceptionConfig")
        {
            Initialize();
            var config = ConfigurationManager.GetSection(sectionName).As<NameValueCollection>();
            foreach (string key in config.Keys)
            {
                var mapType = config[key];
                if (mapType.IsNullOrEmpty()) continue;
                var codeMappers = WebCodeMappers.GetValueBy(key);
                if (codeMappers == null)
                {
                    codeMappers = new Dictionary<string, WebExceptionModel>();
                    WebCodeMappers.Add(key, codeMappers);
                }
                var map = Activator.CreateInstance(Type.GetType(mapType)).As<IWebExceptionMap>();
                codeMappers.AddRange(map.Config());
            }
        }

        /// <summary>
        /// 配置异常类型映射
        /// </summary>
        /// <param name="ex">异常实例</param>
        /// <param name="service">服务名称，MVC控制器或API控制器默认为控制器名称(不包括后缀Controller)</param>
        /// <param name="exceptionModel">异常数据</param>
        /// <returns></returns>
        public WebExceptionModel MapTo(Exception ex, string service, ExceptionModel exceptionModel)
        {
            WebExceptionModel webExceptionModel = null;
            if (exceptionModel.Code.IsNullOrEmpty())
            {
                ExceptionModel exceptionModel2 = null;
                var exType = ex.GetType();
                do
                {
                    exceptionModel2 = TypeMappers.GetValueBy(exType);
                    exType = exType.BaseType;
                } while (exceptionModel2==null);
                exceptionModel.Code = exceptionModel2.Code;
                if (exceptionModel.Message.IsNullOrEmpty())
                {
                    exceptionModel.Message = exceptionModel2.Message;
                }
                if (exceptionModel.Details.IsNullOrEmpty())
                {
                    exceptionModel.Details = exceptionModel2.Details;
                }
            }
            else
            {
                if (service == null) service = "";
                var codeMappers = WebCodeMappers.GetValueBy(service);
                if (codeMappers == null && service.Length > 0)
                {
                    service = "";
                    codeMappers = WebCodeMappers.GetValueBy(service);
                }
                webExceptionModel = codeMappers.GetValueBy(exceptionModel.Code);
            }
            if (webExceptionModel == null)
            {
                var exType = ex.GetType();
                do
                {
                    webExceptionModel = WebTypeMappers.GetValueBy(exType);
                    exType = exType.BaseType;
                } while (webExceptionModel == null);
            }
            return webExceptionModel;
        }

    }
}
