namespace EPE.Presention.Forms.EmployeeManagement
{
    partial class AddUpdateResumeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddUpdateResumeForm));
            this.label2 = new System.Windows.Forms.Label();
            this.TitleTxt = new System.Windows.Forms.TextBox();
            this.SubmitBtn = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.EmployementDP = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.RelaseDP = new System.Windows.Forms.DateTimePicker();
            this.DescriptionTxt = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "عنوان";
            // 
            // TitleTxt
            // 
            this.TitleTxt.Location = new System.Drawing.Point(163, 12);
            this.TitleTxt.Name = "TitleTxt";
            this.TitleTxt.Size = new System.Drawing.Size(265, 27);
            this.TitleTxt.TabIndex = 10;
            // 
            // SubmitBtn
            // 
            this.SubmitBtn.Location = new System.Drawing.Point(355, 240);
            this.SubmitBtn.Name = "SubmitBtn";
            this.SubmitBtn.Size = new System.Drawing.Size(158, 71);
            this.SubmitBtn.TabIndex = 9;
            this.SubmitBtn.Text = "ثبت";
            this.SubmitBtn.UseVisualStyleBackColor = true;
            this.SubmitBtn.Click += new System.EventHandler(this.SubmitBtn_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(23, 58);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 20);
            this.label8.TabIndex = 17;
            this.label8.Text = "تاریخ استخدام";
            // 
            // EmployementDP
            // 
            this.EmployementDP.CustomFormat = "";
            this.EmployementDP.Location = new System.Drawing.Point(163, 58);
            this.EmployementDP.Name = "EmployementDP";
            this.EmployementDP.RightToLeftLayout = true;
            this.EmployementDP.Size = new System.Drawing.Size(265, 27);
            this.EmployementDP.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(23, 111);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(125, 20);
            this.label9.TabIndex = 19;
            this.label9.Text = "تاریخ اتمام همکاری";
            // 
            // RelaseDP
            // 
            this.RelaseDP.CustomFormat = "";
            this.RelaseDP.Location = new System.Drawing.Point(163, 106);
            this.RelaseDP.Name = "RelaseDP";
            this.RelaseDP.RightToLeftLayout = true;
            this.RelaseDP.Size = new System.Drawing.Size(265, 27);
            this.RelaseDP.TabIndex = 18;
            // 
            // DescriptionTxt
            // 
            this.DescriptionTxt.Location = new System.Drawing.Point(163, 154);
            this.DescriptionTxt.Name = "DescriptionTxt";
            this.DescriptionTxt.Size = new System.Drawing.Size(350, 73);
            this.DescriptionTxt.TabIndex = 20;
            this.DescriptionTxt.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 20);
            this.label1.TabIndex = 21;
            this.label1.Text = "شرح کار";
            // 
            // AddUpdateResumeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 323);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DescriptionTxt);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.RelaseDP);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.EmployementDP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TitleTxt);
            this.Controls.Add(this.SubmitBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddUpdateResumeForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.AddUpdateResumeForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label2;
        private TextBox TitleTxt;
        private Button SubmitBtn;
        private Label label8;
        private DateTimePicker EmployementDP;
        private Label label9;
        private DateTimePicker RelaseDP;
        private RichTextBox DescriptionTxt;
        private Label label1;
    }
}