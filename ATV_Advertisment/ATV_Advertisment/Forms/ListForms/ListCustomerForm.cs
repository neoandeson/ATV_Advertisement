using ATV_Advertisement.Common;
using ATV_Advertisment.Common;
using ATV_Advertisment.Forms.CommonForms;
using ATV_Advertisment.Forms.DetailForms;
using ATV_Advertisment.Services;
using DataService.Model;
using ReportService.ExportExcel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static ATV_Advertisment.Common.Constants;

namespace ATV_Advertisment.Forms.ListForms
{
    public partial class ListCustomerForm : CommonForm
    {
        private Customer customer = null;

        public ListCustomerForm()
        {
            InitializeComponent();
            LoadDGV();
        }

        #region AdvanceDataGridView
        private BindingSource bs = null;

        private void LoadDGV()
        {
            CustomerService customerService = null;
            try
            {
                customerService = new CustomerService();
                List<Customer> customers = customerService.GetAll();
                SortableBindingList<Customer> sbl = new SortableBindingList<Customer>(customers);
                bs = new BindingSource();
                bs.DataSource = sbl;
                adgv.DataSource = bs;

                adgv.Columns["Id"].Visible = false;
                adgv.Columns["Phone1"].Visible = false;
                adgv.Columns["Phone2"].Visible = false;
                adgv.Columns["Fax"].Visible = false;
                adgv.Columns["Email"].Visible = false;
                adgv.Columns["StatusId"].Visible = false;
                adgv.Columns["CreateDate"].Visible = false;
                adgv.Columns["LastUpdateBy"].Visible = false;
                adgv.Columns["LastUpdateDate"].Visible = false;

                adgv.Columns["Code"].HeaderText = ADGVText.Code;
                adgv.Columns["Code"].Width = ControlsAttribute.GV_WIDTH_NORMAL;
                adgv.Columns["Name"].HeaderText = ADGVText.Name;
                adgv.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                adgv.Columns["Address"].HeaderText = ADGVText.Address;
                adgv.Columns["Address"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                adgv.Columns["TaxCode"].HeaderText = ADGVText.TaxCode;
                adgv.Columns["TaxCode"].Width = ControlsAttribute.GV_WIDTH_SEEM;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                customerService = null;
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
            if(adgv.SelectedRows.Count > 0)
            {
                var selectedRow = adgv.SelectedRows[0];

                //Prepare model
                if (selectedRow.Cells[0].Value.ToString() != "0")
                {
                    this.customer = new Customer()
                    {
                        Id = int.Parse(selectedRow.Cells[0].Value.ToString()),
                        Code = selectedRow.Cells[1].Value.ToString(),
                        Name = (selectedRow.Cells[2].Value == null) ? "" : selectedRow.Cells[2].Value.ToString(),
                        Address = (selectedRow.Cells[3].Value == null) ? "" : selectedRow.Cells[3].Value.ToString(),
                        Phone1 = (selectedRow.Cells[4].Value == null) ? "" : selectedRow.Cells[4].Value.ToString(),
                        Phone2 = (selectedRow.Cells[5].Value == null) ? "" : selectedRow.Cells[5].Value.ToString(),
                        Email = (selectedRow.Cells[6].Value == null) ? "" : selectedRow.Cells[6].Value.ToString(),
                        Fax = (selectedRow.Cells[7].Value == null) ? "" : selectedRow.Cells[7].Value.ToString(),
                        TaxCode = (selectedRow.Cells[8].Value == null) ? "" : selectedRow.Cells[8].Value.ToString(),
                        StatusId = int.Parse(selectedRow.Cells[9].Value.ToString()),
                    };
                }
            }
        }
        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            customer = null;
            CustomerDetailForm detailForm = new CustomerDetailForm(customer);
            detailForm.FormClosed += new FormClosedEventHandler(DetailForm_Closed);
            detailForm.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            CustomerService customerService = new CustomerService();

            try
            {
                if (customer != null)
                {
                    bool result = customerService.DeleteCustomer(customer.Id);
                    if (result)
                    {
                        LoadDGV();
                        Utilities.ShowMessage(CommonMessage.DELETE_SUCESSFULLY);
                        Logging.LogBusiness(string.Format("{0} {1} {2}",
                            Common.Session.GetUserName(),
                            Common.Constants.LogAction.Delete, "khách hàng " + customer.Code),
                            Common.Constants.BusinessLogType.Delete);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                customerService = null;
            }
        }

        private void btnViewDetail_Click(object sender, EventArgs e)
        {
            if(customer != null)
            {
                CustomerDetailForm detailForm = new CustomerDetailForm(customer);
                detailForm.FormClosed += new FormClosedEventHandler(DetailForm_Closed);
                detailForm.ShowDialog();
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
