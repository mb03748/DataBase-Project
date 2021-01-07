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
    public partial class AddCourse : Form
    {
        public AddCourse()
        {
            InitializeComponent();
        }

        private void AddCourse_Load(object sender, EventArgs e)
        {
            DbConnection load = new DbConnection();
            comboBox1.DataSource = load.Select("SELECT * FROM Department;");
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "DepartmentID";
            DataTable temp = load.Select("SELECT * FROM Course;");
            temp.Columns.Add("FullName", typeof(string), "CourseID + ': ' + Name");
            listBox1.DataSource = temp;
            listBox1.DisplayMember = "FullName";
            listBox1.ValueMember = "CourseID";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Required fields are empty. Please refill!");
                return;
            }
            DbConnection add = new DbConnection();
            //Check if course has a duplicateID
            string course = "SELECT * FROM Course WHERE CourseID = '"+textBox1.Text+"'";
            DataTable temp = add.Select(course);
            if (temp.Rows.Count != 0)
            {
                MessageBox.Show("Duplicate Course ID. Please reenter!");
                return;
            }
            //Add the course
            course = "INSERT INTO Course VALUES('" + textBox1.Text + "'," + comboBox1.SelectedValue + ",'" + textBox3.Text + "','" + richTextBox1.Text + "'," + textBox2.Text + ");";
            add.Inserts(course);
            //Add prereqs
            if (listBox1.Enabled)
            {
                foreach (DataRowView item in listBox1.SelectedItems)
                {
                    string prereq = "INSERT INTO Course_Prereq VALUES('"+textBox1.Text+"', '"+ item.Row["CourseID"].ToString()+"')";
                    add.Inserts(prereq);
                }
            }
            MessageBox.Show("Course Added!");
            this.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            listBox1.Enabled = !listBox1.Enabled;
        }
    }
}
