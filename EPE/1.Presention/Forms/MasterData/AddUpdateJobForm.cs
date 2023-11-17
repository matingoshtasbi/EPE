using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EPE.Application.Abstractions.MasterData;
using EPE.Application.DTOs.MasterData;
using EPE.Domain.MasterData.Aggregates;
using EPE.Domain.MasterData.Enums;
using Microsoft.Extensions.DependencyInjection;

namespace EPE.Presention.Forms.MasterData
{
    public partial class AddUpdateJobForm : Form
    {
        #region members
        // Services
        private readonly IServiceProvider _provider;
        private readonly IMasterDataCommandService _masterDataCommandService;
        private readonly IMasterDataQueryService _masterDataQueryService;

        // Local Variables
        int jobId;
        JobRequest jobResult = new JobRequest();
        JobMD updateJobTemp;
        JobEvaluatedItemRequest selectedEvaluatedItem;


        // DataTables
        DataTable evaluatedItemDT = new DataTable();
        #endregion

        #region constarctors
        public AddUpdateJobForm(IServiceProvider provider)
        {
            InitializeComponent();
            _provider = provider;
            _masterDataCommandService = _provider.GetService<IMasterDataCommandService>()!;
            _masterDataQueryService = _provider.GetService<IMasterDataQueryService>()!;
        }

        public AddUpdateJobForm(IServiceProvider provider, JobMD job)
        {
            InitializeComponent();
            _provider = provider;
            _masterDataCommandService = _provider.GetService<IMasterDataCommandService>()!;
            _masterDataQueryService = _provider.GetService<IMasterDataQueryService>()!;

            updateJobTemp = job;
        }
        #endregion

        private async void JobForm_Load(object sender, EventArgs e)
        {
            InitiateGrid();

            if (this.Text == "ویرایش اطلاعات شغل")
                await FillUpdateGrid(updateJobTemp);

            EvaluatedItemGrid.Columns["شناسه"].Visible = false;

            DisableButtonsAndClearSelection();
        }

