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

namespace Project_windowsForm
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty || textBox2.Text == string.Empty || textBox3.Text == string.Empty || textBox4.Text == string.Empty || textBox5.Text == string.Empty || textBox6.Text == string.Empty || textBox7.Text == string.Empty || textBox8.Text == string.Empty || textBox9.Text == string.Empty || textBox10.Text == string.Empty || maskedTextBox3.Text == string.Empty)
            {
                MessageBox.Show("All fields must be filled");
            }
            else
            {
                Random random = new Random();
                int rand = random.Next(1000000, 9999999);
                string ad_id = rand.ToString();
                string ad_name = textBox1.Text;
                string brand_name = textBox2.Text;
                string condition = textBox3.Text;
                string model_year = maskedTextBox3.Text;
                string manufacturer = textBox4.Text;
                string fuel_type = textBox5.Text;
                string transmission = textBox6.Text;
                string engine_capacity = textBox7.Text;
                string engine_mileage = textBox8.Text;
                string price = textBox9.Text;
                string image_url = textBox10.Text;

                string connString = "Server = localhost;Database = master;Trusted_Connection=True";

                SqlConnection conn = new SqlConnection(connString);
                Console.WriteLine("Openning Connection ...");

                //open connection
                conn.Open();

                Console.WriteLine("Connection successful!");
                string sql = "insert into IPT_CourseProject.dbo.Temp2 ([ad_id],[brand_name],[item_condition],[model_year],[manufacturer],[fuel_type],[transmission],[engine_capacity] ,[description],[engine_mileage],[image_url],[price]) values (@ad_id,@brand_name,@item_condition,@model_year,@manu,@fuel,@trans,@eng_cap,@descrip,@engg_mil,@img_url,@price)";

                try
                {
                    using(SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("ad_id",ad_id);
                        cmd.Parameters.AddWithValue("brand_name",brand_name);
                        cmd.Parameters.AddWithValue("item_condition",condition);
                        cmd.Parameters.AddWithValue("model_year",model_year);
                        cmd.Parameters.AddWithValue("manu",manufacturer);
                        cmd.Parameters.AddWithValue("fuel",fuel_type);
                        cmd.Parameters.AddWithValue("trans",transmission);
                        cmd.Parameters.AddWithValue("eng_cap",engine_capacity);
                        cmd.Parameters.AddWithValue("descrip",ad_name);
                        cmd.Parameters.AddWithValue("engg_mil",engine_mileage);
                        cmd.Parameters.AddWithValue("img_url", image_url);
                        cmd.Parameters.AddWithValue("price",price);
                        int rowsAdded = cmd.ExecuteNonQuery();
                        if (rowsAdded > 0)
                            MessageBox.Show("Row inserted!!");
                        else
                            MessageBox.Show("No row inserted");
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }

            }



        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
