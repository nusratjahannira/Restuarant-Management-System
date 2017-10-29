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
    public partial class Form2 : Form
    {
        DataAccess dt;
        public Form2()
        {
            InitializeComponent();
            dt = new DataAccess();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlDataAdapter sda = new SqlDataAdapter(" select count(*) from log_in_info where user_name='" + textBox1.Text + "' and password='" + textBox2.Text + "'", dt.conn);
            dt.conn.Open();
            DataTable da = new DataTable();
            sda.Fill(da);
            if (textBox1.Text == "" && textBox2.Text == "")
            {
                MessageBox.Show("please enter Username and Password");
                
            }
           else if (textBox1.Text == "Admin" && textBox2.Text == "12345")
            {
                this.Hide();
                Form5 s = new Form5();
                s.Show();
            }


            else
            {
                MessageBox.Show("Incorrect Username and Password");
            }
            dt.conn.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.Hide();
            Form1 s = new Form1();
            s.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        public class DataAccess
        {
            public SqlConnection conn;
            public SqlCommand comm;

            public DataAccess()
            {
                conn = new SqlConnection();
                comm = new SqlCommand();
                //conn.ConnectionString = "Server=AKIBIMTIAZNUHAS\SQLEXPRESS;Database=fast_food_restuarant;Trusted_Connection=True;";
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["log_in_infoString"].ConnectionString;
                comm.Connection = conn;
            }
        }

     

     

       

   
   

       

       
    }
}
