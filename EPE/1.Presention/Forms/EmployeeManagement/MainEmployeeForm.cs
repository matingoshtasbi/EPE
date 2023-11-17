using EPE.Presention.Forms.EmployeeManagement;
using EPE.Application.Abstractions.EmployeeManagement;
using EPE.Application.DTOs.EmployeeManagement;
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
using EPE.Presention.Forms.PerformanceEvaluate;

namespace EPE.Presention.Forms
{
    public partial class MainEmployeeForm : Form
    {
        private readonly IEmployeeQueryService _employeeQueryService;
        private readonly IEmployeeCommandService _employeeCommandService;
        private readonly IServiceProvider _provider;
        string lastSelectedId;

        DataTable employeeDT = new DataTable();

        public MainEmployeeForm(IServiceProvider provider)
        {
            InitializeComponent();
            _provider = provider;
            _employeeQueryService = _provider.GetService<IEmployeeQueryService>()!;
            _employeeCommandService = _provider.GetService<IEmployeeCommandService>()!;
        }

        private async void AddEmployeeBtb_Click(object sender, EventArgs e)
        {
            AddUpdateEmployeeForm addEmployeeForm = new AddUpdateEmployeeForm(_provider);
            this.Hide();
            addEmployeeForm.Text = "افزودن کارمند";
            addEmployeeForm.ShowDialog();

            // After Submit
            this.Show();
            await GetAllEmployees();
        }

        private async Task GetAllEmployees()
        {
            // Clear Table
            employeeDT.Clear();

            // Get Data
            var employees = await _employeeQueryService.FindEmployees();

            foreach (var item in employees.Results)
            {
                employeeDT.Rows.Add(item.Id, item.Code, item.FirstName, item.LastName);
            }

            DisableButtonsAndClearSelection();
        }

        private void DisableButtonsAndClearSelection()
        {
            UpdateEmployeeBtb.Enabled = false;
            DeleteEmployeeBtb.Enabled = false;

            // Clear Grid Selection
            EmployeeGrid.ClearSelection();
        }

        private void InitiateEmployeeGrid()
        {
            // Bind Data To GridView
            employeeDT.Columns.Add("شناسه");
            employeeDT.Columns.Add("کد پرسنلی");
            employeeDT.Columns.Add("نام");
            employeeDT.Columns.Add("نام خانوادگی");
            EmployeeGrid.DataSource = employeeDT;

            foreach (DataGridViewColumn column in EmployeeGrid.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void EmployeeGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (this.Text == "صفحه ی انتخاب کارمند برای ارزیابی عملکرد")
                {
                    var selectedItem = EmployeeGrid.Rows[e.RowIndex];
                    lastSelectedId = selectedItem.Cells[0].Value.ToString()!;
                    PerformanceEvaluateForm performanceEvaluateForm = new PerformanceEvaluateForm(_provider , lastSelectedId);

                    this.Hide();

                    performanceEvaluateForm.ShowDialog();

                    this.Show();

                    DisableButtonsAndClearSelection();
                }
                else
                {
                    UpdateEmployeeBtb.Enabled = true;
                    DeleteEmployeeBtb.Enabled = true;

                    var selectedItem = EmployeeGrid.Rows[e.RowIndex];
                    lastSelectedId = selectedItem.Cells[0].Value.ToString()!;
                }

            }
        }

        private async void UpdateEmployeeBtb_Click(object sender, EventArgs e)
        {
            if (UpdateEmployeeBtb.Enabled == true)
            {
                var employees = await _employeeQueryService.FindEmployee(Guid.Parse(lastSelectedId));
                AddUpdateEmployeeForm addEmployeeForm = new AddUpdateEmployeeForm(_provider, employees);
                this.Hide();
                addEmployeeForm.Text = "ویرایش کارمند";
                addEmployeeForm.ShowDialog();

                // After Submit
                this.Show();
            }
        }

        private async void MainEmployeeForm_Load(object sender, EventArgs e)
        {
            InitiateEmployeeGrid();
            await GetAllEmployees();

            EmployeeGrid.Columns["شناسه"].Visible = false;

        }

        private async void DeleteEmployeeBtb_Click(object sender, EventArgs e)
        {
            if (DeleteEmployeeBtb.Enabled == true)
            {
                try
                {
                    DialogResult dialogResult = MessageBox.Show("آیا مایل به حذف کارمند انتخاب شده هستید؟", "", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        await _employeeCommandService.RemoveEmployee(Guid.Parse(lastSelectedId));
                        MessageBox.Show("حذف با موفقیت انجام شد");
                        await GetAllEmployees();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void EmployeeGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DisableButtonsAndClearSelection();
        }

        private void EmployeeGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DisableButtonsAndClearSelection();
        }
    }
}
