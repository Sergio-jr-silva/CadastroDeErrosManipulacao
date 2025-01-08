using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CadastroDeErros
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            if (
                login.Text == "sergio@26674" && senha.Text == "26674" ||
                login.Text == "morais@25651" && senha.Text == "25651" 
                )
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else { 
                MessageBox.Show("Usuario ou senha incorretos!");
                login.Clear();
                senha.Clear();

                login.Focus();
            
            }
        }
    }
}
