using Blog.DAL;
using Blog.Models;
using Blog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class EntryCategoryController : Controller
    {
        // GET: EntryCategory
        public ActionResult Index(int id)
        {
            CategoryRepository categoryRepository = new CategoryRepository();

            List<CategoryModel> categories = categoryRepository.GetCategories();

            List<CategoryVM> categoryVms = new List<CategoryVM>();

            EntryCategoryVM model = new EntryCategoryVM();

            EntryCategoryRepository entryCategoryRepository = new EntryCategoryRepository();

            List<EntryCategoryModel> entryCategories = entryCategoryRepository.GetEntryCategories();

            foreach (CategoryModel category in categories)
            {
                CategoryVM categoryVM = new CategoryVM();
                categoryVM.Id = category.Id;
                categoryVM.Name = category.Name;
                categoryVM.Description = category.Description;
                categoryVM.EntryCategoryID = entryCategoryRepository.GetEntryCategory(category.Id).EntryCategoryID;

                if (entryCategoryRepository.GetEntryCategory(category.Id).EntryID != id)
                {
                    categoryVM.IsCategory = "block";
                    categoryVM.IsNotCategory = "none";
                }
                else
                {
                    categoryVM.IsCategory = "none";
                    categoryVM.IsNotCategory = "block";
                }

                categoryVms.Add(categoryVM);
            }

            model.Categories = categoryVms;

            return View(model);
        }

        public ActionResult Create(EntryCategoryVM model, int id, int secondid)
        {
            EntryCategoryModel entryCategory = new EntryCategoryModel();

            entryCategory.CategoryID = secondid;
            entryCategory.EntryID = id;
            EntryCategoryRepository entryCategoryRepository = new EntryCategoryRepository();
            entryCategoryRepository.CreateEntryCategory(entryCategory);

            return RedirectToAction("Index", new { id = id });
        }

        public ActionResult Delete(int id, int secondid)
        {
            EntryCategoryRepository entryCategoryRepository = new EntryCategoryRepository();
            entryCategoryRepository.DeleteEntryCategory(secondid);
            return RedirectToAction("Index", new { id = id });
        }
    }
}