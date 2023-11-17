using EPE.Application.Abstractions.MasterData;
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
using EPE.Application.DTOs.MasterData;
using EPE.Domain.MasterData.Aggregates;

namespace EPE.Presention.Forms.MasterData
{
    public partial class MasterDataTemplateForm : Form
    {
        // Service
        private readonly IServiceProvider _provider;
        private readonly IMasterDataQueryService _masterDataQueryService;
        private readonly IMasterDataCommandService _masterDataCommandService;

        // Local Variables
        EducationLevelRequest selectedLevel;
        EducationMajorRequest selectedMajor;
        GenderRequest selectedGender;
        MaritalStatusRequest selectedMaritalStatus;
        MilitaryServiceStatusRequest selectedMilitaryStatus;
        PhysicalInfoRequest selectedPhysicalInfo;
        MeritRequest selectedMerit;
        MeritItemRequest selectedMeritItem;
        EvaluationItemRequest selectedEvaluationItem;
        JobRequest selectedJob;

        // DataTables
        DataTable masterDataDT = new DataTable();


        public MasterDataTemplateForm(IServiceProvider provider)
        {
            InitializeComponent();
            _provider = provider;
            _masterDataQueryService = _provider.GetService<IMasterDataQueryService>()!;
            _masterDataCommandService = _provider.GetService<IMasterDataCommandService>()!;
        }

        private async void MasterDataTemplateForm_Load(object sender, EventArgs e)
        {
            InitiateGrid();

            if (this.Text == "مدیریت آیتم های جنسیت")
            {
                var genders = await _masterDataQueryService.FindGenders();
                foreach (var item in genders)
                {
                    masterDataDT.Rows.Add(item.Id, item.Title);
                }
            }
            else if (this.Text == "مدیریت آیتم مقاطع تحصیلی")
            {
                // Visible Require Controls
                OrderLbl.Visible = true;
                OrderTxt.Visible = true;

                var levels = await _masterDataQueryService.FindEducationLevels();
                foreach (var item in levels.OrderBy(c => c.Order))
                {
                    masterDataDT.Rows.Add(item.Id, item.Title, item.Order);
                }
            }
            else if (this.Text == "مدیریت آیتم های رشته تحصیلی")
            {
                var majors = await _masterDataQueryService.FindEducationMajors();
                foreach (var item in majors)
                {
                    masterDataDT.Rows.Add(item.Id, item.Title);
                }
            }
            else if (this.Text == "مدیریت آیتم های وضعیت خدمت")
            {
                var militaries = await _masterDataQueryService.FindMilitaryServiceStatuses();
                foreach (var item in militaries)
                {
                    masterDataDT.Rows.Add(item.Id, item.Title);
                }
            }
            else if (this.Text == "مدیریت آیتم های وضعیت تاهل")
            {
                var maritals = await _masterDataQueryService.FindMaritalStatuses();
                foreach (var item in maritals)
                {
                    masterDataDT.Rows.Add(item.Id, item.Title);
                }
            }
            else if (this.Text == "مدیریت آیتم های فیزیکی")
            {
                var physicals = await _masterDataQueryService.FindPhysicalInfos();
                foreach (var item in physicals)
                {
                    masterDataDT.Rows.Add(item.Id, item.Title);
                }
            }
            else if (this.Text == "مدیریت انواع شایستگی")
            {
                var merits = await _masterDataQueryService.FindMerits();
                foreach (var item in merits)
                {
                    masterDataDT.Rows.Add(item.Id, item.Title);
                }
            }
            else if (this.Text == "مدیریت آیتم های انواع شایستگی")
            {
                // Visible Require Controls
                TypeLbl.Visible = true;
                TypeCombo.Visible = true;

                // GetCombo Data
                var merits = await _masterDataQueryService.FindMerits();
                TypeCombo.ValueMember = "Id";
                TypeCombo.DisplayMember = "Title";
                foreach (var item in merits)
                {
                    TypeCombo.Items.Add(item);
                }

                // GetGrid Data
                var meritItems = await _masterDataQueryService.FindMeritItems();
                foreach (var item in meritItems.OrderBy(c => c.MeritId))
                {
                    masterDataDT.Rows.Add(item.Id, merits.FirstOrDefault(c => c.Id == item.MeritId)!.Title, item.Title);
                }
            }
            else if (this.Text == "مدیریت آیتم های ارزیابی")
            {
                // Visible Require Controls
                TypeLbl.Visible = true;
                TypeCombo.Visible = true;
                TypeItemLbl.Visible = true;
                TypeItemCombo.Visible = true;
                DescriptionLbl.Visible = true;
                DescriptionTxt.Visible = true;

                // GetCombo Data
                var merits = await _masterDataQueryService.FindMerits();
                TypeCombo.ValueMember = "Id";
                TypeCombo.DisplayMember = "Title";
                foreach (var item in merits)
                {
                    TypeCombo.Items.Add(item);
                }

                var meritItems = await _masterDataQueryService.FindMeritItems();
                TypeItemCombo.ValueMember = "Id";
                TypeItemCombo.DisplayMember = "Title";
                foreach (var item in meritItems)
                {
                    TypeItemCombo.Items.Add(item);
                }

                //GetGrid Data
                var evaluationItems = await _masterDataQueryService.FindEvaluationItems();
                foreach (var item in evaluationItems.OrderBy(c => c.MeritId))
                {
                    var meritItem = meritItems.FirstOrDefault(c => c.Id == item.MeritItemId)!;
                    var merit = merits.FirstOrDefault(c => c.Id == meritItem.MeritId);
                    masterDataDT.Rows.Add(item.Id, merit!.Title, meritItem.Title, item.Title, item.Description);
                }
            }
            else if (this.Text == "مدیریت شغل و آیتم های ارزیابی موثر بر شغل")
            {
                TitleTxt.Visible = false;
                TitleLbl.Visible = false;

                ClearBtn.Visible = false;

                var jobs = await _masterDataQueryService.FindJobs();
                foreach (var item in jobs)
                {
                    masterDataDT.Rows.Add(item.Id, item.Title);
                }
            }

            MasterDataGrid.Columns["شناسه"].Visible = false;

            DisableButtonsAndClearSelection();
        }

