using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class EntryModel
    {
        public int EntryID { get; set; }

        public string EntryTitle { get; set; }

        public DateTime EntryDate { get; set; }

        public string EntryText { get; set; }

        public bool EntryIsPublished { get; set; }

        public string UserID { get; set; }

        public int NewID { get; set; }
    }
}