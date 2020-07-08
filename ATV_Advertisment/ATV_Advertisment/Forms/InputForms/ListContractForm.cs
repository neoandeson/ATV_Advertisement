using ATV_Advertisement.Common;
using ATV_Advertisment.Common;
using ATV_Advertisment.Forms.CommonForms;
using ATV_Advertisment.Forms.DetailForms;
using ATV_Advertisment.Services;
using ATV_Advertisment.ViewModel;
using DataService.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ATV_Advertisment.Common.Constants;

namespace ATV_Advertisment.Forms.InputForms
{
    public partial class ListContractForm : CommonForm
    {
        private Contract contract = null;
        private ContractService _contractService = null;

        public ListContractForm()
        {
            InitializeComponent();
            LoadDGV();
        }

        #region AdvanceDataGridView
        private BindingSource bs = null;

        private void LoadDGV()
        {
            try
            {
                _contractService = new ContractService();
                List<ContractViewModel> contractVMs = _contractService.GetAllVMForList();
                SortableBindingList<ContractViewModel> sbl = new SortableBindingList<ContractViewModel>(contractVMs);
                bs = new BindingSource();
                bs.DataSource = sbl;
                adgv.DataSource = bs;
                adgv.Columns["Id"].Visible = false;

                adgv.Columns["ContractCode"].HeaderText = ADGVText.ContractCode;
                adgv.Columns["ContractCode"].Width = ControlsAttribute.GV_WIDTH_NORMAL;
                adgv.Columns["CustomerCode"].HeaderText = ADGVText.CustomerCode;
                adgv.Columns["CustomerCode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                adgv.Columns["StartDate"].HeaderText = ADGVText.StartDate;
                adgv.Columns["StartDate"].Width = ControlsAttribute.GV_WIDTH_NORMAL;
                adgv.Columns["EndDate"].HeaderText = ADGVText.EndDate;
                adgv.Columns["EndDate"].Width = ControlsAttribute.GV_WIDTH_NORMAL;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                _contractService = null;
            }
        }

        private void adgv_SortStringChanged(object sender, EventArgs e)
        {
            bs.Sort = adgv.SortString;
        }

        private void adgv_FilterStringChanged(object sender, EventArgs e)
        {
            string tmp = adgv.FilterString;
            string pattern = @"([a-zA-Z]+)";
            MatchCollection matches = Regex.Matches(tmp, pattern);
            try
            {
                bs.Filter = adgv.FilterString;
            }
            catch (Exception ex)
            {
                Utilities.ShowError(ex.Message);
            }
        }

        private void adgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (adgv.SelectedRows.Count > 0)
            {
                var selectedRow = adgv.SelectedRows[0];

                //Prepare model
                if (selectedRow.Cells[0].Value.ToString() != "0")
                {
                    contract = new Contract()
                    {
                        Id = int.Parse(selectedRow.Cells[0].Value.ToString()),
                        Code = selectedRow.Cells[1].Value.ToString()
                    };
                }
            }
        }
        #endregion

        private void btnViewDetail_Click(object sender, EventArgs e)
        {
            if (contract != null)
            {
                ContractDetailForm detailForm = new ContractDetailForm(contract);
                detailForm.FormClosed += new FormClosedEventHandler(DetailForm_Closed);
                detailForm.ShowDialog();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            contract = null;
            ContractDetailForm detailForm = new ContractDetailForm(contract);
            detailForm.FormClosed += new FormClosedEventHandler(DetailForm_Closed);
            detailForm.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (contract != null)
                {
                    _contractService = new ContractService();
                    int result = _contractService.DeleteContract(contract.Id);
                    if (result == CRUDStatusCode.SUCCESS)
                    {
                        LoadDGV();
                        Utilities.ShowMessage(CommonMessage.DELETE_SUCESSFULLY);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                _contractService = null;
            }
        }

        private void DetailForm_Closed(object sender, FormClosedEventArgs e)
        {
            LoadDGV();
        }

        private void adgv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            adgv.ClearSelection();
        }
    }
}
