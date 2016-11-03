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

        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="userInfoModels">用户信息集合</param>
        void UpdateUserInfos(List<UserInfo> userInfoModels);
    }
}
