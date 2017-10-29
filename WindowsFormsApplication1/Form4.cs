using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



using System.Data.SqlClient;
using System.Configuration;

namespace WindowsFormsApplication1
{
    public partial class Form4 : Form
    {
        DataAccess dt;
        public Form4()
        {
            InitializeComponent();
            dt = new DataAccess();
        }

     



        public class DataAccess
        {
            public SqlConnection conn;
            public SqlCommand comm;

            public DataAccess()
            {
                conn = new SqlConnection();
                comm = new SqlCommand();
                //conn.ConnectionString = "DESKTOP-1Q3SART;Database=fast_food_restuarant;Trusted_Connection=True;";
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["log_in_infoString"].ConnectionString;
                comm.Connection = conn;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {


            SqlDataAdapter sda = new SqlDataAdapter(" select count(*) from log_in_info where user_name='" + textBox1.Text + "' and password='" + textBox2.Text + "'", dt.conn);
            dt.conn.Open();
            DataTable da = new DataTable();
            sda.Fill(da);
            if (textBox1.Text == "" && textBox2.Text == "")
            {
                MessageBox.Show("please enter Username and Password");
            }

            else if (da.Rows[0][0].ToString() == "1")
            {

                this.Hide();
                Form9 ss = new Form9();
                ss.Show();
            }
            else
            {
                MessageBox.Show("Incorrect Username and Password");
                this.Hide();
                Form4 ss = new Form4();
                ss.Show();
            }
            dt.conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 ss = new Form1();
            ss.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       











    }
}
