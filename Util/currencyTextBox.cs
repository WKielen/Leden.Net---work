using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using Util.Extensions;

namespace Util.Forms
{
    public partial class currencyTextBox : TextBox
    {
        /// <summary>
        /// 
        /// </summary>
        public currencyTextBox()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="container"></param>
        public currencyTextBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        private string _workingText;
        private int _decimalPlaces = 2;
        private string _preFix = "€";
        private char _thousandsSeparator = '.', _decimalsSeparator = ',';

        /// <summary>
        /// Contains the entered text without mask.
        /// </summary>
        public string WorkingText
        {
            get { return _workingText; }
            private set { _workingText = value; }
        }

        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                _workingText = value;
                base.Text = value;
            }
        }


        /// <summary>
        /// Contains the prefix that preceed the inputted text.
        /// </summary>
        public string PreFix
        {
            get { return _preFix; }
            set { _preFix = value; }
        }

        /// <summary>
        /// Contains the separator symbol for thousands.
        /// </summary>
        public char ThousandsSeparator
        {
            get { return _thousandsSeparator; }
            set { _thousandsSeparator = value; }

        }

        /// <summary>
        /// Contains the separator symbol for decimals.
        /// </summary>
        public char DecimalsSeparator
        {
            get { return _decimalsSeparator; }
            set { _decimalsSeparator = value; }
        }

        /// <summary>
        /// Indicates the total places for decimal values.
        /// </summary>
        public int DecimalPlaces
        {
            get { return _decimalPlaces; }
            set { _decimalPlaces = value; }
        }

        /// <summary>
        /// Formats the entered text.
        /// </summary>
        /// <returns></returns>
        public string formatText()
        {
            this.WorkingText = this.Text.Replace((_preFix != "") ? _preFix : " ", String.Empty)
                                        .Replace((_thousandsSeparator.ToString() != "") ? _thousandsSeparator.ToString() : " ", String.Empty)
                                        .Replace((_decimalsSeparator.ToString() != "") ? _decimalsSeparator.ToString() : " ", String.Empty).Trim();
            int counter = 1;
            int counter2 = 0;
            char[] charArray = this.WorkingText.ToCharArray();
            StringBuilder str = new StringBuilder();

            for (int i = charArray.Length - 1; i >= 0; i--)
            {
                str.Insert(0, charArray.GetValue(i));
                if (this.DecimalPlaces == 0 && counter == 3)
                {
                    counter2 = counter;
                }

                if (counter == this.DecimalPlaces && i > 0)
                {
                    if (_decimalsSeparator != Char.MinValue)
                        str.Insert(0, _decimalsSeparator);
                    counter2 = counter + 3;
                }
                else if (counter == counter2 && i > 0)
                {
                    if (_thousandsSeparator != Char.MinValue)
                        str.Insert(0, _thousandsSeparator);
                    counter2 = counter + 3;
                }
                counter = ++counter;
            }
            return (this._preFix != "" && str.ToString() != "") ? _preFix + " " + str.ToString() : (str.ToString() != "") ? str.ToString() : "";
        }



        public decimal ToFromDecimal
        {
            get
            {
                string txt = Text.RemoveNonNumeric();
                if (txt == string.Empty) return 0;
                decimal divideby = 1;
                if (Text.Contains(_decimalsSeparator.ToString())) divideby = (decimal)Math.Pow(10, _decimalPlaces);
                decimal d = Convert.ToDecimal(txt) / divideby;
                return decimal.Round(d, 2, MidpointRounding.AwayFromZero); 
            }
            set
            {
                decimal d = decimal.Round(value, 2, MidpointRounding.AwayFromZero); 
                Text = string.Format ("{0:0.00}", d);
                Text = formatText();
            }
        }

        public int ToFromInteger
        {
            get
            {
                if (!Text.IsNumeric()) return 0;
//              if (!Util.Text.StringUtil.IsNumeric(Text, 10)) return 0;
                return Convert.ToInt32(Text.RemoveNonNumeric());
            }
            set
            {
                Text = value.ToString();
                Text = formatText();
            }
        }

        protected override void OnLostFocus(EventArgs e)
        {
            this.Text = formatText();
            base.OnLostFocus(e);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            this.Text = this.WorkingText;
            base.OnGotFocus(e);
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar))
            {
                if (!(e.KeyChar == Convert.ToChar(Keys.Back)))
                    e.Handled = true;
            }
            base.OnKeyPress(e);
        }
    }
}
