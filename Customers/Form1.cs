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
        public Random r;
        Storage st;
        List<Customer> customs;
        List<Thread> threads;

        public Form1()
        {
            InitializeComponent();
            r = new Random(System.DateTime.Now.Millisecond);
            st = new Storage();
            customs = new List<Customer>();
            threads = new List<Thread>();
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            for (int i = 0; i < 10; i++)
            {
                customs.Add(new Customer(i, st));
                customs[i].outpDel = new Customer.OutputDel(PrintResults);
            }
                        
            for (int i = 0; i < 10; i++)
            {
                threads.Add(new Thread(new ParameterizedThreadStart(customs[i].Work)));
            }

            for (int i = 0; i < 10; i++)
                threads[i].Start(r);
        }

        private void PrintResults(int custID, int custPurchases, int itemsAmount)
        {
            Action action = () => { textBox1.Text += "Customer " + custID + " have made " + custPurchases + " and bought " + itemsAmount + " items." + Environment.NewLine; };
            Invoke(action);
        }
    }
}
