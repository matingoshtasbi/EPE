using EPE.Application.Abstractions.EmployeeManagement;
using EPE.Application.Abstractions.MasterData;
using EPE.Application.DTOs.EmployeeManagement;
using EPE.Domain.EmployeeManagement.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using EPE.Presention.Forms.EmployeeManagement;
using EPE.Domain.MasterData.Aggregates;

namespace EPE.Presention.Forms.EmployeeManagement
{
    public partial class AddUpdateEmployeeForm : Form
    {
        #region memebers

        // Services
        private readonly IEmployeeCommandService _employeeCommandService;
        private readonly IMasterDataQueryService _masterDataQueryService;
        private readonly IServiceProvider _provider;

        // Local Variables
        Guid employeeId;
        EmployeeRequest employeeResult = new EmployeeRequest();
        Domain.EmployeeManagement.Aggregates.Employee updateEmployeeTemp;
        EmployeeEducationRequest selectedEducation;
        EmployeeContactRequest selectedContact;
        EmployeePhysicalInfoRequest selectedPhysical;
        EmployeeResumeRequest selectedResume;

        // DataTables
        DataTable contactDT = new DataTable();
        DataTable educationDT = new DataTable();
        DataTable physicalDT = new DataTable();
        DataTable resumeDT = new DataTable();

        #endregion

        #region constractors
        public AddUpdateEmployeeForm(IServiceProvider provider)
        {
            InitializeComponent();
            _provider = provider;
            _employeeCommandService = _provider.GetService<IEmployeeCommandService>()!;
            _masterDataQueryService = _provider.GetService<IMasterDataQueryService>()!;
        }

        public AddUpdateEmployeeForm(IServiceProvider provider, Domain.EmployeeManagement.Aggregates.Employee employee)
        {
            InitializeComponent();
            _provider = provider;
            _employeeCommandService = _provider.GetService<IEmployeeCommandService>()!;
            _masterDataQueryService = _provider.GetService<IMasterDataQueryService>()!;

            updateEmployeeTemp = employee;
        }
        #endregion

        private async void AddUpdateEmployeeForm_Load(object sender, EventArgs e)
        {
            InitiateGrids();
            await GetAllEmployeeCombos();

            if (this.Text == "ویرایش کارمند" || this.Text == "مشاهده کارمند")
                await FillUpdateCombosAndGrids(updateEmployeeTemp);

            ContactGrid.Columns["شناسه"].Visible = false;
            EducationGrid.Columns["شناسه"].Visible = false;
            PhysicalGrid.Columns["شناسه"].Visible = false;
            ResumeGrid.Columns["شناسه"].Visible = false;

            DisableButtonsAndClearSelection();
        }

