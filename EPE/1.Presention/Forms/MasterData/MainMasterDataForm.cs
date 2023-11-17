using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EPE.Presention.Forms.MasterData
{
    public partial class MainMasterDataForm : Form
    {
        private readonly IServiceProvider _provider;

        public MainMasterDataForm(IServiceProvider provider)
        {
            InitializeComponent();
            _provider = provider;
        }

        private void GenderBtn_Click(object sender, EventArgs e)
        {
            MasterDataTemplateForm masterDataGridForm = new MasterDataTemplateForm(_provider);
            masterDataGridForm.Text = "مدیریت آیتم های جنسیت";
            masterDataGridForm.ShowDialog();
        }

        private void LevelBtn_Click(object sender, EventArgs e)
        {
            MasterDataTemplateForm masterDataGridForm = new MasterDataTemplateForm(_provider);
            masterDataGridForm.Text = "مدیریت آیتم مقاطع تحصیلی";
            masterDataGridForm.ShowDialog();
        }

        private void MajorBtn_Click(object sender, EventArgs e)
        {
            MasterDataTemplateForm masterDataGridForm = new MasterDataTemplateForm(_provider);
            masterDataGridForm.Text = "مدیریت آیتم های رشته تحصیلی";
            masterDataGridForm.ShowDialog();
        }

        private void MilitaryBtn_Click(object sender, EventArgs e)
        {
            MasterDataTemplateForm masterDataGridForm = new MasterDataTemplateForm(_provider);
            masterDataGridForm.Text = "مدیریت آیتم های وضعیت خدمت";
            masterDataGridForm.ShowDialog();
        }

        private void MaritalBtn_Click(object sender, EventArgs e)
        {
            MasterDataTemplateForm masterDataGridForm = new MasterDataTemplateForm(_provider);
            masterDataGridForm.Text = "مدیریت آیتم های وضعیت تاهل";
            masterDataGridForm.ShowDialog();
        }

        private void PhysicalBtn_Click(object sender, EventArgs e)
        {
            MasterDataTemplateForm masterDataGridForm = new MasterDataTemplateForm(_provider);
            masterDataGridForm.Text = "مدیریت آیتم های فیزیکی";
            masterDataGridForm.ShowDialog();
        }

        private void MeritBtn_Click(object sender, EventArgs e)
        {
            MasterDataTemplateForm masterDataGridForm = new MasterDataTemplateForm(_provider);
            masterDataGridForm.Text = "مدیریت انواع شایستگی";
            masterDataGridForm.ShowDialog();
        }

        private void MeritItem_Click(object sender, EventArgs e)
        {
            MasterDataTemplateForm masterDataGridForm = new MasterDataTemplateForm(_provider);
            masterDataGridForm.Text = "مدیریت آیتم های انواع شایستگی";
            masterDataGridForm.ShowDialog();
        }

        private void EvaluationItemBtn_Click(object sender, EventArgs e)
        {
            MasterDataTemplateForm masterDataGridForm = new MasterDataTemplateForm(_provider);
            masterDataGridForm.Text = "مدیریت آیتم های ارزیابی";
            masterDataGridForm.ShowDialog();
        }

        private void JobBtn_Click(object sender, EventArgs e)
        {
            MasterDataTemplateForm masterDataGridForm = new MasterDataTemplateForm(_provider);
            masterDataGridForm.Text = "مدیریت شغل و آیتم های ارزیابی موثر بر شغل";
            masterDataGridForm.ShowDialog();
        }
    }
}
