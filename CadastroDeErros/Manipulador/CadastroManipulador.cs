using System;
using System.Windows.Forms;
using iText.StyledXmlParser.Jsoup.Nodes;
using MySql.Data.MySqlClient;

namespace CadastroDeErros
{
    public partial class CadastroManipulador : Form
    {
        public CadastroManipulador()
        {
            InitializeComponent();
        }

        // Evento do botão cadastrar
        private void cadastrar_Click(object sender, EventArgs e)
        {
            // Obtém os valores dos campos de entrada
            string matricula = Matricula.Text.Trim();
            string nome = Manipulador.Text.Trim();

            // Verifica se os campos estão preenchidos
            if (string.IsNullOrWhiteSpace(matricula) || string.IsNullOrWhiteSpace(nome))
            {
                MessageBox.Show("Por favor, preencha todos os campos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Chama o método de cadastro
            Cadastro(matricula, nome);
        }

        // Método para cadastrar o manipulador no banco de dados
        public void Cadastro(string matricula, string nome)
        {
            try
            {
                // String de conexão com o banco de dados
          string connectionString = "Server=junction.proxy.rlwy.net;Port=19537;Database=railway;User Id=root;Password=AQmzEpJAXIqpYUogVjawuxNxKQOPBAxc;SslMode=Required;";

        string query = @"INSERT INTO Manipuladores (matricula, nome) VALUES (@matricula, @nome)";

                // Conexão com o banco de dados
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Comando para executar a inserção
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@matricula", matricula);
                        cmd.Parameters.AddWithValue("@nome", nome);

                        cmd.ExecuteNonQuery(); // Executa o comando SQL
                        MessageBox.Show("Manipulador cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
            catch (MySqlException ex)
            {
                // Trata erros relacionados ao MySQL
                MessageBox.Show($"Erro ao conectar ao banco de dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Trata outros tipos de erros
                MessageBox.Show($"Ocorreu um erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
