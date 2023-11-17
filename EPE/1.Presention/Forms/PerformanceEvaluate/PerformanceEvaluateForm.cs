using EPE.Application.Abstractions.EmployeeManagement;
using EPE.Presention.Forms.EmployeeManagement;
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
using EPE.Application.Abstractions.MasterData;
using EPE.Domain.MasterData.Aggregates;
using EPE.Application.DTOs.MasterData;
using EPE.Application.DTOs.PerformanceEvaluate;
using EPE.Application.Abstractions.PerformanceEvaluate;
using EPE.Domain.PerformanceEvaluate.Enums;

namespace EPE.Presention.Forms.PerformanceEvaluate
{
    public partial class PerformanceEvaluateForm : Form
    {
        // Services
        private readonly IServiceProvider _provider;
        private readonly IEmployeeQueryService _employeeQueryService;
        private readonly IMasterDataQueryService _masterDataQueryService;
        private readonly IPerformanceEvaluateCommandService _performanceEvaluateCommandService;

        // Local Variables
        string employeeId;
        AddUpdateEmployeeForm viewEmployeeForm = null;
        Domain.EmployeeManagement.Aggregates.Employee employeeTemp;
        JobRequest jobResult = new JobRequest();
        JobEvaluatedItemRequest performanceEvaluate;
        DataGridViewRow selectedRow = null;


        // DataTables
        DataTable performanceEvaluateDT = new DataTable();

        public PerformanceEvaluateForm(IServiceProvider provider, string selectedEmployeeId)
        {
            InitializeComponent();
            _provider = provider;
            _employeeQueryService = _provider.GetService<IEmployeeQueryService>()!;
            _masterDataQueryService = _provider.GetService<IMasterDataQueryService>()!;
            _performanceEvaluateCommandService = _provider.GetService<IPerformanceEvaluateCommandService>()!;

            employeeId = selectedEmployeeId;
        }

        private async void PerformanceEvaluateForm_Load(object sender, EventArgs e)
        {
            var employee = await _employeeQueryService.FindEmployee(Guid.Parse(employeeId));
            employeeTemp = employee;

            InitiateGrid();

            var job = await _masterDataQueryService.FindJob(employeeTemp.JobId!.Value);
            await FillGrid(job);

            PerformanceEvaluateGrid.Columns["شناسه"].Visible = false;


            PerformanceEvaluateGrid.Columns["شایستگی"].ReadOnly = true;
            PerformanceEvaluateGrid.Columns["نوع"].ReadOnly = true;
            PerformanceEvaluateGrid.Columns["عنوان"].ReadOnly = true;
            PerformanceEvaluateGrid.Columns["توضیحات"].ReadOnly = true;
            PerformanceEvaluateGrid.Columns["ضریب اهمیت"].ReadOnly = true;
            PerformanceEvaluateGrid.Columns["وزن در آیتم (%)"].ReadOnly = true;
            PerformanceEvaluateGrid.Columns["وزن در شایستگی (%)"].ReadOnly = true;
            PerformanceEvaluateGrid.Columns["وزن کلی (%)"].ReadOnly = true;
            PerformanceEvaluateGrid.Columns["نمره ملاک"].ReadOnly = true;
            PerformanceEvaluateGrid.Columns["نمره"].DefaultCellStyle.BackColor = Color.IndianRed;

            ClearSelection();

        }

        private void ClearSelection()
        {
            // Clear Grid Selection
            PerformanceEvaluateGrid.ClearSelection();
        }

