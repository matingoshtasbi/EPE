namespace EPE.Presention.Forms.PerformanceEvaluate
{
    partial class PerformanceEvaluateSelectResultForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PerformanceEvaluateSelectResultForm));
            this.DeleteBtb = new System.Windows.Forms.Button();
            this.ViewBtb = new System.Windows.Forms.Button();
            this.ResultGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.ResultGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // DeleteBtb
            // 
            this.DeleteBtb.Enabled = false;
            this.DeleteBtb.Location = new System.Drawing.Point(724, 551);
            this.DeleteBtb.Name = "DeleteBtb";
            this.DeleteBtb.Size = new System.Drawing.Size(178, 79);
            this.DeleteBtb.TabIndex = 6;
            this.DeleteBtb.Text = "حذف";
            this.DeleteBtb.UseVisualStyleBackColor = true;
            this.DeleteBtb.Click += new System.EventHandler(this.DeleteBtb_Click);
            // 
            // ViewBtb
            // 
            this.ViewBtb.Location = new System.Drawing.Point(908, 551);
            this.ViewBtb.Name = "ViewBtb";
            this.ViewBtb.Size = new System.Drawing.Size(178, 79);
            this.ViewBtb.TabIndex = 5;
            this.ViewBtb.Text = "مشاهده";
            this.ViewBtb.UseVisualStyleBackColor = true;
            this.ViewBtb.Click += new System.EventHandler(this.ViewBtb_Click);
            // 
            // ResultGrid
            // 
            this.ResultGrid.AllowUserToAddRows = false;
            this.ResultGrid.AllowUserToDeleteRows = false;
            this.ResultGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ResultGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ResultGrid.Location = new System.Drawing.Point(12, 12);
            this.ResultGrid.MultiSelect = false;
            this.ResultGrid.Name = "ResultGrid";
            this.ResultGrid.ReadOnly = true;
            this.ResultGrid.RowHeadersWidth = 51;
            this.ResultGrid.RowTemplate.Height = 29;
            this.ResultGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ResultGrid.Size = new System.Drawing.Size(1074, 337);
            this.ResultGrid.TabIndex = 4;
            this.ResultGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ResultGrid_CellClick);
            this.ResultGrid.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.ResultGrid_ColumnHeaderMouseClick);
            // 
            // PerformanceEvaluateSelectResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1098, 642);
            this.Controls.Add(this.DeleteBtb);
            this.Controls.Add(this.ViewBtb);
            this.Controls.Add(this.ResultGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PerformanceEvaluateSelectResultForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "صفحه ی انتخاب کارمند برای مشاهده ی نتایج ارزیابی";
            this.Load += new System.EventHandler(this.PerformanceEvaluateSelectResultForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ResultGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button DeleteBtb;
        private Button ViewBtb;
        private DataGridView ResultGrid;
    }
}