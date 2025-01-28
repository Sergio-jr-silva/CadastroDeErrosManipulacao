using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CadastroDeErros.Supervisor
{
    public partial class editar : Form
    {
        private int ErrorId;
        private string ConnectionString = "Server=localhost;Database=ControleErros;Uid=root;Pwd=3477;";

        public editar(int errorId)
        {
            InitializeComponent();
            ErrorId = errorId;
            LoadProducts();
            LoadErrorDetails();
            LoadEmpresas();
        }

        private void LoadProducts()
        {
            try
            {
                string query = "SELECT IdProdutos, Descricao FROM Produtos";

                using (MySqlConnection connection = new MySqlConnection(ConnectionString))
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        var produtos = new DataTable();
                        produtos.Load(reader);

                        if (produtos.Rows.Count > 0)
                        {
                            cmbProduto.DataSource = produtos;
                            cmbProduto.DisplayMember = "Descricao"; // Nome a ser exibido
                            cmbProduto.ValueMember = "IdProdutos"; // Valor associado
                            cmbProduto.SelectedIndex = -1; // Nenhum item selecionado por padrão
                        }
                        else
                        {
                            MessageBox.Show("Nenhum produto encontrado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar produtos: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LoadEmpresas()
        {
            try
            {
                // Consulta SQL para carregar todas as empresas
                string query = "SELECT EmpresaId, NomeEmpresa FROM Empresas";

                using (MySqlConnection connection = new MySqlConnection(ConnectionString))
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    connection.Open();

                    // Executa a consulta e carrega os resultados
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        var empresas = new DataTable();
                        empresas.Load(reader);

                        if (empresas.Rows.Count > 0)
                        {
                            cmbEmpresa.DataSource = empresas;
                            cmbEmpresa.DisplayMember = "NomeEmpresa"; // Nome a ser exibido
                            cmbEmpresa.ValueMember = "EmpresaId";    // Valor associado
                            cmbEmpresa.SelectedIndex = -1;   // Nenhuma empresa selecionada por padrão
                        }
                        else
                        {
                            cmbEmpresa.DataSource = null; // Limpa o combo box se não houver empresas
                            MessageBox.Show("Nenhuma empresa encontrada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar empresas: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void LoadErrorDetails()
        {
            try
            {
                string query = "SELECT IdProdutos, EmpresaId, Descricao, DataCadastro FROM Erros WHERE Id = @Id";

                using (MySqlConnection connection = new MySqlConnection(ConnectionString))
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", ErrorId);
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Define o valor de 'IdProdutos' e verifica se ele existe no DataSource do ComboBox
                            string idProduto = reader["IdProdutos"] != DBNull.Value ? reader["IdProdutos"].ToString() : null;
                            if (!string.IsNullOrEmpty(idProduto) && cmbProduto.Items.Cast<DataRowView>().Any(item => item["IdProdutos"].ToString() == idProduto))
                            {
                                cmbProduto.SelectedValue = idProduto;

                            }
                            else
                            {
                                cmbProduto.SelectedIndex = -1; // Nenhuma seleção válida
                            }

                            // Define o valor de 'EmpresaId' e verifica se ele existe no DataSource do ComboBox
                            string idEmpresa = reader["EmpresaId"] != DBNull.Value ? reader["EmpresaId"].ToString() : null;
                            if (!string.IsNullOrEmpty(idEmpresa) && cmbEmpresa.Items.Cast<DataRowView>().Any(item => item["Id"].ToString() == idEmpresa))
                            {
                                cmbEmpresa.SelectedValue = idEmpresa;
                            }
                            else
                            {
                                cmbEmpresa.SelectedIndex = -1; // Nenhuma seleção válida
                            }

                            // Atualiza o campo de descrição
                            txtDescricao.Text = reader["Descricao"]?.ToString() ?? string.Empty;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar os detalhes do erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void cmbProduto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProduto.SelectedValue != null)
            {
                string selectedProductId = cmbProduto.SelectedValue.ToString();

            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            
        }

        private void btnsalvar_Click(object sender, EventArgs e)
        {
            try
            {
                string query = @"
    UPDATE Erros 
    SET 
        IdProdutos = @IdProdutos, 
        EmpresaId = @EmpresaId, 
        Descricao = @Descricao, 
        DataCadastro = @DataCadastro 
    WHERE 
        Id = @Id";

                using (MySqlConnection connection = new MySqlConnection(ConnectionString))
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    // Obtém os nomes diretamente dos ComboBoxes
                    string IdProduto = cmbProduto.Text; // Obtém o texto selecionado no ComboBox
                    string empresaNome = cmbEmpresa.Text; // Obtém o texto selecionado no ComboBox

                    command.Parameters.AddWithValue("@IdProdutos", IdProduto);
                    command.Parameters.AddWithValue("@EmpresaId", empresaNome);
                    command.Parameters.AddWithValue("@Descricao", txtDescricao.Text ?? string.Empty);
                    command.Parameters.AddWithValue("@DataCadastro", DateTime.Now); // Atualiza com a data atual
                    command.Parameters.AddWithValue("@Id", ErrorId);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Erro atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao atualizar os dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar os dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
