using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using temp0.Models;
using temp0.ViewModels;



namespace temp0.Areas.Users.Controllers
{
    public class FirstPageController : Controller
    {
        dbasesEntities db = new dbasesEntities();
        ViewsModels vm = new ViewsModels();
        // GET: Users/FirstPage
        public ActionResult Index()
        {
           
            return View();
        }
        public ActionResult MainPage()
        {


            vm.News_Categorys = db.News_category.ToList();
            vm.Newss = db.News.ToList();
        
        

           
            return View(vm);
        }
    }
}