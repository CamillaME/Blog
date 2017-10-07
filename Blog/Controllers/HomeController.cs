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
    [RequireHttps]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            EntryRepository entryRepository = new EntryRepository();

            List<EntryModel> entries = entryRepository.GetAllEntries();

            List<EntryVM> entriesVms = new List<EntryVM>();

            foreach (EntryModel entry in entries)
            {
                if(entry.EntryIsPublished == true)
                {
                    EntryVM entryVM = new EntryVM();
                    entryVM.Id = entry.EntryID;
                    entryVM.Title = entry.EntryTitle;
                    entryVM.Text = entry.EntryText;
                    entryVM.Date = entry.EntryDate;
                    entryVM.IsPublished = entry.EntryIsPublished;
                    entriesVms.Add(entryVM);
                }
                else
                {
                    continue;
                }
                
            }

            EntryVM model = new EntryVM();
            model.Entries = entriesVms;
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