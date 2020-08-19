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
    public partial class PreviewForm : Form
    {
        public PreviewForm()
        {
            InitializeComponent();
        }

        private void PreviewForm_Load(object sender, EventArgs e)
        {
            Table.Columns.Add("bn", "Pożyczkobiorca");
            Table.Columns.Add("am", "Dług");
            Table.Columns[0].Width = 230;
            Table.Columns[1].Width = 135;
            for(int i = 0; i < MainForm.BD.Count; i++)
            {
                int amt = MainForm.BD[i].amount;
                string gr;
                if(amt >= 0)
                {
                    if (amt % 100 < 10) gr = "0" + amt % 100;
                    else gr = "" + amt % 100;
                }
                else
                {
                    if (amt % 100 > -10) gr = "0" + (amt % 100) * -1;
                    else gr = "" + (amt % 100) * -1;
                }
                string amount = "" + amt / 100 + ',' + gr;
                Table.Rows.Add(MainForm.BD[i].name, amount);
                Table.Rows[i].Cells[1].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                
            }
        }
    }
}
