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
        private void viewProduct()
        {
            this.Text += " товара";
            dataGridView1.ColumnCount = 1;
            dataGridView1.RowCount = 4;

            dataGridView1.Rows[0].HeaderCell.Value = "Название";
            dataGridView1.Rows[1].HeaderCell.Value = "Производитель";
            dataGridView1.Rows[2].HeaderCell.Value = "Тип устройства";
            dataGridView1.Rows[3].HeaderCell.Value = "Цена";
        }

        private void viewService()
        {
            this.Text += " услуги";
            dataGridView1.ColumnCount = 1;
            dataGridView1.RowCount = 4;

            //dataGridView1.Rows[0].HeaderCell.Value = "";
            //dataGridView1.Rows[1].HeaderCell.Value = "";
            //dataGridView1.Rows[2].HeaderCell.Value = "";
            //dataGridView1.Rows[3].HeaderCell.Value = "";
        }

        private void viewCustomer()
        {
            this.Text += " покупателя";
            dataGridView1.ColumnCount = 1;
            dataGridView1.RowCount = 4;

            //dataGridView1.Rows[0].HeaderCell.Value = "";
            //dataGridView1.Rows[1].HeaderCell.Value = "";
            //dataGridView1.Rows[2].HeaderCell.Value = "";
            //dataGridView1.Rows[3].HeaderCell.Value = "";
        }

        private void viewStaff()
        {
            this.Text += " персонала";
            dataGridView1.ColumnCount = 1;
            dataGridView1.RowCount = 4;

            //dataGridView1.Rows[0].HeaderCell.Value = "";
            //dataGridView1.Rows[1].HeaderCell.Value = "";
            //dataGridView1.Rows[2].HeaderCell.Value = "";
            //dataGridView1.Rows[3].HeaderCell.Value = "";
        }

        public formEditor(string name, string type, string[] values = null)
        {
            InitializeComponent();
            this.Text = name;

            switch (type)
            {
                case "dataGridProducts":
                    viewProduct();
                    break;
                case "dataGridServices":
                    viewService();
                    break;
                case "dataGridCustomers":
                    viewCustomer();
                    break;
                case "dataGridStaff":
                    viewStaff();
                    break;
            }

            int h = dataGridView1.Rows[0].Height * dataGridView1.RowCount;
            ClientSize = new Size(Width, h + panel2.Height + 3);

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
