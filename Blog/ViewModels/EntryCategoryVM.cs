using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.ViewModels
{
    public class EntryCategoryVM
    {
        public int EntryCategoryID { get; set; }

        public int EntryID { get; set; }

        public int CategoryID { get; set; }

        public List<CategoryVM> Categories { get; set; }
    }
}