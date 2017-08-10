using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Customers
{
    public class Customer
    {
        int currItemsAmount;
        int sumItemsAmount;
        int purchaseAmount;
        int customerNumber;
        public delegate int GetItemsDel(int num);
        GetItemsDel del;
        public delegate void OutputDel(int custNum, int purchasesAmount, int itemsAmount);
        public OutputDel outpDel;

        public Customer(int i, Storage st)
        {
            customerNumber = i;
            currItemsAmount = 0;
            purchaseAmount = 0;
            sumItemsAmount = 0;
            del = new GetItemsDel(st.GetItems);
        }

        public void TakeAnItems(Random r)
        {
            currItemsAmount = r.Next(0, 10); 
        }

        public void MakeAPurchase()
        {
            int corr = del(currItemsAmount);
            sumItemsAmount += currItemsAmount;
            purchaseAmount++;
            if (corr < 0)
            {
                sumItemsAmount -= Math.Abs(corr);
                Storage.f = false;
            }
            else if (corr == 0)
            {
                purchaseAmount--;
                Storage.f = false;
            }
        }

        public void Work(Object rr)
        {
            Random r = rr as Random;
            while (Storage.f)
            {
                Thread.Sleep(2);
                TakeAnItems(r);
                MakeAPurchase();
            }

            outpDel(customerNumber, purchaseAmount, sumItemsAmount);            
            //outpDel(customerNumber, purchaseAmount, sumItemsAmount);
        }
    }
}
