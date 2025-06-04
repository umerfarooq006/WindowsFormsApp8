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
    public partial class profile : Form
    {
        string connection = @"Data Source=DESKTOP-97T2LGP\SQLEXPRESS;Initial Catalog=SRM_ERP;Integrated Security=True;TrustServerCertificate=True";
        public profile()
        {
            InitializeComponent();
        }

        private void profile_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connection))
            {
                string query = "select * from users";
                SqlDataAdapter adapter = new SqlDataAdapter(query,conn);

                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connection))
            {
                string query = "insert into users values(@id,@username,@password)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id",textBox1.Text);
                    cmd.Parameters.AddWithValue("@username", textBox3.Text);
                    cmd.Parameters.AddWithValue("@password", textBox2.Text);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    
                    
                }
                MessageBox.Show("user added");
                button2.PerformClick();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connection))
            {
                string query = "select * from users";
                SqlDataAdapter ad = new SqlDataAdapter(query,conn);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                dataGridView1.DataSource= dt;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connection))
            {
                string query = "delete from users where id =@id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("id", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("user deleted successfully");
                    button2.PerformClick();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text= dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text= dataGridView1.CurrentRow.Cells[2].Value.ToString() ;
            textBox3.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connection))
            {
                string query = "update users set username = @username ,password = @password where id = @id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username",textBox3.Text);
                    cmd.Parameters.AddWithValue("@id", textBox1.Text);
                    cmd.Parameters.AddWithValue("@password", textBox2.Text);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close() ;
                    MessageBox.Show("User updated");
                    button2.PerformClick();
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Close();
            
        }
    }
}
