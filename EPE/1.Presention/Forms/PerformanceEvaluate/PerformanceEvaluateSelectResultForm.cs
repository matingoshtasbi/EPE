using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EPE.Application.Abstractions.PerformanceEvaluate;
using Microsoft.Extensions.DependencyInjection;

namespace EPE.Presention.Forms.PerformanceEvaluate
{
    public partial class PerformanceEvaluateSelectResultForm : Form
    {
        DataTable resultDT = new DataTable();
        long lastSelectedId;

        private readonly IServiceProvider _provider;
        private readonly IPerformanceEvaluateQueryService _performanceEvaluateQueryService;
        private readonly IPerformanceEvaluateCommandService _performanceEvaluateCommandService;
        public PerformanceEvaluateSelectResultForm(IServiceProvider provider)
        {
            InitializeComponent();
            _provider = provider;
            _performanceEvaluateQueryService = _provider.GetService<IPerformanceEvaluateQueryService>()!;
            _performanceEvaluateCommandService = _provider.GetService<IPerformanceEvaluateCommandService>()!;
        }

        private async void PerformanceEvaluateSelectResultForm_Load(object sender, EventArgs e)
        {
            InitiateGrid();

            await GetAllResult();

            ResultGrid.Columns["شناسه"].Visible = false;
        }

        private async Task GetAllResult()
        {
            // Clear Table
            resultDT.Clear();

            // Get Data
            var results = await _performanceEvaluateQueryService.FindEPEs();

            foreach (var item in results.Results)
            {
                resultDT.Rows.Add(item.Id, item.EmployeePersonalCode, item.EmployeeFirstName, item.EmployeeLastName, item.RegisterDate);
            }

            DisableButtonsAndClearSelection();
        }

        private void InitiateGrid()
        {
            // Bind Data To GridView
            resultDT.Columns.Add("شناسه");
            resultDT.Columns.Add("کد پرسنلی");
            resultDT.Columns.Add("نام");
            resultDT.Columns.Add("نام خانوادگی");
            resultDT.Columns.Add("تاریخ ارزیابی");
            ResultGrid.DataSource = resultDT;

            foreach (DataGridViewColumn column in ResultGrid.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void DisableButtonsAndClearSelection()
        {
            DeleteBtb.Enabled = false;
            ViewBtb.Enabled = false;

            // Clear Grid Selection
            ResultGrid.ClearSelection();
        }

        private void ResultGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DisableButtonsAndClearSelection();
        }

        private async void ViewBtb_Click(object sender, EventArgs e)
        {
            if (ViewBtb.Enabled == true)
            {
                var epe = await _performanceEvaluateQueryService.FindEPE(lastSelectedId);
                PerformanceEvaluateResultForm performanceEvaluateResultForm = new PerformanceEvaluateResultForm(epe);
                performanceEvaluateResultForm.ShowDialog();
            }
        }

        private async void DeleteBtb_Click(object sender, EventArgs e)
        {
            if (DeleteBtb.Enabled == true)
            {
                try
                {
                    DialogResult dialogResult = MessageBox.Show("آیا مایل به حذف نتیجه ی ارزیابی انتخاب شده هستید؟", "", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        await _performanceEvaluateCommandService.RemoveEPE(lastSelectedId);
                        MessageBox.Show("حذف با موفقیت انجام شد");
                        await GetAllResult();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void ResultGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DeleteBtb.Enabled = true;
                ViewBtb.Enabled = true;

                var selectedItem = ResultGrid.Rows[e.RowIndex];
                lastSelectedId = long.Parse(selectedItem.Cells[0].Value.ToString()!);
            }
        }
    }
}
