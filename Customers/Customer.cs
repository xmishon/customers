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
        int customersAmount = 4;
        int customerNumber;
        public delegate int GetItemsDel(int num);
        GetItemsDel del;
        public delegate void OutputDel(int custNum, int purchasesAmount, int itemsAmount);
        public OutputDel outpDel;

        public Customer(int i, Storage st, int custAmount)
        {
            customerNumber = i;
            currItemsAmount = 0;
            customersAmount = custAmount;
            sumItemsAmount = 0;
            del = new GetItemsDel(st.GetItems);
        }

        public void TakeAnItems(Random r)
        {
            currItemsAmount = r.Next(0, 10); 
        }

        public void MakeAPurchase(int[] purchasesAmount)
        {
            int corr = del(currItemsAmount);
            sumItemsAmount += currItemsAmount;
            purchasesAmount[customerNumber]++;
            if (corr < 0)
            {
                sumItemsAmount -= Math.Abs(corr);
                Storage.f = false;
            }
            else if (corr == 0)
            {
                purchasesAmount[customerNumber]--;
                Storage.f = false;
            }
        }

        public void Work(Object parr)
        {
            Parametres par = parr as Parametres;
            while (Storage.f)
            {
                Thread.Sleep(1);
                TakeAnItems(par.r);
                int t = 0;
                for (int i = 0; i < customersAmount; i++)
                    t = (par.purchasesAmount[customerNumber] - par.purchasesAmount[i]) > t ? (par.purchasesAmount[customerNumber] - par.purchasesAmount[i]) : t;
                if (t <= 0)
                    MakeAPurchase(par.purchasesAmount);
            }

            outpDel(customerNumber, par.purchasesAmount[customerNumber], sumItemsAmount);            
        }
    }

    public class Parametres
    {
        public Random r;
        public int[] purchasesAmount;
    }

}
