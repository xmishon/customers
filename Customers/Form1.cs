using System;
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

        public Form1()
        {
            InitializeComponent();
            r = new Random(System.DateTime.Now.Millisecond);
        }
    }
}
