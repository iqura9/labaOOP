using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        Table table = new Table();
        public Form1()
        {
            InitializeComponent();
            InitializeDataGridView(8, 8);
        }
        private void InitializeDataGridView(int rows, int columns)
        {
            dataGridView1.ColumnHeadersVisible = true;
            dataGridView1.RowHeadersVisible = true;
            dataGridView1.ColumnCount = columns;
            for (int i = 0; i < columns; i++)
            {
                string columnName = Converter.To26System(i);
                dataGridView1.Columns[i].Name = columnName;
                dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            for (int i = 0; i < rows; i++)
            {
                dataGridView1.Rows.Add("");
                dataGridView1.Rows[i].HeaderCell.Value = (i).ToString();
            }
            dataGridView1.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
            // Table.setTable(columns, rows);
            table.setTable(columns, rows);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int col = dataGridView1.SelectedCells[0].ColumnIndex;
            int row = dataGridView1.SelectedCells[0].RowIndex;
            string expression = Table.grid[row][col].expression;
            string value = Table.grid[row][col].value;
            textBox.Text = expression;
            textBox.Focus();

        }

        

        private void Row__add_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            if(dataGridView1.Columns.Count == 0)
            {
                MessageBox.Show("There are no columns!");
                return;
            }
            dataGridView1.Rows.Add(row);
            dataGridView1.Rows[table.rowCount].HeaderCell.Value = (table.rowCount).ToString();
            table.AddRow(dataGridView1);
        }

        private void Row__remove_Click(object sender, EventArgs e)
        {
            if (!table.DeleteRow(dataGridView1)) return;
            dataGridView1.Rows.RemoveAt(table.rowCount);
        }

        private void Column__add_Click(object sender, EventArgs e)
        {
            string name = Converter.To26System(table.colCount);
            dataGridView1.Columns.Add(name, name);
            table.AddColumn(dataGridView1);
        }

        private void Column__remove_Click(object sender, EventArgs e)
        {
            if (!table.DeleteColumn(dataGridView1)) return;
            dataGridView1.Columns.RemoveAt(table.colCount);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            int col = dataGridView1.SelectedCells[0].ColumnIndex;
            int row = dataGridView1.SelectedCells[0].RowIndex;
            string expression = textBox.Text;
            if (expression == "") return;
            table.ChangeCellWithAllPointers(row, col, expression, dataGridView1);
            dataGridView1[col, row].Value = Table.grid[row][col].value;
        }
    }
}