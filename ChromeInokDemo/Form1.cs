﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ChromeInokDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChromeForDoNet.WebInvoice.CallWebBrower(@"C:\Kingstar Winning\demo_2.html", 99999, 99999);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChromeForDoNet.WebInvoice.CallWebBrower("http://ultrasounds.com/", 99999, 99999);
        }
    }
}
