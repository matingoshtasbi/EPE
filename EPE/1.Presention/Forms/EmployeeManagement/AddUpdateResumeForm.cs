using EPE.Application.Abstractions.MasterData;
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

namespace EPE.Presention.Forms.EmployeeManagement
{
    public partial class AddUpdateResumeForm : Form
    {
        public EmployeeResumeRequest Resume = null;
        EmployeeResumeRequest updateResumeTemp;

        private readonly IMasterDataQueryService _masterDataQueryService;
        private readonly IServiceProvider _provider;

        public AddUpdateResumeForm(IServiceProvider provider)
        {
            InitializeComponent();
            _provider = provider;
            _masterDataQueryService = _provider.GetService<IMasterDataQueryService>()!;
        }

        public AddUpdateResumeForm(IServiceProvider provider, EmployeeResumeRequest selectedResume)
        {
            InitializeComponent();
            _provider = provider;
            _masterDataQueryService = _provider.GetService<IMasterDataQueryService>()!;

            updateResumeTemp = selectedResume;
        }

        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Resume = new EmployeeResumeRequest();

                Resume.Title = TitleTxt.Text;
                Resume.FromDate = EmployementDP.Value.Date;
                Resume.ToDate = RelaseDP.Value.Date;
                Resume.Description = DescriptionTxt.Text;

                Resume.IsDeleted = false;

                if (this.Text == "ویرایش سابقه کاری")
                {
                    Resume.Id = updateResumeTemp.Id;
                    MessageBox.Show("سابقه کاری ویرایش شد");
                }
                else
                {
                    Resume.Id = 0;
                    MessageBox.Show("سابقه کاری افزوده شد");
                }

                this.Close();
            }
            catch (Exception ex)
            {
                Resume = null;
                MessageBox.Show(ex.Message);
            }
        }

        private void AddUpdateResumeForm_Load(object sender, EventArgs e)
        {
            if (this.Text == "ویرایش سابقه کاری")
            {
                TitleTxt.Text = updateResumeTemp.Title;
                EmployementDP.Value = updateResumeTemp.FromDate;
                RelaseDP.Value = updateResumeTemp.ToDate;
                DescriptionTxt.Text = updateResumeTemp.Description;
            }
        }
    }
}
