using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.ViewModels
{
    public class EntryVM
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime Date { get; set; }

        public string Text { get; set; }

        public bool IsPublished { get; set; }

        public string Checked { get; set; }

        public List<EntryVM> Entries { get; set; }

        public string UserName { get; set; }

        public string Result { get; set; }

        public string ResultVisble { get; set; }

        public List<String> CategoryNames { get; set; }

        public EntryVM()
        {
            CategoryNames = new List<string>();
        }

        public string UserID { get; set; }

        public string PicPath { get; set; }

        public string UserDescription { get; set; }

        public int UserAge { get; set; }
    }
}