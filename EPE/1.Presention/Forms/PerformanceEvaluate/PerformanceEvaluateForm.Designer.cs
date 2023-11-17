namespace EPE.Presention.Forms.PerformanceEvaluate
{
    partial class PerformanceEvaluateForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PerformanceEvaluateForm));
            this.PerformanceEvaluateGrid = new System.Windows.Forms.DataGridView();
            this.ViewEmployeeBtn = new System.Windows.Forms.Button();
            this.SubmitBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.PerformanceEvaluateGrid)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PerformanceEvaluateGrid
            // 
            this.PerformanceEvaluateGrid.AllowUserToAddRows = false;
            this.PerformanceEvaluateGrid.AllowUserToDeleteRows = false;
            this.PerformanceEvaluateGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.PerformanceEvaluateGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PerformanceEvaluateGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PerformanceEvaluateGrid.Location = new System.Drawing.Point(0, 0);
            this.PerformanceEvaluateGrid.MultiSelect = false;
            this.PerformanceEvaluateGrid.Name = "PerformanceEvaluateGrid";
            this.PerformanceEvaluateGrid.RowHeadersWidth = 51;
            this.PerformanceEvaluateGrid.RowTemplate.Height = 29;
            this.PerformanceEvaluateGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.PerformanceEvaluateGrid.Size = new System.Drawing.Size(1098, 691);
            this.PerformanceEvaluateGrid.TabIndex = 1;
            this.PerformanceEvaluateGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.PerformanceEvaluateGrid_CellClick);
            this.PerformanceEvaluateGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.PerformanceEvaluateGrid_CellValueChanged);
            this.PerformanceEvaluateGrid.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.PerformanceEvaluateGrid_ColumnHeaderMouseClick);
            // 
            // ViewEmployeeBtn
            // 
            this.ViewEmployeeBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ViewEmployeeBtn.Location = new System.Drawing.Point(0, 0);
            this.ViewEmployeeBtn.Name = "ViewEmployeeBtn";
            this.ViewEmployeeBtn.Size = new System.Drawing.Size(1098, 75);
            this.ViewEmployeeBtn.TabIndex = 2;
            this.ViewEmployeeBtn.Text = "مشاهده ی اطلاعات کارمند";
            this.ViewEmployeeBtn.UseVisualStyleBackColor = true;
            this.ViewEmployeeBtn.Click += new System.EventHandler(this.ViewEmployeeBtn_Click);
            // 
            // SubmitBtn
            // 
            this.SubmitBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SubmitBtn.Location = new System.Drawing.Point(0, 75);
            this.SubmitBtn.Name = "SubmitBtn";
            this.SubmitBtn.Size = new System.Drawing.Size(1098, 75);
            this.SubmitBtn.TabIndex = 3;
            this.SubmitBtn.Text = "محاسبه";
            this.SubmitBtn.UseVisualStyleBackColor = true;
            this.SubmitBtn.Click += new System.EventHandler(this.SubmitBtn_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ViewEmployeeBtn);
            this.panel1.Controls.Add(this.SubmitBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 541);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1098, 150);
            this.panel1.TabIndex = 4;
            // 
            // PerformanceEvaluateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1098, 691);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.PerformanceEvaluateGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PerformanceEvaluateForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "صفحه ی ارزیابی عملکرد";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PerformanceEvaluateForm_FormClosed);
            this.Load += new System.EventHandler(this.PerformanceEvaluateForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PerformanceEvaluateGrid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView PerformanceEvaluateGrid;
        private Button ViewEmployeeBtn;
        private Button SubmitBtn;
        private Panel panel1;
    }
}