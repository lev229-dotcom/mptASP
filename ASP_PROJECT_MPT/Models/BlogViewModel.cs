using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_PROJECT_MPT.Models
{
    public class BlogViewModel
    {
        public IEnumerable<Post> Posts { get; set; }
        public BlogFilterViewModel BlogFilterViewModel { get; set; }
    }
}