        private void InitiateGrid()
        {
            performanceEvaluateDT.Columns.Add("شناسه");
            performanceEvaluateDT.Columns.Add("شایستگی");
            performanceEvaluateDT.Columns.Add("نوع");
            performanceEvaluateDT.Columns.Add("عنوان");
            performanceEvaluateDT.Columns.Add("توضیحات");
            performanceEvaluateDT.Columns.Add("ضریب اهمیت");
            performanceEvaluateDT.Columns.Add("وزن در آیتم (%)");
            performanceEvaluateDT.Columns.Add("وزن در شایستگی (%)");
            performanceEvaluateDT.Columns.Add("وزن کلی (%)");
            performanceEvaluateDT.Columns.Add("نمره ملاک");
            performanceEvaluateDT.Columns.Add("نمره");


            PerformanceEvaluateGrid.DataSource = performanceEvaluateDT;
            foreach (DataGridViewColumn column in PerformanceEvaluateGrid.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private async Task FillGrid(JobMD job)
        {
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
                        EvaluationItemDescription = evaluationItem.Description,
                        ImportanceFactor = item.ImportanceFactor,
                        CriterionScore = item.CriterionScore,
                        IsDeleted = false
                    });
                }

                // CalculateScales
                CalculateScales(jobResult.EvaluatedItems, (int)ScaleEnum.Total);

                foreach (var item in jobResult.EvaluatedItems.GroupBy(c => c.MeritTitle))
                {
                    CalculateScales(item.ToList(), (int)ScaleEnum.Merit);
                }

                foreach (var item in jobResult.EvaluatedItems.GroupBy(c => c.MeritItemTitle))
                {
                    CalculateScales(item.ToList(), (int)ScaleEnum.MeritItem);
                }

                foreach (var item in jobResult.EvaluatedItems)
                {
                    performanceEvaluateDT.Rows.Add(item.Id, item.MeritTitle, item.MeritItemTitle, item.EvaluationItemTitle,
                        item.EvaluationItemDescription, item.ImportanceFactor,
                        item.MeritItemScale, item.MeritScale, item.TotalScale, item.CriterionScore, 0);
                }

            }
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

