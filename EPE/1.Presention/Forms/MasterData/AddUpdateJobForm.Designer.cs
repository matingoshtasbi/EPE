namespace EPE.Presention.Forms.MasterData
{
    partial class AddUpdateJobForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddUpdateJobForm));
            this.SubmitBtn = new System.Windows.Forms.Button();
            this.JobTabControl = new System.Windows.Forms.TabControl();
            this.JobInfoTab = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.JobTxt = new System.Windows.Forms.TextBox();
            this.EvaluatedItemTab = new System.Windows.Forms.TabPage();
            this.RemoveEvaluatedItem = new System.Windows.Forms.Button();
            this.UpdateEvaluatedItem = new System.Windows.Forms.Button();
            this.AddEvaluatedItem = new System.Windows.Forms.Button();
            this.EvaluatedItemGrid = new System.Windows.Forms.DataGridView();
            this.JobTabControl.SuspendLayout();
            this.JobInfoTab.SuspendLayout();
            this.EvaluatedItemTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EvaluatedItemGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // SubmitBtn
            // 
            this.SubmitBtn.Location = new System.Drawing.Point(684, 549);
            this.SubmitBtn.Name = "SubmitBtn";
            this.SubmitBtn.Size = new System.Drawing.Size(400, 83);
            this.SubmitBtn.TabIndex = 3;
            this.SubmitBtn.Text = "ثبت";
            this.SubmitBtn.UseVisualStyleBackColor = true;
            this.SubmitBtn.Click += new System.EventHandler(this.SubmitBtn_Click);
            // 
            // JobTabControl
            // 
            this.JobTabControl.Controls.Add(this.JobInfoTab);
            this.JobTabControl.Controls.Add(this.EvaluatedItemTab);
            this.JobTabControl.Location = new System.Drawing.Point(10, 10);
            this.JobTabControl.Name = "JobTabControl";
            this.JobTabControl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.JobTabControl.RightToLeftLayout = true;
            this.JobTabControl.SelectedIndex = 0;
            this.JobTabControl.Size = new System.Drawing.Size(1078, 507);
            this.JobTabControl.TabIndex = 2;
            this.JobTabControl.SelectedIndexChanged += new System.EventHandler(this.JobTabControl_SelectedIndexChanged);
            // 
            // JobInfoTab
            // 
            this.JobInfoTab.Controls.Add(this.label1);
            this.JobInfoTab.Controls.Add(this.JobTxt);
            this.JobInfoTab.Location = new System.Drawing.Point(4, 29);
            this.JobInfoTab.Name = "JobInfoTab";
            this.JobInfoTab.Size = new System.Drawing.Size(1070, 474);
            this.JobInfoTab.TabIndex = 0;
            this.JobInfoTab.Text = "اطلاعات شرکت";
            this.JobInfoTab.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1000, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "نام شغل";
            // 
            // JobTxt
            // 
            this.JobTxt.Location = new System.Drawing.Point(578, 31);
            this.JobTxt.Name = "JobTxt";
            this.JobTxt.Size = new System.Drawing.Size(382, 27);
            this.JobTxt.TabIndex = 0;
            // 
            // EvaluatedItemTab
            // 
            this.EvaluatedItemTab.Controls.Add(this.RemoveEvaluatedItem);
            this.EvaluatedItemTab.Controls.Add(this.UpdateEvaluatedItem);
            this.EvaluatedItemTab.Controls.Add(this.AddEvaluatedItem);
            this.EvaluatedItemTab.Controls.Add(this.EvaluatedItemGrid);
            this.EvaluatedItemTab.Location = new System.Drawing.Point(4, 29);
            this.EvaluatedItemTab.Name = "EvaluatedItemTab";
            this.EvaluatedItemTab.Padding = new System.Windows.Forms.Padding(3);
            this.EvaluatedItemTab.Size = new System.Drawing.Size(1070, 474);
            this.EvaluatedItemTab.TabIndex = 1;
            this.EvaluatedItemTab.Text = "ارزش گذاری آیتم های ارزیابی موثر بر شغل";
            this.EvaluatedItemTab.UseVisualStyleBackColor = true;
            // 
            // RemoveEvaluatedItem
            // 
            this.RemoveEvaluatedItem.Enabled = false;
            this.RemoveEvaluatedItem.Location = new System.Drawing.Point(484, 389);
            this.RemoveEvaluatedItem.Name = "RemoveEvaluatedItem";
            this.RemoveEvaluatedItem.Size = new System.Drawing.Size(233, 79);
            this.RemoveEvaluatedItem.TabIndex = 7;
            this.RemoveEvaluatedItem.Text = "حذف";
            this.RemoveEvaluatedItem.UseVisualStyleBackColor = true;
            this.RemoveEvaluatedItem.Click += new System.EventHandler(this.RemoveEvaluatedItem_Click);
            // 
            // UpdateEvaluatedItem
            // 
            this.UpdateEvaluatedItem.Enabled = false;
            this.UpdateEvaluatedItem.Location = new System.Drawing.Point(245, 389);
            this.UpdateEvaluatedItem.Name = "UpdateEvaluatedItem";
            this.UpdateEvaluatedItem.Size = new System.Drawing.Size(233, 79);
            this.UpdateEvaluatedItem.TabIndex = 6;
            this.UpdateEvaluatedItem.Text = "ویرایش";
            this.UpdateEvaluatedItem.UseVisualStyleBackColor = true;
            this.UpdateEvaluatedItem.Click += new System.EventHandler(this.UpdateEvaluatedItem_Click);
            // 
            // AddEvaluatedItem
            // 
            this.AddEvaluatedItem.Location = new System.Drawing.Point(6, 389);
            this.AddEvaluatedItem.Name = "AddEvaluatedItem";
            this.AddEvaluatedItem.Size = new System.Drawing.Size(233, 79);
            this.AddEvaluatedItem.TabIndex = 1;
            this.AddEvaluatedItem.Text = "افزودن";
            this.AddEvaluatedItem.UseVisualStyleBackColor = true;
            this.AddEvaluatedItem.Click += new System.EventHandler(this.AddEvaluatedItem_Click);
            // 
            // EvaluatedItemGrid
            // 
            this.EvaluatedItemGrid.AllowUserToAddRows = false;
            this.EvaluatedItemGrid.AllowUserToDeleteRows = false;
            this.EvaluatedItemGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.EvaluatedItemGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.EvaluatedItemGrid.Location = new System.Drawing.Point(6, 6);
            this.EvaluatedItemGrid.MultiSelect = false;
            this.EvaluatedItemGrid.Name = "EvaluatedItemGrid";
            this.EvaluatedItemGrid.ReadOnly = true;
            this.EvaluatedItemGrid.RowHeadersWidth = 51;
            this.EvaluatedItemGrid.RowTemplate.Height = 29;
            this.EvaluatedItemGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.EvaluatedItemGrid.Size = new System.Drawing.Size(1058, 225);
            this.EvaluatedItemGrid.TabIndex = 0;
            this.EvaluatedItemGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.EvaluatedItemGrid_CellClick);
            this.EvaluatedItemGrid.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.EvaluatedItemGrid_ColumnHeaderMouseClick);
            this.EvaluatedItemGrid.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.EvaluatedItemGrid_DataBindingComplete);
            // 
            // AddUpdateJobForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1098, 642);
            this.Controls.Add(this.SubmitBtn);
            this.Controls.Add(this.JobTabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AddUpdateJobForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.JobForm_Load);
            this.JobTabControl.ResumeLayout(false);
            this.JobInfoTab.ResumeLayout(false);
            this.JobInfoTab.PerformLayout();
            this.EvaluatedItemTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.EvaluatedItemGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button SubmitBtn;
        private TabControl JobTabControl;
        private TabPage JobInfoTab;
        private Label label1;
        private TextBox JobTxt;
        private TabPage EvaluatedItemTab;
        private Button RemoveEvaluatedItem;
        private Button UpdateEvaluatedItem;
        private Button AddEvaluatedItem;
        private DataGridView EvaluatedItemGrid;
    }
}