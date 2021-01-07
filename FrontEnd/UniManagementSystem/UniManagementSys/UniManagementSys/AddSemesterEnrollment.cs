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
    public partial class AddSemesterEnrollment : Form
    {
        public AddSemesterEnrollment()
        {
            InitializeComponent();
        }

        private void AddSSE_Load(object sender, EventArgs e)
        {
            DbConnection load = new DbConnection();
            DataTable temp = load.Select("Select StudentID, [Name] from Student");
            temp.Columns.Add("Student", typeof(string), "StudentID + ' - ' + [Name]");
            comboBox1.DataSource = temp;
            comboBox1.DisplayMember = "Student";
            comboBox1.ValueMember = "StudentID";
            DataTable temp1 = load.Select("select SemesterID, [Name], year from Semester");
            temp1.Columns.Add("Semester", typeof(string), "[Name] + ' - ' + Year");
            comboBox2.DataSource = temp1;
            comboBox2.DisplayMember = "Semester";
            comboBox2.ValueMember = "SemesterID";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DbConnection add = new DbConnection();
            //Check if student already enrolled
            string query = "SELECT * FROM Student_Semester_Enrolment WHERE Student_StudentID = " + comboBox1.SelectedValue.ToString() + " AND Semester_SemesterID = " + comboBox2.SelectedValue.ToString();
            DataTable temp = add.Select(query);
            if(temp.Rows.Count != 0 )
            {
                MessageBox.Show("Student already registered in selected semester!");
                return;
            }
            //Proceed Enrollment
            query = "INSERT INTO Student_Semester_Enrolment VALUES(" + comboBox1.SelectedValue.ToString() + "," + comboBox2.SelectedValue.ToString() + ",NULL,0)";
            add.Inserts(query);
            MessageBox.Show("Student Enrolled!");
        }
    }
}
