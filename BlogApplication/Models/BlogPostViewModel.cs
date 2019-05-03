using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogApplication.Models
{
    public class BlogPostViewModel
    {
        public string UserFullName { get; set; }
        public BlogPost Post { get; set; }
        public List<Comment> Comments { get; set; }

    }
}