using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.ViewModels
{
    public class CategoryVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<CategoryVM> Categories { get; set; }

        public string IsCategory { get; set; }

        public string IsNotCategory { get; set; }

        public int EntryCategoryID { get; set; }
    }
}