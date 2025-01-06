global using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace CadastroDeErros
{
    public partial class Form1 : Form
    {
        private readonly string connectionString = "server=localhost;port=3306;database=ControleErros;user=root;password=3477;";

        public Form1()
        {
            InitializeComponent();
        }

        private void ResetarFormulario()
        {
            // Limpa os campos de seleção
            cmbManipulador.SelectedIndex = -1;
            Fornecedor.SelectedIndex = -1;
            Produto.SelectedIndex = -1;
            TipoErro.SelectedIndex = -1;

            // Limpa o campo de descrição do erro
            DescErro.Text = string.Empty;

            // Redefine a data de cadastro para a data atual
            DataCadastro.Value = DateTime.Now;

            // Remove os itens carregados nas listas (opcional, se necessário recarregar do banco)
            Produto.Items.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CarregarManipuladores();
            CarregarFornecedor();
            CarregarTipoErro();

            // Adiciona o evento para quando o fornecedor for alterado
            Fornecedor.SelectedIndexChanged += Fornecedor_SelectedIndexChanged;
        }

        private void CarregarManipuladores()
        {
            string query = "SELECT IdManipuladores, Nome, Matricula FROM Manipuladores;";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        cmbManipulador.Items.Clear();

                        while (reader.Read())
                        {
                            cmbManipulador.Items.Add(new ComboBoxManipulador(
                                reader["Nome"].ToString(),
                                reader["IdManipuladores"].ToString(),
                                reader["Matricula"].ToString()
                            ));
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao carregar manipuladores: {ex.Message}");
                }
            }
        }

        private void CarregarFornecedor()
        {
            string query = "SELECT EmpresaId, NomeEmpresa FROM EMPRESAS;";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        Fornecedor.Items.Clear();

                        while (reader.Read())
                        {
                            Fornecedor.Items.Add(new ComboBoxFornecedor(
                                reader["NomeEmpresa"].ToString(),
                                reader["EmpresaId"].ToString()
                            ));
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao carregar fornecedores: {ex.Message}");
                }
            }
        }

        private void CarregarTipoErro()
        {
            string query = "SELECT IdTipoErro, Descricao FROM TipoErro;";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        TipoErro.Items.Clear();

                        while (reader.Read())
                        {
                            TipoErro.Items.Add(new ComboBoxTipoErro(
                                reader["Descricao"].ToString(),
                                reader["IdTipoErro"].ToString()
                            ));
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao carregar tipos de erro: {ex.Message}");
                }
            }
        }

        private void CarregarProdutos(string EmpresaId)
        {
            string query = "SELECT IdProdutos, DESCRICAO FROM PRODUTOS WHERE EmpresaId = @EmpresaId;";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@EmpresaId", EmpresaId);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            Produto.Items.Clear();

                            while (reader.Read())
                            {
                                Produto.Items.Add(new ComboBoxProdutos(
                                    reader["DESCRICAO"].ToString(),
                                    reader["IdProdutos"].ToString()
                                ));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao carregar produtos: {ex.Message}");
                }
            }
        }

        private void Fornecedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Fornecedor.SelectedItem is ComboBoxFornecedor selectedFornecedor)
            {
                CarregarProdutos(selectedFornecedor.EmpresaId);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarEntradas(out string manipulador, out string fornecedor, out string produto,
                                     out string tipoErro, out string descErro, out DateTime dataCadastro))
                {
                    return;
                }

                InserirErro(manipulador, fornecedor, produto, tipoErro, descErro, dataCadastro);

                MessageBox.Show("Registro inserido com sucesso!");
                ResetarFormulario();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao inserir dados: {ex.Message}");
            }
        }

        private bool ValidarEntradas(out string manipulador, out string fornecedor, out string produto,
                                out string tipoErro, out string descErro, out DateTime dataCadastro)
        {
            manipulador = cmbManipulador.SelectedItem is ComboBoxManipulador selectedManipulador
                ? selectedManipulador.nome // Agora pega o nome
                : null;

            fornecedor = Fornecedor.SelectedItem is ComboBoxFornecedor selectedFornecedor
                ? selectedFornecedor.nome // Agora pega o nome
                : null;

            produto = Produto.SelectedItem is ComboBoxProdutos selectedProduto
                ? selectedProduto.descricao // Agora pega o nome
                : null;

            tipoErro = TipoErro.SelectedItem is ComboBoxTipoErro selectedTipoErro
                ? selectedTipoErro.descricao 
                : null;

            descErro = DescErro.Text;
            dataCadastro = DataCadastro.Value;

            if (string.IsNullOrWhiteSpace(manipulador) || string.IsNullOrWhiteSpace(fornecedor) ||
                string.IsNullOrWhiteSpace(produto) || string.IsNullOrWhiteSpace(tipoErro) ||
                string.IsNullOrWhiteSpace(descErro))
            {
                MessageBox.Show("Todos os campos devem ser preenchidos!");
                return false;
            }

            if (dataCadastro > DateTime.Now)
            {
                MessageBox.Show("A data de cadastro não pode ser no futuro!");
                return false;
            }

            return true;
        }





        private void InserirErro(string manipulador, string fornecedor, string produto,
                          string tipoErro, string descErro, DateTime dataCadastro)
        {
            string query = @"
        INSERT INTO ERROS (IdManipuladores, IdProdutos, EmpresaId, TipoErroId, DESCRICAO, DataCadastro) 
        VALUES (@NomeManipulador, @NomeProduto, @NomeFornecedor, @DescricaoTipoErro, @DESCRICAO, @DataCadastro);";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@NomeManipulador", manipulador); // Nome do manipulador
                    cmd.Parameters.AddWithValue("@NomeProduto", produto);        // Nome do produto
                    cmd.Parameters.AddWithValue("@NomeFornecedor", fornecedor);  // Nome da empresa
                    cmd.Parameters.AddWithValue("@DescricaoTipoErro", tipoErro); // Descrição do tipo de erro
                    cmd.Parameters.AddWithValue("@DESCRICAO", descErro);
                    cmd.Parameters.AddWithValue("@DataCadastro", dataCadastro);

                    cmd.ExecuteNonQuery();
                }
            }
        }

    }

    public class ComboBoxManipulador
    {
        public string nome { get; set; }
        public string id { get; set; }
        public string matricula { get; set; }

        public ComboBoxManipulador(string text, string value, string mat)
        {
            nome = text;
            id = value;
            matricula = mat;
        }

        public override string ToString()
        {
            return matricula + " - " + nome;
        }
    }

    public class ComboBoxFornecedor
    {
        public string nome { get; set; }
        public string EmpresaId { get; set; }

        public ComboBoxFornecedor(string text, string value)
        {
            nome = text;
            EmpresaId = value;
        }

        public override string ToString()
        {
            return nome;
        }
    }

    public class ComboBoxTipoErro
    {
        public string descricao { get; set; }
        public string TipoErroId { get; set; }

        public ComboBoxTipoErro(string text, string value)
        {
            descricao = text;
            TipoErroId = value;
        }

        public override string ToString()
        {
            return descricao;
        }
    }

    public class ComboBoxProdutos
    {
        public string descricao { get; set; }
        public string IdProdutos { get; set; }

        public ComboBoxProdutos(string d, string id)
        {
            descricao = d;
            IdProdutos = id;
        }

        public override string ToString()
        {
            return descricao;
        }
 
    }


}


