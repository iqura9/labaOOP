using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
      public class Table
    {
        private const int defaultCol = 30;
        private const int defaultRow = 10;
        public int colCount;
        public int rowCount;
        public static List<List<Cell>> grid = new List<List<Cell>>();
        public Dictionary<string, string> dictionary = new Dictionary<string, string>();
        public Table()
        {
            setTable(defaultCol, defaultRow);
        }
        public void setTable(int col, int row)
        {
            Clear();
            colCount = col;
            rowCount = row;
            for (int i = 0; i < rowCount; i++)
            {
                List<Cell> newRow = new List<Cell>();
                for (int j = 0; j < colCount; j++)
                {
                    newRow.Add(new Cell(i, j));
                    dictionary.Add(newRow.Last().getName(), "");
                }
                grid.Add(newRow);
            }
        }
        public void Clear()
        {
            foreach (List<Cell> list in grid)
            {
                list.Clear();
            }
            grid.Clear();
            dictionary.Clear();
            rowCount = 0;
            colCount = 0;
        }
        public void ChangeCellWithAllPointers(int row, int col, string expression, DataGridView dataGridView1)
        {
            grid[row][col].DeletePointersAndReferences();
            grid[row][col].expression = expression;
            grid[row][col].new_referencesFromThis.Clear();
            if (expression != "")
            {
                if (expression[0] != '=')
                {
                    grid[row][col].value = expression;
                    dictionary[FullName(row, col)] = expression;
                    foreach (Cell cell in grid[row][col].pointersToThis)
                    {
                        RefreshCellAndPointers(cell, dataGridView1);
                    }
                    return;
                }
            }

            string new_expression = ConvertReferences(row, col, expression);
            if (new_expression != "") new_expression = new_expression.Remove(0, 1);


            if (!grid[row][col].CheckLoop(grid[row][col].new_referencesFromThis))
            {
                MessageBox.Show("There is a loop! Change the expression.");
                grid[row][col].expression = "";
                grid[row][col].value = "0";
                dataGridView1[col, row].Value = "0";
                return;
            }

            grid[row][col].AddPointersAndReferences();
            string val = Calculate(new_expression);
            if (val == "Error")
            {
                MessageBox.Show("Error in cell " + FullName(row, col));
                grid[row][col].expression = "";
                grid[row][col].value = "0";
                dataGridView1[col, row].Value = "0";
                return;
            }

            grid[row][col].value = val;
            dictionary[FullName(row, col)] = val;
            foreach (Cell cell in grid[row][col].pointersToThis)
                RefreshCellAndPointers(cell, dataGridView1);

        }
        private string FullName(int row, int col)
        {
            Cell cell = new Cell(row, col);
            return cell.getName();
        }
        public bool RefreshCellAndPointers(Cell cell, System.Windows.Forms.DataGridView dataGridView1)
        {
            cell.new_referencesFromThis.Clear();
            string new_expression = ConvertReferences(cell.row, cell.column, cell.expression);
            new_expression = new_expression.Remove(0, 1);
            string Value = Calculate(new_expression);
            if (Value == "Error")
            {
                MessageBox.Show("Error in cell" + cell.getName());
                cell.expression = "";
                cell.value = "0";
                dataGridView1[cell.column, cell.row].Value = "0";
                return false;
            }
            grid[cell.row][cell.column].value = Value;
            dictionary[FullName(cell.row, cell.column)] = Value;
            dataGridView1[cell.column, cell.row].Value = Value;
            foreach (Cell point in cell.pointersToThis)
            {
                if (!RefreshCellAndPointers(point, dataGridView1))
                    return false;
            }
            return true;
        }
        public void RefreshReferences()
        {
            foreach (List<Cell> list in grid)
            {
                foreach (Cell cell in list)
                {
                    if (cell.referencesFromThis != null)
                        cell.referencesFromThis.Clear();
                    if (cell.new_referencesFromThis != null)
                        cell.new_referencesFromThis.Clear();
                    if (cell.expression == "")
                        continue;
                    string new_expession = cell.expression;
                    if (cell.expression[0] == '=')
                    {
                        new_expession = ConvertReferences(cell.row, cell.column, cell.expression);
                        cell.referencesFromThis.AddRange(cell.new_referencesFromThis);
                    }
                }
            }
        }
        public string ConvertReferences(int row, int col, string expr)
        {
            string cellPattern = @"[A-Z]+[@-9]+";
            Regex regex = new Regex(cellPattern, RegexOptions.IgnoreCase);
            Index nums;

            foreach (Match match in regex.Matches(expr))
            {
                if (dictionary.ContainsKey(match.Value))
                {
                    nums = Converter.From26System(match.Value);
                    grid[row][col].new_referencesFromThis.Add(grid[nums.row][nums.column]);
                }
            }
            MatchEvaluator evaluator = new MatchEvaluator(referenceToValue);
            string new_expression = regex.Replace(expr, evaluator);
            return new_expression;
        }

        public string referenceToValue(Match m)
        {
            if (dictionary.ContainsKey(m.Value))
                if (dictionary[m.Value] == "") return "0";
                else
                    return dictionary[m.Value];
            return m.Value;
        }
        public string Calculate(string expression)
        {
            string res = null;
            try
            {
                res = Convert.ToString(Calculator.Evaluate(expression));
                Console.WriteLine(res);
                if (res == "∞") res = "Division by zero error";
                return res;
            }
            catch
            {
                return "Error";
            }
        }
        public void AddRow(DataGridView dataGridView1)
        {
            List<Cell> newRow = new List<Cell>();
            for (int j = 0; j < colCount; j++)
            {
                newRow.Add(new WindowsFormsApp2.Cell(rowCount, j));
                dictionary.Add(newRow.Last().getName(), "");
            }
            grid.Add(newRow);
            RefreshReferences();
            foreach (List<Cell> list in grid)
            {
                foreach (Cell cell in list)
                {
                    if (cell.referencesFromThis != null)
                    {
                        foreach (Cell cell_ref in cell.referencesFromThis)
                        {
                            if (cell_ref.row == rowCount)
                            {
                                if (!cell_ref.pointersToThis.Contains(cell))
                                {
                                    cell_ref.pointersToThis.Add(cell);
                                }
                            }
                        }
                    }
                }
            }
            for (int j = 0; j < colCount; j++)
            {
                ChangeCellWithAllPointers(rowCount, j, "", dataGridView1);
            }
            rowCount++;
        }
        public void AddColumn(DataGridView dataGridView1)
        {
            List<Cell> newColumn = new List<Cell>();
            for (int j = 0; j < colCount; j++)
            {
                newColumn.Add(new WindowsFormsApp2.Cell(colCount, j));
                dictionary.Add(newColumn.Last().getName(), "");
            }
            grid.Add(newColumn);
            RefreshReferences();
            foreach (List<Cell> list in grid)
            {
                foreach (Cell cell in list)
                {
                    if (cell.referencesFromThis != null)
                    {
                        foreach (Cell cell_ref in cell.referencesFromThis)
                        {
                            if (cell_ref.column == colCount)
                            {
                                if (!cell_ref.pointersToThis.Contains(cell))
                                {
                                    cell_ref.pointersToThis.Add(cell);
                                }
                            }
                        }
                    }
                }
            }
            for (int j = 0; j < rowCount; j++)
            {
                ChangeCellWithAllPointers(colCount, j, "", dataGridView1);
            }
            rowCount++;
        }
        public bool DeleteRow(DataGridView dataGridView1)
        {
            List<Cell> lastRow = new List<Cell>(); //cells that have references on the last row
            List<string> notEmptyCells = new List<string>();
            if (rowCount == 0)
                return false;
            int curCount = rowCount - 1;
            for (int i = 0; i < colCount; i++)
            {
                string name = FullName(curCount, i);
                if (dictionary[name] != "0" && dictionary[name] != "" && dictionary[name] != " ")
                    notEmptyCells.Add(name);
                if (grid[curCount][i].pointersToThis.Count != 0)
                    lastRow.AddRange(grid[curCount][i].pointersToThis);
            }
            if (lastRow.Count != 0 || notEmptyCells.Count != 0)
            {
                string errorMessage = "";
                if (notEmptyCells.Count != 0)
                {
                    errorMessage = "There are not empty cells: ";
                    errorMessage += string.Join("; ", notEmptyCells.ToArray());
                    errorMessage += ' ';
                }
                if (lastRow.Count != 0)
                {
                    errorMessage += "There are cells that point to cells from current row: ";
                    foreach (Cell cell in lastRow)
                    {
                        errorMessage += string.Join(";", cell.getName());
                        errorMessage += " ";
                    }
                }
                errorMessage += "Are you sure you want to delete this row?";
                DialogResult res = MessageBox.Show(errorMessage, "Warning", MessageBoxButtons.YesNo);
                if (res == DialogResult.No) return false;
            }
            for (int i = 0; i < colCount; i++)
            {
                string name = FullName(curCount, i);
                dictionary.Remove(name);
            }
            foreach (Cell cell in lastRow)
                RefreshCellAndPointers(cell, dataGridView1);
            grid.RemoveAt(curCount);
            rowCount--;
            return true;
        }



        public bool DeleteColumn(System.Windows.Forms.DataGridView dataGridViewl)
        {
            List<Cell> lastCol = new List<Cell>(); //cells that have references on the last col
            List<string> notEmptyCells = new List<string>();
            if (colCount == 0)
                return false;
            int curCount = colCount - 1;
            for (int i = 0; i < rowCount; i++)
            {
                string name = FullName(i, curCount);
                if (dictionary[name] != "0" && dictionary[name] != "" && dictionary[name] != " ")
                    notEmptyCells.Add(name);
                if (grid[i][curCount].pointersToThis.Count != 0)
                    lastCol.AddRange(grid[i][curCount].pointersToThis);
            }
            if (lastCol.Count != 0 || notEmptyCells.Count != 0)
            {
                string errorMessage = "";
                if (notEmptyCells.Count != 0)
                {
                    errorMessage = "There are not empty cells: ";
                    errorMessage += string.Join(";", notEmptyCells.ToArray());
                }
                if (lastCol.Count != 0)
                {
                    errorMessage += "There are cells that point to cells from current column :";
                    foreach (Cell cell in lastCol)
                        errorMessage += string.Join(";", cell.getName());
                }

                errorMessage += " Are you sure you want to delete this column?";
                DialogResult res = System.Windows.Forms.MessageBox.Show(errorMessage, "Warning", MessageBoxButtons.YesNo);
                if (res == System.Windows.Forms.DialogResult.No)
                    return false;
            }
            for(int i=0;i<rowCount; i++)
            {
                string name = FullName(i, curCount);
                dictionary.Remove(name);
            }
            foreach (Cell cell in lastCol)
                RefreshCellAndPointers(cell, dataGridViewl);
            for(int i = 0; i < rowCount; i++)
            {
                grid[i].RemoveAt(curCount);
            }
            colCount--;
            return true;
        }
    }
}




