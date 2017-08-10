using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customers
{
    public class Storage
    {
        int Items;
        public static bool f;
        public Storage()
        {
            Items = 1000;
            f = true;
        }

        public int GetItems(int i)
        {
            Items -= i;
                return Items;
        }
    }
}
