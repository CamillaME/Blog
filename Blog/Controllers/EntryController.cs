using Blog.DAL;
using Blog.Models;
using Blog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace Blog.Controllers
{
    //https://stackoverflow.com/questions/22591252/asp-net-mvc4-restrict-all-pages-for-a-non-logged-user
    [Authorize]
    public class EntryController : Controller
    {
        // GET: Entry
        public ActionResult Index()
        {
            EntryRepository entryRepository = new EntryRepository();

            //https://stackoverflow.com/questions/22624470/get-current-user-id-in-asp-net-identity-2-0
            List<EntryModel> entries = entryRepository.GetAllEntries(User.Identity.GetUserId());

            List<EntryVM> entriesVms = new List<EntryVM>();

            UserRepository userRepository = new UserRepository();

            EntryCategoryRepository entryCategoryRepository = new EntryCategoryRepository();

            CategoryRepository categoryRepository = new CategoryRepository();

            List<EntryCategoryVM> entryCategoryVms = new List<EntryCategoryVM>();

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
                entryVM.UserID = entry.UserID;
                entryVM.UserName = user.UserName;

                List<EntryCategoryModel> entryCategories = entryCategoryRepository.GetEntryCategories(entry.EntryID);

                foreach (EntryCategoryModel entryCategory in entryCategories)
                {
                    CategoryModel categoryModel = categoryRepository.GetCategory(entryCategory.CategoryID);
                    entryVM.CategoryNames.Add(categoryModel.Name);
                }

                entriesVms.Add(entryVM);
            }

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

        public ActionResult CreateEntry()
        {
            //CategoryRepository categoryRepository = new CategoryRepository();

            //List<CategoryModel> categories = categoryRepository.GetCategories();

            //List<CategoryVM> categoryVms = new List<CategoryVM>();

            EntryVM model = new EntryVM();
            model.Result = "";
            model.Title = "";
            model.Text = "";
            model.IsPublished = false;
            model.ResultVisble = "display: none";

            //foreach (CategoryModel category in categories)
            //{
            //    CategoryVM categoryVM = new CategoryVM();
            //    categoryVM.Id = category.Id;
            //    categoryVM.Name = category.Name;
            //    categoryVM.Description = category.Description;
            //    categoryVms.Add(categoryVM);
            //}

            //model.Categories = categoryVms;

            return View(model);
        }

        [HttpPost]
        //https://msdn.microsoft.com/en-us/library/hh882339.aspx
        [ValidateInput(false)]
        public ActionResult CreateEntry(EntryVM model)
        {
            EntryModel entry = new EntryModel();

            if (model.Title.Contains("<"))
            {
                model.ResultVisble = "display: block";
                model.Result = "Du kan ikke skrive HTML eller JavaScript i titlen...";
                model.Title = "";
                model.Text = model.Text;
                return View(model);
            }
            else if ((model.Text != null && model.Text.Contains("<script")) ||
                model.Text != null && model.Text.Contains("&lt;script"))
            {
                model.ResultVisble = "display: block";
                model.Result = "Du kan ikke skrive JavaScript i indlæget...";
                model.Title = model.Title;
                model.Text = "";
                return View(model);
            }
            else
            {
                entry.EntryTitle = model.Title;
                entry.EntryText = model.Text;
                entry.EntryDate = DateTime.Now;
                entry.EntryIsPublished = model.IsPublished;
                entry.UserID = User.Identity.GetUserId();
                EntryRepository entryRepository = new EntryRepository();
                entryRepository.CreateEntry(entry);

                //https://stackoverflow.com/questions/31488987/redirecttoaction-with-model-and-list-properties/31489079#31489079
                return RedirectToAction("Index", "EntryCategory", new { id = entry.EntryID });
            }
        }

        public ActionResult EditEntry(int id)
        {
            EntryRepository entryRepository = new EntryRepository();
            EntryModel entry = entryRepository.GetEntry(id);

            EntryVM model = new EntryVM();

            model.Id = entry.EntryID;
            model.Title = entry.EntryTitle;
            model.Text = entry.EntryText;
            model.IsPublished = entry.EntryIsPublished;
            model.Date = entry.EntryDate;

            if (model.IsPublished == true)
            {
                model.Checked = "checked";
            }
            else
            {
                model.Checked = "";
            }

            return View(model);
        }

        [HttpPost]
        //https://msdn.microsoft.com/en-us/library/hh882339.aspx
        [ValidateInput(false)]
        public ActionResult EditEntry(EntryVM model)
        {
            EntryModel entry = new EntryModel();

            if (model.Title.Contains("<"))
            {
                model.ResultVisble = "display: block";
                model.Result = "Du kan ikke skrive HTML eller JavaScript i titlen...";
                model.Title = "";
                model.Text = model.Text;
                return View(model);
            }
            else if ((model.Text != null && model.Text.Contains("<script")) ||
                model.Text != null && model.Text.Contains("&lt;script"))
            {
                model.ResultVisble = "display: block";
                model.Result = "Du kan ikke skrive JavaScript i indlæget...";
                model.Title = model.Title;
                model.Text = "";
                return View(model);
            }
            else
            {
                entry.EntryID = model.Id;
                entry.EntryTitle = model.Title;
                entry.EntryText = model.Text;

                EntryRepository entryRepository1 = new EntryRepository();
                EntryModel entry1 = entryRepository1.GetEntry(entry.EntryID);

                if (entry1.EntryIsPublished == true && model.IsPublished)
                {
                    entry.EntryDate = model.Date;
                }
                else if (entry.EntryIsPublished == false && model.IsPublished)
                {
                    entry.EntryDate = DateTime.Now;
                }
                else
                {
                    entry.EntryDate = DateTime.Now;
                }

                entry.EntryIsPublished = model.IsPublished;

                EntryRepository entryRepository = new EntryRepository();
                entryRepository.UpdateEntry(entry);

                //https://stackoverflow.com/questions/31488987/redirecttoaction-with-model-and-list-properties/31489079#31489079
                return RedirectToAction("Index", "EntryCategory", new { id = entry.EntryID });
            }
        }

        public ActionResult ShowEntry(int id)
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

        public ActionResult DeleteEntry(int id)
        {
            EntryRepository entryRepository = new EntryRepository();
            EntryCategoryRepository entryCategoryRepository = new EntryCategoryRepository();

            List<EntryCategoryModel> entryCategories = entryCategoryRepository.GetEntryCategories(id);

            foreach (EntryCategoryModel entryCategory in entryCategories)
            {
                entryCategoryRepository.DeleteEntryCategory(entryCategory.EntryCategoryID);
            }

            entryRepository.DeleteEntry(id);

            return RedirectToAction("Index");

        }
    }
}