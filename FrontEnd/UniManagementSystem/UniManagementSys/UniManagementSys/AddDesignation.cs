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
    public partial class AddDesignation : Form
    {
        public AddDesignation()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {     
            if (textBox1.Text == "")
            {
                MessageBox.Show("Fields are empty. Please re-enter!");
                return;
            }
            DbConnection add = new DbConnection();
            int num = Convert.ToInt32(add.Select("SELECT DesignationID from Designation ORDER BY DesignationID DESC;").Rows[0][0]) + 1;
            //Check if Designation already exists
            string query = "SELECT * FROM Designation WHERE [PositionTitle] = '" + textBox1.Text + "';";
            DataTable temp = add.Select(query);
            if (temp.Rows.Count != 0)
            {
                MessageBox.Show("Position already exists. Please reenter!");
                return;
            }
            //Proceed adding position
            query = "INSERT INTO Designation VALUES(" + num + ",'" + textBox1.Text + "')";
            add.Inserts(query);
            MessageBox.Show("Designation added!");
            this.Close();
        }
    }
}
