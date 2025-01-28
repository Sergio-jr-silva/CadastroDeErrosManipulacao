using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CadastroDeErros.Supervisor
{
    public partial class GerenciamentoErros : Form
    {
        public GerenciamentoErros()
        {
            InitializeComponent();
            LoadErrors();
        }

        private void LoadErrors()
        {
            string connectionString = "Server=localhost;Database=ControleErros;Uid=root;Pwd=3477;";
            string query = "SELECT Id, IdProdutos, EmpresaId, Descricao, DataCadastro FROM Erros";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            using (MySqlCommand command = new MySqlCommand(query, connection))
            using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
            {
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                TbErros.DataSource = dataTable;

                // Renomear as colunas para exibição mais amigável
                TbErros.Columns["IdProdutos"].HeaderText = "Produto";
                TbErros.Columns["EmpresaId"].HeaderText = "Empresa";
                TbErros.Columns["Descricao"].HeaderText = "Descrição";
                TbErros.Columns["DataCadastro"].HeaderText = "Data de Cadastro";

                // Adiciona colunas de botões se ainda não existirem
                if (!TbErros.Columns.Contains("Edit"))
                {
                    var editButton = new DataGridViewButtonColumn
                    {
                        HeaderText = "Editar",
                        Text = "Editar",
                        UseColumnTextForButtonValue = true,
                        Name = "Edit"
                    };
                    TbErros.Columns.Add(editButton);
                }

                if (!TbErros.Columns.Contains("Delete"))
                {
                    var deleteButton = new DataGridViewButtonColumn
                    {
                        HeaderText = "Excluir",
                        Text = "Excluir",
                        UseColumnTextForButtonValue = true,
                        Name = "Delete"
                    };
                    TbErros.Columns.Add(deleteButton);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Ignora cabeçalhos

            if (TbErros.Columns[e.ColumnIndex].Name == "Edit")
            {
                int errorId = Convert.ToInt32(TbErros.Rows[e.RowIndex].Cells["Id"].Value);
                using (editar editForm = new editar(errorId))
                {
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadErrors(); // Recarrega os dados após salvar
                    }
                }
            }
            else if (TbErros.Columns[e.ColumnIndex].Name == "Delete")
            {
                int Id = Convert.ToInt32(TbErros.Rows[e.RowIndex].Cells["Id"].Value);
                DeleteError(Id);
            }
        }


        private void DeleteError(int Id)
        {
            var confirm = MessageBox.Show("Tem certeza de que deseja excluir este erro?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                string connectionString = "Server=localhost;Database=ControleErros;Uid=root;Pwd=3477;";
                string query = "DELETE FROM Erros WHERE Id = @Id";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", Id);
                    connection.Open();
                    command.ExecuteNonQuery();
                }

                LoadErrors(); // Recarrega os dados após exclusão
            }
        }


    }
}
