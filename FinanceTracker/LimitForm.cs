using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FinanceTracker
{
    public partial class LimitForm : Form
    {
        public LimitForm()
        {
            InitializeComponent();
        }
        public int amount;
        public bool set = false;
        public bool incr = false;
        public bool decr = false;

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                double amt = double.Parse(textBox1.Text);
                int amount = (int)(amt * 100);
                set = true;
                MainForm.limit = amount;
            }else if (radioButton2.Checked)
            {
                double amt = double.Parse(textBox1.Text);
                int amount = (int)(amt * 100);
                incr = true;
                MainForm.limit += amount;
            }else if (radioButton3.Checked)
            {
                double amt = double.Parse(textBox1.Text);
                int amount = (int)(amt * 100);
                decr = true;
                MainForm.limit -= amount;
            }
            
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "") button1.Enabled = true;
            else button1.Enabled = false;
        }

        private void LimitForm_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
        }
    }
}
