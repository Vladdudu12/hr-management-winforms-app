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

namespace hr_management_app.UserControls
{
    public partial class Login : UserControl
    {
        SqlConnection conexiune = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Facultate1052;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        SqlCommand command;
        SqlDataAdapter adapter;
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tbUser.Text == "admin" && tbPass.Text == "admin")
            {
                MessageBox.Show("Bine ati venit!)");
                //Pagina2Log pag2 = new Pagina2Log(0);
                //pag2.Show();
            }
            else
            {
                try
                {
                    conexiune.Open();
                    command.Connection = conexiune;
                    command.CommandText = "SELECT Password FROM Angajati where Username ='" + tbUser.Text + "'";
                    string pass = Convert.ToString(command.ExecuteScalar());
                    if (pass == tbPass.Text && tbUser.Text != "" && tbPass.Text != "")
                    {
                        MessageBox.Show("Bine ati venit!)");
                        command.CommandText = "SELECT Id FROM Angajati where Username ='" + tbUser.Text + "'";
                        int id = Convert.ToInt32(command.ExecuteScalar());
                        //Pagina2Log form2 = new Pagina2Log(id);
                        //form2.ShowDialog();
                    }
                    else if ((tbUser.Text == "" && tbPass.Text == ""))
                    {
                        MessageBox.Show("Username si parola necompletate!");
                    }
                    else { MessageBox.Show("Username sau parole invalid! Incearca din nou!"); }
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
                }
            }

        }
    }
}
