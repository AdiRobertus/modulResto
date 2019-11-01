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
    public partial class frmCashierNav : Form
    {
        public frmCashierNav()
        {
            InitializeComponent();
        }

        DBLKSN2018DataContext db = new DBLKSN2018DataContext();
        frmChangePassword changepassword = new frmChangePassword();

        private void button5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Form1 frm = new Form1();
                this.Close();
                frm.Show();
            }
        }

        private void frmCashierNav_Load(object sender, EventArgs e)
        {
            MsEmployee employee = db.MsEmployees.Where(x => x.Id.Equals(Support.employeeid)).FirstOrDefault();
            lblname.Text = $"Welcome, {employee.Name}";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (changepassword.IsDisposed) changepassword = new frmChangePassword();
            changepassword.Show();
            changepassword.Owner = this;
        }
    }
}
