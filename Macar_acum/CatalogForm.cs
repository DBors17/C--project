using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Macar_acum
{
    public partial class CatalogForm : Form
    {
        public CatalogForm()
        {
            InitializeComponent();
        }

        private void AUTENTIFICARE_Click(object sender, EventArgs e)
        {

        }

        private void CatalogForm_Load(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void SalvareButton_Click(object sender, EventArgs e)
        {
            String Name = NameS.Text;
            String Surname = SurnameS.Text;
            String Nr_matricol = NrMS.Text;

            DB db = new DB();

            MySqlCommand command = new MySqlCommand("INSERT INTO `student` ( `nr_matricol`, `nume`, `prenume`) VALUES(@nr_mat, @nume, @prenume)", db.GetConnection());
            command.Parameters.Add("@nume", MySqlDbType.VarChar).Value = NameS.Text;
            command.Parameters.Add("@prenume", MySqlDbType.VarChar).Value = SurnameS.Text;
            command.Parameters.Add("@nr_mat", MySqlDbType.VarChar).Value = NrMS.Text;

            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Studentul a fost salvat!");
                NameS.Text = "";
                SurnameS.Text = "";
                NrMS.Text = "";
            }
            else
                MessageBox.Show("Studentul nu a fost salvat!");
            db.closeConnection();

        }

        private void SalDisButton_Click(object sender, EventArgs e)
        {
            String Denumire = DenumireD.Text;
            String Cod = CodD.Text;
            String Nr_credite = NrCD.Text;

            DB db = new DB();

            MySqlCommand command1 = new MySqlCommand("INSERT INTO `disciplina` ( `cod_disciplina`, `denumire`, `nr_credite`) VALUES(@cd_dis, @den, @nr_cr)", db.GetConnection());
            command1.Parameters.Add("@cd_dis", MySqlDbType.VarChar).Value = CodD.Text;
            command1.Parameters.Add("@den", MySqlDbType.VarChar).Value = DenumireD.Text;
            command1.Parameters.Add("@nr_cr", MySqlDbType.VarChar).Value = NrCD.Text;

            db.openConnection();
            if (command1.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Disciplina a fost salvata!");
                DenumireD.Text = "";
                CodD.Text = "";
                NrCD.Text = "";
            }
            else
                MessageBox.Show("Disciplina nu a fost salvata!");
            db.closeConnection();
        }
    }
}
