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
    public partial class Form7 : Form
    {
        DataAccess dt;
        public Form7()
        {
            InitializeComponent();
            dt = new DataAccess();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dt.comm.CommandText = "Select * from employee_info";

            dt.conn.Open();

            SqlDataReader r = dt.comm.ExecuteReader();
            listBox1.Items.Add("ID \t\t Name \t\t Age \t\t address \t\t\t phone");
            while (r.Read())
            {
                string id = r["id"].ToString();
                string name = r["name"].ToString();
                string age = r["age"].ToString();
                string address = r["address"].ToString();
                string phone = r["phone"].ToString();

                listBox1.Items.Add(id + "" + name + "\t" + age + "\t" + address + "\t" + phone);
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

        private void button6_Click_1(object sender, EventArgs e)
        {
            string id = textBox1.Text;
            string name = textBox2.Text;
            string age = textBox3.Text;
            string address = textBox4.Text;
            string phone = textBox5.Text;
            SqlDataAdapter sda = new SqlDataAdapter(" select count(*) from employee_info where id='" + id + "'", dt.conn);
            dt.conn.Open();
            DataTable da = new DataTable();
            sda.Fill(da);

            if ((id == "" && name == "") && (age == "" && address == "") && (phone == "" ))
            { MessageBox.Show("No Row is selsected for insert !!"); }
            else if (da.Rows[0][0].ToString() == "1")
            {
                MessageBox.Show("*** Id can not be the same **** !!");
            }
            else if (id == "")
            { MessageBox.Show("Please enter all data!!"); }
            else if (name == "")
            { MessageBox.Show("Please enter all data!!"); }
            else if (age == "")
            { MessageBox.Show("Please enter all data!!"); }
            else if (address == "")
            { MessageBox.Show("Please enter all data!!"); }
            else if (phone == "")
            { MessageBox.Show("Please enter all data!!"); }
            else
            {
                dt.comm.CommandText = "insert into employee_info values('" + id + "','" + name + "', '" + age + "' , '" + address + "' , '" + phone + "')";
                MessageBox.Show("Insert sucessfully ..... !!");
            }
       
            dt.comm.ExecuteNonQuery();
            dt.conn.Close();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text;
            string name = textBox2.Text;
            string age = textBox3.Text;
            string address = textBox4.Text;
            string phone = textBox5.Text;
          
            if ((id == "" && name == "") && (age == "" && address == "") && (phone == ""))
            { MessageBox.Show("No Row is selsected for update !!"); }
            else if (id == "")
            { MessageBox.Show("id must be insert for update !!"); }
            else if (id != "" && (name == "" && age == "" && address == "" && phone == ""))
            { MessageBox.Show("no data  is  update !!"); }


            else if (name != "" && age != "" && address != "" && phone != "" )
            {
                dt.comm.CommandText = "update employee_info set name = '" + name + "', age = '" + age + "', address = '" + address + "', phone = '" + phone + "' where id = '" + id + "'";
                MessageBox.Show("Updated Successfully...!!");
            }

             else  if (name != "")
            {
                dt.comm.CommandText = "update employee_info set name = '" + name + "' where id = '" + id + "'";
                MessageBox.Show("Updated Successfully...!!");
            }
             else if (age != "")
            {
                dt.comm.CommandText = "update employee_info set age = '" + age + "' where id = '" + id + "'";
                MessageBox.Show("Updated Successfully...!!"); 
            }
             else if (address != "")
            {
                dt.comm.CommandText = "update employee_info set address = '" + address + "' where id = '" + id + "'";
                MessageBox.Show("Updated Successfully...!!");
            }
             else if (phone != "")
            {
                dt.comm.CommandText = "update employee_info set phone = '" + phone + "' where id = '" + id + "'";
                MessageBox.Show("Updated Successfully...!!");
            }
           else
            {
                dt.comm.CommandText = "update employee_info set name = '" + name + "' age = '" + age + "' address = '" + address + "' phone = '" + phone + "' where id = '" + id + "'";
                MessageBox.Show("Updated Successfully...!!");
            }
            dt.conn.Open();
            dt.comm.ExecuteNonQuery();
          
            dt.conn.Close();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text;
            string name = textBox2.Text;
            string age = textBox3.Text;
            string address = textBox4.Text;
            string phone = textBox5.Text;
            if ((id == "" && name == "") && (age == "" && address == "") && (phone == ""))
            { MessageBox.Show("No Row is selsected for delete !!"); }
            else if (id != "")
            {
                dt.comm.CommandText = "delete from employee_info where id = '" + id + "'";
                MessageBox.Show(" delete  suceesfully !!");
            }
            else if (name != "")
            {
                dt.comm.CommandText = "delete from employee_info where name = '" + name + "'";
                MessageBox.Show(" delete  suceesfully !!");
            }
            else if (age != "")
            {
                dt.comm.CommandText = "delete from employee_info where age = '" + age + "'";
                MessageBox.Show(" delete  suceesfully !!");

            }
            else if (address != "")
            {
                dt.comm.CommandText = "delete from employee_info where address = '" + address + "'";
                MessageBox.Show(" delete  suceesfully !!");

            }
            else if (phone != "")
            {
                dt.comm.CommandText = "delete from employee_info where phone = '" + phone + "'";
                MessageBox.Show(" delete  suceesfully !!");

            }


            dt.conn.Open();
            dt.comm.ExecuteNonQuery();
            dt.conn.Close();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
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

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        

       


    }
}