        private void DisableButtonsAndClearSelection()
        {
            TypeCombo.SelectedIndex = -1;
            TypeItemCombo.SelectedIndex = -1;
            TitleTxt.Text = "";
            OrderTxt.Text = "";
            DescriptionTxt.Text = "";

            UpdateMasterDataBtb.Enabled = false;
            DeleteMasterDataBtb.Enabled = false;
            AddMasterDataBtb.Enabled = true;

            TypeItemCombo.Enabled = false;

            MasterDataGrid.ClearSelection();
        }

        private void InitiateGrid()
        {
            masterDataDT.Columns.Add("شناسه");
            if (this.Text == "مدیریت آیتم مقاطع تحصیلی")
            {
                masterDataDT.Columns.Add("عنوان");
                masterDataDT.Columns.Add("الویت");
            }
            else if (this.Text == "مدیریت آیتم های انواع شایستگی")
            {
                masterDataDT.Columns.Add("نوع");
                masterDataDT.Columns.Add("عنوان");
            }
            else if (this.Text == "مدیریت آیتم های ارزیابی")
            {
                masterDataDT.Columns.Add("شایستگی");
                masterDataDT.Columns.Add("نوع");
                masterDataDT.Columns.Add("عنوان");
                masterDataDT.Columns.Add("توضیحات");
            }
            else
                masterDataDT.Columns.Add("عنوان");

            MasterDataGrid.DataSource = masterDataDT;
            foreach (DataGridViewColumn column in MasterDataGrid.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            DisableButtonsAndClearSelection();
        }

        private async void TypeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TypeCombo.SelectedIndex != -1 && this.Text == "مدیریت آیتم های ارزیابی")
            {
                TypeItemCombo.Items.Clear();
                TypeItemCombo.Enabled = true;

                var meritId = ((MeritMD)TypeCombo.SelectedItem)!.Id;

                var meritItems = _masterDataQueryService.FindMeritItemsByMeritId(meritId);
                foreach (var item in meritItems)
                {
                    TypeItemCombo.Items.Add(item);
                }
            }
        }

