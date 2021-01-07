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
    public partial class AdminForm : Form
    {
        MainForm mf = null;
        public AdminForm(MainForm mf)
        {
            InitializeComponent();
            this.mf = mf;
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {

        }

        private void AdminForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            mf.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DbConnection view = new DbConnection();
            dataGridView1.DataSource = view.Select("SELECT * FROM Student, Address WHERE Address_AddressID = AddressID");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddStudent addStudent = new AddStudent();
            addStudent.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ViewFaculty viewFac = new ViewFaculty();
            viewFac.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AddFaculty addFaculty = new AddFaculty();
            addFaculty.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            AddCourse addCourse = new AddCourse();
            addCourse.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            CourseOffering courseOff = new CourseOffering();
            courseOff.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            DbConnection view = new DbConnection();
            dataGridView1.DataSource = view.Select("SELECT * FROM CourseOffering,Course,Semester WHERE SemesterID = Semester_SemesterID AND CourseID = Course_CourseID");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            CourseSection courseSec = new CourseSection();
            courseSec.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            AddCourseEnrollment enroll = new AddCourseEnrollment();
            enroll.Show();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            AddDepartment addDepart = new AddDepartment();
            addDepart.Show();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            AddSemester addSeme = new AddSemester();
            addSeme.Show();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            AddDesignation addDesi = new AddDesignation();
            addDesi.Show();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            AddSemesterEnrollment addSSE = new AddSemesterEnrollment();
            addSSE.Show();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            DbConnection view = new DbConnection();
            dataGridView1.DataSource = view.Select("SELECT * FROM Department");
        }

        private void button17_Click(object sender, EventArgs e)
        {
            DbConnection view = new DbConnection();
            dataGridView1.DataSource = view.Select("SELECT * FROM Semester");
        }

        private void button22_Click(object sender, EventArgs e)
        {
            DbConnection view = new DbConnection();
            dataGridView1.DataSource = view.Select("SELECT * FROM CourseSection");
        }

        private void button23_Click(object sender, EventArgs e)
        {
            ViewCourse cDetails = new ViewCourse();
            cDetails.Show();
        }
    }
}
