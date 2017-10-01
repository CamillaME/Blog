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
                entryVM.Date = entry.EntryDate;
                entryVM.IsPublished = entry.EntryIsPublished;
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

        [HttpPost]
        public ActionResult CreateEntry(EntryVM model)
        {
            EntryModel entry = new EntryModel();
            entry.EntryTitle = model.Title;
            entry.EntryText = model.Text;
<<<<<<< HEAD
            entry.EntryDate = model.Date;
            entry.EntryIsPublished = model.IsPublished;
            EntryRepository entryRepository = new EntryRepository();
            entryRepository.CreateEntry(entry);
=======
            entry.EntryDate = DateTime.Now;
            entry.EntryIsPublished = false;

            EntryRepository entryRepository = new EntryRepository();

            entryRepository.CreateEntry(entry);

>>>>>>> 60a2bec1624401b5e34a22ec0ca4cbd2b711d0fc
            return RedirectToAction("Index");
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
        public ActionResult EditEntry(EntryVM model)
        {
            EntryModel entry = new EntryModel();

            entry.EntryID = model.Id;
            entry.EntryTitle = model.Title;
            entry.EntryText = model.Text;
            entry.EntryIsPublished = model.IsPublished;
            entry.EntryDate = model.Date;

            EntryRepository entryRepository = new EntryRepository();
            entryRepository.UpdateEntry(entry);
            return RedirectToAction("Index");
        }

<<<<<<< HEAD
        public ActionResult DeleteEntry(int id)
        {
            EntryRepository entryRepository = new EntryRepository();
            entryRepository.DeleteEntry(id);
            return RedirectToAction("Index");
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
=======
        public ActionResult Delete(int id)
        {
            EntryRepository entryRepository = new EntryRepository();

            entryRepository.DeleteEntry(id);

            return RedirectToAction("Index");
>>>>>>> 60a2bec1624401b5e34a22ec0ca4cbd2b711d0fc
        }
    }
}