        #region MasterData Grid Events
        private void MasterDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.Text == "مدیریت آیتم های جنسیت")
            {
                if (e.RowIndex > -1)
                {
                    UpdateMasterDataBtb.Enabled = true;
                    DeleteMasterDataBtb.Enabled = true;
                    AddMasterDataBtb.Enabled = false;

                    var selectedItem = MasterDataGrid.Rows[e.RowIndex];
                    selectedGender = new GenderRequest()
                    {
                        Id = int.Parse(selectedItem.Cells[0].Value.ToString()!),
                        Title = selectedItem.Cells[1].Value.ToString()!
                    };

                    TitleTxt.Text = selectedGender.Title.ToString();
                }
            }
            else if (this.Text == "مدیریت آیتم مقاطع تحصیلی")
            {
                if (e.RowIndex > -1)
                {
                    UpdateMasterDataBtb.Enabled = true;
                    DeleteMasterDataBtb.Enabled = true;
                    AddMasterDataBtb.Enabled = false;

                    var selectedItem = MasterDataGrid.Rows[e.RowIndex];
                    selectedLevel = new EducationLevelRequest()
                    {
                        Id = int.Parse(selectedItem.Cells[0].Value.ToString()!),
                        Title = selectedItem.Cells[1].Value.ToString()!,
                        Order = int.Parse(selectedItem.Cells[2].Value.ToString()!)
                    };

                    TitleTxt.Text = selectedLevel.Title.ToString();
                    OrderTxt.Text = selectedLevel.Order.ToString();
                }
            }
            else if (this.Text == "مدیریت آیتم های رشته تحصیلی")
            {
                if (e.RowIndex > -1)
                {
                    UpdateMasterDataBtb.Enabled = true;
                    DeleteMasterDataBtb.Enabled = true;
                    AddMasterDataBtb.Enabled = false;

                    var selectedItem = MasterDataGrid.Rows[e.RowIndex];
                    selectedMajor = new EducationMajorRequest()
                    {
                        Id = int.Parse(selectedItem.Cells[0].Value.ToString()!),
                        Title = selectedItem.Cells[1].Value.ToString()!
                    };

                    TitleTxt.Text = selectedMajor.Title.ToString();
                }
            }
            else if (this.Text == "مدیریت آیتم های وضعیت خدمت")
            {
                if (e.RowIndex > -1)
                {
                    UpdateMasterDataBtb.Enabled = true;
                    DeleteMasterDataBtb.Enabled = true;
                    AddMasterDataBtb.Enabled = false;

                    var selectedItem = MasterDataGrid.Rows[e.RowIndex];
                    selectedMilitaryStatus = new MilitaryServiceStatusRequest()
                    {
                        Id = int.Parse(selectedItem.Cells[0].Value.ToString()!),
                        Title = selectedItem.Cells[1].Value.ToString()!
                    };

                    TitleTxt.Text = selectedMilitaryStatus.Title.ToString();
                }
            }
            else if (this.Text == "مدیریت آیتم های وضعیت تاهل")
            {
                if (e.RowIndex > -1)
                {
                    UpdateMasterDataBtb.Enabled = true;
                    DeleteMasterDataBtb.Enabled = true;
                    AddMasterDataBtb.Enabled = false;

                    var selectedItem = MasterDataGrid.Rows[e.RowIndex];
                    selectedMaritalStatus = new MaritalStatusRequest()
                    {
                        Id = int.Parse(selectedItem.Cells[0].Value.ToString()!),
                        Title = selectedItem.Cells[1].Value.ToString()!
                    };

                    TitleTxt.Text = selectedMaritalStatus.Title.ToString();
                }
            }
            else if (this.Text == "مدیریت آیتم های فیزیکی")
            {
                if (e.RowIndex > -1)
                {
                    UpdateMasterDataBtb.Enabled = true;
                    DeleteMasterDataBtb.Enabled = true;
                    AddMasterDataBtb.Enabled = false;

                    var selectedItem = MasterDataGrid.Rows[e.RowIndex];
                    selectedPhysicalInfo = new PhysicalInfoRequest()
                    {
                        Id = int.Parse(selectedItem.Cells[0].Value.ToString()!),
                        Title = selectedItem.Cells[1].Value.ToString()!
                    };

                    TitleTxt.Text = selectedPhysicalInfo.Title.ToString();
                }
            }
            else if (this.Text == "مدیریت انواع شایستگی")
            {
                if (e.RowIndex > -1)
                {
                    UpdateMasterDataBtb.Enabled = true;
                    DeleteMasterDataBtb.Enabled = true;
                    AddMasterDataBtb.Enabled = false;

                    var selectedItem = MasterDataGrid.Rows[e.RowIndex];
                    selectedMerit = new MeritRequest()
                    {
                        Id = int.Parse(selectedItem.Cells[0].Value.ToString()!),
                        Title = selectedItem.Cells[1].Value.ToString()!
                    };

                    TitleTxt.Text = selectedMerit.Title.ToString();
                }
            }
            else if (this.Text == "مدیریت آیتم های انواع شایستگی")
            {
                if (e.RowIndex > -1)
                {
                    UpdateMasterDataBtb.Enabled = true;
                    DeleteMasterDataBtb.Enabled = true;
                    AddMasterDataBtb.Enabled = false;

                    var selectedItem = MasterDataGrid.Rows[e.RowIndex];
                    selectedMeritItem = new MeritItemRequest()
                    {
                        Id = int.Parse(selectedItem.Cells[0].Value.ToString()!),
                        MeritTitle = selectedItem.Cells[1].Value.ToString()!,
                        Title = selectedItem.Cells[2].Value.ToString()!
                    };

                    TitleTxt.Text = selectedMeritItem.Title.ToString();
                    TypeCombo.SelectedIndex = TypeCombo.FindStringExact(selectedMeritItem.MeritTitle);

                    // Add MeritItem To SelectedMeritItem
                    selectedMeritItem.MeritId = ((MeritMD)TypeCombo.SelectedItem)!.Id;
                }
            }
            else if (this.Text == "مدیریت آیتم های ارزیابی")
            {
                if (e.RowIndex > -1)
                {
                    UpdateMasterDataBtb.Enabled = true;
                    DeleteMasterDataBtb.Enabled = true;
                    AddMasterDataBtb.Enabled = false;

                    TypeItemCombo.Enabled = true;

                    var selectedItem = MasterDataGrid.Rows[e.RowIndex];
                    selectedEvaluationItem = new EvaluationItemRequest()
                    {
                        Id = int.Parse(selectedItem.Cells[0].Value.ToString()!),
                        MeritTitle = selectedItem.Cells[1].Value.ToString()!,
                        MeritItemTitle = selectedItem.Cells[2].Value.ToString()!,
                        Title = selectedItem.Cells[3].Value.ToString()!,
                        Description = selectedItem.Cells[4].Value.ToString()!
                    };

                    TitleTxt.Text = selectedEvaluationItem.Title.ToString();
                    TypeCombo.SelectedIndex = TypeCombo.FindStringExact(selectedEvaluationItem.MeritTitle);
                    TypeItemCombo.SelectedIndex = TypeItemCombo.FindStringExact(selectedEvaluationItem.MeritItemTitle);
                    DescriptionTxt.Text = selectedEvaluationItem.Description.ToString();

                    // Add MeritItem To selectedEvaluationItem
                    selectedEvaluationItem.MeritItemId = ((MeritItemMD)TypeItemCombo.SelectedItem)!.Id;
                }
            }
            else if (this.Text == "مدیریت شغل و آیتم های ارزیابی موثر بر شغل")
            {
                if (e.RowIndex > -1)
                {
                    UpdateMasterDataBtb.Enabled = true;
                    DeleteMasterDataBtb.Enabled = true;

                    var selectedItem = MasterDataGrid.Rows[e.RowIndex];
                    selectedJob = new JobRequest()
                    {
                        Id = int.Parse(selectedItem.Cells[0].Value.ToString()!),
                        Title = selectedItem.Cells[1].Value.ToString()!
                    };
                }
            }

        }

        private void MasterDataGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DisableButtonsAndClearSelection();
        }

        private void MasterDataGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DisableButtonsAndClearSelection();
        }

        #endregion

        #region Crud MasterData
        private async void AddMasterDataBtb_Click(object sender, EventArgs e)
        {
            if (this.Text == "مدیریت آیتم های جنسیت")
            {
                try
                {
                    var gender = new GenderRequest()
                    {
                        Title = TitleTxt.Text
                    };

                    // Add To Db
                    var genderId = await _masterDataCommandService.AddGender(gender);

                    // Add To Grid
                    masterDataDT.Rows.Add(genderId, gender.Title);

                    MessageBox.Show("جنسیت با موفقیت افزوده شد");
                    DisableButtonsAndClearSelection();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (this.Text == "مدیریت آیتم مقاطع تحصیلی")
            {
                try
                {
                    var level = new EducationLevelRequest();

                    if (int.TryParse(OrderTxt.Text, out int order))
                    {
                        level.Title = TitleTxt.Text;
                        level.Order = order;
                    }
                    else
                        throw new Exception("الویت مقدار عددی است");

                    // Add To Db
                    var levelId = await _masterDataCommandService.AddEducationLevel(level);

                    // Add To Grid
                    masterDataDT.Rows.Add(levelId, level.Title, level.Order);

                    MessageBox.Show("مقطع تحصیلی با موفقیت افزوده شد");
                    DisableButtonsAndClearSelection();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (this.Text == "مدیریت آیتم های رشته تحصیلی")
            {
                try
                {
                    var major = new EducationMajorRequest()
                    {
                        Title = TitleTxt.Text
                    };

                    // Add To Db
                    var majorId = await _masterDataCommandService.AddEducationMajor(major);

                    // Add To Grid
                    masterDataDT.Rows.Add(majorId, major.Title);

                    MessageBox.Show("رشته تحصیلی با موفقیت افزوده شد");
                    DisableButtonsAndClearSelection();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (this.Text == "مدیریت آیتم های وضعیت خدمت")
            {
                try
                {
                    var military = new MilitaryServiceStatusRequest()
                    {
                        Title = TitleTxt.Text
                    };

                    // Add To Db
                    var militaryId = await _masterDataCommandService.AddMilitaryServiceStatus(military);

                    // Add To Grid
                    masterDataDT.Rows.Add(militaryId, military.Title);

                    MessageBox.Show("وضعیت خدمت با موفقیت افزوده شد");
                    DisableButtonsAndClearSelection();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (this.Text == "مدیریت آیتم های وضعیت تاهل")
            {
                try
                {
                    var marital = new MaritalStatusRequest()
                    {
                        Title = TitleTxt.Text
                    };

                    // Add To Db
                    var maritalId = await _masterDataCommandService.AddMaritalStatus(marital);

                    // Add To Grid
                    masterDataDT.Rows.Add(maritalId, marital.Title);

                    MessageBox.Show("وضعیت تاهل با موفقیت افزوده شد");
                    DisableButtonsAndClearSelection();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (this.Text == "مدیریت آیتم های فیزیکی")
            {
                try
                {
                    var physical = new PhysicalInfoRequest()
                    {
                        Title = TitleTxt.Text
                    };

                    // Add To Db
                    var physicalId = await _masterDataCommandService.AddPhysicalInfo(physical);

                    // Add To Grid
                    masterDataDT.Rows.Add(physicalId, physical.Title);

                    MessageBox.Show("آیتم فیزیکی با موفقیت افزوده شد");
                    DisableButtonsAndClearSelection();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (this.Text == "مدیریت انواع شایستگی")
            {
                try
                {
                    var merit = new MeritRequest()
                    {
                        Title = TitleTxt.Text
                    };

                    // Add To Db
                    var meritId = await _masterDataCommandService.AddMerit(merit);

                    // Add To Grid
                    masterDataDT.Rows.Add(meritId, merit.Title);

                    MessageBox.Show("شایستگی با موفقیت افزوده شد");
                    DisableButtonsAndClearSelection();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (this.Text == "مدیریت آیتم های انواع شایستگی")
            {
                try
                {
                    if (TypeCombo.SelectedIndex == -1)
                        throw new Exception("مقدار شایستگی اجباریست");

                    var meritItem = new MeritItemRequest()
                    {
                        Title = TitleTxt.Text,
                        MeritId = ((MeritMD)TypeCombo.SelectedItem)!.Id,
                        MeritTitle = ((MeritMD)TypeCombo.SelectedItem)!.Title
                    };

                    // Add To Db
                    var meritItemId = await _masterDataCommandService.AddMeritItem(meritItem);

                    // Add To Grid
                    masterDataDT.Rows.Add(meritItemId, meritItem.MeritTitle, meritItem.Title);

                    MessageBox.Show("آیتم شایستگی با موفقیت افزوده شد");
                    DisableButtonsAndClearSelection();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (this.Text == "مدیریت آیتم های ارزیابی")
            {
                try
                {
                    if (TypeItemCombo.SelectedIndex == -1)
                        throw new Exception("مقدار آیتم شایستگی اجباریست");

                    var evaluationItem = new EvaluationItemRequest()
                    {
                        MeritTitle = ((MeritMD)TypeCombo.SelectedItem)!.Title,
                        MeritItemId = ((MeritItemMD)TypeItemCombo.SelectedItem)!.Id,
                        MeritItemTitle = ((MeritItemMD)TypeItemCombo.SelectedItem)!.Title,
                        Title = TitleTxt.Text,
                        Description = DescriptionTxt.Text,
                    };

                    // Add To Db
                    var evaluationItemId = await _masterDataCommandService.AddEvaluationItem(evaluationItem);

                    // Add To Grid
                    masterDataDT.Rows.Add(evaluationItemId, evaluationItem.MeritTitle, evaluationItem.MeritItemTitle,
                        evaluationItem.Title, evaluationItem.Description);

                    MessageBox.Show("آیتم ارزیابی با موفقیت افزوده شد");
                    DisableButtonsAndClearSelection();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (this.Text == "مدیریت شغل و آیتم های ارزیابی موثر بر شغل")
            {
                AddUpdateJobForm addEmployeeForm = new AddUpdateJobForm(_provider);
                this.Hide();
                addEmployeeForm.Text = "افزودن اطلاعات شغل";
                addEmployeeForm.ShowDialog();

                // After Submit
                this.Show();

                var jobs = await _masterDataQueryService.FindJobs();
                masterDataDT.Rows.Clear();
                foreach (var item in jobs)
                {
                    masterDataDT.Rows.Add(item.Id, item.Title);
                }

                DisableButtonsAndClearSelection();
            }
        }

        private async void UpdateMasterDataBtb_Click(object sender, EventArgs e)
        {
            if (this.Text == "مدیریت آیتم های جنسیت")
            {
                try
                {
                    var updateGender = new GenderRequest()
                    {
                        Id = selectedGender.Id,
                        Title = TitleTxt.Text
                    };

                    // Update in DB
                    await _masterDataCommandService.UpdateGender(updateGender);

                    // Remove Old From Grid
                    masterDataDT.Rows.RemoveAt(MasterDataGrid.SelectedRows[0].Index);

                    // Add New To Table
                    masterDataDT.Rows.Add(updateGender.Id, updateGender.Title);

                    MessageBox.Show("جنسیت با موفقیت ویرایش شد");
                    DisableButtonsAndClearSelection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (this.Text == "مدیریت آیتم مقاطع تحصیلی")
            {
                try
                {
                    var updateLevel = new EducationLevelRequest();

                    if (int.TryParse(OrderTxt.Text, out int order))
                    {
                        updateLevel.Id = selectedLevel.Id;
                        updateLevel.Title = TitleTxt.Text;
                        updateLevel.Order = order;
                    }
                    else
                    {
                        throw new Exception("الویت مقدار عددی است");
                    }

                    // Update in DB
                    await _masterDataCommandService.UpdateEducationLevel(updateLevel);

                    // Remove Old From Grid
                    masterDataDT.Rows.RemoveAt(MasterDataGrid.SelectedRows[0].Index);

                    // Add New To Table
                    masterDataDT.Rows.Add(updateLevel.Id, updateLevel.Title, updateLevel.Order);

                    MessageBox.Show("مقطع تحصیلی با موفقیت ویرایش شد");
                    DisableButtonsAndClearSelection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (this.Text == "مدیریت آیتم های رشته تحصیلی")
            {
                try
                {
                    var updateMajor = new EducationMajorRequest()
                    {
                        Id = selectedMajor.Id,
                        Title = TitleTxt.Text
                    };

                    // Update in DB
                    await _masterDataCommandService.UpdateEducationMajor(updateMajor);

                    // Remove Old From Grid
                    masterDataDT.Rows.RemoveAt(MasterDataGrid.SelectedRows[0].Index);

                    // Add New To Table
                    masterDataDT.Rows.Add(updateMajor.Id, updateMajor.Title);

                    MessageBox.Show("رشته تحصیلی با موفقیت ویرایش شد");
                    DisableButtonsAndClearSelection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (this.Text == "مدیریت آیتم های وضعیت خدمت")
            {
                try
                {
                    var updateMilitary = new MilitaryServiceStatusRequest()
                    {
                        Id = selectedMilitaryStatus.Id,
                        Title = TitleTxt.Text
                    };

                    // Update in DB
                    await _masterDataCommandService.UpdateMilitaryServiceStatus(updateMilitary);

                    // Remove Old From Grid
                    masterDataDT.Rows.RemoveAt(MasterDataGrid.SelectedRows[0].Index);

                    // Add New To Table
                    masterDataDT.Rows.Add(updateMilitary.Id, updateMilitary.Title);

                    MessageBox.Show("وضعیت خدمت با موفقیت ویرایش شد");
                    DisableButtonsAndClearSelection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (this.Text == "مدیریت آیتم های وضعیت تاهل")
            {
                try
                {
                    var updateMarital = new MaritalStatusRequest()
                    {
                        Id = selectedMaritalStatus.Id,
                        Title = TitleTxt.Text
                    };

                    // Update in DB
                    await _masterDataCommandService.UpdateMaritalStatus(updateMarital);

                    // Remove Old From Grid
                    masterDataDT.Rows.RemoveAt(MasterDataGrid.SelectedRows[0].Index);

                    // Add New To Table
                    masterDataDT.Rows.Add(updateMarital.Id, updateMarital.Title);

                    MessageBox.Show("وضعیت تاهل با موفقیت ویرایش شد");
                    DisableButtonsAndClearSelection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (this.Text == "مدیریت آیتم های فیزیکی")
            {
                try
                {
                    var updatephysical = new PhysicalInfoRequest()
                    {
                        Id = selectedPhysicalInfo.Id,
                        Title = TitleTxt.Text
                    };

                    // Update in DB
                    await _masterDataCommandService.UpdatePhysicalInfo(updatephysical);

                    // Remove Old From Grid
                    masterDataDT.Rows.RemoveAt(MasterDataGrid.SelectedRows[0].Index);

                    // Add New To Table
                    masterDataDT.Rows.Add(updatephysical.Id, updatephysical.Title);

                    MessageBox.Show("آیتم فیزیکی با موفقیت ویرایش شد");
                    DisableButtonsAndClearSelection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (this.Text == "مدیریت انواع شایستگی")
            {
                try
                {
                    var updateMerit = new MeritRequest()
                    {
                        Id = selectedMerit.Id,
                        Title = TitleTxt.Text
                    };

                    // Update in DB
                    await _masterDataCommandService.UpdateMerit(updateMerit);

                    // Remove Old From Grid
                    masterDataDT.Rows.RemoveAt(MasterDataGrid.SelectedRows[0].Index);

                    // Add New To Table
                    masterDataDT.Rows.Add(updateMerit.Id, updateMerit.Title);

                    MessageBox.Show("شایستگی با موفقیت ویرایش شد");
                    DisableButtonsAndClearSelection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (this.Text == "مدیریت آیتم های انواع شایستگی")
            {
                try
                {
                    var updateMeritItem = new MeritItemRequest()
                    {
                        Id = selectedMeritItem.Id,
                        Title = TitleTxt.Text,
                        MeritId = ((MeritMD)TypeCombo.SelectedItem)!.Id,
                        MeritTitle = ((MeritMD)TypeCombo.SelectedItem)!.Title
                    };

                    // Update in DB
                    await _masterDataCommandService.UpdateMeritItem(updateMeritItem);

                    // Remove Old From Grid
                    masterDataDT.Rows.RemoveAt(MasterDataGrid.SelectedRows[0].Index);

                    // Add New To Table
                    masterDataDT.Rows.Add(updateMeritItem.Id, updateMeritItem.MeritTitle, updateMeritItem.Title);

                    MessageBox.Show("آیتم شایستگی با موفقیت ویرایش شد");
                    DisableButtonsAndClearSelection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (this.Text == "مدیریت آیتم های ارزیابی")
            {
                try
                {
                    if (TypeItemCombo.SelectedIndex == -1)
                        throw new Exception("مقدار آیتم شایستگی اجباریست");

                    var updateEvaluationItem = new EvaluationItemRequest()
                    {
                        Id = selectedEvaluationItem.Id,
                        MeritTitle = ((MeritMD)TypeCombo.SelectedItem)!.Title,
                        MeritItemId = ((MeritItemMD)TypeItemCombo.SelectedItem)!.Id,
                        MeritItemTitle = ((MeritItemMD)TypeItemCombo.SelectedItem)!.Title,
                        Title = TitleTxt.Text,
                        Description = DescriptionTxt.Text,
                    };

                    // Update in DB
                    await _masterDataCommandService.UpdateEvaluationItem(updateEvaluationItem);

                    // Remove Old From Grid
                    masterDataDT.Rows.RemoveAt(MasterDataGrid.SelectedRows[0].Index);

                    // Add New To Table
                    masterDataDT.Rows.Add(updateEvaluationItem.Id, updateEvaluationItem.MeritTitle, updateEvaluationItem.MeritItemTitle,
                        updateEvaluationItem.Title, updateEvaluationItem.Description);

                    MessageBox.Show("آیتم ارزیابی با موفقیت ویرایش شد");
                    DisableButtonsAndClearSelection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (this.Text == "مدیریت شغل و آیتم های ارزیابی موثر بر شغل")
            {
                if (UpdateMasterDataBtb.Enabled == true)
                {
                    var job = await _masterDataQueryService.FindJob(selectedJob.Id);
                    AddUpdateJobForm addJobForm = new AddUpdateJobForm(_provider, job);
                    this.Hide();
                    addJobForm.Text = "ویرایش اطلاعات شغل";
                    addJobForm.ShowDialog();

                    // After Submit
                    this.Show();

                    var jobs = await _masterDataQueryService.FindJobs();
                    masterDataDT.Rows.Clear();
                    foreach (var item in jobs)
                    {
                        masterDataDT.Rows.Add(item.Id, item.Title);
                    }

                    DisableButtonsAndClearSelection();
                }
            }

        }

        private async void DeleteMasterDataBtb_Click(object sender, EventArgs e)
        {
            if (DeleteMasterDataBtb.Enabled == true)
            {
                if (this.Text == "مدیریت آیتم های جنسیت")
                {
                    try
                    {
                        DialogResult dialogResult = MessageBox.Show("آیا مایل به حذف آیتم جنسیت انتخاب شده هستید؟", "", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {

                            // Remove From DB
                            await _masterDataCommandService.RemoveGender(selectedGender.Id);

                            // Remove From Grid
                            masterDataDT.Rows.RemoveAt(MasterDataGrid.SelectedRows[0].Index);

                            MessageBox.Show("حذف آیتم جنسیت با موفقیت انجام شد");
                            DisableButtonsAndClearSelection();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else if (this.Text == "مدیریت آیتم مقاطع تحصیلی")
                {
                    try
                    {
                        DialogResult dialogResult = MessageBox.Show("آیا مایل به حذف آیتم مقطع تحصیلی انتخاب شده هستید؟", "", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {

                            // Remove From DB
                            await _masterDataCommandService.RemoveEducationLevel(selectedLevel.Id);

                            // Remove From Grid
                            masterDataDT.Rows.RemoveAt(MasterDataGrid.SelectedRows[0].Index);

                            MessageBox.Show("حذف آیتم مقطع تحصیلی با موفقیت انجام شد");
                            DisableButtonsAndClearSelection();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else if (this.Text == "مدیریت آیتم های رشته تحصیلی")
                {
                    try
                    {
                        DialogResult dialogResult = MessageBox.Show("آیا مایل به حذف آیتم رشته تحصیلی انتخاب شده هستید؟", "", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {

                            // Remove From DB
                            await _masterDataCommandService.RemoveEducationMajor(selectedMajor.Id);

                            // Remove From Grid
                            masterDataDT.Rows.RemoveAt(MasterDataGrid.SelectedRows[0].Index);

                            MessageBox.Show("حذف آیتم رشته تحصیلی با موفقیت انجام شد");
                            DisableButtonsAndClearSelection();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else if (this.Text == "مدیریت آیتم های وضعیت خدمت")
                {
                    try
                    {
                        DialogResult dialogResult = MessageBox.Show("آیا مایل به حذف آیتم وضعیت خدمت انتخاب شده هستید؟", "", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {

                            // Remove From DB
                            await _masterDataCommandService.RemoveMilitaryServiceStatus(selectedMilitaryStatus.Id);

                            // Remove From Grid
                            masterDataDT.Rows.RemoveAt(MasterDataGrid.SelectedRows[0].Index);

                            MessageBox.Show("حذف آیتم وضعیت خدمت با موفقیت انجام شد");
                            DisableButtonsAndClearSelection();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else if (this.Text == "مدیریت آیتم های وضعیت تاهل")
                {
                    try
                    {
                        DialogResult dialogResult = MessageBox.Show("آیا مایل به حذف آیتم وضعیت تاهل انتخاب شده هستید؟", "", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {

                            // Remove From DB
                            await _masterDataCommandService.RemoveMaritalStatus(selectedMaritalStatus.Id);

                            // Remove From Grid
                            masterDataDT.Rows.RemoveAt(MasterDataGrid.SelectedRows[0].Index);

                            MessageBox.Show("حذف آیتم وضعیت تاهل با موفقیت انجام شد");
                            DisableButtonsAndClearSelection();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else if (this.Text == "مدیریت آیتم های فیزیکی")
                {
                    try
                    {
                        DialogResult dialogResult = MessageBox.Show("آیا مایل به حذف آیتم فیزیکی انتخاب شده هستید؟", "", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {

                            // Remove From DB
                            await _masterDataCommandService.RemovePhysicalInfo(selectedPhysicalInfo.Id);

                            // Remove From Grid
                            masterDataDT.Rows.RemoveAt(MasterDataGrid.SelectedRows[0].Index);

                            MessageBox.Show("حذف آیتم فیزیکی با موفقیت انجام شد");
                            DisableButtonsAndClearSelection();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else if (this.Text == "مدیریت انواع شایستگی")
                {
                    try
                    {
                        DialogResult dialogResult = MessageBox.Show("آیا مایل به حذف شایستگی انتخاب شده هستید؟", "", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {

                            // Remove From DB
                            await _masterDataCommandService.RemoveMerit(selectedMerit.Id);

                            // Remove From Grid
                            masterDataDT.Rows.RemoveAt(MasterDataGrid.SelectedRows[0].Index);

                            MessageBox.Show("حذف شایستگی با موفقیت انجام شد");
                            DisableButtonsAndClearSelection();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else if (this.Text == "مدیریت آیتم های انواع شایستگی")
                {
                    try
                    {
                        DialogResult dialogResult = MessageBox.Show("آیا مایل به حذف آیتم شایستگی انتخاب شده هستید؟", "", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {

                            // Remove From DB
                            await _masterDataCommandService.RemoveMeritItem(selectedMeritItem.Id);

                            // Remove From Grid
                            masterDataDT.Rows.RemoveAt(MasterDataGrid.SelectedRows[0].Index);

                            MessageBox.Show("حذف آیتم شایستگی با موفقیت انجام شد");
                            DisableButtonsAndClearSelection();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else if (this.Text == "مدیریت آیتم های ارزیابی")
                {
                    try
                    {
                        DialogResult dialogResult = MessageBox.Show("آیا مایل به حذف آیتم ارزیابی انتخاب شده هستید؟", "", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {

                            // Remove From DB
                            await _masterDataCommandService.RemoveEvaluationItem(selectedEvaluationItem.Id);

                            // Remove From Grid
                            masterDataDT.Rows.RemoveAt(MasterDataGrid.SelectedRows[0].Index);

                            MessageBox.Show("حذف آیتم ارزیابی با موفقیت انجام شد");
                            DisableButtonsAndClearSelection();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else if (this.Text == "مدیریت شغل و آیتم های ارزیابی موثر بر شغل")
                {
                    if (DeleteMasterDataBtb.Enabled == true)
                    {
                        try
                        {
                            DialogResult dialogResult = MessageBox.Show("آیا مایل به حذف آیتم شغل انتخاب شده هستید؟", "", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                await _masterDataCommandService.RemoveJob(selectedJob.Id);

                                // Remove From Grid
                                masterDataDT.Rows.RemoveAt(MasterDataGrid.SelectedRows[0].Index);

                                MessageBox.Show("حذف آیتم شغل با موفقیت انجام شد");
                                DisableButtonsAndClearSelection();
                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                    }
                }
            }

        }

        #endregion


    }
}
