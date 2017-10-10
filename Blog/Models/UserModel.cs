﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class UserModel
    {
        public string UserID { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public string Description { get; set; }

        public string PicturePath { get; set; }

        public int Age { get; set; }
    }
}