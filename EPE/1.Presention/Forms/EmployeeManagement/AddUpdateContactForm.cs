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
using EPE.Domain.MasterData.Services;
using EPE.Application.Abstractions.MasterData;
using EPE.Domain.MasterData.ValueObjects;

namespace EPE.Presention.Forms.EmployeeManagement
{
    public partial class AddUpdateContactForm : Form
    {
        public EmployeeContactRequest Contact = null;
        EmployeeContactRequest updateContactTemp;

        private readonly IMasterDataQueryService _masterDataQueryService;
        private readonly IServiceProvider _provider;

        public AddUpdateContactForm(IServiceProvider provider)
        {
            InitializeComponent();
            _provider = provider;
            _masterDataQueryService = _provider.GetService<IMasterDataQueryService>()!;

        }

        public AddUpdateContactForm(IServiceProvider provider, EmployeeContactRequest selectedContact)
        {
            InitializeComponent();
            _provider = provider;
            _masterDataQueryService = _provider.GetService<IMasterDataQueryService>()!;

            updateContactTemp = selectedContact;
        }

        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Contact = new EmployeeContactRequest();

                Contact.Title = TitleTxt.Text;
                Contact.Value = ValueTxt.Text;
                if (TypeCombo.SelectedItem != null)
                {
                    Contact.TypeId = ((ContactType)TypeCombo.SelectedItem)!.Id;
                    Contact.ContactTypeTitle = ((ContactType)TypeCombo.SelectedItem)!.Title;
                }
                Contact.IsDeleted = false;

                if (this.Text == "ویرایش اطلاعات تماس")
                {
                    Contact.Id = updateContactTemp.Id;
                    MessageBox.Show("اطلاعات تماس ویرایش شد");
                }
                else
                {
                    Contact.Id = 0;
                    MessageBox.Show("اطلاعات تماس افزوده شد");
                }

                this.Close();
            }
            catch (Exception ex)
            {
                Contact = null;
                MessageBox.Show(ex.Message);
            }
        }

        private async Task GetAllContractCombos()
        {
            // ContactType Combo
            var contactTypes = await _masterDataQueryService.FindContactTypes();
            TypeCombo.ValueMember = "Id";
            TypeCombo.DisplayMember = "Title";
            foreach (var item in contactTypes)
            {
                TypeCombo.Items.Add(item);
            }
        }

        private async void AddUpdateContactForm_Load(object sender, EventArgs e)
        {
            await GetAllContractCombos();

            if (this.Text == "ویرایش اطلاعات تماس")
            {
                TypeCombo.SelectedIndex = TypeCombo.FindStringExact(updateContactTemp.ContactTypeTitle);
                TitleTxt.Text = updateContactTemp.Title;
                ValueTxt.Text = updateContactTemp.Value;
            }
        }
    }
}
