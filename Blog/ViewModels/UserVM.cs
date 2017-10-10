using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;

namespace Blog.ViewModels
{
    public class UserVM
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public string Description { get; set; }

        //public string PicturePath { get; set; }

        public int Age { get; set; }

        public HttpPostedFileBase PicturePath { get; set; }
    }
}