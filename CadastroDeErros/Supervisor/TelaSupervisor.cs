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
        private const string ConnectionString = "Server=localhost;Database=ControleErros;User Id=root;Password=3477;";

        public TelaSupervisor()
        {
            InitializeComponent();
        }

        private void TelaSupervisor_Load(object sender, EventArgs e)
        {
            // Inicialização ao carregar a tela
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "Server=localhost;Database=ControleErros;User Id=root;Password=3477;";
                string query = "SELECT IdProdutos, DESCRICAO, IdManipuladores, DataCadastro, cor FROM ERROS";
                DataTable dataTable = new DataTable();

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

                PdfDocument document = new PdfDocument();
                document.Info.Title = "Relatório de Produtos";
                PdfPage page = document.AddPage();
                page.Orientation = PdfSharp.PageOrientation.Landscape;
                XGraphics gfx = XGraphics.FromPdfPage(page);

                XFont headerFont = new XFont("Arial", 14);
                XFont columnFont = new XFont("Arial", 12);
                XFont dataFont = new XFont("Arial", 10);
                XTextFormatter tf = new XTextFormatter(gfx);

                gfx.DrawString("Relatório de Produtos", headerFont, XBrushes.Black,
                    new XPoint(page.Width / 2 - 50, 40));

                double startX = 20;
                double startY = 80;
                double rowHeight = 30;
                double columnWidth = 150;

                string[] headers = { "Produto", "Cor", "Erro", "Manipulador", "Data do Registro" };
                for (int i = 0; i < headers.Length; i++)
                {
                    gfx.DrawRectangle(XPens.Black, XBrushes.LightGray, startX + (i * columnWidth), startY, columnWidth, rowHeight);
                    gfx.DrawString(headers[i], columnFont, XBrushes.Black, new XPoint(startX + (i * columnWidth) + 10, startY + 20));
                }

                startY += rowHeight;

                foreach (DataRow row in dataTable.Rows)
                {
                    for (int i = 0; i < headers.Length; i++)
                    {
                        gfx.DrawRectangle(XPens.Black, startX + (i * columnWidth), startY, columnWidth, rowHeight);
                    }

                    tf.DrawString(row["IdProdutos"].ToString(), dataFont, XBrushes.Black, new XRect(startX + 10, startY + 5, columnWidth - 20, rowHeight), XStringFormats.TopLeft);
                    tf.DrawString(row["cor"].ToString(), dataFont, XBrushes.Black, new XRect(startX + columnWidth + 10, startY + 5, columnWidth - 20, rowHeight), XStringFormats.TopLeft);
                    tf.DrawString(row["DESCRICAO"].ToString(), dataFont, XBrushes.Black, new XRect(startX + columnWidth * 2 + 10, startY + 5, columnWidth - 20, rowHeight), XStringFormats.TopLeft);
                    tf.DrawString(row["IdManipuladores"].ToString(), dataFont, XBrushes.Black, new XRect(startX + columnWidth * 3 + 10, startY + 5, columnWidth - 20, rowHeight), XStringFormats.TopLeft);
                    tf.DrawString(Convert.ToDateTime(row["DataCadastro"]).ToString("dd/MM/yyyy"), dataFont, XBrushes.Black, new XRect(startX + columnWidth * 4 + 10, startY + 5, columnWidth - 20, rowHeight), XStringFormats.TopLeft);

                    startY += rowHeight;

                    if (startY > page.Height - 50)
                    {
                        page = document.AddPage();
                        page.Orientation = PdfSharp.PageOrientation.Landscape;
                        gfx = XGraphics.FromPdfPage(page);
                        tf = new XTextFormatter(gfx);
                        startY = 40;
                    }
                }

                string filename = "RelatorioProdutos.pdf";
                document.Save(filename);
                Process.Start(new ProcessStartInfo { FileName = filename, UseShellExecute = true });
                MessageBox.Show("Relatório PDF gerado com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            using (var cadastroManipulador = new CadastroManipulador())
            {
                cadastroManipulador.ShowDialog();
            }
        }

        

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            using (var GerenciarErros = new GerenciamentoErros()) { 
            
                GerenciarErros.ShowDialog();

                }
           
        }


        private void pictureBox5_Click(object sender, EventArgs e)
        {
            using (var monitorar = new Monitorar())
            {
                monitorar.ShowDialog();
            }
        }
    }
}
