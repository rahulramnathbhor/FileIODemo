using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileIO
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnBinaryWrite_Click(object sender, EventArgs e)
        {
            try
            {
                Employee employee = new Employee();
                employee.Id = Convert.ToInt32(txtId.Text);
                employee.Name = txtName.Text;
                employee.Salary = Convert.ToInt32(txtSalary.Text);
                //.dat --> data file  / binary file
                FileStream fs = new FileStream(@"D:\Cybage\emp.dat", FileMode.Create, FileAccess.Write);
                BinaryFormatter binary = new BinaryFormatter();
                binary.Serialize(fs, employee);
                fs.Close();
                MessageBox.Show("Binary data saved");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }

        }

        private void btnBinaryRead_Click(object sender, EventArgs e)
        {
            try
            {
                Employee employee = new Employee();

                FileStream fs = new FileStream(@"D:\Cybage\emp.dat", FileMode.Open, FileAccess.Read);
                BinaryFormatter binary = new BinaryFormatter();
                employee = (Employee)binary.Deserialize(fs);
                txtId.Text = employee.Id.ToString();
                txtSalary.Text = employee.Salary.ToString();
                txtName.Text = employee.Name;
                fs.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }

        }

        private void btnsoapWrite_Click(object sender, EventArgs e)
        {
            try
            {
                Employee employee = new Employee();
                employee.Id = Convert.ToInt32(txtId.Text);
                employee.Name = txtName.Text;
                employee.Salary = Convert.ToInt32(txtSalary.Text);
                //.dat --> data file  / binary file
                FileStream fs = new FileStream(@"D:\Cybage\emp.soap", FileMode.Create, FileAccess.Write);
               SoapFormatter soapFormatter = new SoapFormatter();
                soapFormatter.Serialize(fs, employee);
                fs.Close();
                MessageBox.Show("Soap data saved");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }

        private void btnSoapRead_Click(object sender, EventArgs e)
        {
            try
            {
                Employee employee = new Employee();

                FileStream fs = new FileStream(@"D:\Cybage\emp.soap", FileMode.Open, FileAccess.Read);
                SoapFormatter soapFormatter = new SoapFormatter();
                employee = (Employee)soapFormatter.Deserialize(fs);
                txtId.Text = employee.Id.ToString();
                txtSalary.Text = employee.Salary.ToString();
                txtName.Text = employee.Name;
                fs.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }

        private void btnXmlWrite_Click(object sender, EventArgs e)
        {
            try
            {
                Employee employee = new Employee();
                employee.Id = Convert.ToInt32(txtId.Text);
                employee.Name = txtName.Text;
                employee.Salary = Convert.ToInt32(txtSalary.Text);
                //.dat --> data file  / binary file
                FileStream fs = new FileStream(@"D:\Cybage\emp.xml", FileMode.Create, FileAccess.Write);
                XmlSerializer xml = new XmlSerializer(typeof(Employee));
                xml.Serialize(fs, employee);
                fs.Close();
                MessageBox.Show("Xml data saved");
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }

        private void btnXmlRead_Click(object sender, EventArgs e)
        {
            try
            {
                Employee employee = new Employee();

                FileStream fs = new FileStream(@"D:\Cybage\emp.xml", FileMode.Open, FileAccess.Read);
                XmlSerializer xml = new XmlSerializer(typeof(Employee));
                employee = (Employee)xml.Deserialize(fs);
                txtId.Text = employee.Id.ToString();
                txtSalary.Text = employee.Salary.ToString();
                txtName.Text = employee.Name;
                fs.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }

        private void btnJsonWrite_Click(object sender, EventArgs e)
        {
            try
            {


                Employee employee = new Employee();
                employee.Id = Convert.ToInt32(txtId.Text);
                employee.Name = txtName.Text;
                employee.Salary = Convert.ToInt32(txtSalary.Text);
                //.dat --> data file  / binary file
                FileStream fs = new FileStream(@"D:\Cybage\emp.json", FileMode.Create, FileAccess.Write);
                JsonSerializer.Serialize<Employee>(fs, employee);

               
                fs.Close();
                MessageBox.Show("Json data saved");
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }

        private void btnJsonRead_Click(object sender, EventArgs e)
        {
            try
            {
                Employee employee = new Employee();

                FileStream fs = new FileStream(@"D:\Cybage\emp.json", FileMode.Open, FileAccess.Read);
                JsonSerializer.Serialize<Employee>(fs, employee);
                //employee = (Employee) < .Deserialize(fs);
                txtId.Text = employee.Id.ToString();
                txtSalary.Text = employee.Salary.ToString();
                txtName.Text = employee.Name;
                fs.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
    
}

