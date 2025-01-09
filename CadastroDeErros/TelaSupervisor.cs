using System;
using System.Diagnostics;
using System.Windows.Forms;
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
                // Cria um novo documento PDF
                PdfDocument document = new PdfDocument();
                document.Info.Title = "Exemplo Olá Mundo";

                // Adiciona uma página ao documento
                PdfPage page = document.AddPage();

                // Cria um objeto gráfico para a página
                XGraphics gfx = XGraphics.FromPdfPage(page);

                // Define a fonte e o texto
                XFont font = new("Verdana", 20);
                gfx.DrawString("Olá, Mundo!", font, XBrushes.Black,
                    new XRect(0, 0, page.Width, page.Height), XStringFormats.Center);

                // Salva o documento em um arquivo
                string filename = "OlaMundo.pdf";
                document.Save(filename);

                // Abre o PDF no visualizador padrão
                Process.Start(new ProcessStartInfo
                {
                    FileName = filename,
                    UseShellExecute = true
                });

                MessageBox.Show("PDF gerado com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao gerar PDF: {ex.Message}");
            }
        }
    }

    
}