using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customers
{
    public class Customer
    {
        int currItemsAmount;
        int purchaseAmount;
        int customerNumber;
        public delegate int GetItemsDel(int num);
        GetItemsDel del;

        public Customer(int i, Storage st)
        {
            customerNumber = i;
            currItemsAmount = 0;
            purchaseAmount = 0;
            del = new GetItemsDel(st.GetItems);
        }

        public void TakeAnItem(Random r)
        {
            purchaseAmount = r.Next(0, 10); 
        }

        public void MakeAPurchase(Storage st)
        {
            int corr = del(currItemsAmount);
        }
    }
}
