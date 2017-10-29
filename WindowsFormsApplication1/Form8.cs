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
    public partial class Form8 : Form
    {
        DataAccess dt;
        int price, subprice = 0;
        double totalprice;
        string p;
        public Form8()
        {
            InitializeComponent();
            dt = new DataAccess();
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dt.comm.CommandText = "Select * from food_info";

            dt.conn.Open();

            SqlDataReader r = dt.comm.ExecuteReader();
            listBox1.Items.Add("FoodID\tFoodName  \t\t Price");
            while (r.Read())
            {
                string id = r["id"].ToString();
                string name = r["name"].ToString();
                string price = r["price"].ToString();

                listBox1.Items.Add(id + "" + name + "\t " + price);
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
            }
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("");
            comboBox1.Items.Add("Cash");
            comboBox1.Items.Add("Master Card");
            comboBox1.Items.Add("Visa Card");
            comboBox1.Items.Add("Debit Card");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text;
            string amount = textBox2.Text;
            int a = Convert.ToInt32(amount);
            int pr;
            dt.comm.CommandText = "select price from food_info where id= "+id+"";
            dt.conn.Open();
            SqlDataReader r = dt.comm.ExecuteReader();
            while (r.Read())
            {
                p = r["price"].ToString();
            }
            pr = Convert.ToInt32(p);
            price = pr * a;
            subprice = subprice + price;
            textBox3.Text = price.ToString();
            dt.conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox4.Text = subprice.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            totalprice =  subprice + ((subprice * 15 ) / 100 );
            textBox5.Text = totalprice.ToString();

        }

      

        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Cash")
            {
                string recit = textBox6.Text;
                double t = Convert.ToDouble(recit);
                double ret = t - totalprice;
                textBox7.Text = ret.ToString();
            }
            else { MessageBox.Show("please Select cash"); }

          

        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 ss = new Form1();
            ss.Show();
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox1.Text == "Cash")
            {
                comboBox1.Enabled = true;
                comboBox1.Text = "Cash";
                comboBox1.Focus();
                textBox6.Enabled = true;
                textBox6.Text = "";
                textBox7.Enabled = true;
                textBox7.Text = "";
            }
            else
            {
                textBox6.Enabled = false;
                textBox6.Text = "";
                textBox7.Enabled = false;
                textBox7.Text = "";
            }
        }

        


    
    }
}
