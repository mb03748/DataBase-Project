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
    public partial class CourseOffering : Form
    {
        public CourseOffering()
        {
            InitializeComponent();
        }

        private void CourseOffering_Load(object sender, EventArgs e)
        {
            DbConnection load = new DbConnection();
            DataTable temp = load.Select("SELECT * FROM Course;");
            temp.Columns.Add("FullName", typeof(string), "CourseID + ': ' + Name");
            comboBox1.DataSource = temp;
            comboBox1.DisplayMember = "FullName";
            comboBox1.ValueMember = "CourseID";

            temp = load.Select("SELECT * FROM Semester;");
            temp.Columns.Add("FullName", typeof(string), "Name + ' ' + Year");
            comboBox2.DataSource = temp;
            comboBox2.DisplayMember = "FullName";
            comboBox2.ValueMember = "SemesterID";   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DbConnection load = new DbConnection();
            string query = "SELECT CourseOfferingID FROM CourseOffering ORDER BY CourseOfferingID DESC;";
            int newOfferID = Convert.ToInt32(load.Select(query).Rows[0][0]) + 1;
            query = "SELECT * FROM CourseOffering WHERE Semester_SemesterID = " + comboBox2.SelectedValue + " AND Course_CourseID = '" + comboBox1.SelectedValue + "';";
            DataTable temp = load.Select(query);
            if (temp.Rows.Count == 0)
            {
                query = "INSERT INTO CourseOffering VALUES (" + newOfferID + "," + comboBox2.SelectedValue + ",'" + comboBox1.SelectedValue + "')";
                load.Inserts(query);
                MessageBox.Show("Offering Created!");
            }
            else
            {
                MessageBox.Show("Offering Already Exists!");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
