using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hr_management_app
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (tbEmail.Text.Length == 0)
            {
                errorProvider1.SetError(tbEmail, "Trebuie introdus un email");
            }

            if (tbParola.Text.Length == 0)
            {
                errorProvider1.SetError(tbParola, "Trebuie introdusa o parola");
            }

            if(tbEmail.Text.Length > 0 && tbParola.Text.Length > 0) 
            {
                //check in database if both are correct
                //redirect to Firma Page
                
            }
        }
    }
}
