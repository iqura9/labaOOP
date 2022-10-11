namespace WindowsFormsApp2
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.textBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Row = new System.Windows.Forms.Label();
            this.Column__remove = new System.Windows.Forms.Button();
            this.Column__add = new System.Windows.Forms.Button();
            this.Row__remove = new System.Windows.Forms.Button();
            this.Row__add = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.textBox);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.Row);
            this.splitContainer1.Panel1.Controls.Add(this.Column__remove);
            this.splitContainer1.Panel1.Controls.Add(this.Column__add);
            this.splitContainer1.Panel1.Controls.Add(this.Row__remove);
            this.splitContainer1.Panel1.Controls.Add(this.Row__add);
            this.splitContainer1.Panel1.Controls.Add(this.menuStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(995, 394);
            this.splitContainer1.SplitterDistance = 58;
            this.splitContainer1.TabIndex = 0;
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(618, 28);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(365, 20);
            this.textBox.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(276, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Column";
            // 
            // Row
            // 
            this.Row.AutoSize = true;
            this.Row.Location = new System.Drawing.Point(12, 31);
            this.Row.Name = "Row";
            this.Row.Size = new System.Drawing.Size(29, 13);
            this.Row.TabIndex = 4;
            this.Row.Text = "Row";
            // 
            // Column__remove
            // 
            this.Column__remove.Location = new System.Drawing.Point(415, 26);
            this.Column__remove.Name = "Column__remove";
            this.Column__remove.Size = new System.Drawing.Size(73, 23);
            this.Column__remove.TabIndex = 3;
            this.Column__remove.Text = "Remove";
            this.Column__remove.UseVisualStyleBackColor = true;
            this.Column__remove.Click += new System.EventHandler(this.Column__remove_Click);
            // 
            // Column__add
            // 
            this.Column__add.Location = new System.Drawing.Point(334, 26);
            this.Column__add.Name = "Column__add";
            this.Column__add.Size = new System.Drawing.Size(73, 23);
            this.Column__add.TabIndex = 2;
            this.Column__add.Text = "Add";
            this.Column__add.UseVisualStyleBackColor = true;
            this.Column__add.Click += new System.EventHandler(this.Column__add_Click);
            // 
            // Row__remove
            // 
            this.Row__remove.Location = new System.Drawing.Point(160, 26);
            this.Row__remove.Name = "Row__remove";
            this.Row__remove.Size = new System.Drawing.Size(75, 23);
            this.Row__remove.TabIndex = 1;
            this.Row__remove.Text = "Remove";
            this.Row__remove.UseVisualStyleBackColor = true;
            this.Row__remove.Click += new System.EventHandler(this.Row__remove_Click);
            // 
            // Row__add
            // 
            this.Row__add.Location = new System.Drawing.Point(61, 26);
            this.Row__add.Name = "Row__add";
            this.Row__add.Size = new System.Drawing.Size(75, 23);
            this.Row__add.TabIndex = 0;
            this.Row__add.Text = "Add";
            this.Row__add.UseVisualStyleBackColor = true;
            this.Row__add.Click += new System.EventHandler(this.Row__add_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.fileToolStripMenuItem });
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(995, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.openToolStripMenuItem, this.saveToolStripMenuItem });
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(995, 332);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(512, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 21);
            this.button1.TabIndex = 8;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 394);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "MyExcel";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button button1;

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label Row;
        private System.Windows.Forms.Button Column__remove;
        private System.Windows.Forms.Button Column__add;
        private System.Windows.Forms.Button Row__remove;
        private System.Windows.Forms.Button Row__add;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
    }
}