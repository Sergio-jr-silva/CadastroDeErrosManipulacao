using System;
using System.Windows.Forms;
using static Mysqlx.Expect.Open.Types.Condition.Types;

namespace CadastroDeErros
{
    public partial class Login : Form
    {
        public string UsuarioLogado { get; private set; } // Adicionando a propriedade

        public Login()
        {
            InitializeComponent();

            // Adicionar evento para capturar tecla Enter
            this.KeyPreview = true; // Habilitar o KeyDown para o formulário inteiro
            this.KeyDown += Login_KeyDown;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((usuario.Text == "sergio@26674" && senha.Text == "26674") ||
                (usuario.Text == "morais@25651" && senha.Text == "25651"))
            {
                UsuarioLogado = "Comum"; // Define o tipo de usuário logado
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else if (usuario.Text == "denise" && senha.Text == "denise")
            {
                UsuarioLogado = "Supervisor"; // Define o tipo de usuário logado
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuário ou senha incorretos!");
                usuario.Clear();
                senha.Clear();
                usuario.Focus();
            }
        }

     

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Simula o comportamento da tecla Tab
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
                e.Handled = true; // Impede que o Enter faça outra ação
            }
        }
    }
}
