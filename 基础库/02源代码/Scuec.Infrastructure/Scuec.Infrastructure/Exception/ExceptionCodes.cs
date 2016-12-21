namespace Scuec.Infrastructure
{
    /// <summary>异常编码</summary>
    public enum ExceptionCodes
    {
        /// <summary>缺少参数值</summary>
        MissingParameterValue,
        /// <summary>参数解析失败</summary>
        ParameterParsingFailed,
        /// <summary>无效的枚举值</summary>
        InvalidEnumValue,
        /// <summary>操作未授权</summary>
        OperationUnauthorized,
        /// <summary>操作处理失败</summary>
        OperationProcessingFailed
    }
}
