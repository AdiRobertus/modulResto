using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LKSN2018
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        DBLKSN2018DataContext db = new DBLKSN2018DataContext();
        string msg = "";

        private void button1_Click(object sender, EventArgs e)
        {
            if (validation())
            {
                string Password = Support.MD5Has(txtpassword.Text);
                MsEmployee employee = db.MsEmployees.Where(x => x.Email.Equals(txtemail.Text) && x.Password.Equals(Password)).FirstOrDefault();

                if (employee != null)
                {
                    MessageBox.Show("Login has successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Support.employeeid = employee.Id;

                    MessageBox.Show($"Welcome! \n {employee.Name}", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    switch (employee.Position)
                    {
                        case "cashier":
                            frmCashierNav cashier = new frmCashierNav();
                            cashier.Show();
                            this.Hide();
                            break;
                        case "chef":
                            frmNavChef chef = new frmNavChef();
                            chef.Show();
                            this.Hide();
                            break;
                        case "admin":
                            frmNavAdmin admin = new frmNavAdmin();
                            admin.Show();
                            this.Hide();
                            break;
                    }
                }
                else
                    MessageBox.Show("Ensure email and password must be existed in database!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show(msg, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// Validasi data
        /// </summary>
        /// <returns></returns>
        bool validation()
        {
            bool result = false;
            if (txtemail.Text == "" || txtpassword.Text == "")
                msg = "Ensure all fie;d must be filled!";
            else result = true;
            return result;
        }
    }
}
