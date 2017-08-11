using System;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Customers
{
    public partial class Form1 : Form
    {
        
        Storage st;
        List<Customer> customs;
        List<Thread> threads;
        Parametres par;
        const int customersAmount = 10;

        public Form1()
        {
            InitializeComponent();
            par = new Parametres();
            par.r = new Random(System.DateTime.Now.Millisecond);
            st = new Storage();
            customs = new List<Customer>();
            threads = new List<Thread>();
            par.purchasesAmount = new int[customersAmount];
            for (int i = 0; i < customersAmount; i++)
                par.purchasesAmount[i] = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            for (int i = 0; i < customersAmount; i++)
            {
                customs.Add(new Customer(i, st, customersAmount));
                customs[i].outpDel = new Customer.OutputDel(PrintResults);
            }
                        
            for (int i = 0; i < customersAmount; i++)
            {
                threads.Add(new Thread(new ParameterizedThreadStart(customs[i].Work)));
            }

            for (int i = 0; i < customersAmount; i++)
                threads[i].Start(par);
        }

        private void PrintResults(int custID, int custPurchases, int itemsAmount)
        {
            Action action = () => { textBox1.Text += "Customer " + custID + " have made " + custPurchases + " purchases and bought " + itemsAmount + " items." + Environment.NewLine; };
            Invoke(action);
        }
    }
}
