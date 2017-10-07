using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
    }
}