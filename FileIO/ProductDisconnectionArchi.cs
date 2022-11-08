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
    public partial class ProductDisconnectionArchi : Form
    {
        SqlConnection con;
        SqlDataAdapter da;
        SqlCommandBuilder scb;
        DataSet ds;

        public ProductDisconnectionArchi()
        {
            InitializeComponent();
            string constr = ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;
            con = new SqlConnection(constr);
        }
        private void ProductDisconnectionArchi_Load(object sender, EventArgs e)
        {

        }
        public DataSet GetAllproduct()
        {
            da = new SqlDataAdapter("select * from product", con);
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            scb = new SqlCommandBuilder(da);
            ds = new DataSet();
            da.Fill(ds, "product");// product is a table name given to DataTable
            return ds;
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                ds = GetAllproduct();
                DataRow row = ds.Tables["product"].NewRow();
                row["name"] = txtname.Text;
                row["price"] = txtprice.Text;
                row["compname"] = txtcn.Text;
                ds.Tables["product"].Rows.Add(row);
                int result = da.Update(ds.Tables["product"]);
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
                ds = GetAllproduct();
                DataRow row = ds.Tables["product"].Rows.Find(txtid.Text);
                if (row != null)
                {
                    row["name"] = txtname.Text;
                    row["price"] = txtprice.Text;
                    row["compname"] = txtcn.Text;
                    int result = da.Update(ds.Tables["product"]);
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
                ds = GetAllproduct();
                DataRow row = ds.Tables["product"].Rows.Find(txtid.Text);
                if (row != null)
                {
                    row.Delete();
                    int result = da.Update(ds.Tables["product"]);
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
                ds = GetAllproduct();
                DataRow row = ds.Tables["product"].Rows.Find(txtid.Text);
                if (row != null)
                {
                    txtname.Text = row["name"].ToString();
                    txtprice.Text = row["price"].ToString();
                    txtcn.Text = row["company name"].ToString();
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
                ds = GetAllproduct();
                dataGridView1.DataSource = ds.Tables["product"];

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
