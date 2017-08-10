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

        public Storage()
        {
            Items = 100;
        }

        public int GetItems(int i)
        {
            Items -= i;
            if (Items < 0)
                return Math.Abs(Items);
            return Items;
        }
    }
}
