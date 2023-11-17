namespace EPE.Presention.Forms.MasterData
{
    partial class AddUpdateEvaluatedItemForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddUpdateEvaluatedItemForm));
            this.MeritItemCombo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.MeritCombo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CriterionScoreTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ImportanceFactorTxt = new System.Windows.Forms.TextBox();
            this.SubmitBtn = new System.Windows.Forms.Button();
            this.EvaluationItemCombo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // MeritItemCombo
            // 
            this.MeritItemCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MeritItemCombo.Enabled = false;
            this.MeritItemCombo.FormattingEnabled = true;
            this.MeritItemCombo.Location = new System.Drawing.Point(114, 152);
            this.MeritItemCombo.Name = "MeritItemCombo";
            this.MeritItemCombo.Size = new System.Drawing.Size(220, 28);
            this.MeritItemCombo.TabIndex = 23;
            this.MeritItemCombo.SelectedIndexChanged += new System.EventHandler(this.MeritItemCombo_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 20);
            this.label4.TabIndex = 22;
            this.label4.Text = "آیتم شایستگی";
            // 
            // MeritCombo
            // 
            this.MeritCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MeritCombo.FormattingEnabled = true;
            this.MeritCombo.Location = new System.Drawing.Point(114, 103);
            this.MeritCombo.Name = "MeritCombo";
            this.MeritCombo.Size = new System.Drawing.Size(220, 28);
            this.MeritCombo.TabIndex = 21;
            this.MeritCombo.SelectedIndexChanged += new System.EventHandler(this.MeritCombo_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 20);
            this.label3.TabIndex = 20;
            this.label3.Text = "نوع شایستگی";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 20);
            this.label2.TabIndex = 19;
            this.label2.Text = "نمره ملاک";
            // 
            // CriterionScoreTxt
            // 
            this.CriterionScoreTxt.Location = new System.Drawing.Point(114, 55);
            this.CriterionScoreTxt.Name = "CriterionScoreTxt";
            this.CriterionScoreTxt.Size = new System.Drawing.Size(220, 27);
            this.CriterionScoreTxt.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 20);
            this.label1.TabIndex = 17;
            this.label1.Text = "ضریب اهمیت";
            // 
            // ImportanceFactorTxt
            // 
            this.ImportanceFactorTxt.Location = new System.Drawing.Point(114, 12);
            this.ImportanceFactorTxt.Name = "ImportanceFactorTxt";
            this.ImportanceFactorTxt.Size = new System.Drawing.Size(220, 27);
            this.ImportanceFactorTxt.TabIndex = 16;
            // 
            // SubmitBtn
            // 
            this.SubmitBtn.Location = new System.Drawing.Point(355, 238);
            this.SubmitBtn.Name = "SubmitBtn";
            this.SubmitBtn.Size = new System.Drawing.Size(158, 71);
            this.SubmitBtn.TabIndex = 15;
            this.SubmitBtn.Text = "ثبت";
            this.SubmitBtn.UseVisualStyleBackColor = true;
            this.SubmitBtn.Click += new System.EventHandler(this.SubmitBtn_Click);
            // 
            // EvaluationItemCombo
            // 
            this.EvaluationItemCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EvaluationItemCombo.Enabled = false;
            this.EvaluationItemCombo.FormattingEnabled = true;
            this.EvaluationItemCombo.Location = new System.Drawing.Point(114, 200);
            this.EvaluationItemCombo.Name = "EvaluationItemCombo";
            this.EvaluationItemCombo.Size = new System.Drawing.Size(220, 28);
            this.EvaluationItemCombo.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 203);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 20);
            this.label5.TabIndex = 24;
            this.label5.Text = "آیتم ارزیابی";
            // 
            // AddUpdateEvaluatedItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 323);
            this.Controls.Add(this.EvaluationItemCombo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.MeritItemCombo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.MeritCombo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CriterionScoreTxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ImportanceFactorTxt);
            this.Controls.Add(this.SubmitBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AddUpdateEvaluatedItemForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.AddUpdateEvaluatedItemForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox MeritItemCombo;
        private Label label4;
        private ComboBox MeritCombo;
        private Label label3;
        private Label label2;
        private TextBox CriterionScoreTxt;
        private Label label1;
        private TextBox ImportanceFactorTxt;
        private Button SubmitBtn;
        private ComboBox EvaluationItemCombo;
        private Label label5;
    }
}