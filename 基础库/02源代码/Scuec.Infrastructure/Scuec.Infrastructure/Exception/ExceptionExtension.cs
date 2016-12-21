using System;

namespace Scuec.Infrastructure
{
    /// <summary>异常扩展</summary>
    public static class ExceptionExtension
    {
        /// <summary>异常代码</summary>
        private static readonly string Code = "Scuec.Exception:Code";
        /// <summary>异常明细</summary>
        private static readonly string Details = "Scuec.Exception:Details";

        /// <summary>
        /// 抛出符合规范的异常
        /// </summary>
        /// <typeparam name="TCode">异常代码</typeparam>
        /// <param name="ex">扩展类=Exception</param>
        /// <param name="code">异常代码</param>
        /// <param name="details">异常明细(面向调用者)</param>
        public static void Throw<TCode>(this Exception ex, TCode code, string details)
            where TCode : struct
        {
            if (!(ex is UserFriendlyException) && !ex.Data.Contains(Code))
            {
                ex.Data[Code] = code.ToString();
                ex.Data[Details] = details;
            }
            throw ex;
        }

        /// <summary>
        /// 抛出用户友好异常
        /// </summary>
        /// <typeparam name="TCode">异常代码</typeparam>
        /// <param name="code">扩展类=TCode</param>
        /// <param name="message">异常信息(面向用户)</param>
        /// <param name="details">异常明细(面向调用者)</param>
        public static void ThrowUserFriendly<TCode>(this TCode code, string message, string details)
            where TCode : struct
        {
            throw new UserFriendlyException(code.ToString(), message, details);
        }

        /// <summary>
        /// 转换为异常数据
        /// </summary>
        /// <param name="ex">扩展类=Exception</param>
        /// <returns>异常数据</returns>
        public static ExceptionModel ToModel(this Exception ex)
        {
            var model = new ExceptionModel();
            var ex2 = ex.As<UserFriendlyException>();
            if (ex2 == null)
            {
                model.Code = ex.Data[Code].As<string>();
                model.Message = ex.Data[Details].As<string>();
            }
            else
            {
                model.Code = ex2.Code;
                model.Message = ex2.FriendlyMessage;
            }
            model.Details = ex.Message;
            return model;
        }
    }
}
