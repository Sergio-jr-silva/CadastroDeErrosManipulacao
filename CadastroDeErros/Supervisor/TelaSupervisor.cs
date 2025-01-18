using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using CadastroDeErros.Supervisor;
using MySql.Data.MySqlClient;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;


namespace CadastroDeErros
{
    public partial class TelaSupervisor : Form
    {
        public TelaSupervisor()
        {
            InitializeComponent();
        }

        private void TelaSupervisor_Load(object sender, EventArgs e)
        {
            // Qualquer inicialização ao carregar a tela
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                // String de conexão com o banco de dados MySQL
                string connectionString = "Server=localhost;Database=ControleErros;User Id=root;Password=3477;";

                // Consulta SQL para buscar os dados
                string query = "SELECT IdProdutos, DESCRICAO, IdManipuladores, DataCadastro FROM ERROS";

                DataTable dataTable = new DataTable();

                // Conecta ao banco de dados e preenche o DataTable
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }

                if (dataTable.Rows.Count == 0)
                {
                    MessageBox.Show("Nenhum dado encontrado para gerar o relatório.");
                    return;
                }

                // Cria o documento PDF
                PdfDocument document = new PdfDocument();
                document.Info.Title = "Relatório de Produtos";

                // Adiciona uma página ao documento
                PdfPage page = document.AddPage();
                page.Orientation = PdfSharp.PageOrientation.Landscape; // Define a página como paisagem

                XGraphics gfx = XGraphics.FromPdfPage(page);

                // Configura as fontes
                XFont headerFont = new XFont("Arial", 14);
                XFont columnFont = new XFont("Arial", 14);
                XFont dataFont = new XFont("Arial", 10);

                // Título do relatório
                gfx.DrawString("Relatório de Produtos", headerFont, XBrushes.Black,
                    new XPoint(350, 40));

                // Configuração da tabela
                double startX = 20;
                double startY = 80;
                double rowHeight = 40;
                double columnWidth = 200;

                // Desenhar cabeçalho da tabela
                gfx.DrawRectangle(XPens.Black, startX, startY, columnWidth * 4, rowHeight);
                gfx.DrawString("Código do Produto", columnFont, XBrushes.Black, new XPoint(startX + 5, startY + 15));
                gfx.DrawString("Descrição", columnFont, XBrushes.Black, new XPoint(startX + columnWidth + 5, startY + 15));
                gfx.DrawString("Manipulador", columnFont, XBrushes.Black, new XPoint(startX + columnWidth * 2 + 5, startY + 15));
                gfx.DrawString("Data do Registro", columnFont, XBrushes.Black, new XPoint(startX + columnWidth * 3 + 5, startY + 15));

                // Preencher os dados
                startY += rowHeight;

                foreach (DataRow row in dataTable.Rows)
                {
                    // Desenhar linha da tabela
                    gfx.DrawRectangle(XPens.Black, startX, startY, columnWidth, rowHeight);
                    gfx.DrawRectangle(XPens.Black, startX + columnWidth, startY, columnWidth, rowHeight);
                    gfx.DrawRectangle(XPens.Black, startX + columnWidth * 2, startY, columnWidth, rowHeight);
                    gfx.DrawRectangle(XPens.Black, startX + columnWidth * 3, startY, columnWidth, rowHeight);

                    // Preencher dados
                    gfx.DrawString(row["IdProdutos"].ToString(), dataFont, XBrushes.Black, new XPoint(startX + 5, startY + 15));
                    gfx.DrawString(row["DESCRICAO"].ToString(), dataFont, XBrushes.Black, new XPoint(startX + columnWidth + 5, startY + 15));
                    gfx.DrawString(row["idManipuladores"].ToString(), dataFont, XBrushes.Black, new XPoint(startX + columnWidth * 2 + 5, startY + 15));
                    gfx.DrawString(Convert.ToDateTime(row["DataCadastro"]).ToString("dd/MM/yyyy"), dataFont, XBrushes.Black, new XPoint(startX + columnWidth * 3 + 5, startY + 15));

                    startY += rowHeight;

                    // Adicionar nova página se necessário
                    if (startY > page.Height - 40)
                    {
                        page = document.AddPage();
                        page.Orientation = PdfSharp.PageOrientation.Landscape;
                        gfx = XGraphics.FromPdfPage(page);
                        startY = 40;
                    }
                }

                // Salva o arquivo PDF
                string filename = "RelatorioProdutos.pdf";
                document.Save(filename);

                // Abre o PDF no visualizador padrão
                Process.Start(new ProcessStartInfo
                {
                    FileName = filename,
                    UseShellExecute = true
                });

                MessageBox.Show("Relatório PDF gerado com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            using (var CadastroManipulador = new CadastroManipulador())
            {
                var resultado = CadastroManipulador.ShowDialog();


            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            using (var GerenciamentoErros = new GerenciamentoErros())
                {
                var resultado = GerenciamentoErros.ShowDialog();
            }
        }
    }
}