using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mobile_center
{
    public partial class formEditor : Form
    {
        private void makeView(string[] headers)
        {
            dataGridView1.ColumnCount = 1;
            dataGridView1.RowCount = headers.Length - 1;

            for (int i = 1; i < headers.Length; i++)
            {
                dataGridView1.Rows[i - 1].HeaderCell.Value = headers[i];
            }
        }

        public formEditor(string[] headers, string[] values = null)
        {
            InitializeComponent();
            this.Text = headers[0];

            makeView(headers);

            int h = dataGridView1.Rows[0].Height * dataGridView1.RowCount;
            ClientSize = new Size(Width, h + panel2.Height + 4);

            if (values != null)
                for (int i = 0; i < values.Length; i++)
                {
                    dataGridView1[0, i].Value = values[i];
                }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                string[] row = new string[dataGridView1.RowCount];
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    row[i] = dataGridView1[0, i].Value.ToString();
                }

                this.Tag = row;
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Заполните пустые поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void formEditor_Shown(object sender, EventArgs e)
        {
            dataGridView1.Focus();
        }
    }
}
