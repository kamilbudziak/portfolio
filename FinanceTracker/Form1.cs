using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FinanceTracker
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
#if DEBUG
        public string regPath = "register.txt";
        public string limPath = "limit.txt";
#else
        public string regPath = "register.kmz";
        public string limPath = "limit.kmz";
#endif
        public static int limit;
        public static int overallAmount = 0;
        public static List<LoanDetails> LoanHistory = new List<LoanDetails>();
        public static List<BorrowerDetails> BD = new List<BorrowerDetails>();
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = "";
            comboBox1.SelectedIndex = 0;
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox2.SelectedIndex = 0;

            if (File.Exists(limPath))
            {
                string lmt = File.ReadAllText(limPath);
                limit = int.Parse(lmt);
            }
            else
            {
                File.AppendAllText(limPath, "0");
                limit = 0;
            }
            


            if(File.Exists(regPath))
            {
                string[] TAB = File.ReadAllLines(regPath);
                for (int i = 0; i < TAB.Length; i++)
                {
                    string[] tmp = TAB[i].Split('\t');
                    LoanDetails ld = new LoanDetails();
                    ld.name = tmp[0];
                    ld.amount = int.Parse(tmp[1]);
                    ld.interestRate = int.Parse(tmp[2]);
                    ld.issueDate = Convert.ToDateTime(tmp[3]);
                    ld.updateDate = Convert.ToDateTime(tmp[4]);
                    ld.type = tmp[5];
                    LoanHistory.Add(ld);
                    overallAmount += ld.amount;
                    //limit -= ld.amount;
                }

                for(int i = 0; i < LoanHistory.Count; i++)
                {
                    //limit += LoanHistory[i].amount;
                    overallAmount -= LoanHistory[i].amount;
                    LoanHistory[i].update(LoanHistory[i]);
                    overallAmount += LoanHistory[i].amount;
                    //limit -= LoanHistory[i].amount;
                }
                File.Delete(regPath);
                for(int i = 0; i < LoanHistory.Count; i++)
                {
                    LoanDetails ld = LoanHistory[i];
                    File.AppendAllText(regPath, ld.name + '\t' + ld.amount + '\t' + ld.interestRate + '\t' + Convert.ToString(ld.issueDate) + '\t' + Convert.ToString(ld.updateDate) + '\t' + ld.type + '\n');
                }
            }
            

            BtnConfirm.Enabled = false;
            comboBox1.SelectedIndex = 0;
            string gr;
            if (limit - overallAmount >= 0)
            {
                if ((limit - overallAmount) % 100 < 10) gr = "0" + (limit - overallAmount) % 100;
                else gr = "" + (limit - overallAmount) % 100;
                limitLabel.Text = "Pozostały limit: " + (limit - overallAmount) / 100 + "," + gr + " PLN";
                if (overallAmount > limit) limitLabel.ForeColor = Color.Red;
                else limitLabel.ForeColor = Color.Black;
            }
            else
            {
                if ((limit - overallAmount) % 100 > -10) gr = "0" + ((limit - overallAmount) % 100)*-1;
                else gr = "" + ((limit - overallAmount) % 100)*-1;
                limitLabel.Text = "Pozostały limit: " + (limit - overallAmount) / 100 + "," + gr + " PLN";
                if (overallAmount > limit) limitLabel.ForeColor = Color.Red;
                else limitLabel.ForeColor = Color.Black;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                BtnConfirm.Enabled = false;
            }
            else if (comboBox1.SelectedIndex == 1) 
            {
                if (textBox1.Text != "") BtnConfirm.Enabled = true;
                textBox2.Visible = true;
                comboBox2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
            }
            else if(comboBox1.SelectedIndex == 2)
            {
                if (textBox1.Text != "") BtnConfirm.Enabled = true;
                textBox2.Visible = false;
                comboBox2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "") BtnConfirm.Enabled = false;
            else if (comboBox1.SelectedIndex != 0) BtnConfirm.Enabled = true;
            // TODO podsumowanie historii pożyczkobiorcy
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 1)
            {
                double amt = double.Parse(textBox3.Text) * 100;
                int amount = (int)amt;
                double intr = double.Parse(textBox2.Text) * 1000;
                int interest = (int)intr;
                string line = textBox1.Text + '\t' + amount + '\t' + interest + '\t' + Convert.ToString(DateTime.Now) + '\t' + Convert.ToString(DateTime.Now) + '\t' + comboBox2.SelectedIndex + '\n';
                File.AppendAllText(regPath, line);
                overallAmount += amount;

                LoanDetails ld = new LoanDetails();
                ld.name = textBox1.Text;
                ld.amount = amount;
                ld.interestRate = interest;
                ld.issueDate = DateTime.Now;
                ld.updateDate = DateTime.Now;
                LoanHistory.Add(ld);

                string gr;
                if (limit - overallAmount >= 0)
                {
                    if ((limit - overallAmount) % 100 < 10) gr = "0" + (limit - overallAmount) % 100;
                    else gr = "" + (limit - overallAmount) % 100;
                    limitLabel.Text = "Pozostały limit: " + (limit - overallAmount) / 100 + "," + gr + " PLN";
                    limitLabel.ForeColor = Color.Black;
                }
                else
                {
                    if ((limit - overallAmount) % 100 > -10) gr = "0" + ((limit - overallAmount) % 100) * -1;
                    else gr = "" + ((limit - overallAmount) % 100) * -1;
                    limitLabel.Text = "Pozostały limit: " + (limit - overallAmount) / 100 + "," + gr + " PLN";
                    limitLabel.ForeColor = Color.Red;
                }



                textBox1.Text = "";
                comboBox1.SelectedIndex = 0;
                textBox2.Text = "";
                textBox3.Text = "";
                comboBox2.SelectedIndex = 0;
            }
            if (comboBox1.SelectedIndex == 2)
            {
                

                double amt = double.Parse(textBox3.Text) * 100;
                int amount = (int)amt;

                for(int i=0;i<LoanHistory.Count && amount > 0; i++)
                {
                    if(LoanHistory[i].name == textBox1.Text)
                    {
                        if(amount >= LoanHistory[i].amount)
                        {
                            amount -= LoanHistory[i].amount;
                            overallAmount -= LoanHistory[i].amount;
                            LoanHistory[i].amount = 0;
                        }
                        else
                        {
                            LoanHistory[i].amount -= amount;
                            overallAmount -= amount;
                            amount = 0;
                        }
                    }
                }
                for(int i = 0; i < LoanHistory.Count; i++)
                {
                    if(LoanHistory[i].amount == 0)
                    {
                        LoanHistory.Remove(LoanHistory[i]);
                        i--;
                    }
                }

                File.Delete(regPath);
                for (int i = 0; i < LoanHistory.Count; i++)
                {
                    LoanDetails ld = LoanHistory[i];
                    File.AppendAllText(regPath, ld.name + '\t' + ld.amount + '\t' + ld.interestRate + '\t' + Convert.ToString(ld.issueDate) + '\t' + Convert.ToString(ld.updateDate) + '\t' + ld.type + '\n');
                }

                string gr;
                if (limit - overallAmount >= 0)
                {
                    if ((limit - overallAmount) % 100 < 10) gr = "0" + (limit - overallAmount) % 100;
                    else gr = "" + (limit - overallAmount) % 100;
                    limitLabel.Text = "Pozostały limit: " + (limit - overallAmount) / 100 + "," + gr + " PLN";
                    limitLabel.ForeColor = Color.Black;
                }
                else
                {
                    if ((limit - overallAmount) % 100 > -10) gr = "0" + ((limit - overallAmount) % 100) * -1;
                    else gr = "" + ((limit - overallAmount) % 100) * -1;
                    limitLabel.Text = "Pozostały limit: " + (limit - overallAmount) / 100 + "," + gr + " PLN";
                    limitLabel.ForeColor = Color.Red;
                }

                textBox1.Text = "";
                comboBox1.SelectedIndex = 0;
                textBox2.Text = "";
                textBox3.Text = "";
                comboBox2.SelectedIndex = 0;
            }
        }

        private void BtnSetLimit_Click(object sender, EventArgs e)
        {
            LimitForm lf = new LimitForm();
            lf.ShowDialog();
            string gr;
            if (limit - overallAmount >= 0)
            {
                if ((limit - overallAmount) % 100 < 10) gr = "0" + (limit - overallAmount) % 100;
                else gr = "" + (limit - overallAmount) % 100;
                limitLabel.Text = "Pozostały limit: " + (limit - overallAmount) / 100 + "," + gr + " PLN";
                if (overallAmount > limit) limitLabel.ForeColor = Color.Red;
                else limitLabel.ForeColor = Color.Black;
            }
            else
            {
                if ((limit - overallAmount) % 100 > -10) gr = "0" + ((limit - overallAmount) % 100) * -1;
                else gr = "" + ((limit - overallAmount) % 100) * -1;
                limitLabel.Text = "Pozostały limit: " + (limit - overallAmount) / 100 + "," + gr + " PLN";
                if (overallAmount > limit) limitLabel.ForeColor = Color.Red;
                else limitLabel.ForeColor = Color.Black;
            }
            File.WriteAllText(limPath, Convert.ToString(limit));
        }

        private void BtnPreview_Click(object sender, EventArgs e)
        {
            BD.Clear();
            for(int i = 0; i < LoanHistory.Count; i++)
            {
                bool check = false;
                for(int j = 0; j < BD.Count && !check; j++)
                {
                    if(LoanHistory[i].name == BD[j].name)
                    {
                        BD[j].amount += LoanHistory[i].amount;
                        check = true;
                    }
                }
                if (!check)
                {
                    BorrowerDetails bd = new BorrowerDetails();
                    bd.name = LoanHistory[i].name;
                    bd.amount = LoanHistory[i].amount;
                    BD.Add(bd);
                }
            }
            PreviewForm pf = new PreviewForm();
            pf.Show();
        }
    }
}