        private async void SubmitBtn_Click(object sender, EventArgs e)
        {
            try
            {
                jobResult.Title = JobTxt.Text;

                if (this.Text == "افزودن اطلاعات شغل")
                {
                    await _masterDataCommandService.AddJob(jobResult);
                    MessageBox.Show("اطلاعات شغل با موفقیت ثبت شد");
                }
                else
                {
                    jobResult.Id = jobId;

                    await _masterDataCommandService.UpdateJob(jobResult);
                    MessageBox.Show("اطلاعات شغل با موفقیت ویرایش شد");
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private async Task FillUpdateGrid(JobMD job)
        {
            // Fill TextBox
            jobId = job.Id!;
            JobTxt.Text = job.Title;

            if (job.EvaluatedItems.Any())
            {
                // Fill Contact Grid
                var merits = await _masterDataQueryService.FindMerits();
                var meritItems = await _masterDataQueryService.FindMeritItems();
                var evaluationItems = await _masterDataQueryService.FindEvaluationItems();

                foreach (var item in job.EvaluatedItems)
                {
                    var evaluationItem = evaluationItems.FirstOrDefault(c => c.Id == item.EvaluationItemId)!;
                    var meritItem = meritItems.FirstOrDefault(c => c.Id == evaluationItem.MeritItemId)!;
                    var merit = merits.FirstOrDefault(c => c.Id == meritItem.MeritId)!;

                    jobResult.EvaluatedItems.Add(new JobEvaluatedItemRequest()
                    {
                        Id = item.Id,
                        MeritTitle = merit.Title,
                        MeritItemTitle = meritItem.Title,
                        EvaluationItemId = item.EvaluationItemId,
                        EvaluationItemTitle = evaluationItem.Title,
                        ImportanceFactor = item.ImportanceFactor,
                        CriterionScore = item.CriterionScore,
                        IsDeleted = false
                    });
                }

                // CalculateScales
                CalculateScales(jobResult.EvaluatedItems, (int)ScaleEnumMD.Total);

                foreach (var item in jobResult.EvaluatedItems.GroupBy(c => c.MeritTitle))
                {
                    CalculateScales(item.ToList(), (int)ScaleEnumMD.Merit);
                }

                foreach (var item in jobResult.EvaluatedItems.GroupBy(c => c.MeritItemTitle))
                {
                    CalculateScales(item.ToList(), (int)ScaleEnumMD.MeritItem);
                }

                foreach (var item in jobResult.EvaluatedItems)
                {
                    evaluatedItemDT.Rows.Add(item.Id, item.MeritTitle, item.MeritItemTitle, item.EvaluationItemTitle,
                        item.ImportanceFactor, item.MeritItemScale, item.MeritScale, item.TotalScale, item.CriterionScore);
                }

            }

        }

        private void InitiateGrid()
        {
            // EvaluatedItem
            evaluatedItemDT.Columns.Add("شناسه");
            evaluatedItemDT.Columns.Add("شایستگی");
            evaluatedItemDT.Columns.Add("نوع");
            evaluatedItemDT.Columns.Add("عنوان");
            evaluatedItemDT.Columns.Add("ضریب اهمیت");
            evaluatedItemDT.Columns.Add("وزن در آیتم (%)");
            evaluatedItemDT.Columns.Add("وزن در شایستگی (%)");
            evaluatedItemDT.Columns.Add("وزن کلی (%)");
            evaluatedItemDT.Columns.Add("نمره ملاک");

            EvaluatedItemGrid.DataSource = evaluatedItemDT;
            foreach (DataGridViewColumn column in EvaluatedItemGrid.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void DisableButtonsAndClearSelection()
        {
            // Disable Buttons
            UpdateEvaluatedItem.Enabled = false;
            RemoveEvaluatedItem.Enabled = false;
            // Clear Grid Selection
            EvaluatedItemGrid.ClearSelection();
        }

        private void JobTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisableButtonsAndClearSelection();
        }

        private void CalculateScales(List<JobEvaluatedItemRequest> evaluatedItems, int scaleType)
        {
            // Get Sum Of Factors
            var totalImportanceFactor = 0;
            foreach (var item in evaluatedItems)
            {
                totalImportanceFactor += item.ImportanceFactor;
            }

            if (totalImportanceFactor > 0)
            {
                // Calculate All Scales
                foreach (var item in evaluatedItems)
                {
                    item.MeritItemScale = ((double)item.ImportanceFactor / (double)totalImportanceFactor) * 100;
                }

                double[] originalValues = evaluatedItems.Select(c => c.MeritItemScale).ToArray();
                List<(double orginal, int round)> valuePairs = new List<(double orginal, int round)>();

                double totalSum = originalValues.Sum();
                int currentSum = 0;

                for (int i = 0; i < originalValues.Length; i++)
                {
                    double ratio = originalValues[i] / totalSum;
                    int roundedValue = (int)Math.Round(ratio * 100);
                    valuePairs.Add((originalValues[i], roundedValue));
                    currentSum += roundedValue;
                }

                // Calculate the rounding error
                int roundingError = 100 - currentSum;

                // Distribute the rounding error by adding or subtracting from the rounded values
                for (int i = 0; i < Math.Abs(roundingError); i++)
                {
                    int indexToAdjust = roundingError > 0 ? i : i % originalValues.Length;
                    var pair = valuePairs[indexToAdjust];
                    valuePairs[indexToAdjust] = (pair.orginal, pair.round + Math.Sign(roundingError));
                }
                // Now, roundedIntValues should contain integer values that sum up to 100.     

                foreach (var item in evaluatedItems)
                {
                    var temp = valuePairs.FirstOrDefault(c => c.orginal == item.MeritItemScale)!.round;
                    valuePairs.Remove(valuePairs.FirstOrDefault(c => c.orginal == item.MeritItemScale));
                    if (scaleType == (int)ScaleEnumMD.MeritItem)
                        item.MeritItemScale = temp;
                    else if (scaleType == (int)ScaleEnumMD.Merit)
                        item.MeritScale = temp;
                    else if (scaleType == (int)ScaleEnumMD.Total)
                        item.TotalScale = temp;
                }
            }
        }


        #region evaluatedItem
        private void EvaluatedItemGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DisableButtonsAndClearSelection();
        }

        private void EvaluatedItemGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            RemoveEvaluatedItem.Enabled = true;
            UpdateEvaluatedItem.Enabled = true;


            if (e.RowIndex > -1)
            {
                var selectedItem = EvaluatedItemGrid.Rows[e.RowIndex];
                selectedEvaluatedItem = new JobEvaluatedItemRequest()
                {
                    Id = long.Parse(selectedItem.Cells[0].Value.ToString()!),
                    MeritTitle = selectedItem.Cells[1].Value.ToString()!,
                    MeritItemTitle = selectedItem.Cells[2].Value.ToString()!,
                    EvaluationItemTitle = selectedItem.Cells[3].Value.ToString()!,
                    ImportanceFactor = int.Parse(selectedItem.Cells[4].Value.ToString()!),
                    CriterionScore = int.Parse(selectedItem.Cells[8].Value.ToString()!)
                };
            }
        }

        private void EvaluatedItemGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DisableButtonsAndClearSelection();
        }

        private async void AddEvaluatedItem_Click(object sender, EventArgs e)
        {
            AddUpdateEvaluatedItemForm addEvaluatedItemForm = new AddUpdateEvaluatedItemForm(_provider);
            addEvaluatedItemForm.Text = "افزودن آیتم موثر بر شغل";
            addEvaluatedItemForm.ShowDialog();

            // After Submit
            if (addEvaluatedItemForm.EvaluatedItem != null)
            {
                jobResult.EvaluatedItems.Add(addEvaluatedItemForm.EvaluatedItem);

                // ReFill Table with New Scales
                evaluatedItemDT.Rows.Clear();

                var merits = await _masterDataQueryService.FindMerits();
                var meritItems = await _masterDataQueryService.FindMeritItems();
                var evaluationItems = await _masterDataQueryService.FindEvaluationItems();

                foreach (var item in jobResult.EvaluatedItems.Where(c => c.IsDeleted == false))
                {
                    var evaluationItem = evaluationItems.FirstOrDefault(c => c.Id == item.EvaluationItemId)!;
                    var meritItem = meritItems.FirstOrDefault(c => c.Id == evaluationItem.MeritItemId)!;
                    var merit = merits.FirstOrDefault(c => c.Id == meritItem.MeritId)!;

                    item.MeritTitle = merit.Title;
                    item.MeritItemTitle = meritItem.Title;
                    item.EvaluationItemTitle = evaluationItem.Title;
                }

                // CalculateScales
                CalculateScales(jobResult.EvaluatedItems, (int)ScaleEnumMD.Total);

                foreach (var item in jobResult.EvaluatedItems.GroupBy(c => c.MeritTitle))
                {
                    CalculateScales(item.ToList(), (int)ScaleEnumMD.Merit);
                }

                foreach (var item in jobResult.EvaluatedItems.GroupBy(c => c.MeritItemTitle))
                {
                    CalculateScales(item.ToList(), (int)ScaleEnumMD.MeritItem);
                }

                foreach (var item in jobResult.EvaluatedItems)
                {
                    evaluatedItemDT.Rows.Add(item.Id, item.MeritTitle, item.MeritItemTitle, item.EvaluationItemTitle,
                        item.ImportanceFactor, item.MeritItemScale, item.MeritScale, item.TotalScale, item.CriterionScore);
                }
                addEvaluatedItemForm.Dispose();
            }
        }

        private async void UpdateEvaluatedItem_Click(object sender, EventArgs e)
        {
            if (UpdateEvaluatedItem.Enabled == true)
            {

                AddUpdateEvaluatedItemForm updateEvaluatedItem = new AddUpdateEvaluatedItemForm(_provider, selectedEvaluatedItem);
                updateEvaluatedItem.Text = "ویرایش آیتم موثر بر شغل";
                updateEvaluatedItem.ShowDialog();

                // After Submit
                if (updateEvaluatedItem.EvaluatedItem != null)
                {
                    // Update in Employee
                    JobEvaluatedItemRequest updatedEvaluatedItem;
                    if (selectedEvaluatedItem.Id != 0)
                    {
                        updatedEvaluatedItem = jobResult.EvaluatedItems.FirstOrDefault(c => c.Id == selectedEvaluatedItem.Id)!;
                    }
                    else
                    {
                        updatedEvaluatedItem = jobResult.EvaluatedItems.FirstOrDefault(c => c.Id == selectedEvaluatedItem.Id &&
                        c.MeritTitle == selectedEvaluatedItem.MeritTitle &&
                        c.MeritItemTitle == selectedEvaluatedItem.MeritItemTitle &&
                        c.EvaluationItemTitle == selectedEvaluatedItem.EvaluationItemTitle &&
                        c.ImportanceFactor == selectedEvaluatedItem.ImportanceFactor &&
                        c.CriterionScore == selectedEvaluatedItem.CriterionScore)!;
                    }

                    updatedEvaluatedItem!.MeritTitle = updateEvaluatedItem.EvaluatedItem.MeritTitle;
                    updatedEvaluatedItem!.MeritItemTitle = updateEvaluatedItem.EvaluatedItem.MeritItemTitle;
                    updatedEvaluatedItem!.EvaluationItemTitle = updateEvaluatedItem.EvaluatedItem.EvaluationItemTitle;
                    updatedEvaluatedItem!.EvaluationItemId = updateEvaluatedItem.EvaluatedItem.EvaluationItemId;
                    updatedEvaluatedItem.ImportanceFactor = updateEvaluatedItem.EvaluatedItem.ImportanceFactor;
                    updatedEvaluatedItem.CriterionScore = updateEvaluatedItem.EvaluatedItem.CriterionScore;

                    // ReFill Table with New Scales
                    evaluatedItemDT.Rows.Clear();

                    var merits = await _masterDataQueryService.FindMerits();
                    var meritItems = await _masterDataQueryService.FindMeritItems();
                    var evaluationItems = await _masterDataQueryService.FindEvaluationItems();

                    foreach (var item in jobResult.EvaluatedItems.Where(c => c.IsDeleted == false))
                    {
                        var evaluationItem = evaluationItems.FirstOrDefault(c => c.Id == item.EvaluationItemId)!;
                        var meritItem = meritItems.FirstOrDefault(c => c.Id == evaluationItem.MeritItemId)!;
                        var merit = merits.FirstOrDefault(c => c.Id == meritItem.MeritId)!;

                        item.MeritTitle = merit.Title;
                        item.MeritItemTitle = meritItem.Title;
                        item.EvaluationItemTitle = evaluationItem.Title;
                    }


                    // CalculateScales
                    CalculateScales(jobResult.EvaluatedItems, (int)ScaleEnumMD.Total);

                    foreach (var item in jobResult.EvaluatedItems.GroupBy(c => c.MeritTitle))
                    {
                        CalculateScales(item.ToList(), (int)ScaleEnumMD.Merit);
                    }

                    foreach (var item in jobResult.EvaluatedItems.GroupBy(c => c.MeritItemTitle))
                    {
                        CalculateScales(item.ToList(), (int)ScaleEnumMD.MeritItem);
                    }

                    foreach (var item in jobResult.EvaluatedItems)
                    {
                        evaluatedItemDT.Rows.Add(item.Id, item.MeritTitle, item.MeritItemTitle, item.EvaluationItemTitle,
                            item.ImportanceFactor, item.MeritItemScale, item.MeritScale, item.TotalScale, item.CriterionScore);
                    }

                    updateEvaluatedItem.Dispose();
                }

                DisableButtonsAndClearSelection();
            }
        }

        private async void RemoveEvaluatedItem_Click(object sender, EventArgs e)
        {
            if (RemoveEvaluatedItem.Enabled == true)
            {
                try
                {
                    DialogResult dialogResult = MessageBox.Show("آیا مایل به حذف اطلاعات موثر بر شغل انتخاب شده هستید؟", "", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {

                        if (selectedEvaluatedItem.Id == 0)
                        {
                            // Remove From Job
                            var deletedItem = jobResult.EvaluatedItems.FirstOrDefault(c => c.Id == selectedEvaluatedItem.Id &&
                            c.MeritTitle == selectedEvaluatedItem.MeritTitle &&
                            c.MeritItemTitle == selectedEvaluatedItem.MeritItemTitle &&
                            c.EvaluationItemTitle == selectedEvaluatedItem.EvaluationItemTitle &&
                            c.ImportanceFactor == selectedEvaluatedItem.ImportanceFactor &&
                            c.CriterionScore == selectedEvaluatedItem.CriterionScore);

                            jobResult.EvaluatedItems.Remove(deletedItem!);
                        }
                        else
                        {
                            // Remove From Job
                            var deletedItem = jobResult.EvaluatedItems.FirstOrDefault(c => c.Id == selectedEvaluatedItem.Id);

                            deletedItem!.IsDeleted = true;

                            // add This to Doesn't Influance on Scale
                            deletedItem!.ImportanceFactor = 0;
                        }

                        // ReFill Table with New Scales
                        evaluatedItemDT.Rows.Clear();

                        var merits = await _masterDataQueryService.FindMerits();
                        var meritItems = await _masterDataQueryService.FindMeritItems();
                        var evaluationItems = await _masterDataQueryService.FindEvaluationItems();

                        foreach (var item in jobResult.EvaluatedItems.Where(c => c.IsDeleted == false))
                        {
                            var evaluationItem = evaluationItems.FirstOrDefault(c => c.Id == item.EvaluationItemId)!;
                            var meritItem = meritItems.FirstOrDefault(c => c.Id == evaluationItem.MeritItemId)!;
                            var merit = merits.FirstOrDefault(c => c.Id == meritItem.MeritId)!;

                            item.MeritTitle = merit.Title;
                            item.MeritItemTitle = meritItem.Title;
                            item.EvaluationItemTitle = evaluationItem.Title;
                        }

                        // CalculateScales
                        CalculateScales(jobResult.EvaluatedItems, (int)ScaleEnumMD.Total);

                        foreach (var item in jobResult.EvaluatedItems.GroupBy(c => c.MeritTitle))
                        {
                            CalculateScales(item.ToList(), (int)ScaleEnumMD.Merit);
                        }

                        foreach (var item in jobResult.EvaluatedItems.GroupBy(c => c.MeritItemTitle))
                        {
                            CalculateScales(item.ToList(), (int)ScaleEnumMD.MeritItem);
                        }

                        foreach (var item in jobResult.EvaluatedItems)
                        {
                            evaluatedItemDT.Rows.Add(item.Id, item.MeritTitle, item.MeritItemTitle, item.EvaluationItemTitle,
                                item.ImportanceFactor, item.MeritItemScale , item.MeritScale , item.TotalScale, item.CriterionScore);
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
