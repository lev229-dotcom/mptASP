using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_PROJECT_MPT.Models
{
    public class FilterViewModel
    {
        public int? SelectID { get; private set; }
        public string SelectionLogin { get; private set; }
        public string SelectionEmail { get; private set; }

        public FilterViewModel(int? id, string email, string login)
        {
            SelectID = id;
            SelectionLogin = login;
            SelectionEmail = email;
        }
    }
}
