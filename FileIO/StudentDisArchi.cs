using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileIO
{
    public partial class StudentDisArchi : Form
    {
        SqlConnection con;
        SqlDataAdapter da;
        SqlCommandBuilder scb;
        DataSet ds;

        public StudentDisArchi()
        {
            InitializeComponent();
            string constr = ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;
            con = new SqlConnection(constr);
        }

        private void StudentDisArchi_Load(object sender, EventArgs e)
        {

        }
        public DataSet GetAllstudent()
        {
            da = new SqlDataAdapter("select * from student", con);
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            scb = new SqlCommandBuilder(da);
            ds = new DataSet();
            da.Fill(ds, "student");// product is a table name given to DataTable
            return ds;
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                ds = GetAllstudent();
                DataRow row = ds.Tables["student"].NewRow();
                row["name"] = txtname.Text;
                row["sub1"] = txtsub1.Text;
                row["sub2"] = txtsub2.Text;
                row["sub3"] = txtsub3.Text;
                row["percentage"] = txtper.Text;
                ds.Tables["student"].Rows.Add(row);
                int result = da.Update(ds.Tables["student"]);
                if (result == 1)
                {
                    MessageBox.Show("Record inserted");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                ds = GetAllstudent();
                DataRow row = ds.Tables["product"].Rows.Find(txtrollno.Text);
                if (row != null)
                {
                    row["name"] = txtname.Text;
                    row["sub1"] = txtsub1.Text;
                    row["sub2"] = txtsub2.Text;
                    row["sub3"] = txtsub3.Text;
                    row["percentage"] = txtper.Text;
                    int result = da.Update(ds.Tables["student"]);
                    if (result == 1)
                    {
                        MessageBox.Show("Record updated");
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                ds = GetAllstudent();
                DataRow row = ds.Tables["student"].Rows.Find(txtrollno.Text);
                if (row != null)
                {
                    row.Delete();
                    int result = da.Update(ds.Tables["student"]);
                    if (result == 1)
                    {
                        MessageBox.Show("Record deleted");
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            try
            {
                ds = GetAllstudent();
                DataRow row = ds.Tables["student"].Rows.Find(txtrollno.Text);
                if (row != null)
                {
                    txtname.Text = row["name"].ToString();
                    txtsub1.Text = row["sub1"].ToString();
                    txtsub2.Text = row["sub2"].ToString();
                    txtsub3.Text = row["sub3"].ToString();
                    txtper.Text = row["percentage"].ToString();
                }
                else
                {
                    MessageBox.Show("Record not found");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnshowall_Click(object sender, EventArgs e)
        {
            try
            {
                ds = GetAllstudent();
                dataGridView1.DataSource = ds.Tables["student"];

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       
    }
}
