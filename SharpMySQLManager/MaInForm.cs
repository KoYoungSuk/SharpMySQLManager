using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharpMySQLManager
{
    public partial class MaInForm : Form
    {
        MySqlConnection conn = null;
        Global g = new Global(); 
        public MaInForm(MySqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
            label7.Text = g.checkOS();
            label2.Text = "STATUS: Successfully Connected at [ " + DateTime.Now.ToString() + " ] ";
            listBox2.Items.Add("Successfully Connected at [ " + DateTime.Now.ToString() + " ] ");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Close();
            Application.Exit();
        }

        private void exitXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            conn.Close();
            Application.Exit(); 
        }

        private void aboutThisProgramAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm af = new AboutForm();
            af.Show(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                String sql = textBox1.Text;
                listBox1.Items.Add(sql);
                listBox2.Items.Add(sql);
                String firstsql = sql.Split(' ')[0];
                MySqlCommand scmd = new MySqlCommand(sql, conn);
                if (firstsql.Equals("select")) { 
                    MySqlDataAdapter mda = new MySqlDataAdapter();
                    mda.SelectCommand = scmd; 
                    DataTable dt = new DataTable();
                    mda.Fill(dt);
                    dataGridView1.DataSource = dt; 
                }
                else
                {
                    int result = scmd.ExecuteNonQuery();
                    if(result == 1)
                    {
                        g.informationmessage("Success!");
                    }
                    else
                    {
                        g.errormessage("Unknown Error Message");
                    }
                }
            }catch(Exception ex)
            {
                listBox2.Items.Add(ex.Message);
                g.errormessage(ex.Message); 
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Close();
            Application.Exit(); 
        }

        private void MaInForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.Filter = "SQL Files(*.sql)|*.sql|All Files(*.*)|*.*";
                saveFileDialog1.OverwritePrompt = true;
                saveFileDialog1.Title = "Save as SQL Documents.";
                saveFileDialog1.FileName = DateTime.Now.ToShortDateString();
                
                if(saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter sw = File.CreateText(saveFileDialog1.FileName);
                    for(int i=0; i<listBox1.Items.Count; i++)
                    {
                        sw.Write(listBox1.Items[i] + "\r\n");
                    }
                    sw.Flush();
                    sw.Close();
                    g.informationmessage("Successfully Saved.");
                }
                else
                {
                    g.informationmessage("Cancelled."); 
                }
            }catch(Exception ex)
            {
                g.errormessage(ex.Message); 
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.Filter = "Text Documents(*.txt)|*.txt|All Files(*.*)|*.*";
                saveFileDialog1.OverwritePrompt = true;
                saveFileDialog1.Title = "Save as SQL Documents.";
                saveFileDialog1.FileName = DateTime.Now.ToShortDateString(); 
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter sw = File.CreateText(saveFileDialog1.FileName);
                    sw.Write("=====MySQL=====");
                    sw.Write("\r\n");
                    sw.Write("SAVE DATE: " + DateTime.Now.ToString() + " \r\n");
                    for(int i=0; i<listBox2.Items.Count; i++)
                    {
                        sw.Write(listBox2.Items[i] + "\r\n");
                    }
                    sw.Flush();
                    sw.Close();
                    g.informationmessage("Successfully Saved.");
                }
                else
                {
                    g.informationmessage("Cancelled.");
                }
            }
            catch (Exception ex)
            {
                g.errormessage(ex.Message);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label8.Text = DateTime.Now.ToString(); 
        }

        private void clearDataGridViewCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null; 
        }

        private void disconnectDataBaseDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            conn.Close();
            conn = null;
            Form1 frm = new Form1();
            this.Hide();
            frm.Show(); 
        }

        private void blackBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Black; 
        }

        private void whiteWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.White; 
        }
    }
}
