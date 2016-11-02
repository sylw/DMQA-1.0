using AutoMapper;
using DMQA.Database.Models;
using DMQA.DataService.ViewModels;

namespace DMQA.DataService.Tool
{
    /// <summary>
    /// 创建模型映射
    /// </summary>
    public static class AutoMapperExtention
    {
        public static void InitializationMapper()
        {
            Mapper.CreateMap<tb_UserInfo, UserInfo>();
            //Mapper.CreateMap<tb_UserInfo, UserInfo>()
            //    .ForMember(s => s.Code, t => t.MapFrom(e => e.Code));
        }
    }
}
