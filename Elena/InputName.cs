﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Elena
{
    public partial class InputName : Form
    {
        public InputName()
        {
            InitializeComponent();
        }

        public String ReturnName()
        {
            return textBox1.Text;
        }

        internal void SetName(string name)
        {
            textBox1.Text = name;
        }
    }
}
