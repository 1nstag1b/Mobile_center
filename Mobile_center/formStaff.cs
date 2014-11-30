﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Mobile_center
{
    public partial class formStaff : Form
    {
        private DataGridManager manager;

        public formStaff(DataGridManager manager)
        {
            InitializeComponent();
            this.MdiParent = Program.formMain;
            this.Dock = DockStyle.Fill;
            this.manager = manager;
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            manager.Add();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            manager.Edit();
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            manager.Remove();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            manager.Add();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            manager.Edit();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            manager.Remove();
        }

        private void dataGridStaff_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
                manager.Remove();
        }

        private void formStaff_Activated(object sender, EventArgs e)
        {
            manager.DataGrid = dataGridStaff;
        }
    }
}
