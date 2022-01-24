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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();

            userNameField.Text = "Ex: Munte";
            userNameField.ForeColor = Color.Gray;
            userSurnameField.Text = "Ex: Andrei";
            userSurnameField.ForeColor = Color.Gray;

        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void userNameField_Enter(object sender, EventArgs e)
        {
            if (userNameField.Text == "Ex: Munte")
            {
                userNameField.Text = "";
                userNameField.ForeColor = Color.Black;

            }
        }

        private void userNameField_Leave(object sender, EventArgs e)
        {
            if (userNameField.Text == "")
            {
                userNameField.Text = "Ex: Munte";
                userNameField.ForeColor = Color.Gray;
            }
                
        }

        private void userSurnameField_Enter(object sender, EventArgs e)
        {
            if (userSurnameField.Text == "Ex: Andrei")
            {
                userSurnameField.Text = "";
                userSurnameField.ForeColor = Color.Black;

            }
        }

        private void userSurnameField_Leave(object sender, EventArgs e)
        {
            if (userSurnameField.Text == "")
            {
                userSurnameField.Text = "Ex: Andrei";
                userSurnameField.ForeColor = Color.Gray;
            }
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            if (userNameField.Text == "Ex: Munte")
            {
                MessageBox.Show("Introdu numele:");
                return;
            }

            if (userSurnameField.Text == "Ex: Andrei")
            {
                MessageBox.Show("Introdu prenumele:");
                return;
            }

            if (loginField.Text == "")
            {
                MessageBox.Show("Introdu login-ul:");
                return;
            }

            if (passField.Text == "")
            {
                MessageBox.Show("Introdu parola:");
                return;
            }

            if (isUserExists())
            return;

            DB db = new DB();

            MySqlCommand command = new MySqlCommand("INSERT INTO `users` ( `login`, `pass`, `name`, `surname`) VALUES(@login, @pass, @name, @surname)",db.GetConnection());
            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = loginField.Text;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = passField.Text;
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = userNameField.Text;
            command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = userSurnameField.Text;

            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Contul a fost creat!");
                this.Hide();
                Login loginForm = new Login();
                loginForm.Show();
            }
            else
                MessageBox.Show("Contul nu a fost creat!");
            db.closeConnection();
        }

        public Boolean isUserExists()
        {

            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @uL", db.GetConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginField.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Acest login deja exista, alegeti altul");
                return true;
            }

            else
                return false;
        }

        private void Register_Load(object sender, EventArgs e)
        {
        }

        private void registerLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login loginForm = new Login();
            loginForm.Show();
        }
    }
}
