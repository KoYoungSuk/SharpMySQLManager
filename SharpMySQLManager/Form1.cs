using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace SharpMySQLManager
{
    public partial class Form1 : Form
    {
        MySqlConnection conn;
        Global g = new Global();
        // var isCapsLockToggled = Keyboard.IsKeyToggled(Key.CapsLock);
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String address = textBox1.Text.Split(':')[0];
            String port = textBox1.Text.Split(':')[1];
            String id = textBox2.Text;
            String password = textBox3.Text;
            String database = textBox4.Text;

            try
            {
                String connstr = String.Format("Server={0};Port={1};Uid={2};Pwd={3};DataBase={4};Charset=UTF8", address, port, id, password, database);
                conn = new MySqlConnection(connstr);
                conn.Open();
                MaInForm mf = new MaInForm(conn);
                this.Hide(); 
                mf.Show();
            }catch(Exception ex)
            {
                g.errormessage(ex.Message);
            }
        }

        private void textBox4_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e); 
            }
        }
    }
}
