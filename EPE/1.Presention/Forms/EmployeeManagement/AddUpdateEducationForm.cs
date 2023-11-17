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
using EPE.Application.Abstractions.MasterData;
using EPE.Domain.MasterData.Aggregates;

namespace EPE.Presention.Forms.EmployeeManagement
{
    public partial class AddUpdateEducationForm : Form
    {
        public EmployeeEducationRequest Education = null;
        EmployeeEducationRequest updateEducationTemp;

        private readonly IMasterDataQueryService _masterDataQueryService;
        private readonly IServiceProvider _provider;

        public AddUpdateEducationForm(IServiceProvider provider)
        {
            InitializeComponent();
            _provider = provider;
            _masterDataQueryService = _provider.GetService<IMasterDataQueryService>()!;
        }

        public AddUpdateEducationForm(IServiceProvider provider, EmployeeEducationRequest selectedEducation)
        {
            InitializeComponent();
            _provider = provider;
            _masterDataQueryService = _provider.GetService<IMasterDataQueryService>()!;

            updateEducationTemp = selectedEducation;
        }

        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            try
            {

                Education = new EmployeeEducationRequest();

                if (LevelCombo.SelectedItem != null)
                {
                    Education.LevelId = ((EducationLevelMD)LevelCombo.SelectedItem)!.Id;
                    Education.LevelTitle = ((EducationLevelMD)LevelCombo.SelectedItem)!.Title;
                }
                if (MajorCombo.SelectedItem != null)
                {
                    Education.MajorId = ((EducationMajorMD)MajorCombo.SelectedItem)!.Id;
                    Education.MajorTitle = ((EducationMajorMD)MajorCombo.SelectedItem)!.Title;
                }

                Education.Minor = MinorTxt.Text;
                if (double.TryParse(AverageTxt.Text, out double temp))
                {
                    Education.Average = temp;
                }
                else
                {
                    throw new Exception("معدل مقدار عددی است");
                }

                Education.IsDeleted = false;

                if (this.Text == "ویرایش اطلاعات تحصیلی")
                {
                    Education.Id = updateEducationTemp.Id;
                    MessageBox.Show("اطلاعات تحصیلی ویرایش شد");
                }
                else
                {
                    Education.Id = 0;
                    MessageBox.Show("اطلاعات تحصیلی افزوده شد");
                }

                this.Close();
            }
            catch (Exception ex)
            {
                Education = null;
                MessageBox.Show(ex.Message);
            }

        }

        private async Task GetAllEducationCombos()
        {
            // Level Combo
            var levels = await _masterDataQueryService.FindEducationLevels();
            LevelCombo.ValueMember = "Id";
            LevelCombo.DisplayMember = "Title";
            foreach (var item in levels.OrderByDescending(c => c.Order))
            {
                LevelCombo.Items.Add(item);
            }

            // Major Comvo
            var majors = await _masterDataQueryService.FindEducationMajors();
            MajorCombo.ValueMember = "Id";
            MajorCombo.DisplayMember = "Title";
            foreach (var item in majors)
            {
                MajorCombo.Items.Add(item);
            }
        }

        private async void AddUpdateEducationForm_Load(object sender, EventArgs e)
        {
            await GetAllEducationCombos();

            if (this.Text == "ویرایش اطلاعات تحصیلی")
            {
                LevelCombo.SelectedIndex = LevelCombo.FindStringExact(updateEducationTemp.LevelTitle);
                MajorCombo.SelectedIndex = MajorCombo.FindStringExact(updateEducationTemp.MajorTitle);
                MinorTxt.Text = updateEducationTemp.Minor;
                AverageTxt.Text = updateEducationTemp.AverageStr;
            }
        }
    }
}
