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
    public partial class AddDepartment : Form
    {
        public AddDepartment()
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
            int num = Convert.ToInt32(add.Select("SELECT DepartmentID from Department ORDER BY DepartmentID DESC;").Rows[0][0]) + 1;
            //Check if Designation already exists
            string query = "SELECT * FROM Department WHERE [Name] = '" + textBox1.Text + "';";
            DataTable temp = add.Select(query);
            if (temp.Rows.Count != 0)
            {
                MessageBox.Show("A similar department already exists. Please rename!");
                return;
            }
            //Proceed adding department
            query = "INSERT INTO Department VALUES(" + num + ",'" + textBox1.Text + "','"+ textBox2.Text +"')";
            add.Inserts(query);
            MessageBox.Show("Department added!");
            this.Close();
        }

        private void AddDepartment_Load(object sender, EventArgs e)
        {

        }
    }
}
