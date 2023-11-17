namespace EPE.Presention.Forms.MasterData
{
    partial class MasterDataTemplateForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MasterDataTemplateForm));
            this.DeleteMasterDataBtb = new System.Windows.Forms.Button();
            this.UpdateMasterDataBtb = new System.Windows.Forms.Button();
            this.AddMasterDataBtb = new System.Windows.Forms.Button();
            this.MasterDataGrid = new System.Windows.Forms.DataGridView();
            this.OrderLbl = new System.Windows.Forms.Label();
            this.OrderTxt = new System.Windows.Forms.TextBox();
            this.TitleLbl = new System.Windows.Forms.Label();
            this.TitleTxt = new System.Windows.Forms.TextBox();
            this.TypeLbl = new System.Windows.Forms.Label();
            this.TypeCombo = new System.Windows.Forms.ComboBox();
            this.DescriptionLbl = new System.Windows.Forms.Label();
            this.DescriptionTxt = new System.Windows.Forms.RichTextBox();
            this.ClearBtn = new System.Windows.Forms.Button();
            this.TypeItemLbl = new System.Windows.Forms.Label();
            this.TypeItemCombo = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.MasterDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // DeleteMasterDataBtb
            // 
            this.DeleteMasterDataBtb.Enabled = false;
            this.DeleteMasterDataBtb.Location = new System.Drawing.Point(540, 551);
            this.DeleteMasterDataBtb.Name = "DeleteMasterDataBtb";
            this.DeleteMasterDataBtb.Size = new System.Drawing.Size(178, 79);
            this.DeleteMasterDataBtb.TabIndex = 7;
            this.DeleteMasterDataBtb.Text = "حذف";
            this.DeleteMasterDataBtb.UseVisualStyleBackColor = true;
            this.DeleteMasterDataBtb.Click += new System.EventHandler(this.DeleteMasterDataBtb_Click);
            // 
            // UpdateMasterDataBtb
            // 
            this.UpdateMasterDataBtb.Enabled = false;
            this.UpdateMasterDataBtb.Location = new System.Drawing.Point(724, 551);
            this.UpdateMasterDataBtb.Name = "UpdateMasterDataBtb";
            this.UpdateMasterDataBtb.Size = new System.Drawing.Size(178, 79);
            this.UpdateMasterDataBtb.TabIndex = 6;
            this.UpdateMasterDataBtb.Text = "ویرایش";
            this.UpdateMasterDataBtb.UseVisualStyleBackColor = true;
            this.UpdateMasterDataBtb.Click += new System.EventHandler(this.UpdateMasterDataBtb_Click);
            // 
            // AddMasterDataBtb
            // 
            this.AddMasterDataBtb.Location = new System.Drawing.Point(908, 551);
            this.AddMasterDataBtb.Name = "AddMasterDataBtb";
            this.AddMasterDataBtb.Size = new System.Drawing.Size(178, 79);
            this.AddMasterDataBtb.TabIndex = 5;
            this.AddMasterDataBtb.Text = "افزودن";
            this.AddMasterDataBtb.UseVisualStyleBackColor = true;
            this.AddMasterDataBtb.Click += new System.EventHandler(this.AddMasterDataBtb_Click);
            // 
            // MasterDataGrid
            // 
            this.MasterDataGrid.AllowUserToAddRows = false;
            this.MasterDataGrid.AllowUserToDeleteRows = false;
            this.MasterDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.MasterDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MasterDataGrid.Location = new System.Drawing.Point(12, 12);
            this.MasterDataGrid.MultiSelect = false;
            this.MasterDataGrid.Name = "MasterDataGrid";
            this.MasterDataGrid.ReadOnly = true;
            this.MasterDataGrid.RowHeadersWidth = 51;
            this.MasterDataGrid.RowTemplate.Height = 29;
            this.MasterDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.MasterDataGrid.Size = new System.Drawing.Size(1074, 337);
            this.MasterDataGrid.TabIndex = 4;
            this.MasterDataGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MasterDataGrid_CellClick);
            this.MasterDataGrid.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.MasterDataGrid_ColumnHeaderMouseClick);
            this.MasterDataGrid.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.MasterDataGrid_DataBindingComplete);
            // 
            // OrderLbl
            // 
            this.OrderLbl.AutoSize = true;
            this.OrderLbl.Location = new System.Drawing.Point(17, 459);
            this.OrderLbl.Name = "OrderLbl";
            this.OrderLbl.Size = new System.Drawing.Size(46, 20);
            this.OrderLbl.TabIndex = 17;
            this.OrderLbl.Text = "الویت";
            this.OrderLbl.Visible = false;
            // 
            // OrderTxt
            // 
            this.OrderTxt.Location = new System.Drawing.Point(91, 456);
            this.OrderTxt.Name = "OrderTxt";
            this.OrderTxt.Size = new System.Drawing.Size(235, 27);
            this.OrderTxt.TabIndex = 16;
            this.OrderTxt.Visible = false;
            // 
            // TitleLbl
            // 
            this.TitleLbl.AutoSize = true;
            this.TitleLbl.Location = new System.Drawing.Point(17, 414);
            this.TitleLbl.Name = "TitleLbl";
            this.TitleLbl.Size = new System.Drawing.Size(45, 20);
            this.TitleLbl.TabIndex = 15;
            this.TitleLbl.Text = "عنوان";
            // 
            // TitleTxt
            // 
            this.TitleTxt.Location = new System.Drawing.Point(91, 411);
            this.TitleTxt.Name = "TitleTxt";
            this.TitleTxt.Size = new System.Drawing.Size(235, 27);
            this.TitleTxt.TabIndex = 14;
            // 
            // TypeLbl
            // 
            this.TypeLbl.AutoSize = true;
            this.TypeLbl.Location = new System.Drawing.Point(17, 368);
            this.TypeLbl.Name = "TypeLbl";
            this.TypeLbl.Size = new System.Drawing.Size(31, 20);
            this.TypeLbl.TabIndex = 21;
            this.TypeLbl.Text = "نوع";
            this.TypeLbl.Visible = false;
            // 
            // TypeCombo
            // 
            this.TypeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TypeCombo.FormattingEnabled = true;
            this.TypeCombo.Location = new System.Drawing.Point(91, 365);
            this.TypeCombo.Name = "TypeCombo";
            this.TypeCombo.Size = new System.Drawing.Size(235, 28);
            this.TypeCombo.TabIndex = 20;
            this.TypeCombo.Visible = false;
            this.TypeCombo.SelectedIndexChanged += new System.EventHandler(this.TypeCombo_SelectedIndexChanged);
            // 
            // DescriptionLbl
            // 
            this.DescriptionLbl.AutoSize = true;
            this.DescriptionLbl.Location = new System.Drawing.Point(360, 414);
            this.DescriptionLbl.Name = "DescriptionLbl";
            this.DescriptionLbl.Size = new System.Drawing.Size(69, 20);
            this.DescriptionLbl.TabIndex = 23;
            this.DescriptionLbl.Text = "توضیحات";
            this.DescriptionLbl.Visible = false;
            // 
            // DescriptionTxt
            // 
            this.DescriptionTxt.Location = new System.Drawing.Point(435, 411);
            this.DescriptionTxt.Name = "DescriptionTxt";
            this.DescriptionTxt.Size = new System.Drawing.Size(651, 86);
            this.DescriptionTxt.TabIndex = 22;
            this.DescriptionTxt.Text = "";
            this.DescriptionTxt.Visible = false;
            // 
            // ClearBtn
            // 
            this.ClearBtn.Location = new System.Drawing.Point(17, 551);
            this.ClearBtn.Name = "ClearBtn";
            this.ClearBtn.Size = new System.Drawing.Size(178, 79);
            this.ClearBtn.TabIndex = 24;
            this.ClearBtn.Text = "پاک کردن";
            this.ClearBtn.UseVisualStyleBackColor = true;
            this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // TypeItemLbl
            // 
            this.TypeItemLbl.AutoSize = true;
            this.TypeItemLbl.Location = new System.Drawing.Point(360, 368);
            this.TypeItemLbl.Name = "TypeItemLbl";
            this.TypeItemLbl.Size = new System.Drawing.Size(58, 20);
            this.TypeItemLbl.TabIndex = 26;
            this.TypeItemLbl.Text = "نوع آیتم";
            this.TypeItemLbl.Visible = false;
            // 
            // TypeItemCombo
            // 
            this.TypeItemCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TypeItemCombo.Enabled = false;
            this.TypeItemCombo.FormattingEnabled = true;
            this.TypeItemCombo.Location = new System.Drawing.Point(434, 365);
            this.TypeItemCombo.Name = "TypeItemCombo";
            this.TypeItemCombo.Size = new System.Drawing.Size(235, 28);
            this.TypeItemCombo.TabIndex = 25;
            this.TypeItemCombo.Visible = false;
            // 
            // MasterDataTemplateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1098, 642);
            this.Controls.Add(this.TypeItemLbl);
            this.Controls.Add(this.TypeItemCombo);
            this.Controls.Add(this.ClearBtn);
            this.Controls.Add(this.OrderTxt);
            this.Controls.Add(this.DescriptionLbl);
            this.Controls.Add(this.DescriptionTxt);
            this.Controls.Add(this.TypeLbl);
            this.Controls.Add(this.TypeCombo);
            this.Controls.Add(this.OrderLbl);
            this.Controls.Add(this.TitleLbl);
            this.Controls.Add(this.TitleTxt);
            this.Controls.Add(this.DeleteMasterDataBtb);
            this.Controls.Add(this.UpdateMasterDataBtb);
            this.Controls.Add(this.AddMasterDataBtb);
            this.Controls.Add(this.MasterDataGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MasterDataTemplateForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.MasterDataTemplateForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MasterDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button DeleteMasterDataBtb;
        private Button UpdateMasterDataBtb;
        private Button AddMasterDataBtb;
        private DataGridView MasterDataGrid;
        private Label OrderLbl;
        private TextBox OrderTxt;
        private Label TitleLbl;
        private TextBox TitleTxt;
        private Label TypeLbl;
        private ComboBox TypeCombo;
        private Label DescriptionLbl;
        private RichTextBox DescriptionTxt;
        private Button ClearBtn;
        private Label TypeItemLbl;
        private ComboBox TypeItemCombo;
    }
}