﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MobileCenter
{
    public partial class servicesForm : Form
    {
        public servicesForm()
        {
            InitializeComponent();
            this.MdiParent = Program.mainForm;
            this.Dock = DockStyle.Fill;
        }
    }
}