        private async void SubmitBtn_Click(object sender, EventArgs e)
        {
            try
            {
                employeeResult.IdNo = IdNoTxt.Text;
                employeeResult.Code = CodeTxt.Text;
                employeeResult.FirstName = FirstNameTxt.Text;
                employeeResult.LastName = LastNameTxt.Text;
                employeeResult.FatherName = FatherNameTxt.Text;
                employeeResult.Birthplace = BirthPlaceTxt.Text;
                employeeResult.Nationality = NationalityTxt.Text;
                employeeResult.Birthdate = BirthDateDP.Value.Date;
                employeeResult.EmploymentDate = EmployementDP.Value.Date;
                employeeResult.ReleaseDate = RelaseDP.Value.Date;
                employeeResult.Description = DescriptionTxt.Text;

                if (GenderCombo.SelectedItem != null)
                {
                    employeeResult.GenderId = ((GenderMD)GenderCombo.SelectedItem)!.Id;
                }
                if (MilitaryCombo.SelectedItem != null)
                {
                    employeeResult.MilitaryServiceStatusId = ((MilitaryServiceStatusMD)MilitaryCombo.SelectedItem)!.Id;
                }
                if (JobCombo.SelectedItem != null)
                {
                    employeeResult.JobId = ((JobMD)JobCombo.SelectedItem)!.Id;
                }
                if (MaritalCombo.SelectedItem != null)
                {
                    employeeResult.MaritalStatusId = ((MaritalStatusMD)MaritalCombo.SelectedItem)!.Id;
                }
                if (int.TryParse(IndependantTxt.Text, out int temp))
                {
                    employeeResult.NumberOfDependents = temp;
                }
                else
                {
                    throw new Exception("تعداد عائله مقدار عددی است");
                }

                if (this.Text == "افزودن کارمند")
                {
                    await _employeeCommandService.AddEmployee(employeeResult);
                    MessageBox.Show("اطلاعات کارمند با موفقیت ثبت شد");
                }
                else
                {
                    employeeResult.Id = employeeId;

                    await _employeeCommandService.UpdateEmployee(employeeResult);
                    MessageBox.Show("اطلاعات کارمند با موفقیت ویرایش شد");
                }




                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async Task FillUpdateCombosAndGrids(Domain.EmployeeManagement.Aggregates.Employee employee)
        {

            // Fill TextBox and DatePickers
            employeeId = employee.Id!;
            IdNoTxt.Text = employee.IdNo;
            CodeTxt.Text = employee.Code;
            FirstNameTxt.Text = employee.FirstName;
            LastNameTxt.Text = employee.LastName;
            FatherNameTxt.Text = employee.FatherName;
            BirthPlaceTxt.Text = employee.Birthplace;
            NationalityTxt.Text = employee.Nationality;

            if (employee.Birthdate != null)
                BirthDateDP.Value = employee.Birthdate!.Value;
            EmployementDP.Value = employee.EmploymentDate;
            if (employee.Birthdate != null)
                RelaseDP.Value = employee.ReleaseDate!.Value;

            IndependantTxt.Text = employee.NumberOfDependents.ToString();
            DescriptionTxt.Text = employee.Description;

            // Fill Combos
            var gender = await _masterDataQueryService!.FindGender(employee.GenderId!.Value);
            GenderCombo.SelectedIndex = GenderCombo.FindStringExact(gender.Title);

            var military = await _masterDataQueryService.FindMilitaryServiceStatus(employee.MilitaryServiceStatusId!.Value);
            MilitaryCombo.SelectedIndex = MilitaryCombo.FindStringExact(military.Title);

            var job = await _masterDataQueryService!.FindJob(employee.JobId!.Value);
            JobCombo.SelectedIndex = JobCombo.FindStringExact(job.Title);

            var marital = await _masterDataQueryService!.FindMaritalStatus(employee.MaritalStatusId!.Value);
            MaritalCombo.SelectedIndex = MaritalCombo.FindStringExact(marital.Title);

            // Fill Contact Grid
            var contactTypes = await _masterDataQueryService.FindContactTypes();
            foreach (var item in employee.Contacts)
            {
                employeeResult.Contacts.Add(new EmployeeContactRequest()
                {
                    Id = item.Id,
                    Title = item.Title,
                    TypeId = (int)item.Type,
                    Value = item.Value,
                    IsDeleted = false
                });

                contactDT.Rows.Add(item.Id, item.Title,
                    item.Value,
                    contactTypes.FirstOrDefault(c => c.Id == (int)item.Type)!.Title);
            }

            // Fill Education Grid
            var levels = await _masterDataQueryService.FindEducationLevels();
            var majors = await _masterDataQueryService.FindEducationMajors();
            foreach (var item in employee.Educations)
            {
                employeeResult.Educations.Add(new EmployeeEducationRequest()
                {
                    Id = item.Id,
                    LevelId = item.LevelId,
                    MajorId = item.MajorId,
                    Minor = item.Minor!,
                    Average = item.Average,
                    IsDeleted = false
                });

                educationDT.Rows.Add(item.Id, levels.FirstOrDefault(c => c.Id == item.LevelId)!.Title,
                    majors.FirstOrDefault(c => c.Id == item.MajorId)!.Title,
                    item.Minor,
                    item.Average);
            }

            // Fill PhysicalInfo Grid
            var physicals = await _masterDataQueryService.FindPhysicalInfos();
            foreach (var item in employee.PhysicalInfo)
            {
                employeeResult.PhysicalInfo.Add(new EmployeePhysicalInfoRequest()
                {
                    Id = item.Id,
                    PhysicalInfoId = item.PhysicalInfoId,
                    Value = item.Value,
                    IsDeleted = false
                });

                physicalDT.Rows.Add(item.Id, physicals.FirstOrDefault(c => c.Id == item.PhysicalInfoId)!.Title,
                    item.Value);
            }

            // Fill Resume Grid
            foreach (var item in employee.Resume)
            {
                employeeResult.Resume.Add(new EmployeeResumeRequest()
                {
                    Id = item.Id,
                    Title = item.Title,
                    FromDate = item.FromDate.Date,
                    ToDate = item.ToDate.Date,
                    Description = item.Description,
                    IsDeleted = false
                });

                resumeDT.Rows.Add(item.Id, item.Title,
                    item.FromDate.Date, item.ToDate.Date, item.Description);
            }
        }

        private async Task GetAllEmployeeCombos()
        {

            // Gender Combo
            var genders = await _masterDataQueryService.FindGenders();
            GenderCombo.ValueMember = "Id";
            GenderCombo.DisplayMember = "Title";
            foreach (var item in genders)
            {
                GenderCombo.Items.Add(item);
            }

            // Militiry Combo
            var militiries = await _masterDataQueryService.FindMilitaryServiceStatuses();
            MilitaryCombo.ValueMember = "Id";
            MilitaryCombo.DisplayMember = "Title";
            foreach (var item in militiries)
            {
                MilitaryCombo.Items.Add(item);
            }

            // Job Combo
            var jobs = await _masterDataQueryService.FindJobs();
            JobCombo.ValueMember = "Id";
            JobCombo.DisplayMember = "Title";
            foreach (var item in jobs)
            {
                JobCombo.Items.Add(item);
            }

            // Marital Combo
            var maritals = await _masterDataQueryService.FindMaritalStatuses();
            MaritalCombo.ValueMember = "Id";
            MaritalCombo.DisplayMember = "Title";
            foreach (var item in maritals)
            {
                MaritalCombo.Items.Add(item);
            }


        }

        private void InitiateGrids()
        {
            // Contact
            contactDT.Columns.Add("شناسه");
            contactDT.Columns.Add("عنوان");
            contactDT.Columns.Add("مقدار");
            contactDT.Columns.Add("نوع");
            ContactGrid.DataSource = contactDT;
            foreach (DataGridViewColumn column in ContactGrid.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            // Education
            educationDT.Columns.Add("شناسه");
            educationDT.Columns.Add("مقطع");
            educationDT.Columns.Add("رشته");
            educationDT.Columns.Add("گرایش");
            educationDT.Columns.Add("معدل");
            EducationGrid.DataSource = educationDT;
            foreach (DataGridViewColumn column in EducationGrid.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            // Physical
            physicalDT.Columns.Add("شناسه");
            physicalDT.Columns.Add("نوع");
            physicalDT.Columns.Add("مقدار");
            PhysicalGrid.DataSource = physicalDT;
            foreach (DataGridViewColumn column in PhysicalGrid.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            // Resume
            resumeDT.Columns.Add("شناسه");
            resumeDT.Columns.Add("عنوان");
            resumeDT.Columns.Add("تاریخ استخدام");
            resumeDT.Columns.Add("تاریخ پایان همکاری");
            resumeDT.Columns.Add("شرح کار");
            ResumeGrid.DataSource = resumeDT;
            foreach (DataGridViewColumn column in ResumeGrid.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void DisableButtonsAndClearSelection()
        {
            // Disable Buttons
            UpdateContact.Enabled = false;
            RemoveContact.Enabled = false;
            UpdateEducation.Enabled = false;
            RemoveEducation.Enabled = false;
            UpdatePhysical.Enabled = false;
            RemovePhysical.Enabled = false;
            UpdateResume.Enabled = false;
            RemoveResume.Enabled = false;

            // Clear Grid Selection
            ContactGrid.ClearSelection();
            EducationGrid.ClearSelection();
            PhysicalGrid.ClearSelection();
            ResumeGrid.ClearSelection();

        }

        private void EmployeeTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisableButtonsAndClearSelection();
        }

        #region contact

        private void ContactGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DisableButtonsAndClearSelection();
        }

        private void ContactGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            RemoveContact.Enabled = true;
            UpdateContact.Enabled = true;

            if (e.RowIndex > -1)
            {
                var selectedItem = ContactGrid.Rows[e.RowIndex];
                selectedContact = new EmployeeContactRequest()
                {
                    Id = int.Parse(selectedItem.Cells[0].Value.ToString()!),
                    Title = selectedItem.Cells[1].Value.ToString()!,
                    Value = selectedItem.Cells[2].Value.ToString()!,
                    ContactTypeTitle = selectedItem.Cells[3].Value.ToString()!
                };
            }
        }

        private void ContactGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DisableButtonsAndClearSelection();
        }

        private void AddContact_Click(object sender, EventArgs e)
        {
            AddUpdateContactForm addContactForm = new AddUpdateContactForm(_provider);
            addContactForm.Text = "افزودن اطلاعات تماس";
            addContactForm.ShowDialog();

            // After Submit
            if (addContactForm.Contact != null)
            {
                employeeResult.Contacts.Add(addContactForm.Contact);

                contactDT.Rows.Add(0, addContactForm.Contact.Title,
                    addContactForm.Contact.Value,
                    addContactForm.Contact.ContactTypeTitle);

                addContactForm.Dispose();
            }

        }

        private void UpdateContact_Click(object sender, EventArgs e)
        {
            if (UpdateContact.Enabled == true)
            {

                AddUpdateContactForm updateContact = new AddUpdateContactForm(_provider, selectedContact);
                updateContact.Text = "ویرایش اطلاعات تماس";
                updateContact.ShowDialog();

                // After Submit
                if (updateContact.Contact != null)
                {
                    // Update in Employee
                    EmployeeContactRequest updatedEmployeeContact;
                    if (selectedContact.Id != 0)
                    {
                        updatedEmployeeContact = employeeResult.Contacts.FirstOrDefault(c => c.Id == selectedContact.Id)!;
                    }
                    else
                    {
                        updatedEmployeeContact = employeeResult.Contacts.FirstOrDefault(c => c.Id == selectedContact.Id &&
                        c.Title == selectedContact.Title && c.Value == selectedContact.Value &&
                        c.ContactTypeTitle == selectedContact.ContactTypeTitle)!;
                    }

                    updatedEmployeeContact!.Title = updateContact.Contact.Title;
                    updatedEmployeeContact.Value = updateContact.Contact.Value;
                    updatedEmployeeContact.TypeId = updateContact.Contact.TypeId;

                    // Remove Old From Table
                    contactDT.Rows.RemoveAt(ContactGrid.SelectedRows[0].Index);
                    // Add New To Table
                    contactDT.Rows.Add(updateContact.Contact.Id, updateContact.Contact.Title,
                        updateContact.Contact.Value,
                        updateContact.Contact.ContactTypeTitle);

                    updateContact.Dispose();
                }

                DisableButtonsAndClearSelection();

            }
        }

        private void RemoveContact_Click(object sender, EventArgs e)
        {
            if (RemoveContact.Enabled == true)
            {
                try
                {
                    DialogResult dialogResult = MessageBox.Show("آیا مایل به حذف اطلاعات تماس انتخاب شده هستید؟", "", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {

                        if (selectedContact.Id == 0)
                        {
                            // Remove From employee
                            var deletedItem = employeeResult.Contacts.FirstOrDefault(c => c.Id == selectedContact.Id && 
                            c.Value == selectedContact.Value && c.Title == selectedContact.Title &&
                            c.ContactTypeTitle == selectedContact.ContactTypeTitle);
                            employeeResult.Contacts.Remove(deletedItem!);

                            // Remove From Table
                            contactDT.Rows.RemoveAt(ContactGrid.SelectedRows[0].Index);
                        }
                        else
                        {
                            // Remove From employee
                            var deletedItem = employeeResult.Contacts.FirstOrDefault(c => c.Id == selectedContact.Id);
                            deletedItem!.IsDeleted = true;

                            // Remove From Table
                            contactDT.Rows.RemoveAt(ContactGrid.SelectedRows[0].Index);
                        }
                        MessageBox.Show("حذف با موفقیت انجام شد");
                        DisableButtonsAndClearSelection();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        #endregion

        #region education
        private void EducationGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DisableButtonsAndClearSelection();
        }

        private void EducationGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            RemoveEducation.Enabled = true;
            UpdateEducation.Enabled = true;

            if (e.RowIndex > -1)
            {
                var selectedItem = EducationGrid.Rows[e.RowIndex];
                selectedEducation = new EmployeeEducationRequest()
                {
                    Id = int.Parse(selectedItem.Cells[0].Value.ToString()!),
                    LevelTitle = selectedItem.Cells[1].Value.ToString()!,
                    MajorTitle = selectedItem.Cells[2].Value.ToString()!,
                    Minor = selectedItem.Cells[3].Value.ToString()!,
                    AverageStr = selectedItem.Cells[4].Value.ToString()!
                };
            }
        }

        private void EducationGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DisableButtonsAndClearSelection();
        }

        private void AddEducation_Click(object sender, EventArgs e)
        {

            AddUpdateEducationForm addEducationForm = new AddUpdateEducationForm(_provider);
            addEducationForm.Text = "افزودن اطلاعات تحصیلی";
            addEducationForm.ShowDialog();

            // After Submit
            if (addEducationForm.Education != null)
            {
                employeeResult.Educations.Add(addEducationForm.Education);

                educationDT.Rows.Add(0, addEducationForm.Education.LevelTitle,
                    addEducationForm.Education.MajorTitle,
                    addEducationForm.Education.Minor,
                    addEducationForm.Education.Average);
            }



        }

        private void UpdateEducation_Click(object sender, EventArgs e)
        {

            if (UpdateEducation.Enabled == true)
            {

                AddUpdateEducationForm updateEducation = new AddUpdateEducationForm(_provider, selectedEducation);
                updateEducation.Text = "ویرایش اطلاعات تحصیلی";
                updateEducation.ShowDialog();

                // After Submit
                if (updateEducation.Education != null)
                {
                    // Update in Employee
                    EmployeeEducationRequest updatedEmployeeEducation;
                    if (selectedEducation.Id != 0)
                    {
                        updatedEmployeeEducation = employeeResult.Educations.FirstOrDefault(c => c.Id == selectedEducation.Id)!;
                    }
                    else
                    {
                        updatedEmployeeEducation = employeeResult.Educations.FirstOrDefault(c => c.Id == selectedEducation.Id &&
                        c.LevelTitle == selectedEducation.LevelTitle && c.MajorTitle == selectedEducation.MajorTitle &&
                        c.Minor == selectedEducation.Minor && c.Average.ToString() == selectedEducation.AverageStr)!;
                    }

                    updatedEmployeeEducation!.LevelId = updateEducation.Education.LevelId;
                    updatedEmployeeEducation.MajorId = updateEducation.Education.MajorId;
                    updatedEmployeeEducation.Minor = updateEducation.Education.Minor;
                    updatedEmployeeEducation.Average = updateEducation.Education.Average;

                    // Remove Old From Table
                    educationDT.Rows.RemoveAt(EducationGrid.SelectedRows[0].Index);
                    // Add New To Table
                    educationDT.Rows.Add(updateEducation.Education.Id, updateEducation.Education.LevelTitle,
                        updateEducation.Education.MajorTitle,
                        updateEducation.Education.Minor,
                        updateEducation.Education.Average);

                    updateEducation.Dispose();
                }

                DisableButtonsAndClearSelection();

            }
        }

        private void RemoveEducation_Click(object sender, EventArgs e)
        {
            if (RemoveEducation.Enabled == true)
            {
                try
                {
                    DialogResult dialogResult = MessageBox.Show("آیا مایل به حذف اطلاعات تحصیلی انتخاب شده هستید؟", "", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {

                        if (selectedEducation.Id == 0)
                        {
                            // Remove From employee
                            var deletedItem = employeeResult.Educations.FirstOrDefault(c => c.Id == selectedEducation.Id &&
                            c.LevelTitle == selectedEducation.LevelTitle && c.MajorTitle == selectedEducation.MajorTitle &&
                            c.Minor == selectedEducation.Minor && c.Average.ToString() == selectedEducation.AverageStr);
                            employeeResult.Educations.Remove(deletedItem!);

                            // Remove From Table
                            educationDT.Rows.RemoveAt(EducationGrid.SelectedRows[0].Index);
                        }
                        else
                        {
                            // Remove From employee
                            var deletedItem = employeeResult.Educations.FirstOrDefault(c => c.Id == selectedEducation.Id);
                            deletedItem!.IsDeleted = true;
                            // Remove From Table
                            educationDT.Rows.RemoveAt(EducationGrid.SelectedRows[0].Index);
                        }
                        MessageBox.Show("حذف با موفقیت انجام شد");
                        DisableButtonsAndClearSelection();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        #endregion

        #region physical
        private void PhysicalGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DisableButtonsAndClearSelection();
        }

        private void PhysicalGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            RemovePhysical.Enabled = true;
            UpdatePhysical.Enabled = true;

            if (e.RowIndex > -1)
            {
                var selectedItem = PhysicalGrid.Rows[e.RowIndex];
                selectedPhysical = new EmployeePhysicalInfoRequest()
                {
                    Id = int.Parse(selectedItem.Cells[0].Value.ToString()!),
                    PhysicalInfoTitle = selectedItem.Cells[1].Value.ToString()!,
                    Value = selectedItem.Cells[2].Value.ToString()!
                };
            }
        }

        private void PhysicalGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DisableButtonsAndClearSelection();
        }

        private void AddPhysical_Click(object sender, EventArgs e)
        {
            AddUpdatePhysicalForm addPhysicalForm = new AddUpdatePhysicalForm(_provider);
            addPhysicalForm.Text = "افزودن اطلاعات فیزیکی";
            addPhysicalForm.ShowDialog();

            // After Submit
            if (addPhysicalForm.Physical != null)
            {
                employeeResult.PhysicalInfo.Add(addPhysicalForm.Physical);

                physicalDT.Rows.Add(0, addPhysicalForm.Physical.PhysicalInfoTitle,
                    addPhysicalForm.Physical.Value);

                addPhysicalForm.Dispose();
            }
        }

        private void UpdatePhysical_Click(object sender, EventArgs e)
        {
            if (UpdatePhysical.Enabled == true)
            {

                AddUpdatePhysicalForm updatePhysical = new AddUpdatePhysicalForm(_provider, selectedPhysical);
                updatePhysical.Text = "ویرایش اطلاعات فیزیکی";
                updatePhysical.ShowDialog();

                // After Submit
                if (updatePhysical.Physical != null)
                {
                    // Update in Employee
                    EmployeePhysicalInfoRequest updatedEmployeePhysical;
                    if (selectedPhysical.Id != 0)
                    {
                        updatedEmployeePhysical = employeeResult.PhysicalInfo.FirstOrDefault(c => c.Id == selectedPhysical.Id)!;
                    }
                    else
                    {
                        updatedEmployeePhysical = employeeResult.PhysicalInfo.FirstOrDefault(c => c.Id == selectedPhysical.Id &&
                        c.PhysicalInfoTitle == selectedPhysical.PhysicalInfoTitle && c.Value == selectedPhysical.Value)!;
                    }

                    updatedEmployeePhysical!.PhysicalInfoId = updatePhysical.Physical.PhysicalInfoId;
                    updatedEmployeePhysical.Value = updatePhysical.Physical.Value;

                    // Remove Old From Table
                    physicalDT.Rows.RemoveAt(PhysicalGrid.SelectedRows[0].Index);
                    // Add New To Table
                    physicalDT.Rows.Add(updatePhysical.Physical.Id, updatePhysical.Physical.PhysicalInfoTitle,
                        updatePhysical.Physical.Value);

                    updatePhysical.Dispose();
                }

                DisableButtonsAndClearSelection();

            }
        }

        private void RemovePhysical_Click(object sender, EventArgs e)
        {
            if (RemovePhysical.Enabled == true)
            {
                try
                {
                    DialogResult dialogResult = MessageBox.Show("آیا مایل به حذف اطلاعات فیزیکی انتخاب شده هستید؟", "", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {

                        if (selectedPhysical.Id == 0)
                        {
                            // Remove From employee
                            var deletedItem = employeeResult.PhysicalInfo.FirstOrDefault(c => c.Id == selectedPhysical.Id &&
                            c.PhysicalInfoTitle == selectedPhysical.PhysicalInfoTitle && c.Value == selectedPhysical.Value);
                            employeeResult.PhysicalInfo.Remove(deletedItem!);

                            // Remove From Table
                            physicalDT.Rows.RemoveAt(PhysicalGrid.SelectedRows[0].Index);
                        }
                        else
                        {
                            // Remove From employee
                            var deletedItem = employeeResult.PhysicalInfo.FirstOrDefault(c => c.Id == selectedPhysical.Id);
                            deletedItem!.IsDeleted = true;
                            // Remove From Table
                            physicalDT.Rows.RemoveAt(PhysicalGrid.SelectedRows[0].Index);
                        }
                        MessageBox.Show("حذف با موفقیت انجام شد");
                        DisableButtonsAndClearSelection();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        #endregion

        #region resume
        private void ResumeGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DisableButtonsAndClearSelection();
        }

        private void ResumeGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            RemoveResume.Enabled = true;
            UpdateResume.Enabled = true;

            if (e.RowIndex > -1)
            {
                var selectedItem = ResumeGrid.Rows[e.RowIndex];
                selectedResume = new EmployeeResumeRequest()
                {
                    Id = int.Parse(selectedItem.Cells[0].Value.ToString()!),
                    Title = selectedItem.Cells[1].Value.ToString()!,
                    FromDate = DateTime.Parse(selectedItem.Cells[2].Value.ToString()!),
                    ToDate = DateTime.Parse(selectedItem.Cells[3].Value.ToString()!),
                    Description = selectedItem.Cells[4].Value.ToString()!
                };
            }
        }

        private void ResumeGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DisableButtonsAndClearSelection();
        }

        private void AddResume_Click(object sender, EventArgs e)
        {
            AddUpdateResumeForm addResumeForm = new AddUpdateResumeForm(_provider);
            addResumeForm.Text = "افزودن سابقه کاری";
            addResumeForm.ShowDialog();

            // After Submit
            if (addResumeForm.Resume != null)
            {
                employeeResult.Resume.Add(addResumeForm.Resume);

                resumeDT.Rows.Add(0, addResumeForm.Resume.Title,
                    addResumeForm.Resume.FromDate.Date, addResumeForm.Resume.ToDate.Date, addResumeForm.Resume.Description);

                addResumeForm.Dispose();
            }
        }

        private void UpdateResume_Click(object sender, EventArgs e)
        {
            if (UpdateResume.Enabled == true)
            {

                AddUpdateResumeForm updateResume = new AddUpdateResumeForm(_provider, selectedResume);
                updateResume.Text = "ویرایش سابقه کاری";
                updateResume.ShowDialog();

                // After Submit
                if (updateResume.Resume != null)
                {
                    // Update in Employee
                    EmployeeResumeRequest updatedEmployeeResume;
                    if (selectedResume.Id != 0)
                    {
                        updatedEmployeeResume = employeeResult.Resume.FirstOrDefault(c => c.Id == selectedResume.Id)!;
                    }
                    else
                    {
                        updatedEmployeeResume = employeeResult.Resume.FirstOrDefault(c => c.Id == selectedResume.Id &&
                        c.Title == selectedResume.Title && c.FromDate == selectedResume.FromDate.Date &&
                        c.ToDate == selectedResume.ToDate.Date && c.Description == selectedResume.Description)!;
                    }

                    updatedEmployeeResume!.Title = updateResume.Resume.Title;
                    updatedEmployeeResume!.FromDate = updateResume.Resume.FromDate.Date;
                    updatedEmployeeResume!.ToDate = updateResume.Resume.ToDate.Date;
                    updatedEmployeeResume.Description = updateResume.Resume.Description;

                    // Remove Old From Table
                    resumeDT.Rows.RemoveAt(ResumeGrid.SelectedRows[0].Index);
                    // Add New To Table
                    resumeDT.Rows.Add(updateResume.Resume.Id, updateResume.Resume.Title,
                        updateResume.Resume.FromDate.Date, updateResume.Resume.ToDate.Date, updateResume.Resume.Description);

                    updateResume.Dispose();
                }

                DisableButtonsAndClearSelection();

            }
        }

        private void RemoveResume_Click(object sender, EventArgs e)
        {
            if (RemoveResume.Enabled == true)
            {
                try
                {
                    DialogResult dialogResult = MessageBox.Show("آیا مایل به حذف سابقه کاری انتخاب شده هستید؟", "", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {

                        if (selectedResume.Id == 0)
                        {
                            // Remove From employee
                            var deletedItem = employeeResult.Resume.FirstOrDefault(c => c.Id == selectedResume.Id &&
                            c.Title == selectedResume.Title && c.Description == selectedResume.Description &&
                            c.FromDate.Date == selectedResume.FromDate.Date && c.ToDate.Date == selectedResume.ToDate.Date);
                            employeeResult.Resume.Remove(deletedItem!);

                            // Remove From Table
                            resumeDT.Rows.RemoveAt(ResumeGrid.SelectedRows[0].Index);
                        }
                        else
                        {
                            // Remove From employee
                            var deletedItem = employeeResult.Resume.FirstOrDefault(c => c.Id == selectedResume.Id);
                            deletedItem!.IsDeleted = true;
                            // Remove From Table
                            resumeDT.Rows.RemoveAt(ResumeGrid.SelectedRows[0].Index);
                        }
                        MessageBox.Show("حذف با موفقیت انجام شد");
                        DisableButtonsAndClearSelection();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }




        #endregion

    }
}