                    if (scaleType == (int)ScaleEnum.MeritItem)
                        item.MeritItemScale = temp;
                    else if (scaleType == (int)ScaleEnum.Merit)
                        item.MeritScale = temp;
                    else if (scaleType == (int)ScaleEnum.Total)
                        item.TotalScale = temp;
                }
            }
        }

        private async void ViewEmployeeBtn_Click(object sender, EventArgs e)
        {
            if (viewEmployeeForm == null || viewEmployeeForm.IsDisposed)
                viewEmployeeForm = new AddUpdateEmployeeForm(_provider, employeeTemp);

            viewEmployeeForm.Text = "مشاهده کارمند";
            ManegeControls(viewEmployeeForm);

            viewEmployeeForm.Show();
        }

        private void ManegeControls(AddUpdateEmployeeForm viewEmployeeForm)
        {
            foreach (var item in viewEmployeeForm.Controls)
            {
                if (item is TabControl)
                {
                    var tab = (TabControl)item;
                    tab.Size = new Size(1078, 627);
                    foreach (var tabPage in tab.Controls)
                    {
                        var tPage = (TabPage)tabPage;
                        foreach (var itemTab in tPage.Controls)
                        {
                            if (itemTab is Button)
                            {
                                var btn = (Button)itemTab;
                                btn.Visible = false;
                            }
                            else if (itemTab is DateTimePicker)
                            {
                                var dp = (DateTimePicker)itemTab;
                                dp.Enabled = false;
                            }
                            else if (itemTab is TextBox)
                            {
                                var txt = (TextBox)itemTab;
                                txt.Enabled = false;
                            }
                            else if (itemTab is DataGridView)
                            {
                                var gv = (DataGridView)itemTab;
                                gv.Enabled = false;
                                gv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
                                gv.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                                gv.Size = new Size(1058, 583);
                            }
                            else if (itemTab is ComboBox)
                            {
                                var cmb = (ComboBox)itemTab;
                                cmb.Enabled = false;
                            }
                            else if (itemTab is RichTextBox)
                            {
                                var rich = (RichTextBox)itemTab;
                                rich.Enabled = false;
                                rich.Size = new Size(1058, 560);
                            }
                        }
                    }
                }
                else if (item is Button)
                {
                    var btn = (Button)item;
                    btn.Visible = false;
                }
            }
        }

        private async void SubmitBtn_Click(object sender, EventArgs e)
        {
            if (PerformanceEvaluateGrid.Rows.Count > 0)
            {
                try
                {
                    EmployeePerformanceEvaluateRequest result = new EmployeePerformanceEvaluateRequest();

                    result.EmployeePersonalCode = employeeTemp.Code;
                    result.EmployeeFirstName = employeeTemp.FirstName;
                    result.EmployeeLastName = employeeTemp.LastName;

                    foreach (DataGridViewRow row in PerformanceEvaluateGrid.Rows)
                    {
                        result.PerformanceEvaluateItems.Add(new PerformanceEvaluateItemRequest()
                        {
                            MeritTitle = row.Cells[1].Value.ToString()!,
                            MeritItemTitle = row.Cells[2].Value.ToString()!,
                            EvaluationItemTitle = row.Cells[3].Value.ToString()!,
                            EvaluationItemDescription = row.Cells[4].Value.ToString()!,
                            ImportanceFactor = int.Parse(row.Cells[5].Value.ToString()!),
                            MeritItemScale = double.Parse(row.Cells[6].Value.ToString()!),
                            MeritScale = double.Parse(row.Cells[7].Value.ToString()!),
                            TotalScale = double.Parse(row.Cells[8].Value.ToString()!),
                            CriterionScore = int.Parse(row.Cells[9].Value.ToString()!),
                            Score = int.Parse(row.Cells[10].Value.ToString()!)
                        });
                    }

                    var epe = await _performanceEvaluateCommandService.Calculate(result);
                    MessageBox.Show("ارزیابی با موفقیت انجام شد");
                    PerformanceEvaluateResultForm performanceEvaluateResultForm = new PerformanceEvaluateResultForm(epe);
                    this.Close();
                    performanceEvaluateResultForm.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("کارمند فاقد آیتم ارزیابی میباشد ، ابتدا آیتم های موثر برای شغل وی را ایجاد کنید");
            }
        }

        private void PerformanceEvaluateForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (viewEmployeeForm != null && viewEmployeeForm.IsDisposed == false)
                viewEmployeeForm.Close();
        }

        #region performanceEvaluated

        #endregion

        private void PerformanceEvaluateGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {


            }
        }

        private void PerformanceEvaluateGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ClearSelection();
        }

        private void PerformanceEvaluateGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                selectedRow = PerformanceEvaluateGrid.Rows[e.RowIndex];

                if (selectedRow.Cells[10].Value.ToString() != "0")
                {

                    if (!long.TryParse(selectedRow.Cells[10].Value.ToString(), out long temp))
                        throw new Exception("مقدار وارد شده نامعتبر است");

                    if (temp < 0 || temp > 100)
                        throw new Exception("مقدار وارد شده باید بین 0 تا 100 باشد");

                    foreach (DataGridViewRow row in PerformanceEvaluateGrid.Rows)
                    {
                        if (row.Cells[0].Value.ToString()! == selectedRow.Cells[0].Value.ToString())
                        {
                            if (int.Parse(row.Cells[10].Value.ToString()!) >= int.Parse(row.Cells[9].Value.ToString()!))
                                row.Cells[10]!.Style.BackColor = Color.LightGreen;
                            else
                                row.Cells[10]!.Style.BackColor = Color.Yellow;
                        }
                    }
                }
                else
                {
                    foreach (DataGridViewRow row in PerformanceEvaluateGrid.Rows)
                    {
                        if (row.Cells[0].Value.ToString()! == selectedRow.Cells[0].Value.ToString())
                        {
                            row.Cells[10]!.Style.BackColor = Color.IndianRed;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                foreach (DataGridViewRow row in PerformanceEvaluateGrid.Rows)
                {
                    if (row.Cells[0].Value.ToString()! == selectedRow.Cells[0].Value.ToString())
                    {
                        row.Cells[10]!.Style.BackColor = Color.IndianRed;
                        row.Cells[10]!.Value = 0;
                    }
                }

                ClearSelection();
            }
        }
    }
}
