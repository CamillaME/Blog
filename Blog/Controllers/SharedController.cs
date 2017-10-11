using Blog.DAL;
using Blog.Models;
using Blog.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class SharedController : Controller
    {
        // GET: Shared
        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult _loginViewFront()
        //{
        //    UserRepository userRepository = new UserRepository();
        //    UserModel user = userRepository.GetUser(User.Identity.GetUserId());
        //    EntryVM model = new EntryVM();

        //    model.PicPath = user.PicturePath;

        //    return View(model);
        //}
    }
}