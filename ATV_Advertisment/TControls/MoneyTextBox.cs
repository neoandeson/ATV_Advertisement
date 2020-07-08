using System;
using System.Windows.Forms;

namespace TControls
{
    // https://www.c-sharpcorner.com/article/display-currency-values-with-a-custom-control/
    public partial class MoneyTextBox: TextBox
    {
        // member variable used to keep dollar value
        private Decimal mMoneyValue;

        // constructor
        public MoneyTextBox()
        {
            InitializeComponent();
            MoneyValue = 0;
        }

        // default OnPaint
        protected override void OnPaint(PaintEventArgs pe)
        {
            // Calling the base class OnPaint
            base.OnPaint(pe);
        }

        /// <summary>
        /// Keypress handler used to restrict user input
        /// to numbers and control characters
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MoneyTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // allows only numbers, decimals and control characters
           if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.')
            {
                e.Handled = true;
            }
        }

        private void MoneyTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.Text != String.Empty)
                    MoneyValue = Convert.ToDecimal(this.Text);
                else
                    MoneyValue = 0;
            }
            catch { }
        }

        /// <summary>
        /// Revert back to the display of numbers only
        /// whenever the user clicks in the box for
        /// editing purposes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MoneyTextBox_Validated(object sender, EventArgs e)
        {
            try
            {
                // format the value as currency
                Decimal dTmp = Convert.ToDecimal(this.Text);
                this.Text = String.Format("{0:0,0}", dTmp);
            }
            catch { }
        }

        /// <summary>
        /// property to maintain value of control
        /// </summary>
        public decimal MoneyValue
        {
            get
            {
                return mMoneyValue;
            }
            set
            {
                mMoneyValue = value;
            }
        }
    }
}
