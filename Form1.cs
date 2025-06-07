using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp8
{
    public partial class Form1 : Form
    {
        string connection = @"Data Source=DESKTOP-97T2LGP\SQLEXPRESS;Initial Catalog=SRM_ERP;Integrated Security=True;TrustServerCertificate=True";
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            if (username == "" && password == "'")
            {
                label4.Text = "please enter username and password";
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(connection))
                {
                    string query = "select * from users where username = @username and password = @password";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("username", username);
                        cmd.Parameters.AddWithValue("password", password);
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            
                             label4.Text = "login successfull";
                            profile pf = new profile();
                            pf.Show();
                            this.Hide();
                            
                            

                        }
                        else
                        {
                            label4.Text = "invalid username or password";
                        }
                        conn.Close();
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
