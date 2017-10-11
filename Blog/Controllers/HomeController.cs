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
    [RequireHttps]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            EntryRepository entryRepository = new EntryRepository();

            List<EntryModel> entries = entryRepository.GetAllEntries();

            UserRepository userRepository = new UserRepository();

            List<EntryVM> entriesVms = new List<EntryVM>();

            EntryCategoryRepository entryCategoryRepository = new EntryCategoryRepository();

            CategoryRepository categoryRepository = new CategoryRepository();

            List<EntryCategoryVM> entryCategoryVms = new List<EntryCategoryVM>();

            //https://stackoverflow.com/questions/22624470/get-current-user-id-in-asp-net-identity-2-0
            UserModel userLoggedIn = userRepository.GetUser(User.Identity.GetUserId());

            foreach (EntryModel entry in entries)
            {
                string userID = entryRepository.GetEntry(entry.EntryID).UserID;
                UserModel user = userRepository.GetUser(userID);

                if (entry.EntryIsPublished == true)
                {
                    EntryVM entryVM = new EntryVM();
                    entryVM.Id = entry.EntryID;
                    entryVM.Title = entry.EntryTitle;
                    entryVM.Text = entry.EntryText;
                    entryVM.Date = entry.EntryDate;
                    entryVM.IsPublished = entry.EntryIsPublished;
                    entryVM.UserName = user.UserName;
                    entryVM.UserID = user.UserID;
                    List<EntryCategoryModel> entryCategories = entryCategoryRepository.GetEntryCategories(entry.EntryID);

                    foreach (EntryCategoryModel entryCategory in entryCategories)
                    {
                        CategoryModel categoryModel = categoryRepository.GetCategory(entryCategory.CategoryID);
                        entryVM.CategoryNames.Add(categoryModel.Name);
                    }
                    entriesVms.Add(entryVM);
                }
                else
                {
                    continue;
                }

            }

            EntryVM model = new EntryVM();
            model.Entries = entriesVms;

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

            return View(model);
        }

        public ActionResult Show(int id)
        {
            EntryRepository entryRepository = new EntryRepository();
            EntryModel entry = entryRepository.GetEntry(id);
            EntryVM model = new EntryVM();
            model.Id = entry.EntryID;
            model.Title = entry.EntryTitle;
            model.Text = entry.EntryText;
            model.IsPublished = entry.EntryIsPublished;
            model.Date = entry.EntryDate;
            return View(model);
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