using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Employee_Management_System
{
    public partial class AddEmployee : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=Employee_manager; Integrated Security=true");
        public AddEmployee()
        {
            InitializeComponent();
        }

        private void btnEmp_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_addEmployees", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Employee_Name", SqlDbType.VarChar).Value = txtEmpName.Text;
            cmd.Parameters.Add("@Employee_Number", SqlDbType.VarChar).Value = txtEmpNo.Text;
            cmd.Parameters.Add("@Contact", SqlDbType.VarChar).Value = txtDept.Text;
            cmd.Parameters.Add("@Salary", SqlDbType.VarChar).Value = txtEmpSal.Text;
            cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = txtEmpEmail.Text;
            cmd.Parameters.Add("@Addresss", SqlDbType.VarChar).Value = txtEmpAddress.Text;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Employee Details Added");
            con.Close();
            txtEmpName.Text = "";
            txtEmpNo.Text = "";
            txtDept.Text = "";
            txtEmpSal.Text = "";
            txtEmpEmail.Text = "";
            txtEmpAddress.Text = "";
        }
    }
}
