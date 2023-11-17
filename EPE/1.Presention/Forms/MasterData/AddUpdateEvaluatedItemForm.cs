using EPE.Application.Abstractions.MasterData;
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
using EPE.Application.DTOs.MasterData;
using EPE.Domain.MasterData.Aggregates;

namespace EPE.Presention.Forms.MasterData
{
    public partial class AddUpdateEvaluatedItemForm : Form
    {
        public JobEvaluatedItemRequest EvaluatedItem = null;
        JobEvaluatedItemRequest updateEvaluatedItemTemp;

        private readonly IMasterDataQueryService _masterDataQueryService;
        private readonly IServiceProvider _provider;
        public AddUpdateEvaluatedItemForm(IServiceProvider provider)
        {
            InitializeComponent();
            _provider = provider;
            _masterDataQueryService = _provider.GetService<IMasterDataQueryService>()!;
        }

        public AddUpdateEvaluatedItemForm(IServiceProvider provider, JobEvaluatedItemRequest selectedEvaluatedItem)
        {
            InitializeComponent();
            _provider = provider;
            _masterDataQueryService = _provider.GetService<IMasterDataQueryService>()!;

            updateEvaluatedItemTemp = selectedEvaluatedItem;
        }

        private async void AddUpdateEvaluatedItemForm_Load(object sender, EventArgs e)
        {
            await GetAllEvaluatedItemCombos();

            if (this.Text == "ویرایش آیتم موثر بر شغل")
            {
                ImportanceFactorTxt.Text = updateEvaluatedItemTemp.ImportanceFactor.ToString();
                CriterionScoreTxt.Text = updateEvaluatedItemTemp.CriterionScore.ToString();

                MeritCombo.SelectedIndex = MeritCombo.FindStringExact(updateEvaluatedItemTemp.MeritTitle);
                MeritItemCombo.SelectedIndex = MeritItemCombo.FindStringExact(updateEvaluatedItemTemp.MeritItemTitle);
                EvaluationItemCombo.SelectedIndex = EvaluationItemCombo.FindStringExact(updateEvaluatedItemTemp.EvaluationItemTitle);
            }

        }

        private async Task GetAllEvaluatedItemCombos()
        {
            // Merit Combo
            var merits = await _masterDataQueryService.FindMerits();
            MeritCombo.ValueMember = "Id";
            MeritCombo.DisplayMember = "Title";
            foreach (var item in merits)
            {
                MeritCombo.Items.Add(item);
            }

            // MeritItem Combo
            var meritItems = await _masterDataQueryService.FindMeritItems();
            MeritItemCombo.ValueMember = "Id";
            MeritItemCombo.DisplayMember = "Title";
            foreach (var item in merits)
            {
                MeritItemCombo.Items.Add(item);
            }

            // EvaluationItem Combo
            var evaluationItem = await _masterDataQueryService.FindEvaluationItems();
            EvaluationItemCombo.ValueMember = "Id";
            EvaluationItemCombo.DisplayMember = "Title";
            foreach (var item in merits)
            {
                EvaluationItemCombo.Items.Add(item);
            }
        }

        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            try
            {
                EvaluatedItem = new JobEvaluatedItemRequest();

                if (int.TryParse(ImportanceFactorTxt.Text, out int importanceFactorTemp))
                    EvaluatedItem.ImportanceFactor = importanceFactorTemp;
                else
                    throw new Exception("ضریب اهمیت مقدار عددی است");

                if (int.TryParse(CriterionScoreTxt.Text, out int criterionScoreTemp))
                    EvaluatedItem.CriterionScore = criterionScoreTemp;
                else
                    throw new Exception("ضریب اهمیت مقدار عددی است");


                if (MeritCombo.SelectedItem != null)
                {
                    EvaluatedItem.MeritTitle = ((MeritMD)MeritCombo.SelectedItem)!.Title;
                }
                if (MeritItemCombo.SelectedItem != null)
                {
                    EvaluatedItem.MeritItemTitle = ((MeritItemMD)MeritItemCombo.SelectedItem)!.Title;
                }
                if (EvaluationItemCombo.SelectedItem != null)
                {
                    EvaluatedItem.EvaluationItemTitle = ((EvaluationItemMD)EvaluationItemCombo.SelectedItem)!.Title;
                    EvaluatedItem.EvaluationItemId = ((EvaluationItemMD)EvaluationItemCombo.SelectedItem)!.Id;
                }

                EvaluatedItem.IsDeleted = false;

                if (this.Text == "ویرایش آیتم موثر بر شغل")
                {
                    EvaluatedItem.Id = updateEvaluatedItemTemp.Id;
                    MessageBox.Show("اطلاعات آیتم موثر بر شغل ویرایش شد");
                }
                else
                {
                    EvaluatedItem.Id = 0;
                    MessageBox.Show("اطلاعات آیتم موثر بر شغل افزوده شد");
                }

                this.Close();
            }
            catch (Exception ex)
            {
                EvaluatedItem = null;
                MessageBox.Show(ex.Message);
            }
        }

        private void MeritItemCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MeritItemCombo.SelectedIndex != -1)
            {
                EvaluationItemCombo.Items.Clear();
                EvaluationItemCombo.Enabled = true;

                var meritItemId = ((MeritItemMD)MeritItemCombo.SelectedItem)!.Id;

                var evaluationItems = _masterDataQueryService.FindEvaluationItemsByMeritItemId(meritItemId);
                foreach (var item in evaluationItems)
                {
                    EvaluationItemCombo.Items.Add(item);
                }
            }
        }

        private void MeritCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MeritCombo.SelectedIndex != -1)
            {
                MeritItemCombo.Items.Clear();
                EvaluationItemCombo.Items.Clear();
                MeritItemCombo.Enabled = true;

                var meritId = ((MeritMD)MeritCombo.SelectedItem)!.Id;

                var meritItems = _masterDataQueryService.FindMeritItemsByMeritId(meritId);
                foreach (var item in meritItems)
                {
                    MeritItemCombo.Items.Add(item);
                }
            }
        }
    }
}
