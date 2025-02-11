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
        private readonly string connectionString = "Server=junction.proxy.rlwy.net;Port=19537;Database=railway;User Id=root;Password=AQmzEpJAXIqpYUogVjawuxNxKQOPBAxc;SslMode=Required;";

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
                string connectionString = "Server=junction.proxy.rlwy.net;Port=19537;Database=railway;User Id=root;Password=AQmzEpJAXIqpYUogVjawuxNxKQOPBAxc;SslMode=Required;";
                string query = "SELECT IdProdutos, DESCRICAO, IdManipuladores, DataCadastro, cor, TipoErroId, Valor FROM Erros";

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
                XTextFormatter tf = new XTextFormatter(gfx);

                XFont headerFont = new XFont("Arial", 12);
                XFont dataFont = new XFont("Arial", 10);
                XBrush textBrush = XBrushes.Black;

                double margin = 20;
                double startX = margin;
                double startY = margin ;
                double rowHeight = 25;
                double pageWidth = page.Width - 2 * margin;
                double columnWidth = pageWidth / 7;

                string[] headers = { "Produto", "Cor", "Descrição", "Colaborador", "Valor", "Tipo Erro", "Data do Registro" };

                // Desenhando cabeçalho
                for (int i = 0; i < headers.Length; i++)
                {
                    XRect headerRect = new XRect(startX + (i * columnWidth), startY, columnWidth, rowHeight);
                    gfx.DrawRectangle(XBrushes.LightGray, headerRect);
                    tf.Alignment = XParagraphAlignment.Center;
                    tf.DrawString(headers[i], headerFont, textBrush, headerRect);
                }

                startY += rowHeight;

                // Desenhando dados
                foreach (DataRow row in dataTable.Rows)
                {
                    for (int i = 0; i < headers.Length; i++)
                    {
                        XRect cellRect = new XRect(startX + (i * columnWidth), startY, columnWidth, rowHeight);
                        gfx.DrawRectangle(XPens.Black, cellRect);
                    }

                    tf.Alignment = XParagraphAlignment.Center; // Mantendo tudo centralizado

                    tf.DrawString(row["IdProdutos"].ToString(), dataFont, textBrush,
                        new XRect(startX, startY + 3, columnWidth, rowHeight));

                    tf.DrawString(row["cor"].ToString(), dataFont, textBrush,
                        new XRect(startX + columnWidth, startY + 5, columnWidth, rowHeight));

                    tf.DrawString(row["DESCRICAO"].ToString(), dataFont, textBrush,
                        new XRect(startX + columnWidth * 2, startY + 5, columnWidth, rowHeight));

                    tf.DrawString(row["IdManipuladores"].ToString(), dataFont, textBrush,
                        new XRect(startX + columnWidth * 3, startY + 5, columnWidth, rowHeight));

                    tf.DrawString(row["Valor"].ToString(), dataFont, textBrush,
                        new XRect(startX + columnWidth * 4, startY + 5, columnWidth, rowHeight));

                    tf.DrawString(row["TipoErroId"].ToString(), dataFont, textBrush,
                        new XRect(startX + columnWidth * 5, startY + 5, columnWidth, rowHeight));

                    tf.DrawString(Convert.ToDateTime(row["DataCadastro"]).ToString("dd/MM/yyyy"), dataFont, textBrush,
                        new XRect(startX + columnWidth * 6, startY + 5, columnWidth, rowHeight));

                    startY += rowHeight;

                    if (startY > page.Height - 50)
                    {
                        page = document.AddPage();
                        page.Orientation = PdfSharp.PageOrientation.Landscape;
                        gfx = XGraphics.FromPdfPage(page);
                        tf = new XTextFormatter(gfx);
                        startY = margin + 40;
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
