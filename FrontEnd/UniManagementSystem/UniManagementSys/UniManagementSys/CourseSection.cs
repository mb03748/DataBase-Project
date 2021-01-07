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
    public partial class CourseSection : Form
    {
        public CourseSection()
        {
            InitializeComponent();
        }

        private void CourseSection_Load(object sender, EventArgs e)
        {
            DbConnection load = new DbConnection();
            DataTable temp = load.Select("SELECT * FROM Semester;");
            temp.Columns.Add("FullName", typeof(string), "Name + ' ' + Year");
            comboBox1.DataSource = temp;
            comboBox1.DisplayMember = "FullName";
            comboBox1.ValueMember = "SemesterID";
            comboBox1.Text = "";

        }

        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue == null) return;
            DbConnection load = new DbConnection();
            string query = "SELECT CourseID, [Name] FROM CourseOffering, Course WHERE Course_CourseID = CourseID AND Semester_SemesterID = "+ comboBox1.SelectedValue.ToString();
            DataTable temp = load.Select(query);
            temp.Columns.Add("FullName", typeof(string), "CourseID + ': ' + Name");
            comboBox2.DataSource = temp;
            comboBox2.DisplayMember = "FullName";
            comboBox2.ValueMember = "CourseID";
            comboBox2.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DbConnection add = new DbConnection();
            string query = "SELECT CourseSectionID FROM CourseSection ORDER BY CourseSectionID DESC;";
            int newSecID = Convert.ToInt32(add.Select(query).Rows[0][0]) + 1;
            query="SELECT CourseOfferingID FROM CourseOffering WHERE Semester_SemesterID = "+comboBox1.SelectedValue+" AND Course_CourseID = '"+comboBox2.SelectedValue+"'";
            int courseOffID = Convert.ToInt32(add.Select(query).Rows[0][0]);
            query = "INSERT INTO CourseSection VALUES(" +newSecID+","+ comboBox3.SelectedValue.ToString() + "," + courseOffID.ToString() + "," + textBox1.Text + "," + 0 + ")";
            add.Inserts(query);
            MessageBox.Show("Section Created!");
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_DropDownClosed(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_DropDownClosed(object sender, EventArgs e)
        {
            if (comboBox2.SelectedValue == null) return;
            DbConnection load = new DbConnection();
            //Load department information of the selected course
            string query = "SELECT DepartmentID,Department.[Name] FROM Course, Department WHERE DepartmentID = Department_DepartmentID AND CourseID = '"+ comboBox2.SelectedValue.ToString() + "'";
            DataTable temp = load.Select(query);
            textBox2.Text = temp.Rows[0][1].ToString();
            string deptID = temp.Rows[0][0].ToString();
            //Load faculty members from the selected course department
            query = "SELECT FacultyID, Faculty.[Name] FROM Faculty, Faculty_Department, Department WHERE Faculty_FacultyID = FacultyID AND DepartmentID = Department_DepartmentID AND Department_DepartmentID = " +deptID;
            temp = load.Select(query);
            temp.Columns.Add("Faculty", typeof(string), "FacultyID + ' : ' + [Name]");
            comboBox3.DataSource = temp;
            comboBox3.DisplayMember = "Faculty";
            comboBox3.ValueMember = "FacultyID";
        }
    }
}
