using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mobile_center
{
    public class DataGridManager
    {
        private DataGridView dataGrid;

        public DataGridView DataGrid
        {
            get { return dataGrid; }
            set { dataGrid = value; }
        }

        public DataGridManager() 
        {
            dataGrid = null;
        }

        public DataGridManager(DataGridView dataGrid)
        {
            this.dataGrid = dataGrid;
        }

        private string[] getHeaders(string caption)
        {
            List<string> headers = new List<string>();

            switch (dataGrid.Name)
            {
                case "dataGridProducts":
                    headers.Add(caption + " товара");
                    break;
                case "dataGridOrders":
                    headers.Add(caption + " заказа");
                    break;
                case "dataGridCustomers":
                    headers.Add(caption + " покупателя");
                    break;
                case "dataGridStaff":
                    headers.Add(caption + " персонала");
                    break;
            }
            
            for (int i = 1; i < dataGrid.ColumnCount; i++)
            {
                headers.Add(dataGrid.Columns[i].HeaderText);
            }

            return headers.ToArray();
        }

        public void Add()
        {
            string[] row = null;

            formEditor add = new formEditor(getHeaders("Добавление"));

            if (add.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                row = (string[])add.Tag;

                //Добавление в БД
                //Если успешно, то добавляем новую строку в таблицу

                dataGrid.Rows.Add(row);
            }

            add.Dispose();  
        }

        public void Edit()
        {
            int index = dataGrid.Rows.GetFirstRow(DataGridViewElementStates.Selected);

            if (index == -1)
            {
                MessageBox.Show("Не выбрана строка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string[] values = new string[dataGrid.ColumnCount];
            for (int i = 0; i < dataGrid.ColumnCount; i++)
            {
                values[i] = dataGrid[i, index].Value.ToString();
            }

            formEditor edit = new formEditor(getHeaders("Изменение"), values);
            
            if (edit.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string[] row = (string[])edit.Tag;

                //Обновление БД
                //Если успешно, то удаляем старую строку и добавляем новую строку в таблицу
                
                dataGrid.Rows.RemoveAt(index);
                dataGrid.Rows.Insert(index, row);
            }
            edit.Dispose();
        }

        public void Remove()
        {
            int index = dataGrid.Rows.GetFirstRow(DataGridViewElementStates.Selected);

            if (index == -1)
            {
                MessageBox.Show("Не выбрана строка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Вы действительно хотите удалить эту строку?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                //Удаление из БД
                //Если успешно, то удаляем строку из таблицы 

                dataGrid.Rows.RemoveAt(index);
            }
        }
    }
}
