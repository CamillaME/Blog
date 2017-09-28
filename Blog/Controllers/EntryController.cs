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
    public class EntryController : Controller
    {
        // GET: Entry
        public ActionResult Index()
        {
            EntryRepository entryRepository = new EntryRepository();

            List<EntryModel> entries = new List<EntryModel>();

            List<EntryVM> entriesVms = new List<EntryVM>();

            foreach (EntryModel entry in entries)
            {
                EntryVM entryVM = new EntryVM();
                entryVM.Id = entry.EntryID;
                entryVM.Title = entry.EntryTitle;
                entryVM.Text = entry.EntryText;
                entriesVms.Add(entryVM);
            }

            EntryVM model = new EntryVM();
            model.Entries = entriesVms;

            return View(model);
        }

        public ActionResult CreateEntry()
        {
            return View();
        }

        public ActionResult EditEntry()
        {
            return View();
        }
    }
}