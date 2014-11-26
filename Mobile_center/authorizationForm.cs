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
    public partial class authorizationForm : Form
    {
        public authorizationForm()
        {
            InitializeComponent();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            string login = tbLogin.Text;
            string password = tbPassword.Text;

            if (login == "" || password == "")
            {
                MessageBox.Show("Error!");
                return;
            }

            tbLogin.Clear();
            tbPassword.Clear();
            Hide();
            Program.mainForm.Show();
        }
    }
}
