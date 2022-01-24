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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            CatalogForm catalogForm = new CatalogForm();
            catalogForm.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void ModButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            ModForm modForm = new ModForm();
            modForm.Show();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            DeleteForm deleteForm = new DeleteForm();
            deleteForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
