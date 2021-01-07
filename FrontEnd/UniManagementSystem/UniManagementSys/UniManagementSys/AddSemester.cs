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
    public partial class AddSemester : Form
    {
        public AddSemester()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Fields are empty. Please re-enter!");
                return;
            }
            DbConnection add = new DbConnection();
            int num = Convert.ToInt32(add.Select("SELECT SemesterID from Semester ORDER BY SemesterID Desc;").Rows[0][0]) + 1;
            //check if sem already exists
            string query = "SELECT * FROM Semester WHERE Year = " + textBox2.Text + " AND Name = '" + textBox1.Text + "';";
            DataTable temp = add.Select(query);
            if(temp.Rows.Count != 0)
            {
                MessageBox.Show("Semester already exists. Please reenter!");
                return;
            }
            //proceed to add semester
            query = "INSERT INTO Semester VALUES(" + num + ",'" + textBox1.Text + "','" + textBox2.Text + "')";
            add.Inserts(query);
            MessageBox.Show("Semester added!");
        }

        private void AddSemester_Load(object sender, EventArgs e)
        {

        }
    }
}
