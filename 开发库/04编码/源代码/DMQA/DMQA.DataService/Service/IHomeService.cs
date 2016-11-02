using System.Collections.Generic;
using DMQA.DataService.ViewModels;

namespace DMQA.DataService.Service
{
    public interface IHomeService
    {
        /// <summary>
        /// 获取用户信息集合
        /// </summary>
        /// <returns></returns>
        List<UserInfo> GetUserInfos();
    }
}
