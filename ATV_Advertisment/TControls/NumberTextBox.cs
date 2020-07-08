using System;
using System.Windows.Forms;

namespace TControls
{
    public partial class NumberTextBox : TextBox
    {
        private int LastNumber = 0;
        private int MaxNumber = 32767;

        public NumberTextBox(int maxInput)
        {
            InitializeComponent();
            MaxNumber = maxInput;
        }

        // default OnPaint
        protected override void OnPaint(PaintEventArgs pe)
        {
            // Calling the base class OnPaint
            base.OnPaint(pe);
        }

        /// <summary>
        /// Keypress handler used to restrict user input to numbers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumberTextBox_KeyPress(object sender, KeyPressEventArgs e)
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

        private void NumberTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(this.Text))
                {
                    if (Convert.ToInt16(this.Text) > MaxNumber)
                    {
                        this.Text = LastNumber.ToString();
                    }
                    else
                    {
                        LastNumber = Convert.ToInt16(this.Text);
                    }
                } else
                {
                    LastNumber = 0;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// property to maintain value of control
        /// </summary>
        public int NumberValue
        {
            get
            {
                return LastNumber;
            }
            set
            {
                LastNumber = value;
            }
        }
    }
}
