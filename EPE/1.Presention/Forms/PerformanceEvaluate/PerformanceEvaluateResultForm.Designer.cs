namespace EPE.Presention.Forms.PerformanceEvaluate
{
    partial class PerformanceEvaluateResultForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PerformanceEvaluateResultForm));
            this.PerformanceEvaluateTabControl = new System.Windows.Forms.TabControl();
            this.EmployeeInfoTab = new System.Windows.Forms.TabPage();
            this.TotalWeightedScore = new System.Windows.Forms.TextBox();
            this.TotalWeightedCriterionScoreTxt = new System.Windows.Forms.TextBox();
            this.MeritFactor = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.EvaluateDP = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.LastNameTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.FirstNameTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CodeTxt = new System.Windows.Forms.TextBox();
            this.EvaluateItemTab = new System.Windows.Forms.TabPage();
            this.EvaluateItemGrid = new System.Windows.Forms.DataGridView();
            this.MeritItemTab = new System.Windows.Forms.TabPage();
            this.MeritItemGrid = new System.Windows.Forms.DataGridView();
            this.MeritTab = new System.Windows.Forms.TabPage();
            this.MeritGrid = new System.Windows.Forms.DataGridView();
            this.PerformanceEvaluateTabControl.SuspendLayout();
            this.EmployeeInfoTab.SuspendLayout();
            this.EvaluateItemTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EvaluateItemGrid)).BeginInit();
            this.MeritItemTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MeritItemGrid)).BeginInit();
            this.MeritTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MeritGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // PerformanceEvaluateTabControl
            // 
            this.PerformanceEvaluateTabControl.Controls.Add(this.EmployeeInfoTab);
            this.PerformanceEvaluateTabControl.Controls.Add(this.EvaluateItemTab);
            this.PerformanceEvaluateTabControl.Controls.Add(this.MeritItemTab);
            this.PerformanceEvaluateTabControl.Controls.Add(this.MeritTab);
            this.PerformanceEvaluateTabControl.Location = new System.Drawing.Point(10, 12);
            this.PerformanceEvaluateTabControl.Name = "PerformanceEvaluateTabControl";
            this.PerformanceEvaluateTabControl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.PerformanceEvaluateTabControl.RightToLeftLayout = true;
            this.PerformanceEvaluateTabControl.SelectedIndex = 0;
            this.PerformanceEvaluateTabControl.Size = new System.Drawing.Size(1078, 625);
            this.PerformanceEvaluateTabControl.TabIndex = 1;
            this.PerformanceEvaluateTabControl.SelectedIndexChanged += new System.EventHandler(this.PerformanceEvaluateTabControl_SelectedIndexChanged);
            // 
            // EmployeeInfoTab
            // 
            this.EmployeeInfoTab.Controls.Add(this.TotalWeightedScore);
            this.EmployeeInfoTab.Controls.Add(this.TotalWeightedCriterionScoreTxt);
            this.EmployeeInfoTab.Controls.Add(this.MeritFactor);
            this.EmployeeInfoTab.Controls.Add(this.label6);
            this.EmployeeInfoTab.Controls.Add(this.label5);
            this.EmployeeInfoTab.Controls.Add(this.label1);
            this.EmployeeInfoTab.Controls.Add(this.label8);
            this.EmployeeInfoTab.Controls.Add(this.EvaluateDP);
            this.EmployeeInfoTab.Controls.Add(this.label4);
            this.EmployeeInfoTab.Controls.Add(this.LastNameTxt);
            this.EmployeeInfoTab.Controls.Add(this.label3);
            this.EmployeeInfoTab.Controls.Add(this.FirstNameTxt);
            this.EmployeeInfoTab.Controls.Add(this.label2);
            this.EmployeeInfoTab.Controls.Add(this.CodeTxt);
            this.EmployeeInfoTab.Location = new System.Drawing.Point(4, 29);
            this.EmployeeInfoTab.Name = "EmployeeInfoTab";
            this.EmployeeInfoTab.Size = new System.Drawing.Size(1070, 592);
            this.EmployeeInfoTab.TabIndex = 0;
            this.EmployeeInfoTab.Text = "اطلاعات فردی و شرکتی";
            this.EmployeeInfoTab.UseVisualStyleBackColor = true;
            // 
            // TotalWeightedScore
            // 
            this.TotalWeightedScore.Location = new System.Drawing.Point(89, 320);
            this.TotalWeightedScore.Name = "TotalWeightedScore";
            this.TotalWeightedScore.ReadOnly = true;
            this.TotalWeightedScore.Size = new System.Drawing.Size(215, 27);
            this.TotalWeightedScore.TabIndex = 23;
            // 
            // TotalWeightedCriterionScoreTxt
            // 
            this.TotalWeightedCriterionScoreTxt.Location = new System.Drawing.Point(562, 320);
            this.TotalWeightedCriterionScoreTxt.Name = "TotalWeightedCriterionScoreTxt";
            this.TotalWeightedCriterionScoreTxt.ReadOnly = true;
            this.TotalWeightedCriterionScoreTxt.Size = new System.Drawing.Size(215, 27);
            this.TotalWeightedCriterionScoreTxt.TabIndex = 22;
            // 
            // MeritFactor
            // 
            this.MeritFactor.AutoSize = true;
            this.MeritFactor.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.MeritFactor.Location = new System.Drawing.Point(213, 481);
            this.MeritFactor.Name = "MeritFactor";
            this.MeritFactor.Size = new System.Drawing.Size(31, 41);
            this.MeritFactor.TabIndex = 19;
            this.MeritFactor.Text = "?";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(466, 481);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(571, 41);
            this.label6.TabIndex = 18;
            this.label6.Text = "ضریب شایستگی (میانگین تمام شایستگی ها)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(783, 312);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(254, 31);
            this.label5.TabIndex = 17;
            this.label5.Text = "مجموع وزنی نمرات ملاک ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(336, 314);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 31);
            this.label1.TabIndex = 16;
            this.label1.Text = "مجموع وزنی نمرات";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(970, 203);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 20);
            this.label8.TabIndex = 15;
            this.label8.Text = "تاریخ ارزیابی";
            // 
            // EvaluateDP
            // 
            this.EvaluateDP.CustomFormat = "";
            this.EvaluateDP.Enabled = false;
            this.EvaluateDP.Location = new System.Drawing.Point(562, 198);
            this.EvaluateDP.Name = "EvaluateDP";
            this.EvaluateDP.RightToLeftLayout = true;
            this.EvaluateDP.Size = new System.Drawing.Size(376, 27);
            this.EvaluateDP.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(966, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "نام خانوادگی";
            // 
            // LastNameTxt
            // 
            this.LastNameTxt.Location = new System.Drawing.Point(562, 142);
            this.LastNameTxt.Name = "LastNameTxt";
            this.LastNameTxt.ReadOnly = true;
            this.LastNameTxt.Size = new System.Drawing.Size(376, 27);
            this.LastNameTxt.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1029, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "نام";
            // 
            // FirstNameTxt
            // 
            this.FirstNameTxt.Location = new System.Drawing.Point(562, 86);
            this.FirstNameTxt.Name = "FirstNameTxt";
            this.FirstNameTxt.ReadOnly = true;
            this.FirstNameTxt.Size = new System.Drawing.Size(376, 27);
            this.FirstNameTxt.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(986, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "کد پرسنلی";
            // 
            // CodeTxt
            // 
            this.CodeTxt.Location = new System.Drawing.Point(562, 35);
            this.CodeTxt.Name = "CodeTxt";
            this.CodeTxt.ReadOnly = true;
            this.CodeTxt.Size = new System.Drawing.Size(376, 27);
            this.CodeTxt.TabIndex = 2;
            // 
            // EvaluateItemTab
            // 
            this.EvaluateItemTab.Controls.Add(this.EvaluateItemGrid);
            this.EvaluateItemTab.Location = new System.Drawing.Point(4, 29);
            this.EvaluateItemTab.Name = "EvaluateItemTab";
            this.EvaluateItemTab.Padding = new System.Windows.Forms.Padding(3);
            this.EvaluateItemTab.Size = new System.Drawing.Size(1070, 592);
            this.EvaluateItemTab.TabIndex = 1;
            this.EvaluateItemTab.Text = "نتایج آیتم های ارزیابی";
            this.EvaluateItemTab.UseVisualStyleBackColor = true;
            // 
            // EvaluateItemGrid
            // 
            this.EvaluateItemGrid.AllowUserToAddRows = false;
            this.EvaluateItemGrid.AllowUserToDeleteRows = false;
            this.EvaluateItemGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.EvaluateItemGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.EvaluateItemGrid.Location = new System.Drawing.Point(6, 6);
            this.EvaluateItemGrid.MultiSelect = false;
            this.EvaluateItemGrid.Name = "EvaluateItemGrid";
            this.EvaluateItemGrid.ReadOnly = true;
            this.EvaluateItemGrid.RowHeadersWidth = 51;
            this.EvaluateItemGrid.RowTemplate.Height = 29;
            this.EvaluateItemGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.EvaluateItemGrid.Size = new System.Drawing.Size(1058, 580);
            this.EvaluateItemGrid.TabIndex = 0;
            // 
            // MeritItemTab
            // 
            this.MeritItemTab.Controls.Add(this.MeritItemGrid);
            this.MeritItemTab.Location = new System.Drawing.Point(4, 29);
            this.MeritItemTab.Name = "MeritItemTab";
            this.MeritItemTab.Padding = new System.Windows.Forms.Padding(3);
            this.MeritItemTab.Size = new System.Drawing.Size(1070, 592);
            this.MeritItemTab.TabIndex = 2;
            this.MeritItemTab.Text = "نتایج آیتم های شایستگی";
            this.MeritItemTab.UseVisualStyleBackColor = true;
            // 
            // MeritItemGrid
            // 
            this.MeritItemGrid.AllowUserToAddRows = false;
            this.MeritItemGrid.AllowUserToDeleteRows = false;
            this.MeritItemGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.MeritItemGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MeritItemGrid.Location = new System.Drawing.Point(6, 6);
            this.MeritItemGrid.MultiSelect = false;
            this.MeritItemGrid.Name = "MeritItemGrid";
            this.MeritItemGrid.ReadOnly = true;
            this.MeritItemGrid.RowHeadersWidth = 51;
            this.MeritItemGrid.RowTemplate.Height = 29;
            this.MeritItemGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.MeritItemGrid.Size = new System.Drawing.Size(1058, 580);
            this.MeritItemGrid.TabIndex = 2;
            // 
            // MeritTab
            // 
            this.MeritTab.Controls.Add(this.MeritGrid);
            this.MeritTab.Location = new System.Drawing.Point(4, 29);
            this.MeritTab.Name = "MeritTab";
            this.MeritTab.Padding = new System.Windows.Forms.Padding(3);
            this.MeritTab.Size = new System.Drawing.Size(1070, 592);
            this.MeritTab.TabIndex = 3;
            this.MeritTab.Text = "نتایج انواع شایستگی";
            this.MeritTab.UseVisualStyleBackColor = true;
            // 
            // MeritGrid
            // 
            this.MeritGrid.AllowUserToAddRows = false;
            this.MeritGrid.AllowUserToDeleteRows = false;
            this.MeritGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.MeritGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MeritGrid.Location = new System.Drawing.Point(6, 6);
            this.MeritGrid.MultiSelect = false;
            this.MeritGrid.Name = "MeritGrid";
            this.MeritGrid.ReadOnly = true;
            this.MeritGrid.RowHeadersWidth = 51;
            this.MeritGrid.RowTemplate.Height = 29;
            this.MeritGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.MeritGrid.Size = new System.Drawing.Size(1058, 580);
            this.MeritGrid.TabIndex = 2;
            // 
            // PerformanceEvaluateResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1098, 642);
            this.Controls.Add(this.PerformanceEvaluateTabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PerformanceEvaluateResultForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "مشاهده ی نتیجه ی ارزیابی";
            this.Load += new System.EventHandler(this.PerformanceEvaluateResultForm_Load);
            this.PerformanceEvaluateTabControl.ResumeLayout(false);
            this.EmployeeInfoTab.ResumeLayout(false);
            this.EmployeeInfoTab.PerformLayout();
            this.EvaluateItemTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.EvaluateItemGrid)).EndInit();
            this.MeritItemTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MeritItemGrid)).EndInit();
            this.MeritTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MeritGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl PerformanceEvaluateTabControl;
        private TabPage EmployeeInfoTab;
        private Label label8;
        private DateTimePicker EvaluateDP;
        private Label label4;
        private TextBox LastNameTxt;
        private Label label3;
        private TextBox FirstNameTxt;
        private Label label2;
        private TextBox CodeTxt;
        private TabPage EvaluateItemTab;
        private DataGridView EvaluateItemGrid;
        private TabPage MeritItemTab;
        private DataGridView MeritItemGrid;
        private TabPage MeritTab;
        private DataGridView MeritGrid;
        private Label label6;
        private Label label5;
        private Label label1;
        private Label MeritFactor;
        private TextBox TotalWeightedCriterionScoreTxt;
        private TextBox TotalWeightedScore;
    }
}