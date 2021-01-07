using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniManagementSys
{
    public partial class AddFaculty : Form
    {
        public AddFaculty()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" 
                || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "" || textBox9.Text == "")
            {
                MessageBox.Show("Required fields are empty. Please reenter!");
                return;
            }
            DbConnection add = new DbConnection();
            //Check if duplicateID
            string query = "SELECT * FROM Faculty WHERE FacultyID = " + textBox1.Text;
            DataTable temp = add.Select(query);
            if (temp.Rows.Count != 0)
            {
                MessageBox.Show("Duplicate Faculty ID. Please reenter!");
                return;
            }
            //Proceed to add.
            //Add Address Entry
            int newAddrID = Convert.ToInt32(add.Select("SELECT AddressID FROM Address ORDER BY AddressID DESC;").Rows[0][0]) + 1;
            query = "INSERT INTO [Address] VALUES (" + newAddrID + ", '" + textBox4.Text + "', '" + textBox5.Text + "', '" + textBox6.Text + "', '" + textBox7.Text + "');";
            add.Inserts(query);

            //Add Faculty Entry
            query = "INSERT INTO Faculty VALUES(" + textBox1.Text + ", " + newAddrID + ", '" + textBox2.Text + "', '" + textBox3.Text + "', '" + comboBox1.Text + "', '" + dateTimePicker1.Value + "', " + textBox8.Text + ")";
            add.Inserts(query);

            //Add Department Entry
            query = "INSERT INTO Faculty_Department VALUES (" + textBox1.Text + ", " + comboBox3.SelectedValue + ", " + 1 + ");";
            add.Inserts(query);
            if (checkBox1.Checked == true)
            {
                query = "INSERT INTO Faculty_Department VALUES (" + textBox1.Text + ", " + comboBox2.SelectedValue + ", " + 0 + ");";
                add.Inserts(query);
            }

            //Add Designation Info
            string startDate = "1-1-" + System.DateTime.Now.Year.ToString();
            string endDate = "1-1-" + (System.DateTime.Now.Year + Convert.ToInt32(textBox9.Text)).ToString();
            foreach (DataRowView item in listBox2.SelectedItems)
            {
                query= "INSERT INTO Faculty_Designation VALUES(" + textBox1.Text + "," + item.Row["DesignationID"].ToString() + ",'" + startDate + "','" + endDate + "');";
                add.Inserts(query);
            }
            MessageBox.Show("Faculty Added!");
            this.Close();
        }

        private void AddFaculty_Load(object sender, EventArgs e)
        {
            textBox9.Text = "1";

            DbConnection add = new DbConnection();
            comboBox3.DataSource = add.Select("SELECT * FROM Department;");
            comboBox3.DisplayMember = "Name";
            comboBox3.ValueMember = "DepartmentID";
            comboBox3.Text = "";

            DataTable temp = add.Select("SELECT * FROM Designation;");
            listBox2.DataSource = temp;
            listBox2.DisplayMember = "PositionTitle";
            listBox2.ValueMember = "DesignationID";
        }

        private void comboBox3_DropDownClosed(object sender, EventArgs e)
        {
            if (comboBox3.SelectedValue == null) return;
            DbConnection add = new DbConnection();
            string updateMinor = "SELECT * FROM Department WHERE DepartmentID != " + comboBox3.SelectedValue + ";";
            comboBox2.DataSource = add.Select(updateMinor);
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "DepartmentID";
            comboBox2.Text = "";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            comboBox2.Enabled = !comboBox2.Enabled;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
