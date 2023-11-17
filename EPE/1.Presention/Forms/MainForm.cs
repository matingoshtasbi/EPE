using EPE.Presention.Forms;
using EPE.Application.Abstractions.EmployeeManagement;
using EPE.Presention.Forms;
using Microsoft.Extensions.DependencyInjection;
using EPE.Presention.Forms.MasterData;
using EPE.Presention.Forms.PerformanceEvaluate;

namespace EPE.Presention.Forms
{
    public partial class MainForm : Form
    {
        private readonly IEmployeeQueryService _employeeQueryService;
        private readonly IEmployeeCommandService _employeeCommandService;
        private readonly IServiceProvider _provider;

        public MainForm(IServiceProvider provider)
        {
            InitializeComponent();
            _provider = provider;
            _employeeQueryService = _provider.GetService<IEmployeeQueryService>()!;
            _employeeCommandService = _provider.GetService<IEmployeeCommandService>()!;

        }

        #region employeeManagement
        private void employeeMenuBtn_Click(object sender, EventArgs e)
        {
            MainEmployeeForm employeeForm = new MainEmployeeForm(_provider);
            employeeForm.ShowDialog();
        }
        #endregion

        #region masterData
        private void masterDataMenuBtn_Click(object sender, EventArgs e)
        {
            MainMasterDataForm employeeForm = new MainMasterDataForm(_provider);
            employeeForm.ShowDialog();
        }
        #endregion

        #region aboutUs
        private void aboutMenuBtn_Click(object sender, EventArgs e)
        {
            var helpText = "1. برای استفاده از برنامه ابتدا در بخش اطلاعات پایه ، اطلاعات اولیه ی لازم برای محیط شغلی و سازمان خود را در سه بخش اطلاعات کارمندی ، اطلاعات ارزیابی و اطلاعات شغلی ثبت کنید. \n\n" +
                "2. سپس در بخش مدیریت کارمندان ، لیست کارمندان خود را با استفاده از آیتم های اطلاعات پایه ای ثبت شده و اطلاعات فردی هر شخص ذخیره کنید. \n\n" +
                "3. در انتها میتوانید در بخش ارزیابی عملکرد براساس اطلاعات کارمند و آیتم های ارزیابی ذخیره شده ، کارمندان را ارزیابی کنید و نتایج ارزیابی عملکرد کارمندان را مشاهده کنید. \n\n\n" +
                "ارتباط با سازنده : Matin.Goshtasbi@Gmail.com \n";

            MessageBox.Show(null, helpText, "راهنمای برنامه",
            MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1,
            MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
        }
        #endregion

        #region PerformanceEvaluate
        private void performanceEvaluateMenuBtn_Click(object sender, EventArgs e)
        {
            PerformanceEvaluateMenuForm performanceEvaluateMenuForm = new PerformanceEvaluateMenuForm(_provider);
            performanceEvaluateMenuForm.ShowDialog();
        }
        #endregion

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}