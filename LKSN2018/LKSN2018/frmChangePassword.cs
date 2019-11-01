using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace LKSN2018
{
    public partial class frmChangePassword : Form
    {
        public frmChangePassword()
        {
            InitializeComponent();
        }

#region Variable
        /// <summary>
        /// Set Variable
        /// </summary>
        DBLKSN2018DataContext db = new DBLKSN2018DataContext();
        string msg = "";
        #endregion

        /// <summary>
        /// event ketika btnsave diklik
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnsave_Click(object sender, EventArgs e)
        {
            if (validation())
            {

                string password = Support.MD5Has(txtoldpassword.Text);

                MsEmployee employee = db.MsEmployees.Where(x => x.Id.Equals(Support.employeeid)).FirstOrDefault();
                employee.Password = password;
                try
                {
                    db.SubmitChanges();
                    MessageBox.Show("Change Password has been success!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show(msg, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            this.Close();
        }

        /// <summary>
        /// Validasi data
        /// </summary>
        /// <returns></returns>
        bool validation()
        {
            string password = Support.MD5Has(txtoldpassword.Text);
            MsEmployee employee = db.MsEmployees.Where(x => x.Id.Equals(Support.employeeid)).FirstOrDefault();
            Regex r1 = new Regex("[A-Z]+[a-z]+[0-9]+");
            Regex r2 = new Regex("[A-Z]+[0-9]+[a-z]+");
            Regex r3 = new Regex("[a-z]+[0-9]+[A-Z]+");
            Regex r4 = new Regex("[a-z]+[A-Z]+[0-9]+");
            Regex r5 = new Regex("[0-9]+[A-Z]+[a-z]+");
            Regex r6 = new Regex("[0-9]+[a-z]+[A-Z]+");


            bool result = false;
            if (!employee.Password.Equals(password))
                msg = "Ensure old password input correctly";
            else if (txtconfirmpassword.Text != txtnewpassword.Text)
                msg = "Ensure confirm password must be same with new password";
            else if (!(r1.IsMatch(txtnewpassword.Text) ||
                      r2.IsMatch(txtnewpassword.Text) ||
                      r3.IsMatch(txtnewpassword.Text) ||
                      r4.IsMatch(txtnewpassword.Text) ||
                      r5.IsMatch(txtnewpassword.Text) ||
                      r6.IsMatch(txtnewpassword.Text)))
                msg = "Ensure new password must contains uppercase, lowercase and number";
            else result = true;
            return result;
        }
    }
}
