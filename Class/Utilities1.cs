using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace FypWeb.Class
{
    public static class Utilities1
    {
        
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString.ToString();
        }
    }
}