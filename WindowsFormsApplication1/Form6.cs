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
    public partial class Form6 : Form
    {
        DataAccess dt;
        public Form6()
        {
            InitializeComponent();
            dt = new DataAccess();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            this.Hide();
            Form1 ss = new Form1();
            ss.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Hide();
            Form5 ss = new Form5();
            ss.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
           
            string id = textBox1.Text;
            string name = textBox2.Text;
            string price = textBox3.Text;


             SqlDataAdapter sda = new SqlDataAdapter(" select count(*) from food_info where id='" + id + "'" , dt.conn);
            dt.conn.Open();
            DataTable da = new DataTable();
            sda.Fill(da);
           
            if ((id == "" && name == "") && (price == ""))
            { MessageBox.Show("No Row is selsected for insert !!"); }
            if (da.Rows[0][0].ToString() == "1")
            {
                MessageBox.Show("*** Id can not be the same **** !!");
            }
            else if (id == "")
            { MessageBox.Show("Please enter all data!!"); }
            else  if (name == "")
            { MessageBox.Show("Please enter all data!!"); }
            else if (price == "")
            { MessageBox.Show("Please enter all data!!"); }
            else
            { dt.comm.CommandText = "insert into food_info values('" + id + "','" + name + "', '" + price + "')";
             MessageBox.Show("Insert sucessfully ..... !!"); }
            
            dt.comm.ExecuteNonQuery();

            dt.conn.Close();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
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

                listBox1.Items.Add(id + "" +name + "\t " + price);
            }
            dt.conn.Close();
        }

        

        private void button8_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text;
            string name = textBox2.Text;
            string price = textBox3.Text;
            if ((id == "" && name == "") && (price == ""))
            { MessageBox.Show("No Row is selsected for update !!"); }
            else  if (id == "")
            { MessageBox.Show("id must be insert for update !!"); }
            else if (id != "" && (name == "" && price == ""))
            { MessageBox.Show("no data  is  update !!"); }
            else if (name != "" && price != "")
            {
                dt.comm.CommandText = "update food_info set name = '" + name + "', price = '" + price + "' where id = '" + id + "'";
                MessageBox.Show("Updated Successfully...!!");
            }
          
            else if (name != "")
            {
                dt.comm.CommandText = "update food_info set name = '" + name + "' where id = '" + id + "'";
                MessageBox.Show("Updated Successfully...!!");
            }
            else if (price != "")
            {
                dt.comm.CommandText = "update food_info set price = '" + price + "' where id = '" + id + "'";
                MessageBox.Show("Updated Successfully...!!");
            }
            

            else
            { dt.comm.CommandText = "update food_info set price = '" + price + "',name = '" + name + "' where id = '" + id + "'";
            MessageBox.Show("Updated Successfully...!!");
            }
            dt.conn.Open();
            dt.comm.ExecuteNonQuery();
            dt.conn.Close();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }


        private void button7_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text;
            string name = textBox2.Text;
            string price = textBox3.Text;
            if ((id == "" && name == "" )&& (price == ""))
            { MessageBox.Show("No Row is selsected for delete !!"); }
            else  if (id != "" )
            { dt.comm.CommandText = "delete from food_info where id = '" + id + "'";
            MessageBox.Show(" delete  suceesfully !!");
            }
             else  if (name!= "") 
            { dt.comm.CommandText = "delete from food_info where name = '" + name + "'";
            MessageBox.Show(" delete  suceesfully !!");
            }
             else  if (price != "")
            {
                dt.comm.CommandText = "delete from food_info where price = '" + price + "'";
                MessageBox.Show(" delete  suceesfully !!");

            }
            

            dt.conn.Open();
            dt.comm.ExecuteNonQuery();
            dt.conn.Close();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
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

      

  
    }

}
