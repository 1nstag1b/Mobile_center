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

        public void Add()
        {
            string[] row = null;

            formEditor add = new formEditor("Добавление", dataGrid.Name);

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

            string[] row = dataGrid.Rows[index].Cells.Cast<DataGridViewTextBoxCell>().Select(cell => cell.Value.ToString()).ToArray();
            formEditor edit = new formEditor("Изменение", dataGrid.Name, row);
            
            if (edit.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                row = (string[])edit.Tag;

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
