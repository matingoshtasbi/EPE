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

namespace EPE.Presention.Forms.PerformanceEvaluate
{
    public partial class PerformanceEvaluateMenuForm : Form
    {
        private readonly IServiceProvider _provider;

        public PerformanceEvaluateMenuForm(IServiceProvider provider)
        {
            InitializeComponent();
            _provider = provider;
        }

        private void CalculateBtn_Click(object sender, EventArgs e)
        {
            MainEmployeeForm employeeForm = new MainEmployeeForm(_provider);
            foreach (var item in employeeForm.Controls)
            {
                if (item is Button)
                {
                    var btn = (Button)item;
                    btn.Visible = false;
                }
                else if (item is DataGridView)
                {
                    var grid = (DataGridView)item;
                    grid.Size = new Size(1074, 618);
                }
            }
            employeeForm.Text = "صفحه ی انتخاب کارمند برای ارزیابی عملکرد";
            employeeForm.ShowDialog();
        }

        private void ResultBtn_Click(object sender, EventArgs e)
        {
            PerformanceEvaluateSelectResultForm employeeForm = new PerformanceEvaluateSelectResultForm(_provider);
            employeeForm.ShowDialog();
        }
    }
}
