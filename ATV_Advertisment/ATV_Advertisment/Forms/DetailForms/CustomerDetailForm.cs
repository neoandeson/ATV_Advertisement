using ATV_Advertisment.Common;
using ATV_Advertisment.Forms.CommonForms;
using ATV_Advertisment.Services;
using DataService.Model;
using System;
using System.Windows.Forms;
using static ATV_Advertisment.Common.Constants;

namespace ATV_Advertisment.Forms.DetailForms
{
    public partial class CustomerDetailForm : CommonForm
    {
        private CustomerService _customerService;

        public Customer model { get; set; }

        public CustomerDetailForm(Customer inputModel)
        {
            this.model = inputModel;

            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            if (model != null)
            {
                txtCode.Text = model.Code;
                txtName.Text = model.Name;
                txtAddress.Text = model.Address;
                txtPhone1.Text = model.Phone1;
                txtPhone2.Text = model.Phone2;
                txtFax.Text = model.Fax;
                txtTaxCode.Text = model.TaxCode;
                txtEmail.Text = model.Email;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CustomerService customerService = null;
            bool result = false;

            try
            {
                customerService = new CustomerService();

                if(!IsValidate())
                {
                    return;
                }

                if (model == null)
                {
                    //Add
                    model = new Customer()
                    {
                        Code = txtCode.Text,
                        Name = txtName.Text,
                        Address = txtAddress.Text,
                        Phone1 = txtPhone1.Text,
                        Phone2 = txtPhone2.Text,
                        Fax = txtFax.Text,
                        TaxCode = txtTaxCode.Text,
                        Email = txtEmail.Text,
                    };
                    result = customerService.AddCustomer(model);
                    if (result)
                    {
                        Utilities.ShowMessage(CommonMessage.ADD_SUCESSFULLY);
                        Logging.LogBusiness(string.Format("{0} {1} {2}",
                            Common.Session.GetUserName(),
                            Common.Constants.LogAction.Create, "khách hàng mã " + model.Code),
                            Common.Constants.BusinessLogType.Create);
                    }
                }
                else
                {
                    //Edit
                    model.Code = txtCode.Text;
                    model.Name = txtName.Text;
                    model.Address = txtAddress.Text;
                    model.Phone1 = txtPhone1.Text;
                    model.Phone2 = txtPhone2.Text;
                    model.Fax = txtFax.Text;
                    model.TaxCode = txtTaxCode.Text;
                    model.Email = txtEmail.Text;

                    result = customerService.EditCustomer(model);
                    if (result)
                    {
                        Utilities.ShowMessage(CommonMessage.EDIT_SUCESSFULLY);
                        Logging.LogBusiness(string.Format("{0} {1} {2}",
                            Common.Session.GetUserName(),
                            Common.Constants.LogAction.Update, "khách hàng mã " + model.Code),
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
                customerService = null;
            }
        }

        private void txtPhone1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtPhone2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtFax_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtTaxCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtCode_Leave(object sender, EventArgs e)
        {
            try
            {
                _customerService = new CustomerService();
                var isExistCode = _customerService.IsExistCode(txtCode.Text);
                if(isExistCode)
                {
                    Utilities.ShowMessage(CommonMessage.USED_CODE);
                    txtCode.Focus();
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

        private bool IsValidate()
        {
            bool result = true;

            if (string.IsNullOrWhiteSpace(txtCode.Text))
            {
                MessageBox.Show("Mã không được để trống");
                result = false;
            } else if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Tên không được để trống");
                result = false;
            } else if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("Địa chỉ không được để trống");
                result = false;
            } else if (string.IsNullOrWhiteSpace(txtPhone1.Text))
            {
                MessageBox.Show("Số điện thoại 1 không được để trống");
                result = false;
            }

            return result;
        }
    }
}
