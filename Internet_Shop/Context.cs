using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internet_Shop
{
    internal class Context : Internet_shopEntities
    {
        public static Internet_shopEntities DB { get; } = new Internet_shopEntities();
    }
}
