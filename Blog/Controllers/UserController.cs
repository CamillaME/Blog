using Blog.DAL;
using Blog.Models;
using Blog.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            EntryRepository entryRepository = new EntryRepository();

            List<EntryModel> entries = entryRepository.GetAllEntries(Url.RequestContext.RouteData.Values["id"].ToString());

            List<EntryVM> entriesVms = new List<EntryVM>();

            UserRepository userRepository = new UserRepository();

            EntryCategoryRepository entryCategoryRepository = new EntryCategoryRepository();

            CategoryRepository categoryRepository = new CategoryRepository();

            List<EntryCategoryVM> entryCategoryVms = new List<EntryCategoryVM>();

            UserModel userBlog = userRepository.GetUser(Url.RequestContext.RouteData.Values["id"].ToString());
            UserModel userLoggedIn = userRepository.GetUser(User.Identity.GetUserId());

            EntryVM model = new EntryVM();

            foreach (EntryModel entry in entries)
            {
                string userID = entryRepository.GetEntry(entry.EntryID).UserID;
                UserModel user = userRepository.GetUser(userID);

                EntryVM entryVM = new EntryVM();
                entryVM.Id = entry.EntryID;
                entryVM.Title = entry.EntryTitle;
                entryVM.Text = entry.EntryText;
                entryVM.Date = entry.EntryDate;
                entryVM.IsPublished = entry.EntryIsPublished;
                entryVM.UserName = user.UserName;

                List<EntryCategoryModel> entryCategories = entryCategoryRepository.GetEntryCategories(entry.EntryID);

                foreach (EntryCategoryModel entryCategory in entryCategories)
                {
                    CategoryModel categoryModel = categoryRepository.GetCategory(entryCategory.CategoryID);
                    entryVM.CategoryNames.Add(categoryModel.Name);
                }

                entriesVms.Add(entryVM);
            }

            if (userBlog.PicturePath != "")
            {
                model.OtherPicPath = "/" + userBlog.PicturePath;
            }
            else
            {
                model.OtherPicPath = "/Content/images/avatar-1577909_640.png";
            }

            model.OtherUserAge = userBlog.Age;

            model.OtherUserDescription = userBlog.Description;
            model.UserName = userBlog.UserName;

            if (userLoggedIn.PicturePath != "")
            {
                model.PicPath = "/" + userLoggedIn.PicturePath;
            }
            else
            {
                model.PicPath = "/Content/images/avatar-1577909_640.png";
            }

            model.UserAge = userLoggedIn.Age;

            model.UserDescription = userLoggedIn.Description;

            model.Entries = entriesVms;

            return View(model);
        }

        public ActionResult EditUser()
        {
            UserRepository userRepository = new UserRepository();
            UserModel user = userRepository.GetUser(User.Identity.GetUserId());

            UserVM model = new UserVM();

            model.Id = user.UserID;
            model.Email = user.Email;
            model.Description = user.Description;
            model.Age = user.Age;

            return View(model);
        }

        [HttpPost]
        public ActionResult EditUser(UserVM model)
        {
            UserModel user = new UserModel();
            UserRepository userRepository = new UserRepository();

            user.UserID = User.Identity.GetUserId();
            user.Email = model.Email;
            user.Description = model.Description;

            if (model.PicturePath == null)
            {
                user.PicturePath = userRepository.GetUser(user.UserID).PicturePath;
            }
            else
            {
                string dirPath = "~/Content/images/" + user.UserID + "/";

                if (!Directory.Exists(Server.MapPath(dirPath)))
                {
                    Directory.CreateDirectory(Server.MapPath(dirPath));
                }

                string savePath = Server.MapPath(dirPath + model.PicturePath.FileName);
                model.PicturePath.SaveAs(savePath);

                user.PicturePath = "Content/images/" + user.UserID + "/" + model.PicturePath.FileName;
            }

            user.Age = model.Age;

            userRepository.UpdateUser(user);

            return View(model);
        }

        public ActionResult DeleteUser(string id)
        {
            UserRepository userRepository = new UserRepository();
            CategoryRepository categoryRepository = new CategoryRepository();
            EntryRepository entryRepository = new EntryRepository();
            EntryCategoryRepository entryCategoryRepository = new EntryCategoryRepository();

            List<CategoryModel> categories = categoryRepository.GetCategories(id);
            List<EntryModel> entries = entryRepository.GetAllEntries(id);

            foreach (EntryModel entry in entries)
            {
                List<EntryCategoryModel> entryCategories = entryCategoryRepository.GetEntryCategories(entry.EntryID);

                foreach (EntryCategoryModel entryCategory in entryCategories)
                {
                    entryCategoryRepository.DeleteEntryCategory(entryCategory.EntryCategoryID);
                }

                entryRepository.DeleteEntry(entry.EntryID);
            }

            foreach (CategoryModel category in categories)
            {
                categoryRepository.DeleteCategory(category.Id);
            }

            userRepository.DeleteUser(id);

            if (Directory.Exists(Server.MapPath("~/Content/images/" + id + "/")))
            {
                DirectoryInfo info = new DirectoryInfo(Server.MapPath("~/Content/images/" + id + "/"));
                info.GetFiles("*", SearchOption.AllDirectories).ToList().ForEach(file => file.Delete());
                Directory.Delete(Server.MapPath("~/Content/images/" + id + "/"));
            }

            return RedirectToAction("Register", "Account");
        }
    }
}