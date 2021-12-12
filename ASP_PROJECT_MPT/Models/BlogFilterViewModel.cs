using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_PROJECT_MPT.Models
{
    public class BlogFilterViewModel
    { 
        public string SelectionLogin { get; private set; }

        public BlogFilterViewModel(string login)
        {
            SelectionLogin = login; 
        }
    }
}
