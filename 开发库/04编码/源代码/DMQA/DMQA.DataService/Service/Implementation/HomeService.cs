using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMQA.Database.Models;
using DMQA.DataService.Enum;
using DMQA.DataService.ViewModels;

namespace DMQA.DataService.Service
{
    public class HomeService : IHomeService
    {
        /// <summary>
        /// 数据上下文 可以想象成数据库对象
        /// </summary>
        private BaseDbContext _baseDbContext { get; set; }

        public HomeService()
        {
            _baseDbContext = new BaseDbContext();
        }

        /// <summary>
        /// 获取用户信息列表
        /// </summary>
        /// <returns></returns>
        public List<UserInfo> GetUserInfos()
        {
            //数据库对象的tb_UserInfo表对象，选择所有项 Select(t => t)
            var userInfo = _baseDbContext.tb_UserInfo.Select(t => t);
            //AutoMapper的套路写法
            return userInfo.Select(AutoMapper.Mapper.Map<tb_UserInfo, UserInfo>).ToList();
        }

        /// <summary>
        /// 更新用户信息表
        /// </summary>
        /// <param name="userInfoModels"></param>
        public void UpdateUserInfos(List<UserInfo> userInfoModels)
        {
            //遍历列表中的每一项
            foreach (var userInfoModel in userInfoModels)
            {
                //状态为 新增
                if (userInfoModel._state == EnumNodeState.added.ToString())
                {
                    AddUserInfo(userInfoModel);
                }

                //状态为 修改
                if (userInfoModel._state == EnumNodeState.modified.ToString())
                {
                    ModifyUserInfo(userInfoModel);
                }

                //状态为 删除
                if (userInfoModel._state == EnumNodeState.removed.ToString())
                {
                    RemoveUserInfo(userInfoModel.Code);
                }
            }
        }

        /// <summary>
        /// 添加一条用户信息
        /// </summary>
        private void AddUserInfo(UserInfo userInfo)
        {
            var newtbUserInfo = new tb_UserInfo()
            {
                Code = Guid.NewGuid().ToString(),
                UserName = userInfo.UserName,
                Password = userInfo.Password,
                Sex = userInfo.Sex,
                Email = userInfo.Email,
                Mark = 0,
                RewardMark = 0,
                PaidMark = 0,
                ACount = 0,
                AAcceptCount = 0,
                QSolvedCount = 0,
                QUnsolveCount = 0,
                QCancelledCount = 0,
                CreatedDate = userInfo.CreatedDate
            };
            _baseDbContext.tb_UserInfo.Add(newtbUserInfo);
            _baseDbContext.SaveChanges();
        }

        /// <summary>
        /// 修改一条用户信息
        /// </summary>
        private void ModifyUserInfo(UserInfo userInfo)
        {
            var tbUserInfo = _baseDbContext.tb_UserInfo.FirstOrDefault(t => t.Code == userInfo.Code);
            if(tbUserInfo == null) return;
            tbUserInfo.Password = userInfo.Password;
            tbUserInfo.Sex = userInfo.Sex;
            tbUserInfo.Email = userInfo.Email;
            _baseDbContext.SaveChanges();

        }


        /// <summary>
        /// 删除一条用户信息
        /// </summary>
        /// <param name="code"></param>
        private void RemoveUserInfo(string code)
        {
            var userInfo = _baseDbContext.tb_UserInfo.Find(code);
            if (userInfo != null)
            {
                _baseDbContext.tb_UserInfo.Remove(userInfo);
                _baseDbContext.SaveChanges();
            }
        }
    }
}
