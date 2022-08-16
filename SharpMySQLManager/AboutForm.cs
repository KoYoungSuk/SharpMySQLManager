using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharpMySQLManager
{
    public partial class AboutForm : Form
    {
        Global g = new Global();
        public AboutForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide(); 
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label5.Text = DateTime.Now.ToString();
            this.Text = DateTime.Now.ToString();
            String second = label5.Text.Split(':')[2];
            int secondint = Int32.Parse(second);
            if(secondint % 2 == 0)
            {
                button2.Enabled = true;
                button2.ForeColor = Color.White;
                label5.ForeColor = this.BackColor;
            }
            else
            {
                button2.Enabled = false;
                button2.ForeColor = this.BackColor; 
                label5.ForeColor = Color.Black; 
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop(); 
            DialogResult dr = g.informationmessage(g.checkOS());
            if(dr == DialogResult.OK)
            {
                g.informationmessage("OK Easter Egg");
            }
            else
            {
                g.informationmessage("Cancel Easter Egg"); 
            }
            timer1.Start(); 
        }
    }
}
