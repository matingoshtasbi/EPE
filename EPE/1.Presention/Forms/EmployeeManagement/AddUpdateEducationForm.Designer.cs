namespace EPE.Presention.Forms.EmployeeManagement
{
    partial class AddUpdateEducationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddUpdateEducationForm));
            this.SubmitBtn = new System.Windows.Forms.Button();
            this.LevelCombo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.AverageTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.MinorTxt = new System.Windows.Forms.TextBox();
            this.MajorCombo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SubmitBtn
            // 
            this.SubmitBtn.Location = new System.Drawing.Point(355, 240);
            this.SubmitBtn.Name = "SubmitBtn";
            this.SubmitBtn.Size = new System.Drawing.Size(158, 71);
            this.SubmitBtn.TabIndex = 1;
            this.SubmitBtn.Text = "ثبت";
            this.SubmitBtn.UseVisualStyleBackColor = true;
            this.SubmitBtn.Click += new System.EventHandler(this.SubmitBtn_Click);
            // 
            // LevelCombo
            // 
            this.LevelCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LevelCombo.FormattingEnabled = true;
            this.LevelCombo.Location = new System.Drawing.Point(86, 15);
            this.LevelCombo.Name = "LevelCombo";
            this.LevelCombo.Size = new System.Drawing.Size(235, 28);
            this.LevelCombo.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "مقطع";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "معدل";
            // 
            // AverageTxt
            // 
            this.AverageTxt.Location = new System.Drawing.Point(86, 165);
            this.AverageTxt.Name = "AverageTxt";
            this.AverageTxt.Size = new System.Drawing.Size(235, 27);
            this.AverageTxt.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "گرایش";
            // 
            // MinorTxt
            // 
            this.MinorTxt.Location = new System.Drawing.Point(86, 113);
            this.MinorTxt.Name = "MinorTxt";
            this.MinorTxt.Size = new System.Drawing.Size(235, 27);
            this.MinorTxt.TabIndex = 7;
            // 
            // MajorCombo
            // 
            this.MajorCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MajorCombo.FormattingEnabled = true;
            this.MajorCombo.Location = new System.Drawing.Point(86, 64);
            this.MajorCombo.Name = "MajorCombo";
            this.MajorCombo.Size = new System.Drawing.Size(235, 28);
            this.MajorCombo.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "رشته";
            // 
            // AddUpdateEducationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 323);
            this.Controls.Add(this.MajorCombo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.LevelCombo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.AverageTxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MinorTxt);
            this.Controls.Add(this.SubmitBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AddUpdateEducationForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.AddUpdateEducationForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button SubmitBtn;
        private ComboBox LevelCombo;
        private Label label3;
        private Label label2;
        private TextBox AverageTxt;
        private Label label1;
        private TextBox MinorTxt;
        private ComboBox MajorCombo;
        private Label label4;
    }
}