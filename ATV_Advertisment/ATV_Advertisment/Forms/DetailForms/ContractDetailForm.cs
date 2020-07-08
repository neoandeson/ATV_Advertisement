using ATV_Advertisement.Common;
using ATV_Advertisment.Common;
using ATV_Advertisment.Forms.CommonForms;
using ATV_Advertisment.Services;
using ATV_Advertisment.ViewModel;
using DataService.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static ATV_Advertisment.Common.Constants;

namespace ATV_Advertisment.Forms.DetailForms
{
    //Contract infomation
    public partial class ContractDetailForm : CommonForm
    {
        private ContractItem contractDetail = null;
        public Contract model { get; set; }
        private ContractService _contractService = null;
        private ContractItemService _contractItemService = null;
        private CustomerService _customerService = null;
        private SystemConfigService _systemConfigService = null;
        private int CustomerId = 0;

        public ContractDetailForm(Contract inputModel)
        {
            InitializeComponent();

            this.model = inputModel;
            if (model != null)
            {
                if (model.Code != "0")
                {
                    contractDetail = new ContractItem()
                    {
                        ContractCode = model.Code
                    };
                    LoadDGV();
                }
            }

            LoadListCustomerCode();
            LoadData();
        }

        public void LoadData()
        {
            try
            {
                if (model != null)
                {
                    gbContractDetail.Visible = true;

                    _contractService = new ContractService();
                    _customerService = new CustomerService();
                    model = _contractService.GetById(model.Id);
                    if (model != null)
                    {
                        txtCustomerCode.ReadOnly = true;
                        var customer = _customerService.GetByCode(model.CustomerCode);
                        if (customer != null)
                        {
                            txtCustomerCode.Text = customer.Code;
                            txtCustomerName.Text = customer.Name;

                            txtCode.Text = model.Code;
                            //cboContractType.SelectedValue = model.ContractTypeId;
                            dtpStartDate.Value = model.StartDate.Value;
                            dtpEndDate.Value = model.EndDate.Value;
                            txtDiscount.Text = model.Discount.ToString();
                            txtCost.Text = Utilities.DoubleMoneyToText(model.SumCost);
                            txtTotalCost.Text = Utilities.DoubleMoneyToText(model.Cost);
                        }
                        else
                        {
                            Utilities.ShowMessage(CommonMessage.CUSTOMER_NOTFOUND);
                        }
                    }
                }
                else
                {
                    gbContractDetail.Visible = false;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                _contractService = null;
                _customerService = null;
            }
        }

        private void LoadListCustomerCode()
        {
            try
            {
                _customerService = new CustomerService();
                AutoCompleteStringCollection autoCollection = new AutoCompleteStringCollection();
                foreach (var code in _customerService.GetAllCustomerCode())
                {
                    autoCollection.Add(code);
                }
                txtCustomerCode.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtCustomerCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtCustomerCode.AutoCompleteCustomSource = autoCollection;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _customerService = null;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Contract result = null;
                int editResult = CRUDStatusCode.ERROR;

                _contractService = new ContractService();
                _systemConfigService = new SystemConfigService();

                if (model == null)
                {
                    //Add
                    model = new Contract()
                    {
                        Code = txtCode.Text,
                        CustomerCode = txtCustomerCode.Text,
                        //ContractTypeId = (int)cboContractType.SelectedValue,
                        StartDate = dtpStartDate.Value,
                        EndDate = dtpEndDate.Value,
                        SumCost = Utilities.GetDoubleFromTextBox(txtCost),
                        Discount = Utilities.GetDoubleFromTextBox(txtDiscount),
                        Cost = Utilities.GetDoubleFromTextBox(txtTotalCost)
                    };
                    result = _contractService.AddContract(model);
                    if (result != null)
                    {
                        model = result;
                        gbContractDetail.Visible = true;
                        _systemConfigService.UseLastContractNumber();
                        contractDetail = new ContractItem()
                        {
                            ContractCode = model.Code
                        };
                        txtCustomerCode.ReadOnly = true;
                        Utilities.ShowMessage(CommonMessage.ADD_SUCESSFULLY);
                        Logging.LogBusiness(string.Format("{0} {1} {2}",
                            Common.Session.GetUserName(),
                            Common.Constants.LogAction.Create, "hợp đồng mã " + model.Code),
                            Common.Constants.BusinessLogType.Create);
                    }
                }
                else
                {
                    //Edit
                    model.CustomerCode = txtCustomerCode.Text;

                    //model.ContractTypeId = (int)cboContractType.SelectedValue;
                    model.StartDate = dtpStartDate.Value;
                    model.EndDate = dtpEndDate.Value;
                    model.SumCost = Utilities.GetDoubleFromTextBox(txtCost);
                    model.Cost = Utilities.GetDoubleFromTextBox(txtTotalCost);
                    model.Discount = Utilities.GetDoubleFromTextBox(txtDiscount);

                    editResult = _contractService.EditContract(model);
                    if (editResult == CRUDStatusCode.SUCCESS)
                    {
                        gbContractDetail.Visible = true;
                        Utilities.ShowMessage(CommonMessage.EDIT_SUCESSFULLY);
                        Logging.LogBusiness(string.Format("{0} {1} {2}",
                            Common.Session.GetUserName(),
                            Common.Constants.LogAction.Update, "hợp đồng mã " + model.Code),
                            Common.Constants.BusinessLogType.Update);
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
                _systemConfigService = null;
            }
        }

        private void txtCustomerCode_Leave(object sender, EventArgs e)
        {
            try
            {
                CustomerId = 0;
                _customerService = new CustomerService();
                Customer customer = _customerService.GetByCode(txtCustomerCode.Text);
                if (customer != null)
                {
                    txtCustomerName.Text = customer.Name;
                    CustomerId = customer.Id;
                    if (string.IsNullOrWhiteSpace(txtCode.Text))
                    {
                        GetLastedContractCode();
                    }
                }
                else
                {
                    Utilities.ShowMessage(CommonMessage.CUSTOMER_NOTFOUND);
                    txtCustomerName.Text = string.Empty;
                    txtCode.Text = string.Empty;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _customerService = null;
            }
        }

        #region AdvanceDataGridView
        private BindingSource bs = null;

        private void LoadDGV()
        {
            try
            {
                _contractItemService = new ContractItemService();
                List<ContractItemViewModel> contractDetailVMs = _contractItemService.GetAllVMForListByContractCode(model.Code);
                SortableBindingList<ContractItemViewModel> sbl = new SortableBindingList<ContractItemViewModel>(contractDetailVMs);
                bs = new BindingSource();
                bs.DataSource = sbl;
                adgv.DataSource = bs;

                adgv.Columns["Id"].Visible = false;
                adgv.Columns["StatusId"].Visible = false;
                adgv.Columns["CreateDate"].Visible = false;
                adgv.Columns["LastUpdateBy"].Visible = false;
                adgv.Columns["LastUpdateDate"].Visible = false;
                adgv.Columns["DurationSecond"].Visible = false;

                adgv.Columns["ContractCode"].HeaderText = ADGVText.BelongToContractCode;
                adgv.Columns["ContractCode"].Width = ControlsAttribute.GV_WIDTH_NORMAL;
                adgv.Columns["ProductName"].HeaderText = ADGVText.Name;
                adgv.Columns["ProductName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                adgv.Columns["NumberOfShow"].HeaderText = ADGVText.NumberOfShow;
                adgv.Columns["NumberOfShow"].Width = ControlsAttribute.GV_WIDTH_SEEM;
                adgv.Columns["TotalCost"].HeaderText = ADGVText.Cost;
                adgv.Columns["TotalCost"].Width = ControlsAttribute.GV_WIDTH_NORMAL;
                adgv.Columns["ShowTypeId"].HeaderText = ADGVText.ShowType;
                adgv.Columns["ShowTypeId"].Width = ControlsAttribute.GV_WIDTH_NORMAL;

                lblNOProducts.Text = contractDetailVMs.Count + " sản phẩm";
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                _contractItemService = null;
            }
        }

        private void adgv_SortStringChanged(object sender, EventArgs e)
        {
            bs.Sort = adgv.SortString;
        }

        private void adgv_FilterStringChanged(object sender, EventArgs e)
        {
            string tmp = adgv.FilterString;
            string pattern = @"([a-zA-Z0-9 ]+)";
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
                if (selectedRow.Cells[0].Value.ToString() != "0" && !String.IsNullOrWhiteSpace(selectedRow.Cells[0].Value.ToString()))
                {
                    contractDetail = new ContractItem()
                    {
                        Id = int.Parse(selectedRow.Cells[0].Value.ToString()),
                        ProductName = selectedRow.Cells[2].Value.ToString()
                    };
                }
                else
                {
                    contractDetail = null;
                }
            }
        }
        #endregion

        private void btnAddDetail_Click(object sender, EventArgs e)
        {
            if (contractDetail != null)
            {
                contractDetail.Id = 0;
            }
            ContractItemDetailForm contractDetailDetailForm = new ContractItemDetailForm(contractDetail);
            contractDetailDetailForm.FormClosed += new FormClosedEventHandler(DetailForm_Closed);
            contractDetailDetailForm.ShowDialog();
        }

        private void btnDeleteDetail_Click(object sender, EventArgs e)
        {

        }

        private void btnDeleteDetail_Click2(object sender, EventArgs e)
        {
            if (Utilities.ShowConfirmMessage(CommonMessage.CONFIRM_DELETE))
            {
                using (var context = new ATVEntities())
                {
                    using (DbContextTransaction transaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            if (contractDetail != null)
                            {
                                var ctrDetail = context.ContractItems.FirstOrDefault(c => c.Id == contractDetail.Id);

                                if (ctrDetail != null)
                                {
                                    ctrDetail.StatusId = Constants.CommonStatus.CANCEL;

                                    var producSchedulShowes = context.ProductScheduleShows.Where(p => p.ContractDetailId == ctrDetail.Id);
                                    if (producSchedulShowes.Count() > 0)
                                    {
                                        context.ProductScheduleShows.RemoveRange(producSchedulShowes);
                                    }
                                    context.SaveChanges();
                                }
                            }

                            transaction.Commit();

                            UpdateContractCost();
                            LoadDGV();
                            Utilities.ShowMessage(CommonMessage.DELETE_SUCESSFULLY);

                            Logging.LogBusiness(string.Format("{0} {1} {2}",
                                Common.Session.GetUserName(),
                                Common.Constants.LogAction.Delete, "hợp đồng mã " + model.Code),
                                Common.Constants.BusinessLogType.Delete);
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw ex;
                        }
                    }
                }
            }
        }

        private void btnViewDtail_Click(object sender, EventArgs e)
        {
            if (contractDetail != null)
            {
                if (contractDetail.Id != 0)
                {
                    ContractItemDetailForm detailForm = new ContractItemDetailForm(contractDetail);
                    detailForm.FormClosed += new FormClosedEventHandler(DetailForm_Closed);
                    detailForm.ShowDialog();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click2(object sender, EventArgs e)
        {
            if (Utilities.ShowConfirmMessage(CommonMessage.CONFIRM_CANCLE))
            {
                int result = CRUDStatusCode.ERROR;

                using (var context = new ATVEntities())
                {
                    using (DbContextTransaction transaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            var contract = context.Contracts.FirstOrDefault(c => c.Id == model.Id);
                            if (contract != null)
                            {
                                contract.StatusId = Constants.CommonStatus.CANCEL;
                                context.SaveChanges();

                                var contractItems = context.ContractItems.Where(ci => ci.ContractCode == contract.Code);
                                foreach (var ci in contractItems)
                                {
                                    ci.StatusId = Constants.CommonStatus.CANCEL;
                                    var producSchedulShowes = context.ProductScheduleShows.Where(p => p.ContractDetailId == ci.Id);
                                    context.ProductScheduleShows.RemoveRange(producSchedulShowes);

                                    context.SaveChanges();
                                }
                            }

                            transaction.Commit();
                            result = CRUDStatusCode.SUCCESS;
                            Utilities.ShowMessage(CommonMessage.CANCEL_SUCESSFULLY);

                            Logging.LogBusiness(string.Format("{0} {1} {2}",
                                Common.Session.GetUserName(),
                                Common.Constants.LogAction.Cancle, "hợp đồng mã " + model.Code),
                                Common.Constants.BusinessLogType.Delete);

                            UpdateContractCost();
                            gbContractDetail.Visible = false;
                        }
                        catch (Exception ex)
                        {
                            gbContractDetail.Visible = true;
                            transaction.Rollback();
                            throw ex;
                        }
                    }
                }
            }
        }

        private void DetailForm_Closed(object sender, FormClosedEventArgs e)
        {
            LoadDGV();
            UpdateContractCost();
        }

        private string GetLastedContractCode()
        {
            string result = "";
            try
            {
                _systemConfigService = new SystemConfigService();
                txtCode.Text = _systemConfigService.GetLastContractNumberAsString();

                return result;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _systemConfigService = null;
            }
        }

        private void UpdateContractCost()
        {
            try
            {
                _contractService = new ContractService();
                double result = _contractService.UpdateContractCost(model.Code);
                txtCost.Text = Utilities.DoubleMoneyToText(result);
                CalculateContractTotalCost(true);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _contractService = null;
            }
        }

        private void CalculateContractTotalCost(bool isSaving)
        {
            if (!isSaving)
            {
                try
                {
                    double cost = Utilities.GetDoubleFromTextBox(txtCost);
                    double discount = Utilities.GetDoubleFromTextBox(txtDiscount);
                    double sumCost = cost - (cost * discount) / 100;

                    txtTotalCost.Text = Utilities.DoubleMoneyToText(sumCost);
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                try
                {
                    double sumCost = Utilities.GetDoubleFromTextBox(txtCost);
                    double discount = Utilities.GetDoubleFromTextBox(txtDiscount);
                    double cost = sumCost - (sumCost * discount) / 100;

                    txtTotalCost.Text = Utilities.DoubleMoneyToText(cost);

                    _contractService = new ContractService();
                    _contractService.UpdatContractCostInfo(txtCode.Text, cost, sumCost, discount);
                    Logging.LogBusiness(string.Format("{0} {1} {2}",
                            Common.Session.GetUserName(),
                            Common.Constants.LogAction.Update, "giá tiền của hợp đồng mã " + model.Code + " do thay đổi nội dung hợp đồng"),
                            Common.Constants.BusinessLogType.Update);
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    _contractService = null;
                }
            }
        }

        private void adgv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            adgv.ClearSelection();
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            CalculateContractTotalCost(false);
        }
    }
}
