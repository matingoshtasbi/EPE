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
    public partial class AddUpdatePhysicalForm : Form
    {
        public EmployeePhysicalInfoRequest Physical = null;
        EmployeePhysicalInfoRequest updatePhysicalTemp;

        private readonly IMasterDataQueryService _masterDataQueryService;
        private readonly IServiceProvider _provider;

        public AddUpdatePhysicalForm(IServiceProvider provider)
        {
            InitializeComponent();
            _provider = provider;
            _masterDataQueryService = _provider.GetService<IMasterDataQueryService>()!;
        }

        public AddUpdatePhysicalForm(IServiceProvider provider, EmployeePhysicalInfoRequest selectedPhysical)
        {
            InitializeComponent();
            _provider = provider;
            _masterDataQueryService = _provider.GetService<IMasterDataQueryService>()!;

            updatePhysicalTemp = selectedPhysical;
        }

        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Physical = new EmployeePhysicalInfoRequest();

                Physical.Value = ValueTxt.Text;
                if (TypeCombo.SelectedItem != null)
                {
                    Physical.PhysicalInfoId = ((PhysicalInfoMD)TypeCombo.SelectedItem)!.Id;
                    Physical.PhysicalInfoTitle = ((PhysicalInfoMD)TypeCombo.SelectedItem)!.Title;
                }
                Physical.IsDeleted = false;

                if (this.Text == "ویرایش اطلاعات تماس")
                {
                    Physical.Id = updatePhysicalTemp.Id;
                    MessageBox.Show("اطلاعات فیزیکی ویرایش شد");
                }
                else
                {
                    Physical.Id = 0;
                    MessageBox.Show("اطلاعات فیزیکی افزوده شد");
                }

                this.Close();
            }
            catch (Exception ex)
            {
                Physical = null;
                MessageBox.Show(ex.Message);
            }
        }

        private async Task GetAllPhysicalCombos()
        {
            // PhysicalType Combo
            var physicals = await _masterDataQueryService.FindPhysicalInfos();
            TypeCombo.ValueMember = "Id";
            TypeCombo.DisplayMember = "Title";
            foreach (var item in physicals)
            {
                TypeCombo.Items.Add(item);
            }
        }

        private async void AddUpdatePhysicalForm_Load(object sender, EventArgs e)
        {
            await GetAllPhysicalCombos();

            if (this.Text == "ویرایش اطلاعات فیزیکی")
            {
                TypeCombo.SelectedIndex = TypeCombo.FindStringExact(updatePhysicalTemp.PhysicalInfoTitle);
                ValueTxt.Text = updatePhysicalTemp.Value;
            }
        }
    }
}
