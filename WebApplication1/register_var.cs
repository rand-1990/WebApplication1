using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class register_var
    {
        public string username { set; get; }
        public string email { set; get; }
        public string salt { set; get; }
        public string verifier { set; get; }
    }
}