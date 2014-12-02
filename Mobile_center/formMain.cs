using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Mobile_center
{
    public partial class formMain : Form
    {
        private void showChildForm(int n)
        {
            if (ActiveMdiChild != null)
                ActiveMdiChild.Hide();

            switch (n)
            {
                case 1:
                    Program.formProducts.Show();
                    break;
                case 2:
                    Program.formOrders.Show();
                    break;
                case 3:
                    Program.formCustomers.Show();
                    break;
                case 4:
                    Program.formStaff.Show();
                    break;
            }
        }

        private void uncheckLast(ToolStripMenuItem i)
        {
            if (!i.Checked) return;

            foreach (ToolStripMenuItem item in (menuStrip1.Items[0] as ToolStripMenuItem).DropDownItems)
            {
                if (item.Checked && !item.Equals(i))
                {
                   item.Checked = false;
                   return;
                }
            }
        }

        public formMain()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }

        private void formMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showChildForm(1);
            this.Text = "Mobile Center: Товары";
            (sender as ToolStripMenuItem).Checked = true;
        }

        private void ordersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showChildForm(2);
            this.Text = "Mobile Center: Заказы";
            (sender as ToolStripMenuItem).Checked = true;
        }

        private void customersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showChildForm(3);
            this.Text = "Mobile Center: Покупатели";
            (sender as ToolStripMenuItem).Checked = true;
        }

        private void staffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showChildForm(4);
            this.Text = "Mobile Center: Персонал";
            (sender as ToolStripMenuItem).Checked = true;
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
                ActiveMdiChild.Hide();
            Hide();
            Program.formAuthorization.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void productsToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            uncheckLast(sender as ToolStripMenuItem);
        }

        private void ordersToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            uncheckLast(sender as ToolStripMenuItem);
        }

        private void customersToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            uncheckLast(sender as ToolStripMenuItem);
        }

        private void staffToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            uncheckLast(sender as ToolStripMenuItem);
        } 
    }
}
