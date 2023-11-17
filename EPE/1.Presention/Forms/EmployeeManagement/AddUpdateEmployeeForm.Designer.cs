namespace EPE.Presention.Forms.EmployeeManagement
{
    partial class AddUpdateEmployeeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddUpdateEmployeeForm));
            this.EmployeeTabControl = new System.Windows.Forms.TabControl();
            this.EmployeeInfoTab = new System.Windows.Forms.TabPage();
            this.label19 = new System.Windows.Forms.Label();
            this.JobCombo = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.MilitaryCombo = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.MaritalCombo = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.IndependantTxt = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.NationalityTxt = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.GenderCombo = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.RelaseDP = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.EmployementDP = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.BirthPlaceTxt = new System.Windows.Forms.TextBox();
            this.BirthDateDP = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.FatherNameTxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.LastNameTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.FirstNameTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CodeTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.IdNoTxt = new System.Windows.Forms.TextBox();
            this.EmployeeContactTab = new System.Windows.Forms.TabPage();
            this.RemoveContact = new System.Windows.Forms.Button();
            this.UpdateContact = new System.Windows.Forms.Button();
            this.AddContact = new System.Windows.Forms.Button();
            this.ContactGrid = new System.Windows.Forms.DataGridView();
            this.EmployeeEducationTab = new System.Windows.Forms.TabPage();
            this.RemoveEducation = new System.Windows.Forms.Button();
            this.UpdateEducation = new System.Windows.Forms.Button();
            this.AddEducation = new System.Windows.Forms.Button();
            this.EducationGrid = new System.Windows.Forms.DataGridView();
            this.EmployeePhysicalTab = new System.Windows.Forms.TabPage();
            this.RemovePhysical = new System.Windows.Forms.Button();
            this.UpdatePhysical = new System.Windows.Forms.Button();
            this.AddPhysical = new System.Windows.Forms.Button();
            this.PhysicalGrid = new System.Windows.Forms.DataGridView();
            this.EmployeeResumeTab = new System.Windows.Forms.TabPage();
            this.RemoveResume = new System.Windows.Forms.Button();
            this.UpdateResume = new System.Windows.Forms.Button();
            this.AddResume = new System.Windows.Forms.Button();
            this.ResumeGrid = new System.Windows.Forms.DataGridView();
            this.EmployeeExtraInfoTab = new System.Windows.Forms.TabPage();
            this.DescriptionTxt = new System.Windows.Forms.RichTextBox();
            this.SubmitBtn = new System.Windows.Forms.Button();
            this.EmployeeTabControl.SuspendLayout();
            this.EmployeeInfoTab.SuspendLayout();
            this.EmployeeContactTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ContactGrid)).BeginInit();
            this.EmployeeEducationTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EducationGrid)).BeginInit();
            this.EmployeePhysicalTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PhysicalGrid)).BeginInit();
            this.EmployeeResumeTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ResumeGrid)).BeginInit();
            this.EmployeeExtraInfoTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // EmployeeTabControl
            // 
            this.EmployeeTabControl.Controls.Add(this.EmployeeInfoTab);
            this.EmployeeTabControl.Controls.Add(this.EmployeeContactTab);
            this.EmployeeTabControl.Controls.Add(this.EmployeeEducationTab);
            this.EmployeeTabControl.Controls.Add(this.EmployeePhysicalTab);
            this.EmployeeTabControl.Controls.Add(this.EmployeeResumeTab);
            this.EmployeeTabControl.Controls.Add(this.EmployeeExtraInfoTab);
            this.EmployeeTabControl.Location = new System.Drawing.Point(12, 12);
            this.EmployeeTabControl.Name = "EmployeeTabControl";
            this.EmployeeTabControl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.EmployeeTabControl.RightToLeftLayout = true;
            this.EmployeeTabControl.SelectedIndex = 0;
            this.EmployeeTabControl.Size = new System.Drawing.Size(1078, 507);
            this.EmployeeTabControl.TabIndex = 0;
            this.EmployeeTabControl.SelectedIndexChanged += new System.EventHandler(this.EmployeeTabControl_SelectedIndexChanged);
            // 
            // EmployeeInfoTab
            // 
            this.EmployeeInfoTab.Controls.Add(this.label19);
            this.EmployeeInfoTab.Controls.Add(this.JobCombo);
            this.EmployeeInfoTab.Controls.Add(this.label16);
            this.EmployeeInfoTab.Controls.Add(this.MilitaryCombo);
            this.EmployeeInfoTab.Controls.Add(this.label15);
            this.EmployeeInfoTab.Controls.Add(this.MaritalCombo);
            this.EmployeeInfoTab.Controls.Add(this.label14);
            this.EmployeeInfoTab.Controls.Add(this.IndependantTxt);
            this.EmployeeInfoTab.Controls.Add(this.label11);
            this.EmployeeInfoTab.Controls.Add(this.NationalityTxt);
            this.EmployeeInfoTab.Controls.Add(this.label10);
            this.EmployeeInfoTab.Controls.Add(this.GenderCombo);
            this.EmployeeInfoTab.Controls.Add(this.label9);
            this.EmployeeInfoTab.Controls.Add(this.RelaseDP);
            this.EmployeeInfoTab.Controls.Add(this.label8);
            this.EmployeeInfoTab.Controls.Add(this.EmployementDP);
            this.EmployeeInfoTab.Controls.Add(this.label7);
            this.EmployeeInfoTab.Controls.Add(this.label6);
            this.EmployeeInfoTab.Controls.Add(this.BirthPlaceTxt);
            this.EmployeeInfoTab.Controls.Add(this.BirthDateDP);
            this.EmployeeInfoTab.Controls.Add(this.label5);
            this.EmployeeInfoTab.Controls.Add(this.FatherNameTxt);
            this.EmployeeInfoTab.Controls.Add(this.label4);
            this.EmployeeInfoTab.Controls.Add(this.LastNameTxt);
            this.EmployeeInfoTab.Controls.Add(this.label3);
            this.EmployeeInfoTab.Controls.Add(this.FirstNameTxt);
            this.EmployeeInfoTab.Controls.Add(this.label2);
            this.EmployeeInfoTab.Controls.Add(this.CodeTxt);
            this.EmployeeInfoTab.Controls.Add(this.label1);
            this.EmployeeInfoTab.Controls.Add(this.IdNoTxt);
            this.EmployeeInfoTab.Location = new System.Drawing.Point(4, 29);
            this.EmployeeInfoTab.Name = "EmployeeInfoTab";
            this.EmployeeInfoTab.Size = new System.Drawing.Size(1070, 474);
            this.EmployeeInfoTab.TabIndex = 0;
            this.EmployeeInfoTab.Text = "اطلاعات فردی و شرکتی";
            this.EmployeeInfoTab.UseVisualStyleBackColor = true;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(713, 320);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(41, 20);
            this.label19.TabIndex = 37;
            this.label19.Text = "شغل";
            // 
            // JobCombo
            // 
            this.JobCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.JobCombo.FormattingEnabled = true;
            this.JobCombo.Location = new System.Drawing.Point(356, 320);
            this.JobCombo.Name = "JobCombo";
            this.JobCombo.Size = new System.Drawing.Size(270, 28);
            this.JobCombo.TabIndex = 36;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(650, 260);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(104, 20);
            this.label16.TabIndex = 31;
            this.label16.Text = "وضعیت خدمت";
            // 
            // MilitaryCombo
            // 
            this.MilitaryCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MilitaryCombo.FormattingEnabled = true;
            this.MilitaryCombo.Location = new System.Drawing.Point(356, 260);
            this.MilitaryCombo.Name = "MilitaryCombo";
            this.MilitaryCombo.Size = new System.Drawing.Size(270, 28);
            this.MilitaryCombo.TabIndex = 30;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(236, 35);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(93, 20);
            this.label15.TabIndex = 29;
            this.label15.Text = "وضعیت تاهل";
            // 
            // MaritalCombo
            // 
            this.MaritalCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MaritalCombo.FormattingEnabled = true;
            this.MaritalCombo.Location = new System.Drawing.Point(17, 33);
            this.MaritalCombo.Name = "MaritalCombo";
            this.MaritalCombo.Size = new System.Drawing.Size(202, 28);
            this.MaritalCombo.TabIndex = 28;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(251, 86);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(78, 20);
            this.label14.TabIndex = 27;
            this.label14.Text = "تعداد عائله";
            // 
            // IndependantTxt
            // 
            this.IndependantTxt.Location = new System.Drawing.Point(17, 86);
            this.IndependantTxt.Name = "IndependantTxt";
            this.IndependantTxt.Size = new System.Drawing.Size(202, 27);
            this.IndependantTxt.TabIndex = 26;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(1014, 379);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 20);
            this.label11.TabIndex = 21;
            this.label11.Text = "ملیت";
            // 
            // NationalityTxt
            // 
            this.NationalityTxt.Location = new System.Drawing.Point(778, 379);
            this.NationalityTxt.Name = "NationalityTxt";
            this.NationalityTxt.Size = new System.Drawing.Size(182, 27);
            this.NationalityTxt.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(699, 193);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 20);
            this.label10.TabIndex = 19;
            this.label10.Text = "جنسیت";
            // 
            // GenderCombo
            // 
            this.GenderCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GenderCombo.FormattingEnabled = true;
            this.GenderCombo.Location = new System.Drawing.Point(356, 198);
            this.GenderCombo.Name = "GenderCombo";
            this.GenderCombo.Size = new System.Drawing.Size(270, 28);
            this.GenderCombo.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(629, 144);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(125, 20);
            this.label9.TabIndex = 17;
            this.label9.Text = "تاریخ اتمام همکاری";
            // 
            // RelaseDP
            // 
            this.RelaseDP.CustomFormat = "";
            this.RelaseDP.Location = new System.Drawing.Point(356, 142);
            this.RelaseDP.Name = "RelaseDP";
            this.RelaseDP.RightToLeftLayout = true;
            this.RelaseDP.Size = new System.Drawing.Size(270, 27);
            this.RelaseDP.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(659, 86);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 20);
            this.label8.TabIndex = 15;
            this.label8.Text = "تاریخ استخدام";
            // 
            // EmployementDP
            // 
            this.EmployementDP.CustomFormat = "";
            this.EmployementDP.Location = new System.Drawing.Point(356, 86);
            this.EmployementDP.Name = "EmployementDP";
            this.EmployementDP.RightToLeftLayout = true;
            this.EmployementDP.Size = new System.Drawing.Size(270, 27);
            this.EmployementDP.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(685, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 20);
            this.label7.TabIndex = 13;
            this.label7.Text = "تاریخ تولد";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(989, 317);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "محل تولد";
            // 
            // BirthPlaceTxt
            // 
            this.BirthPlaceTxt.Location = new System.Drawing.Point(778, 317);
            this.BirthPlaceTxt.Name = "BirthPlaceTxt";
            this.BirthPlaceTxt.Size = new System.Drawing.Size(182, 27);
            this.BirthPlaceTxt.TabIndex = 11;
            // 
            // BirthDateDP
            // 
            this.BirthDateDP.CustomFormat = "";
            this.BirthDateDP.Location = new System.Drawing.Point(356, 29);
            this.BirthDateDP.Name = "BirthDateDP";
            this.BirthDateDP.RightToLeftLayout = true;
            this.BirthDateDP.Size = new System.Drawing.Size(270, 27);
            this.BirthDateDP.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1006, 257);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "نام پدر";
            // 
            // FatherNameTxt
            // 
            this.FatherNameTxt.Location = new System.Drawing.Point(778, 257);
            this.FatherNameTxt.Name = "FatherNameTxt";
            this.FatherNameTxt.Size = new System.Drawing.Size(182, 27);
            this.FatherNameTxt.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(966, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "نام خانوادگی";
            // 
            // LastNameTxt
            // 
            this.LastNameTxt.Location = new System.Drawing.Point(778, 198);
            this.LastNameTxt.Name = "LastNameTxt";
            this.LastNameTxt.Size = new System.Drawing.Size(182, 27);
            this.LastNameTxt.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1029, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "نام";
            // 
            // FirstNameTxt
            // 
            this.FirstNameTxt.Location = new System.Drawing.Point(778, 142);
            this.FirstNameTxt.Name = "FirstNameTxt";
            this.FirstNameTxt.Size = new System.Drawing.Size(182, 27);
            this.FirstNameTxt.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(986, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "کد پرسنلی";
            // 
            // CodeTxt
            // 
            this.CodeTxt.Location = new System.Drawing.Point(778, 86);
            this.CodeTxt.Name = "CodeTxt";
            this.CodeTxt.Size = new System.Drawing.Size(182, 27);
            this.CodeTxt.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1000, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "کد ملی";
            // 
            // IdNoTxt
            // 
            this.IdNoTxt.Location = new System.Drawing.Point(778, 31);
            this.IdNoTxt.Name = "IdNoTxt";
            this.IdNoTxt.Size = new System.Drawing.Size(182, 27);
            this.IdNoTxt.TabIndex = 0;
            // 
            // EmployeeContactTab
            // 
            this.EmployeeContactTab.Controls.Add(this.RemoveContact);
            this.EmployeeContactTab.Controls.Add(this.UpdateContact);
            this.EmployeeContactTab.Controls.Add(this.AddContact);
            this.EmployeeContactTab.Controls.Add(this.ContactGrid);
            this.EmployeeContactTab.Location = new System.Drawing.Point(4, 29);
            this.EmployeeContactTab.Name = "EmployeeContactTab";
            this.EmployeeContactTab.Padding = new System.Windows.Forms.Padding(3);
            this.EmployeeContactTab.Size = new System.Drawing.Size(1070, 474);
            this.EmployeeContactTab.TabIndex = 1;
            this.EmployeeContactTab.Text = "اطلاعات تماس";
            this.EmployeeContactTab.UseVisualStyleBackColor = true;
            // 
            // RemoveContact
            // 
            this.RemoveContact.Enabled = false;
            this.RemoveContact.Location = new System.Drawing.Point(484, 389);
            this.RemoveContact.Name = "RemoveContact";
            this.RemoveContact.Size = new System.Drawing.Size(233, 79);
            this.RemoveContact.TabIndex = 7;
            this.RemoveContact.Text = "حذف";
            this.RemoveContact.UseVisualStyleBackColor = true;
            this.RemoveContact.Click += new System.EventHandler(this.RemoveContact_Click);
            // 
            // UpdateContact
            // 
            this.UpdateContact.Enabled = false;
            this.UpdateContact.Location = new System.Drawing.Point(245, 389);
            this.UpdateContact.Name = "UpdateContact";
            this.UpdateContact.Size = new System.Drawing.Size(233, 79);
            this.UpdateContact.TabIndex = 6;
            this.UpdateContact.Text = "ویرایش";
            this.UpdateContact.UseVisualStyleBackColor = true;
            this.UpdateContact.Click += new System.EventHandler(this.UpdateContact_Click);
            // 
            // AddContact
            // 
            this.AddContact.Location = new System.Drawing.Point(6, 389);
            this.AddContact.Name = "AddContact";
            this.AddContact.Size = new System.Drawing.Size(233, 79);
            this.AddContact.TabIndex = 1;
            this.AddContact.Text = "افزودن";
            this.AddContact.UseVisualStyleBackColor = true;
            this.AddContact.Click += new System.EventHandler(this.AddContact_Click);
            // 
            // ContactGrid
            // 
            this.ContactGrid.AllowUserToAddRows = false;
            this.ContactGrid.AllowUserToDeleteRows = false;
            this.ContactGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ContactGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ContactGrid.Location = new System.Drawing.Point(6, 6);
            this.ContactGrid.MultiSelect = false;
            this.ContactGrid.Name = "ContactGrid";
            this.ContactGrid.ReadOnly = true;
            this.ContactGrid.RowHeadersWidth = 51;
            this.ContactGrid.RowTemplate.Height = 29;
            this.ContactGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ContactGrid.Size = new System.Drawing.Size(1058, 225);
            this.ContactGrid.TabIndex = 0;
            this.ContactGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ContactGrid_CellClick);
            this.ContactGrid.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.ContactGrid_ColumnHeaderMouseClick);
            this.ContactGrid.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.ContactGrid_DataBindingComplete);
            // 
            // EmployeeEducationTab
            // 
            this.EmployeeEducationTab.Controls.Add(this.RemoveEducation);
            this.EmployeeEducationTab.Controls.Add(this.UpdateEducation);
            this.EmployeeEducationTab.Controls.Add(this.AddEducation);
            this.EmployeeEducationTab.Controls.Add(this.EducationGrid);
            this.EmployeeEducationTab.Location = new System.Drawing.Point(4, 29);
            this.EmployeeEducationTab.Name = "EmployeeEducationTab";
            this.EmployeeEducationTab.Padding = new System.Windows.Forms.Padding(3);
            this.EmployeeEducationTab.Size = new System.Drawing.Size(1070, 474);
            this.EmployeeEducationTab.TabIndex = 2;
            this.EmployeeEducationTab.Text = "اطلاعات تحصیلی و آموزشی";
            this.EmployeeEducationTab.UseVisualStyleBackColor = true;
            // 
            // RemoveEducation
            // 
            this.RemoveEducation.Enabled = false;
            this.RemoveEducation.Location = new System.Drawing.Point(484, 389);
            this.RemoveEducation.Name = "RemoveEducation";
            this.RemoveEducation.Size = new System.Drawing.Size(233, 79);
            this.RemoveEducation.TabIndex = 5;
            this.RemoveEducation.Text = "حذف";
            this.RemoveEducation.UseVisualStyleBackColor = true;
            this.RemoveEducation.Click += new System.EventHandler(this.RemoveEducation_Click);
            // 
            // UpdateEducation
            // 
            this.UpdateEducation.Enabled = false;
            this.UpdateEducation.Location = new System.Drawing.Point(245, 389);
            this.UpdateEducation.Name = "UpdateEducation";
            this.UpdateEducation.Size = new System.Drawing.Size(233, 79);
            this.UpdateEducation.TabIndex = 4;
            this.UpdateEducation.Text = "ویرایش";
            this.UpdateEducation.UseVisualStyleBackColor = true;
            this.UpdateEducation.Click += new System.EventHandler(this.UpdateEducation_Click);
            // 
            // AddEducation
            // 
            this.AddEducation.Location = new System.Drawing.Point(6, 389);
            this.AddEducation.Name = "AddEducation";
            this.AddEducation.Size = new System.Drawing.Size(233, 79);
            this.AddEducation.TabIndex = 3;
            this.AddEducation.Text = "افزودن";
            this.AddEducation.UseVisualStyleBackColor = true;
            this.AddEducation.Click += new System.EventHandler(this.AddEducation_Click);
            // 
            // EducationGrid
            // 
            this.EducationGrid.AllowUserToAddRows = false;
            this.EducationGrid.AllowUserToDeleteRows = false;
            this.EducationGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.EducationGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.EducationGrid.Location = new System.Drawing.Point(6, 6);
            this.EducationGrid.MultiSelect = false;
            this.EducationGrid.Name = "EducationGrid";
            this.EducationGrid.ReadOnly = true;
            this.EducationGrid.RowHeadersWidth = 51;
            this.EducationGrid.RowTemplate.Height = 29;
            this.EducationGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.EducationGrid.Size = new System.Drawing.Size(1058, 225);
            this.EducationGrid.TabIndex = 2;
            this.EducationGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.EducationGrid_CellClick);
            this.EducationGrid.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.EducationGrid_ColumnHeaderMouseClick);
            this.EducationGrid.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.EducationGrid_DataBindingComplete);
            // 
            // EmployeePhysicalTab
            // 
            this.EmployeePhysicalTab.Controls.Add(this.RemovePhysical);
            this.EmployeePhysicalTab.Controls.Add(this.UpdatePhysical);
            this.EmployeePhysicalTab.Controls.Add(this.AddPhysical);
            this.EmployeePhysicalTab.Controls.Add(this.PhysicalGrid);
            this.EmployeePhysicalTab.Location = new System.Drawing.Point(4, 29);
            this.EmployeePhysicalTab.Name = "EmployeePhysicalTab";
            this.EmployeePhysicalTab.Padding = new System.Windows.Forms.Padding(3);
            this.EmployeePhysicalTab.Size = new System.Drawing.Size(1070, 474);
            this.EmployeePhysicalTab.TabIndex = 3;
            this.EmployeePhysicalTab.Text = "اطلاعات فیزیکی";
            this.EmployeePhysicalTab.UseVisualStyleBackColor = true;
            // 
            // RemovePhysical
            // 
            this.RemovePhysical.Enabled = false;
            this.RemovePhysical.Location = new System.Drawing.Point(484, 389);
            this.RemovePhysical.Name = "RemovePhysical";
            this.RemovePhysical.Size = new System.Drawing.Size(233, 79);
            this.RemovePhysical.TabIndex = 7;
            this.RemovePhysical.Text = "حذف";
            this.RemovePhysical.UseVisualStyleBackColor = true;
            this.RemovePhysical.Click += new System.EventHandler(this.RemovePhysical_Click);
            // 
            // UpdatePhysical
            // 
            this.UpdatePhysical.Enabled = false;
            this.UpdatePhysical.Location = new System.Drawing.Point(245, 389);
            this.UpdatePhysical.Name = "UpdatePhysical";
            this.UpdatePhysical.Size = new System.Drawing.Size(233, 79);
            this.UpdatePhysical.TabIndex = 6;
            this.UpdatePhysical.Text = "ویرایش";
            this.UpdatePhysical.UseVisualStyleBackColor = true;
            this.UpdatePhysical.Click += new System.EventHandler(this.UpdatePhysical_Click);
            // 
            // AddPhysical
            // 
            this.AddPhysical.Location = new System.Drawing.Point(6, 389);
            this.AddPhysical.Name = "AddPhysical";
            this.AddPhysical.Size = new System.Drawing.Size(233, 79);
            this.AddPhysical.TabIndex = 3;
            this.AddPhysical.Text = "افزودن";
            this.AddPhysical.UseVisualStyleBackColor = true;
            this.AddPhysical.Click += new System.EventHandler(this.AddPhysical_Click);
            // 
            // PhysicalGrid
            // 
            this.PhysicalGrid.AllowUserToAddRows = false;
            this.PhysicalGrid.AllowUserToDeleteRows = false;
            this.PhysicalGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.PhysicalGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PhysicalGrid.Location = new System.Drawing.Point(6, 6);
            this.PhysicalGrid.MultiSelect = false;
            this.PhysicalGrid.Name = "PhysicalGrid";
            this.PhysicalGrid.ReadOnly = true;
            this.PhysicalGrid.RowHeadersWidth = 51;
            this.PhysicalGrid.RowTemplate.Height = 29;
            this.PhysicalGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.PhysicalGrid.Size = new System.Drawing.Size(1058, 225);
            this.PhysicalGrid.TabIndex = 2;
            this.PhysicalGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.PhysicalGrid_CellClick);
            this.PhysicalGrid.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.PhysicalGrid_ColumnHeaderMouseClick);
            this.PhysicalGrid.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.PhysicalGrid_DataBindingComplete);
            // 
            // EmployeeResumeTab
            // 
            this.EmployeeResumeTab.Controls.Add(this.RemoveResume);
            this.EmployeeResumeTab.Controls.Add(this.UpdateResume);
            this.EmployeeResumeTab.Controls.Add(this.AddResume);
            this.EmployeeResumeTab.Controls.Add(this.ResumeGrid);
            this.EmployeeResumeTab.Location = new System.Drawing.Point(4, 29);
            this.EmployeeResumeTab.Name = "EmployeeResumeTab";
            this.EmployeeResumeTab.Padding = new System.Windows.Forms.Padding(3);
            this.EmployeeResumeTab.Size = new System.Drawing.Size(1070, 474);
            this.EmployeeResumeTab.TabIndex = 4;
            this.EmployeeResumeTab.Text = "سوابق کاری";
            this.EmployeeResumeTab.UseVisualStyleBackColor = true;
            // 
            // RemoveResume
            // 
            this.RemoveResume.Enabled = false;
            this.RemoveResume.Location = new System.Drawing.Point(484, 389);
            this.RemoveResume.Name = "RemoveResume";
            this.RemoveResume.Size = new System.Drawing.Size(233, 79);
            this.RemoveResume.TabIndex = 11;
            this.RemoveResume.Text = "حذف";
            this.RemoveResume.UseVisualStyleBackColor = true;
            this.RemoveResume.Click += new System.EventHandler(this.RemoveResume_Click);
            // 
            // UpdateResume
            // 
            this.UpdateResume.Enabled = false;
            this.UpdateResume.Location = new System.Drawing.Point(245, 389);
            this.UpdateResume.Name = "UpdateResume";
            this.UpdateResume.Size = new System.Drawing.Size(233, 79);
            this.UpdateResume.TabIndex = 10;
            this.UpdateResume.Text = "ویرایش";
            this.UpdateResume.UseVisualStyleBackColor = true;
            this.UpdateResume.Click += new System.EventHandler(this.UpdateResume_Click);
            // 
            // AddResume
            // 
            this.AddResume.Location = new System.Drawing.Point(6, 389);
            this.AddResume.Name = "AddResume";
            this.AddResume.Size = new System.Drawing.Size(233, 79);
            this.AddResume.TabIndex = 9;
            this.AddResume.Text = "افزودن";
            this.AddResume.UseVisualStyleBackColor = true;
            this.AddResume.Click += new System.EventHandler(this.AddResume_Click);
            // 
            // ResumeGrid
            // 
            this.ResumeGrid.AllowUserToAddRows = false;
            this.ResumeGrid.AllowUserToDeleteRows = false;
            this.ResumeGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ResumeGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ResumeGrid.Location = new System.Drawing.Point(6, 6);
            this.ResumeGrid.MultiSelect = false;
            this.ResumeGrid.Name = "ResumeGrid";
            this.ResumeGrid.ReadOnly = true;
            this.ResumeGrid.RowHeadersWidth = 51;
            this.ResumeGrid.RowTemplate.Height = 29;
            this.ResumeGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ResumeGrid.Size = new System.Drawing.Size(1058, 225);
            this.ResumeGrid.TabIndex = 8;
            this.ResumeGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ResumeGrid_CellClick);
            this.ResumeGrid.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.ResumeGrid_ColumnHeaderMouseClick);
            this.ResumeGrid.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.ResumeGrid_DataBindingComplete);
            // 
            // EmployeeExtraInfoTab
            // 
            this.EmployeeExtraInfoTab.Controls.Add(this.DescriptionTxt);
            this.EmployeeExtraInfoTab.Location = new System.Drawing.Point(4, 29);
            this.EmployeeExtraInfoTab.Name = "EmployeeExtraInfoTab";
            this.EmployeeExtraInfoTab.Padding = new System.Windows.Forms.Padding(3);
            this.EmployeeExtraInfoTab.Size = new System.Drawing.Size(1070, 474);
            this.EmployeeExtraInfoTab.TabIndex = 5;
            this.EmployeeExtraInfoTab.Text = "اطلاعات تکمیلی";
            this.EmployeeExtraInfoTab.UseVisualStyleBackColor = true;
            // 
            // DescriptionTxt
            // 
            this.DescriptionTxt.Location = new System.Drawing.Point(6, 29);
            this.DescriptionTxt.Name = "DescriptionTxt";
            this.DescriptionTxt.Size = new System.Drawing.Size(1058, 418);
            this.DescriptionTxt.TabIndex = 0;
            this.DescriptionTxt.Text = "";
            // 
            // SubmitBtn
            // 
            this.SubmitBtn.Location = new System.Drawing.Point(686, 551);
            this.SubmitBtn.Name = "SubmitBtn";
            this.SubmitBtn.Size = new System.Drawing.Size(400, 83);
            this.SubmitBtn.TabIndex = 1;
            this.SubmitBtn.Text = "ثبت";
            this.SubmitBtn.UseVisualStyleBackColor = true;
            this.SubmitBtn.Click += new System.EventHandler(this.SubmitBtn_Click);
            // 
            // AddUpdateEmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1098, 642);
            this.Controls.Add(this.SubmitBtn);
            this.Controls.Add(this.EmployeeTabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AddUpdateEmployeeForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.AddUpdateEmployeeForm_Load);
            this.EmployeeTabControl.ResumeLayout(false);
            this.EmployeeInfoTab.ResumeLayout(false);
            this.EmployeeInfoTab.PerformLayout();
            this.EmployeeContactTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ContactGrid)).EndInit();
            this.EmployeeEducationTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.EducationGrid)).EndInit();
            this.EmployeePhysicalTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PhysicalGrid)).EndInit();
            this.EmployeeResumeTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ResumeGrid)).EndInit();
            this.EmployeeExtraInfoTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl EmployeeTabControl;
        private TabPage EmployeeInfoTab;
        private TabPage EmployeeContactTab;
        private TabPage EmployeeEducationTab;
        private TabPage EmployeePhysicalTab;
        private Button SubmitBtn;
        private TextBox IdNoTxt;
        private Label label2;
        private TextBox CodeTxt;
        private Label label1;
        private Label label5;
        private TextBox FatherNameTxt;
        private Label label4;
        private TextBox LastNameTxt;
        private Label label3;
        private TextBox FirstNameTxt;
        private DateTimePicker BirthDateDP;
        private Label label6;
        private TextBox BirthPlaceTxt;
        private Label label9;
        private DateTimePicker RelaseDP;
        private Label label8;
        private DateTimePicker EmployementDP;
        private Label label7;
        private Label label10;
        private ComboBox GenderCombo;
        private Label label11;
        private TextBox NationalityTxt;
        private Label label14;
        private TextBox IndependantTxt;
        private Label label15;
        private ComboBox MaritalCombo;
        private Label label16;
        private ComboBox MilitaryCombo;
        private DataGridView ContactGrid;
        private Button AddContact;
        private Button AddEducation;
        private DataGridView EducationGrid;
        private Button AddPhysical;
        private DataGridView PhysicalGrid;
        private Label label19;
        private ComboBox JobCombo;
        private Button RemoveEducation;
        private Button UpdateEducation;
        private Button RemoveContact;
        private Button UpdateContact;
        private Button RemovePhysical;
        private Button UpdatePhysical;
        private TabPage EmployeeResumeTab;
        private Button RemoveResume;
        private Button UpdateResume;
        private Button AddResume;
        private DataGridView ResumeGrid;
        private TabPage EmployeeExtraInfoTab;
        private RichTextBox DescriptionTxt;
    }
}