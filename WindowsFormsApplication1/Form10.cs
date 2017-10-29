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
    public partial class Form10 : Form
    {
        DataAccess dt;
        public Form10()
        {
            InitializeComponent();
            dt = new DataAccess();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dt.comm.CommandText = "Select * from log_in_info";

            dt.conn.Open();

            SqlDataReader r = dt.comm.ExecuteReader();
            listBox1.Items.Add("Name \t\t Password");
            while (r.Read())
            {
              
                string user_name = r["user_name"].ToString();
                string password = r["password"].ToString();
                listBox1.Items.Add(user_name + "" + password );
             

            }
            dt.conn.Close();

        }


        public class DataAccess
        {
            public SqlConnection conn;
            public SqlCommand comm;

            public DataAccess()
            {
                conn = new SqlConnection();
                comm = new SqlCommand();
                //conn.ConnectionString = "Server=DESKTOP-1Q3SART;Database=fast_food_restuarant;Trusted_Connection=True;";
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["log_in_infoString"].ConnectionString;
                comm.Connection = conn;
                SqlDataAdapter da = new SqlDataAdapter(comm);
            }


        }

        private void button7_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 ss = new Form5();
            ss.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 ss = new Form1();
            ss.Show();
        }


    }
}
