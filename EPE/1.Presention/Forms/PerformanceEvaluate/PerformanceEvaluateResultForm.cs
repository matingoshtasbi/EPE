using EPE.Domain.PerformanceEvaluate.Aggregates;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EPE.Presention.Forms.PerformanceEvaluate
{
    public partial class PerformanceEvaluateResultForm : Form
    {
        EmployeePerformanceEvaluate epeTemp;
        DataTable meritDT = new DataTable();
        DataTable meritItemDT = new DataTable();
        DataTable evaluateItemDT = new DataTable();
        public PerformanceEvaluateResultForm(EmployeePerformanceEvaluate epe)
        {
            InitializeComponent();
            epeTemp = epe;
        }

        private void PerformanceEvaluateResultForm_Load(object sender, EventArgs e)
        {
            InitiateGrids();

            FillFieldsAndGrids();

            //CalculatScoreColors();
        }

        private void CalculatScoreColors()
        {
            // Calculate Grids Score (For Color)
            foreach (DataGridViewRow row in EvaluateItemGrid.Rows)
            {
                if (row.Cells[9].Value.ToString() == "0")
                    row.Cells[9]!.Style.BackColor = Color.IndianRed;
                else if (int.Parse(row.Cells[9].Value.ToString()!) >= int.Parse(row.Cells[8].Value.ToString()!))
                    row.Cells[9]!.Style.BackColor = Color.LightGreen;
                else
                    row.Cells[9]!.Style.BackColor = Color.Yellow;
            }

            foreach (DataGridViewRow row in MeritItemGrid.Rows)
            {
                if (row.Cells[5].Value.ToString() == "0")
                    row.Cells[5]!.Style.BackColor = Color.IndianRed;
                else if (int.Parse(row.Cells[5].Value.ToString()!) >= int.Parse(row.Cells[4].Value.ToString()!))
                    row.Cells[5]!.Style.BackColor = Color.LightGreen;
                else
                    row.Cells[5]!.Style.BackColor = Color.Yellow;
            }

            foreach (DataGridViewRow row in MeritGrid.Rows)
            {
                if (row.Cells[3].Value.ToString() == "0")
                    row.Cells[3]!.Style.BackColor = Color.IndianRed;
                else if (int.Parse(row.Cells[3].Value.ToString()!) >= int.Parse(row.Cells[2].Value.ToString()!))
                    row.Cells[3]!.Style.BackColor = Color.LightGreen;
                else
                    row.Cells[3]!.Style.BackColor = Color.Yellow;
            }
        }

        private void FillFieldsAndGrids()
        {
            // Fill Fields
            CodeTxt.Text = epeTemp.EmployeePersonalCode;
            FirstNameTxt.Text = epeTemp.EmployeeFirstName;
            LastNameTxt.Text = epeTemp.EmployeeLastName;
            EvaluateDP.Value = epeTemp.RegisterDate;
            TotalWeightedCriterionScoreTxt.Text = epeTemp.TotalWeightedCriterionScore.ToString();
            TotalWeightedScore.Text = epeTemp.TotalWeightedScore.ToString();

            MeritFactor.Text = epeTemp.MeritFactor.ToString();
            if (double.Parse(MeritFactor.Text) >= 1.00)
                MeritFactor.ForeColor = Color.Green;
            else
                MeritFactor.ForeColor = Color.Red;


            // Fill Grids
            foreach (var item in epeTemp.PerformanceEvaluateItems)
            {
                evaluateItemDT.Rows.Add(item.MeritTitle, item.MeritItemTitle, item.EvaluationItemTitle,
                    item.EvaluationItemDescription, item.ImportanceFactor, item.MeritItemScale,
                    item.MeritScale, item.TotalScale, item.CriterionScore, item.Score);
            }

            foreach (var item in epeTemp.MeritItemAverages)
            {
                meritItemDT.Rows.Add(item.MeritTitle, item.MeritItemTitle,
                    item.MeritScale, item.TotalScale, item.CriterionScore, item.Score);
            }

            foreach (var item in epeTemp.MeritAverages)
            {
                meritDT.Rows.Add(item.MeritTitle, item.TotalScale, item.CriterionScore, item.Score);
            }
        }

        private void InitiateGrids()
        {
            // EvaluateItem
            evaluateItemDT.Columns.Add("شایستگی");
            evaluateItemDT.Columns.Add("نوع");
            evaluateItemDT.Columns.Add("عنوان");
            evaluateItemDT.Columns.Add("توضیحات");
            evaluateItemDT.Columns.Add("ضریب اهمیت");
            evaluateItemDT.Columns.Add("وزن در آیتم (%)");
            evaluateItemDT.Columns.Add("وزن در شایستگی (%)");
            evaluateItemDT.Columns.Add("وزن کلی (%)");
            evaluateItemDT.Columns.Add("نمره ملاک");
            evaluateItemDT.Columns.Add("نمره");
            EvaluateItemGrid.DataSource = evaluateItemDT;
            foreach (DataGridViewColumn column in EvaluateItemGrid.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            // MeritItem
            meritItemDT.Columns.Add("شایستگی");
            meritItemDT.Columns.Add("عنوان");
            meritItemDT.Columns.Add("وزن در شایستگی (%)");
            meritItemDT.Columns.Add("وزن کلی (%)");
            meritItemDT.Columns.Add("نمره ملاک");
            meritItemDT.Columns.Add("نمره");
            MeritItemGrid.DataSource = meritItemDT;
            foreach (DataGridViewColumn column in MeritItemGrid.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            // Merit
            meritDT.Columns.Add("عنوان");
            meritDT.Columns.Add("وزن کلی (%)");
            meritDT.Columns.Add("نمره ملاک");
            meritDT.Columns.Add("نمره");
            MeritGrid.DataSource = meritDT;
            foreach (DataGridViewColumn column in MeritGrid.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void PerformanceEvaluateTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculatScoreColors();
        }
    }
}
