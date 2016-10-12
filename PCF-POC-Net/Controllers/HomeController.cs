using Microsoft.Extensions.Options;
using PCF_POC.Data;
using PCF_POC.Interfaces;
using PCF_POC.Models.HomeViewModels;
using PCF_POC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PCF_POC_Net.Controllers
{
    public class HomeController : Controller
    {

        private AppSettings _settings { get; set; }
        private IAppInfoService _appInfoservice;

        public HomeController(IAppInfoService appInfoService)
        {
           // _settings = settings.Value;
            _appInfoservice = appInfoService;
        }
        public ActionResult Index()
        {
            //var deployType = _settings.DeploymentType;
            //if (string.IsNullOrEmpty(deployType))
            //{
            //    ViewBag.DeployType = 1;
            //    return View();
            //}
            ViewBag.DeployType = 0;
            return View();
        }

        public ActionResult Recommendation()
        {
            var model = new RecommendationViewModel();
            model.equipments = _appInfoservice.GetEquipments<Equipment>();
            model.packages = _appInfoservice.GetData<Package>();
            return View(model);
        }

        public ActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public ActionResult Error()
        {
            return View();
        }
    }
}