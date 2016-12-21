using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DMQA.DataService.Service;
using DMQA.DataService.ViewModels;

namespace DMQA.Web.Controllers
{
    public class HomeController : Controller
    {
        public IHomeService homeService { get; set; }

        public HomeController(IHomeService service)
        {
            homeService = service;
        }

        /// <summary>
        /// 获取用户信息列表
        /// </summary>
        /// <returns></returns>
        public JsonResult GetUserInfos()
        {
            return Json(homeService.GetUserInfos(), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 保存对用户信息列表的修改
        /// </summary>
        /// <param name="nodeParams"></param>
        public void SaveUserInfos(string nodeParams)
        {
            //List<UserInfo> models = JsonUtil.JsonToObject(nodeParams, typeof(List<UserInfo>)) as List<UserInfo>;
            //if (models != null && models.Count > 0)
            //{
            //    homeService.UpdateUserInfos(models);
            //}
        }

        public ActionResult UserInfoManage()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}