using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    //static: not able to new
    public static class Messages
    {
        public static string ProductAdded = "Product added successfully";
        public static string ProductNameInvalid = "Product name invalid";
        internal static string MaintenanceTime="System is maintaining";
        internal static string ProductsListed="Products listed.";
    }
}
