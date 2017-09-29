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

            List<EntryModel> entries = entryRepository.GetAllEntries();

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

        public ActionResult EditEntry(int id)
        {
            EntryRepository entryRepository = new EntryRepository();
            EntryModel entry = entryRepository.GetEntry(id);

            EntryVM model = new EntryVM();

            model.Id = entry.EntryID;
            model.Title = entry.EntryTitle;
            model.Text = entry.EntryText;
            
            return View(model);
        }

        [HttpPost]
        public ActionResult EditEntry (EntryVM model)
        {
            EntryModel entry = new EntryModel();

            entry.EntryID = model.Id;
            entry.EntryTitle = model.Title;
            entry.EntryText = model.Text;

            EntryRepository entryRepository = new EntryRepository();
            entryRepository.UpdateEntry(entry);
            return RedirectToAction("Index");
        }
    }
}