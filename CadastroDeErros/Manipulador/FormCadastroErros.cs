using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace CadastroDeErros
{
    public partial class FormCadastroErros : Form
    {
        private readonly string connectionString = "Server=junction.proxy.rlwy.net;Port=19537;Database=railway;User Id=root;Password=AQmzEpJAXIqpYUogVjawuxNxKQOPBAxc;SslMode=Required;";

        public FormCadastroErros()
        {
            InitializeComponent();
        }

        private void ResetarFormulario()
        {
            cmbManipulador.SelectedIndex = -1;
            Fornecedor.SelectedIndex = -1;
            Produto.SelectedIndex = -1;
            TipoErro.SelectedIndex = -1;
            DescErro.Text = string.Empty;
            quantidade.Text = string.Empty;
            valor.Text = string.Empty;
            cor.Text = string.Empty;
            DataCadastro.Value = DateTime.Now;
            Produto.Items.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CarregarManipuladores();
            CarregarFornecedor();
            CarregarTipoErro();
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
            string query = "SELECT EmpresaId, NomeEmpresa FROM Empresas;";

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

        private void CarregarProdutos(string empresaId)
        {
            string query = "SELECT IdProdutos, DESCRICAO FROM Produtos WHERE EmpresaId = @EmpresaId;";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@EmpresaId", empresaId);

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
                                     out string tipoErro, out string descErro, out DateTime dataCadastro, out decimal valor, out int quantidade, out string cor))
                {
                    return;
                }

                InserirErro(manipulador, fornecedor, produto, tipoErro, descErro, dataCadastro, valor, quantidade, cor);

                MessageBox.Show("Registro inserido com sucesso!");
                ResetarFormulario();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao inserir dados: {ex.Message}");
            }
        }

        private bool ValidarEntradas(out string manipulador, out string fornecedor, out string produto,
                              out string tipoErro, out string descErro, out DateTime dataCadastro,
                              out decimal Valor, out int Quantidade, out string Cor)
        {
            // Inicializa os parâmetros out com valores padrão
            manipulador = null;
            fornecedor = null;
            produto = null;
            tipoErro = null;
            descErro = null;
            dataCadastro = DateTime.MinValue;
            Valor = 0;
            Quantidade = 0;
            Cor = null;

            try
            {
                // Atribui valores aos parâmetros
                manipulador = cmbManipulador.SelectedItem is ComboBoxManipulador selectedManipulador
                    ? selectedManipulador.nome
                    : null;

                fornecedor = Fornecedor.SelectedItem is ComboBoxFornecedor selectedFornecedor
                    ? selectedFornecedor.nome
                    : null;

                produto = Produto.SelectedItem is ComboBoxProdutos selectedProduto
                    ? selectedProduto.descricao
                    : null;

                tipoErro = TipoErro.SelectedItem is ComboBoxTipoErro selectedTipoErro
                    ? selectedTipoErro.descricao
                    : null;

                descErro = !string.IsNullOrWhiteSpace(DescErro.Text) ? DescErro.Text : null;

                dataCadastro = DataCadastro.Value;

                Cor = !string.IsNullOrWhiteSpace(cor.Text) ? cor.Text : null;

                // Validação e conversão segura de Valor
                if (!decimal.TryParse(valor.Text, out Valor))
                {
                    Valor = 0; // Define um valor padrão
                }

                // Validação e conversão segura de Quantidade
                if (!int.TryParse(quantidade.Text, out Quantidade))
                {
                    Quantidade = 0; // Define um valor padrão
                }

                // Verifica se algum campo obrigatório está vazio
                if (string.IsNullOrEmpty(manipulador) || string.IsNullOrEmpty(fornecedor) ||
                    string.IsNullOrEmpty(produto) || string.IsNullOrEmpty(tipoErro) ||
                    string.IsNullOrEmpty(descErro))
                {
                    return false; // Retorna falso se algum campo obrigatório estiver inválido
                }

                return true; // Retorna verdadeiro se todas as validações passarem
            }
            catch (Exception ex)
            {
                // Log ou tratamento de erro (se necessário)
                Console.WriteLine($"Erro ao validar entradas: {ex.Message}");
                return false; // Retorna falso em caso de exceção
            }
        }


        private void InserirErro(string manipulador, string fornecedor, string produto,
                                  string tipoErro, string descErro, DateTime dataCadastro,
                                  decimal valor, int quantidade, string cor)
        {
            string query = @"
                INSERT INTO Erros (IdManipuladores, IdProdutos, EmpresaId, TipoErroId, DESCRICAO, DataCadastro, Quantidade, Valor, cor) 
                VALUES (@NomeManipulador, @NomeProduto, @NomeFornecedor, @DescricaoTipoErro, @DESCRICAO, @DataCadastro, @Quantidade, @Valor, @cor);";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@NomeManipulador", manipulador);
                    cmd.Parameters.AddWithValue("@NomeProduto", produto);
                    cmd.Parameters.AddWithValue("@NomeFornecedor", fornecedor);
                    cmd.Parameters.AddWithValue("@DescricaoTipoErro", tipoErro);
                    cmd.Parameters.AddWithValue("@DESCRICAO", descErro);
                    cmd.Parameters.AddWithValue("@DataCadastro", dataCadastro);
                    cmd.Parameters.AddWithValue("@Quantidade", quantidade);
                    cmd.Parameters.AddWithValue("@Valor", valor);
                    cmd.Parameters.AddWithValue("@cor", cor);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void DescErro_TextChanged(object sender, EventArgs e)
        {

        }

        private void Produto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cor_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbManipulador_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void TipoErro_SelectedIndexChanged(object sender, EventArgs e)
        {

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
