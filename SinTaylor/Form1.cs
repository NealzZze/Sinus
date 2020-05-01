using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SinTaylor
{
    public partial class Form1 : Form
    {
        private double _epsilon = 0.1;
        private readonly int[] _allowedKeys = {1, 3, 8, 22, 26, (int)Keys.Delete};
        public Form1()
        {
            InitializeComponent();
            textBox1.KeyPress += textBox1_keyPress;
        }
        
        private void textBox1_keyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case',':
                    e.KeyChar = '.';
                    e.Handled = textBox1.Text.Contains('.');
                    break;
                case'-':
                    e.Handled = textBox1.SelectionStart != 0 || textBox1.Text.Contains('-');
                    break;
                case'.':
                    e.Handled = textBox1.Text.Contains('.');
                    break;
                default:
                    e.Handled = !(char.IsDigit(e.KeyChar) || _allowedKeys.Contains(e.KeyChar));
                    break;
            }
        }

        private void textBox1_textChanged(object sender, EventArgs e)
        {
            textBox2.Text = textBox1.Text;
        }

        private void Print(TextBox tb, double val)
        {
            switch (textBox3.Text)
            {
                case "0.1":
                    tb.Text = $@"{val:F2}";
                    break;
                case "0.01":
                    tb.Text = $@"{val:F3}";
                    break;
                case "0.001":
                    tb.Text = $@"{val:F4}";
                    break;
                case "0.0001":
                    tb.Text = $@"{val:F5}";
                    break;
                case "0.00001":
                    tb.Text = $@"{val:F6}";
                    break;
                case "0.000001":
                    tb.Text = $@"{val:F7}";
                    break;
            }
        }
        private void radiobutton_state_changed(object sender, EventArgs e)
        {
            var rb = sender as RadioButton;
            if (rb == null) return;
            if (!rb.Checked) return;
            textBox3.Text = rb.Text;
            _epsilon = double.Parse(textBox3.Text)/10;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            double value;
            var success = double.TryParse(textBox1.Text, out value);
            if (success && Math.Abs(value)<=29)
            {
                int count;
                var result = Math.Sin(value);
                var sum = MathSin.Sin(value, _epsilon, out count);
                Print(textBox4, result);
                Print(textBox6, sum);
                textBox5.Text = $@"{count}";
            }
            else if(Math.Abs(value)>29)
            {
                MessageBox.Show(@"Check interval.", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}