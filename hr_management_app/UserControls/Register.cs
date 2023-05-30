using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hr_management_app.UserControls
{
    public partial class Register : UserControl
    {
        SqlConnection conexiune = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Facultate1052;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        SqlCommand command;
        SqlDataAdapter adapter;

        List<Angajat> angajatList = new List<Angajat>();
        public static Angajat a = new Angajat();
       
        public Register()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            int id = new Random().Next(50);
            string nume = tbNume.Text;
            string prenume = tbPrenume.Text;
            int varsta = Convert.ToInt32(tbVarsta.Text);
            string jobTitle = cbJob.Text;
            string[] nrOreLucrateString = tbOreLucrate.Text.Split(',').ToArray();
            int[] nrOreLucrateInt = new int[nrOreLucrateString.Length];
            for (int i = 0; i < nrOreLucrateString.Length; i++)
            {
                nrOreLucrateInt[i] = Convert.ToInt32(nrOreLucrateString[i]);
            }
            string password = tbPassword.Text;
            string confPass = tbConfirmPassword.Text;
            string username = tbUsername.Text;

            if (tbNume.Text == "" || tbPrenume.Text == "" || tbVarsta.Text == "" || tbPassword.Text == "" || tbConfirmPassword.Text == "" || tbUsername.Text == "" || tbOreLucrate.Text == "") 
            {
                MessageBox.Show("Unul sau mai multe campuri sunt necompletate!");
            }
            else
            {
                Job job = new Job();
                if (jobTitle == "HR")
                {
                    job = new Job(jobTitle, 5000, 40);
                }
                else if (jobTitle == "Programator")
                {
                    job = new Job(jobTitle, 7000, 40);
                }

                angajatList.Add(new Angajat(id, nrOreLucrateInt, job, nume, prenume, varsta, password, confPass, username));
            }

            try
            {
                conexiune.Open();
                command = new SqlCommand("INSERT INTO ANGAJATI(Id, Nume, Prenume, Varsta, NrOreLucrateSaptamanal, Job, Password, Username) VALUES (@id, @nume, @prenume, @varsta, @nrOreLucrateSaptamanal, @job, @password, @username)", conexiune);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@nume", nume);
                command.Parameters.AddWithValue("@prenume", prenume);
                command.Parameters.AddWithValue("@varsta", varsta);
                command.Parameters.AddWithValue("@nrOreLucrateSaptamanal", tbOreLucrate.Text);
                command.Parameters.AddWithValue("@job", cbJob.Text);
                command.Parameters.AddWithValue("@password", password);
                command.Parameters.AddWithValue("@username", username);
                command.ExecuteNonQuery();
                MessageBox.Show("Angajat inregistrat cu succes!");
            } 
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexiune.Close();
                tbNume.Clear();
                tbPrenume.Clear();
                tbVarsta.Clear();
                tbOreLucrate.Clear();
                tbPassword.Clear();
                tbConfirmPassword.Clear();
                tbUsername.Clear();
            }
        }

        private void tbNume_Validating(object sender, CancelEventArgs e)
        {
            if (tbNume.Text == "")
            {
                eroare.SetError(tbNume, "Nu ati introdus numele!");
                tbNume.Focus();
            }
            else if (!Regex.IsMatch(tbNume.Text, "([A-ZAÎ??Â])+(?=.{1,40}$)[a-zA-ZAÎ??Âaî??]+(?:[-\\s][a-zA-ZAÎ??Âaî??â]+)*$"))
            {
                eroare.SetError(tbNume, "Numele trebuie sa inceapa cu litera mare si sa nu contina numere!");
                tbNume.Focus();
            }
            else
            {
                eroare.SetError(tbNume, "");
            }
        }

        private void tbPrenume_Validating(object sender, CancelEventArgs e)
        {
            if (tbPrenume.Text == "")
            {
                eroare.SetError(tbPrenume, "Nu ati introdus prenumele!");
                tbPrenume.Focus();
            }
            else if (!Regex.IsMatch(tbPrenume.Text, "([A-ZAÎ??Â])+(?=.{1,40}$)[a-zA-ZAÎ??Âaî??]+(?:[-\\s][a-zA-ZAÎ??Âaî??â]+)*$"))
            {
                eroare.SetError(tbPrenume, "Prenumele trebuie sa inceapa cu litera mare si sa nu contina numere!");
                tbPrenume.Focus();
            }
            else
            {
                eroare.SetError(tbPrenume, "");
            }
        }

        private void tbPassword_Validating(object sender, CancelEventArgs e)
        {
            if (tbPassword.Text == "")
            {
                eroare.SetError(tbPassword, "Nu ati introdus o parola!");
                tbPassword.Focus();
            }
            else
            {
                eroare.SetError(tbPassword, "");
            }
        }

        private void tbConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (tbPassword.Text != tbConfirmPassword.Text)
            {
                eroare.SetError(tbConfirmPassword, "Parolele nu se potrivesc!");
                tbConfirmPassword.Focus();
            }
            else if (tbConfirmPassword.Text == "")
            {
                eroare.SetError(tbConfirmPassword, "Trebuie sa confirmi parola!");
                tbConfirmPassword.Focus();
            }
            else
            {
                eroare.SetError(tbConfirmPassword, "");
            }

        }

        private void tbUsername_Validating(object sender, CancelEventArgs e)
        {
            if (tbUsername.Text == "")
            {
                eroare.SetError(tbUsername, "Numele de utilizator este necompletat!");
                tbUsername.Focus();
            }
            else
            {
                eroare.SetError(tbUsername, "");
            }
        }

        private void tbPassword_TextChanged(object sender, EventArgs e)
        {
            tbPassword.UseSystemPasswordChar = true;
        }

        private void tbUsername_TextChanged(object sender, EventArgs e)
        {
            tbConfirmPassword.UseSystemPasswordChar = true;
        }
    }
}
