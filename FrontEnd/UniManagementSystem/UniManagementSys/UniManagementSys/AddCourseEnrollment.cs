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
    public partial class AddCourseEnrollment : Form
    {
        int CreditLimit = 20;
        public AddCourseEnrollment()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void EnrollStudent_Load(object sender, EventArgs e)
        {
            DbConnection add = new DbConnection();
            DataTable temp = add.Select("SELECT * FROM Student;");
            temp.Columns.Add("FullName", typeof(string), "StudentID + ': ' + Name");
            comboBox1.DataSource = temp;
            comboBox1.DisplayMember = "FullName";
            comboBox1.ValueMember = "StudentID";
            comboBox1.Text = "Please select Student..";
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedValue == null || comboBox2.SelectedValue == null || textBox1.Text == "" || textBox2.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Proper selections haven't been made. Please recheck!");
                return;
            }
            if(Convert.ToInt32(textBox1.Text) + Convert.ToInt32(textBox2.Text) >  CreditLimit)
            {
                MessageBox.Show("Enrollment would exceed limit of " + CreditLimit.ToString() + " cr. hrs.");
                return;
            }
            if (Convert.ToInt32(textBox4.Text) == Convert.ToInt32(textBox5.Text))
            {
                MessageBox.Show("Class is full!");
                return;
            }
            DbConnection add = new DbConnection();
            string query = "";
            DataTable temp = new DataTable();
            //Check if prereqs have been met if the selected course has prereqs
            if(listBox1.DataSource != null)
            {
                query = "(SELECT CourseID FROM Course WHERE CourseID IN (SELECT Course_PreReqID FROM Course, Course_Prereq WHERE Course.CourseID = Course_Prereq.Course_CourseID AND CourseID = '" + comboBox3.SelectedValue + "')) EXCEPT (SELECT DISTINCT Course_CourseID FROM Student_Course_Enrolment, CourseSection, CourseOffering WHERE CourseSection_CourseSectionID = CourseSectionID AND CourseOffering_CourseOfferingID = CourseOfferingID AND Student_StudentID = " + comboBox1.SelectedValue + ")";
                temp = add.Select(query);
                if (temp.Rows.Count > 0)
                {
                    MessageBox.Show("Prereqs. have not been met! Please retry.");
                    return;
                }
            }
            //Enroll the student, all conditions have been met!
            query = "INSERT INTO Student_Course_Enrolment VALUES (" + comboBox1.SelectedValue + ", " + comboBox4.SelectedValue + ", 0)";
            try
            {
                //enroll student
                temp = add.Select(query);
                //update semester record
                query = "UPDATE Student_Semester_Enrolment SET Credits = Credits + 3 WHERE Student_StudentID = "+comboBox1.SelectedValue+" AND Semester_SemesterID = " + comboBox2.SelectedValue;
                add.Inserts(query);
                query = "UPDATE CourseSection SET NoStudents = NoStudents + 1 WHERE CourseSectionID = " + comboBox4.SelectedValue;
                add.Inserts(query);
                MessageBox.Show("Student Enrolled!");
            }
            catch (Exception er)
            {
                MessageBox.Show("Cannot enroll in already enrolled section/Correct errors in the form!");
                return;
            }
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_DropDownClosed(object sender, EventArgs e)
        {
            comboBox4.DataSource = null;
            textBox2.Text = ""; textBox3.Text = ""; textBox4.Text = ""; textBox5.Text = ""; textBox6.Text = ""; textBox7.Text = "";
            richTextBox1.Text = ""; listBox1.DataSource = null; listBox1.Text = "";

            if (comboBox1.SelectedValue == null) return;
            DbConnection load = new DbConnection();
            string query = "SELECT * FROM Course,Department WHERE DepartmentID = Department_DepartmentID AND CourseID = '" + comboBox3.SelectedValue + "'";
            DataTable temp = load.Select(query);
            if (temp.Rows.Count == 0) return;
            textBox2.Text = temp.Rows[0][4].ToString();
            textBox3.Text = temp.Rows[0][6].ToString();
            richTextBox1.Text = temp.Rows[0][3].ToString();

            query = "SELECT * FROM CourseOffering WHERE Course_CourseID  = '"+comboBox3.SelectedValue+"'AND Semester_SemesterID = " + comboBox2.SelectedValue;
            temp = load.Select(query);
            if (temp.Rows.Count == 0) return;
            textBox6.Text = temp.Rows[0][0].ToString();

            //PreReqs
            query = "SELECT CourseID, [Name] FROM Course WHERE CourseID IN (SELECT Course_PreReqID FROM Course, Course_Prereq WHERE Course.CourseID = Course_Prereq.Course_CourseID AND CourseID = '" + comboBox3.SelectedValue + "');";
            temp = load.Select(query);
            if (temp.Rows.Count != 0)
            {
                temp.Columns.Add("FullName", typeof(string), "CourseID + ': ' + Name");
                listBox1.DataSource = temp;
                listBox1.DisplayMember = "FullName";
                listBox1.ValueMember = "CourseID";
            }
            
            query = "SELECT * FROM CourseSection WHERE CourseOffering_CourseOfferingID = " + textBox6.Text;
            temp = load.Select(query);
            if (temp.Rows.Count == 0) return;
            comboBox4.DataSource = temp;
            temp.Columns.Add("Name", typeof(string));
            int i = 1;
            foreach (DataRow row in temp.Rows)
            {
                row["Name"] = "L"+i.ToString();
                i++;
            }
            comboBox4.DisplayMember = "Name";
            comboBox4.ValueMember = "CourseSectionID";
            comboBox4.Text = "";


        }

        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            comboBox2.DataSource = null; comboBox3.DataSource = null; comboBox4.DataSource = null;
            textBox1.Text = ""; textBox2.Text = ""; textBox3.Text = ""; textBox4.Text = ""; textBox5.Text = ""; textBox6.Text = ""; textBox7.Text = "";
            richTextBox1.Text = ""; listBox1.DataSource = null; listBox1.Text = "";
            if (comboBox1.SelectedValue == null) return; 
            DbConnection load = new DbConnection();
            string query = "SELECT * FROM Student_Semester_Enrolment, Semester WHERE SemesterID = Semester_SemesterID AND Student_StudentID = " + comboBox1.SelectedValue;
            DataTable temp = load.Select(query);
            temp.Columns.Add("FullName", typeof(string), "Name + ' ' + Year");
            comboBox2.DataSource = temp;
            comboBox2.DisplayMember = "FullName";
            comboBox2.ValueMember = "SemesterID";
            comboBox2.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void comboBox2_DropDownClosed(object sender, EventArgs e)
        {
            comboBox3.DataSource = null; comboBox4.DataSource = null;
            textBox1.Text = ""; textBox2.Text = ""; textBox3.Text = ""; textBox4.Text = ""; textBox5.Text = ""; textBox6.Text = ""; textBox7.Text = "";
            richTextBox1.Text = ""; listBox1.DataSource = null; listBox1.Text = "";
            if (comboBox2.SelectedValue == null) return;
            DbConnection load = new DbConnection();
            string query = "SELECT * FROM CourseOffering, Course WHERE CourseID = Course_CourseID AND Semester_SemesterID = " + comboBox2.SelectedValue;
            DataTable temp = load.Select(query);
            temp.Columns.Add("FullName", typeof(string), "CourseID + ': ' + Name");
            comboBox3.DataSource = temp;
            comboBox3.DisplayMember = "FullName";
            comboBox3.ValueMember = "CourseID";
            comboBox3.Text = "";

            query = "SELECT * FROM Student_Semester_Enrolment WHERE Student_StudentID = "+comboBox1.SelectedValue+" AND Semester_SemesterID = " + comboBox2.SelectedValue;
            temp = load.Select(query);
            MessageBox.Show(query);
            if (temp.Rows.Count == 0) return;
            textBox1.Text = temp.Rows[0][3].ToString();
        }

        private void comboBox4_DropDownClosed(object sender, EventArgs e)
        {
            textBox4.Text = ""; textBox5.Text = ""; textBox7.Text = "";

            if (comboBox4.SelectedValue == null) return;
            DbConnection load = new DbConnection();
            string secID = comboBox4.SelectedValue.ToString();
            string query = "SELECT * FROM CourseSection, Faculty WHERE FacultyID = Faculty_FacultyID AND CourseOffering_CourseOfferingID = " + textBox6.Text + "AND CourseSectionID = " + secID;
            DataTable temp = load.Select(query);
            if (temp.Rows.Count == 0) return;
            textBox7.Text = temp.Rows[0][7].ToString();
            textBox4.Text = temp.Rows[0][3].ToString();
            textBox5.Text = temp.Rows[0][4].ToString();
        }

        private void comboBox4_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void comboBox3_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void comboBox2_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }
    }
}
