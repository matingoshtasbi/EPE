namespace EPE.Presention.Forms
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.aboutMenuBtn = new System.Windows.Forms.Button();
            this.masterDataMenuBtn = new System.Windows.Forms.Button();
            this.performanceEvaluateMenuBtn = new System.Windows.Forms.Button();
            this.employeeMenuBtn = new System.Windows.Forms.Button();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("IRANSans", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(739, 44);
            this.label1.TabIndex = 2;
            this.label1.Text = "اپلیکیشن ارزیابی عملکرد کارکنان";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mainPanel
            // 
            this.mainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainPanel.Controls.Add(this.aboutMenuBtn);
            this.mainPanel.Controls.Add(this.masterDataMenuBtn);
            this.mainPanel.Controls.Add(this.performanceEvaluateMenuBtn);
            this.mainPanel.Controls.Add(this.employeeMenuBtn);
            this.mainPanel.Location = new System.Drawing.Point(54, 131);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(624, 649);
            this.mainPanel.TabIndex = 3;
            // 
            // aboutMenuBtn
            // 
            this.aboutMenuBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.aboutMenuBtn.Location = new System.Drawing.Point(0, 480);
            this.aboutMenuBtn.Name = "aboutMenuBtn";
            this.aboutMenuBtn.Size = new System.Drawing.Size(624, 160);
            this.aboutMenuBtn.TabIndex = 7;
            this.aboutMenuBtn.Text = "راهنمای برنامه";
            this.aboutMenuBtn.UseVisualStyleBackColor = true;
            this.aboutMenuBtn.Click += new System.EventHandler(this.aboutMenuBtn_Click);
            // 
            // masterDataMenuBtn
            // 
            this.masterDataMenuBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.masterDataMenuBtn.Location = new System.Drawing.Point(0, 320);
            this.masterDataMenuBtn.Name = "masterDataMenuBtn";
            this.masterDataMenuBtn.Size = new System.Drawing.Size(624, 160);
            this.masterDataMenuBtn.TabIndex = 6;
            this.masterDataMenuBtn.Text = "اطلاعات پایه";
            this.masterDataMenuBtn.UseVisualStyleBackColor = true;
            this.masterDataMenuBtn.Click += new System.EventHandler(this.masterDataMenuBtn_Click);
            // 
            // performanceEvaluateMenuBtn
            // 
            this.performanceEvaluateMenuBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.performanceEvaluateMenuBtn.Location = new System.Drawing.Point(0, 160);
            this.performanceEvaluateMenuBtn.Name = "performanceEvaluateMenuBtn";
            this.performanceEvaluateMenuBtn.Size = new System.Drawing.Size(624, 160);
            this.performanceEvaluateMenuBtn.TabIndex = 5;
            this.performanceEvaluateMenuBtn.Text = "ارزیابی عملکرد";
            this.performanceEvaluateMenuBtn.UseVisualStyleBackColor = true;
            this.performanceEvaluateMenuBtn.Click += new System.EventHandler(this.performanceEvaluateMenuBtn_Click);
            // 
            // employeeMenuBtn
            // 
            this.employeeMenuBtn.AutoSize = true;
            this.employeeMenuBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.employeeMenuBtn.Location = new System.Drawing.Point(0, 0);
            this.employeeMenuBtn.Name = "employeeMenuBtn";
            this.employeeMenuBtn.Size = new System.Drawing.Size(624, 160);
            this.employeeMenuBtn.TabIndex = 4;
            this.employeeMenuBtn.Text = "مدیریت کارمندان";
            this.employeeMenuBtn.UseVisualStyleBackColor = true;
            this.employeeMenuBtn.Click += new System.EventHandler(this.employeeMenuBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 810);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "صفحه ی اصلی";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Label label1;
        private Panel mainPanel;
        private Button aboutMenuBtn;
        private Button masterDataMenuBtn;
        private Button performanceEvaluateMenuBtn;
        private Button employeeMenuBtn;
    }
}