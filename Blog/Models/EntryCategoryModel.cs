using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class EntryCategoryModel
    {
        public int EntryCategoryID { get; set; }

        public int EntryID { get; set; }

        public int CategoryID { get; set; }
    }
}