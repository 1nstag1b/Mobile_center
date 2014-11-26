using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MobileCenter
{
    public partial class mainForm : Form
    {
        public void showChildForm(int n)
        {
            if (ActiveMdiChild != null)
                ActiveMdiChild.Hide();

            switch (n)
            {
                case 1:
                    Program.productsForm.Show();
                    break;
                case 2:
                    Program.servicesForm.Show();
                    break;
                case 3:
                    Program.customersForm.Show();
                    break;
                case 4:
                    Program.staffForm.Show();
                    break;
            }
        }

        public mainForm()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }

        private void mainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showChildForm(1);
        }

        private void servicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showChildForm(2);
        }

        private void customersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showChildForm(3);
        }

        private void staffToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            showChildForm(4);
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
                ActiveMdiChild.Hide();
            Hide();
            Program.authorizationForm.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }    
    }
}
