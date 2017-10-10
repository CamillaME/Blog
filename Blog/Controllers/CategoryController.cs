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
    [Authorize]
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            CategoryRepository categoryRepository = new CategoryRepository();

            List<CategoryModel> categories = categoryRepository.GetCategories(User.Identity.GetUserId());

            List<CategoryVM> categoryVms = new List<CategoryVM>();

            foreach (CategoryModel category in categories)
            {
                CategoryVM categoryVM = new CategoryVM();
                categoryVM.Id = category.Id;
                categoryVM.Name = category.Name;
                categoryVM.Description = category.Description;
                categoryVms.Add(categoryVM);
            }

            CategoryVM model = new CategoryVM();
            model.Categories = categoryVms;

            return View(model);
        }

        public ActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCategory(CategoryVM model)
        {
            CategoryModel category = new CategoryModel();
            category.Name = model.Name;
            category.Description = model.Description;
            category.UserID = User.Identity.GetUserId();
            CategoryRepository categoryRepository = new CategoryRepository();
            categoryRepository.CreateCategory(category);

            return RedirectToAction("Index");
        }

        public ActionResult EditCategory(int id)
        {
            CategoryRepository categoryRepository = new CategoryRepository();
            CategoryModel category = categoryRepository.GetCategory(id);

            CategoryVM model = new CategoryVM();
            model.Id = category.Id;
            model.Name = category.Name;
            model.Description = category.Description;

            return View(model);
        }

        [HttpPost]
        public ActionResult EditCategory(CategoryVM model)
        {
            CategoryModel category = new CategoryModel();
            category.Id = model.Id;
            category.Name = model.Name;
            category.Description = model.Description;
            CategoryRepository categoryRepository = new CategoryRepository();
            categoryRepository.UpdateCategory(category);

            return RedirectToAction("Index");
        }

        public ActionResult DeleteCategory(int id)
        {
            CategoryRepository categoryRepository = new CategoryRepository();

            categoryRepository.DeleteCategory(id);

            return RedirectToAction("Index");
        }
    }
}