using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMQA.Database.Models;
using DMQA.DataService.ViewModels;

namespace DMQA.DataService.Service
{
    public class HomeService : IHomeService
    {
        private BaseDbContext _baseDbContext { get; set; }

        public HomeService()
        {
            _baseDbContext = new BaseDbContext();
        }
        public List<UserInfo> GetUserInfos()
        {
            var userInfo = _baseDbContext.tb_UserInfo.Select(t => t);
            return userInfo.Select(AutoMapper.Mapper.Map<tb_UserInfo, UserInfo>).ToList();
        }
    }
}
