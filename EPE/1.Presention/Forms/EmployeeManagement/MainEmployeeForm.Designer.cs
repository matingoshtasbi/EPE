namespace EPE.Presention.Forms
{
    partial class MainEmployeeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainEmployeeForm));
            this.EmployeeGrid = new System.Windows.Forms.DataGridView();
            this.AddEmployeeBtb = new System.Windows.Forms.Button();
            this.UpdateEmployeeBtb = new System.Windows.Forms.Button();
            this.DeleteEmployeeBtb = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.EmployeeGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // EmployeeGrid
            // 
            this.EmployeeGrid.AllowUserToAddRows = false;
            this.EmployeeGrid.AllowUserToDeleteRows = false;
            this.EmployeeGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.EmployeeGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.EmployeeGrid.Location = new System.Drawing.Point(12, 12);
            this.EmployeeGrid.MultiSelect = false;
            this.EmployeeGrid.Name = "EmployeeGrid";
            this.EmployeeGrid.ReadOnly = true;
            this.EmployeeGrid.RowHeadersWidth = 51;
            this.EmployeeGrid.RowTemplate.Height = 29;
            this.EmployeeGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.EmployeeGrid.Size = new System.Drawing.Size(1074, 337);
            this.EmployeeGrid.TabIndex = 0;
            this.EmployeeGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.EmployeeGrid_CellClick);
            this.EmployeeGrid.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.EmployeeGrid_ColumnHeaderMouseClick);
            this.EmployeeGrid.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.EmployeeGrid_DataBindingComplete);
            // 
            // AddEmployeeBtb
            // 
            this.AddEmployeeBtb.Location = new System.Drawing.Point(908, 551);
            this.AddEmployeeBtb.Name = "AddEmployeeBtb";
            this.AddEmployeeBtb.Size = new System.Drawing.Size(178, 79);
            this.AddEmployeeBtb.TabIndex = 1;
            this.AddEmployeeBtb.Text = "افزودن کارمند";
            this.AddEmployeeBtb.UseVisualStyleBackColor = true;
            this.AddEmployeeBtb.Click += new System.EventHandler(this.AddEmployeeBtb_Click);
            // 
            // UpdateEmployeeBtb
            // 
            this.UpdateEmployeeBtb.Enabled = false;
            this.UpdateEmployeeBtb.Location = new System.Drawing.Point(724, 551);
            this.UpdateEmployeeBtb.Name = "UpdateEmployeeBtb";
            this.UpdateEmployeeBtb.Size = new System.Drawing.Size(178, 79);
            this.UpdateEmployeeBtb.TabIndex = 2;
            this.UpdateEmployeeBtb.Text = "ویرایش کارمند";
            this.UpdateEmployeeBtb.UseVisualStyleBackColor = true;
            this.UpdateEmployeeBtb.Click += new System.EventHandler(this.UpdateEmployeeBtb_Click);
            // 
            // DeleteEmployeeBtb
            // 
            this.DeleteEmployeeBtb.Enabled = false;
            this.DeleteEmployeeBtb.Location = new System.Drawing.Point(540, 551);
            this.DeleteEmployeeBtb.Name = "DeleteEmployeeBtb";
            this.DeleteEmployeeBtb.Size = new System.Drawing.Size(178, 79);
            this.DeleteEmployeeBtb.TabIndex = 3;
            this.DeleteEmployeeBtb.Text = "حذف کارمند";
            this.DeleteEmployeeBtb.UseVisualStyleBackColor = true;
            this.DeleteEmployeeBtb.Click += new System.EventHandler(this.DeleteEmployeeBtb_Click);
            // 
            // MainEmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1098, 642);
            this.Controls.Add(this.DeleteEmployeeBtb);
            this.Controls.Add(this.UpdateEmployeeBtb);
            this.Controls.Add(this.AddEmployeeBtb);
            this.Controls.Add(this.EmployeeGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainEmployeeForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "صفحه ی کارمندان";
            this.Load += new System.EventHandler(this.MainEmployeeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.EmployeeGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView EmployeeGrid;
        private Button AddEmployeeBtb;
        private Button UpdateEmployeeBtb;
        private Button DeleteEmployeeBtb;
    }
}