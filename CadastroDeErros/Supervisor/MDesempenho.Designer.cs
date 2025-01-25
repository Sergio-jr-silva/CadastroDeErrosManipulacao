using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CadastroDeErros.Supervisor
{
    public partial class MDesempenho : Form
    {
        public MDesempenho()
        {
            InitializeComponent();
            CarregarDados();
        }

        private void MDesempenho_Load(object sender, EventArgs e)
        {
            ConfigurarGrafico();
        }

        private void ConfigurarGrafico()
        {
            // Configurar o gráfico
            chartErros.Titles.Clear();
            chartErros.Series.Clear();
            chartErros.ChartAreas.Clear();

            chartErros.Titles.Add("Erros por Manipulador");
            chartErros.ChartAreas.Add(new ChartArea("MainArea"));

            var serie = new Series("Erros")
            {
                ChartType = SeriesChartType.Pie,
                IsValueShownAsLabel = true
            };
            chartErros.Series.Add(serie);
        }

        private void CarregarDados()
        {
            // Dados de exemplo
            var dtErros = new DataTable();
            dtErros.Columns.Add("Manipulador", typeof(string));
            dtErros.Columns.Add("Porcentagem", typeof(double));

            dtErros.Rows.Add("Carlos", 40);
            dtErros.Rows.Add("Ana", 30);
            dtErros.Rows.Add("João", 20);
            dtErros.Rows.Add("Marcos", 10);

            // Vincular os dados ao gráfico
        


            // Dados de principais erros
            var dtPrincipaisErros = new DataTable();
            dtPrincipaisErros.Columns.Add("Erro", typeof(string));
            dtPrincipaisErros.Columns.Add("Frequência", typeof(int));

            dtPrincipaisErros.Rows.Add("Erro de manipulação", 25);
            dtPrincipaisErros.Rows.Add("Desistência", 15);

            // Carregar os dados no DataGridView
            dgvPrincipaisErros.DataSource = dtPrincipaisErros;
        }

        private void InitializeComponent()
        {
            this.chartErros = new Chart();
            this.dgvPrincipaisErros = new DataGridView();
            this.labelGrafico = new Label();
            this.labelErros = new Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartErros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrincipaisErros)).BeginInit();
            this.SuspendLayout();
            // 
            // chartErros
            // 
            this.chartErros.Location = new Point(12, 37);
            this.chartErros.Name = "chartErros";
            this.chartErros.Size = new Size(400, 300);
            this.chartErros.TabIndex = 0;
            this.chartErros.Text = "chartErros";
            // 
            // dgvPrincipaisErros
            // 
            this.dgvPrincipaisErros.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrincipaisErros.Location = new Point(430, 37);
            this.dgvPrincipaisErros.Name = "dgvPrincipaisErros";
            this.dgvPrincipaisErros.Size = new Size(300, 300);
            this.dgvPrincipaisErros.TabIndex = 1;
            // 
            // labelGrafico
            // 
            this.labelGrafico.AutoSize = true;
            this.labelGrafico.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            this.labelGrafico.Location = new Point(12, 9);
            this.labelGrafico.Name = "labelGrafico";
            this.labelGrafico.Size = new Size(202, 21);
            this.labelGrafico.TabIndex = 2;
            this.labelGrafico.Text = "Erros por Manipuladores:";
            // 
            // labelErros
            // 
            this.labelErros.AutoSize = true;
            this.labelErros.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            this.labelErros.Location = new Point(430, 9);
            this.labelErros.Name = "labelErros";
            this.labelErros.Size = new Size(131, 21);
            this.labelErros.TabIndex = 3;
            this.labelErros.Text = "Principais Erros:";
            // 
            // MDesempenho
            // 
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(744, 351);
            this.Controls.Add(this.labelErros);
            this.Controls.Add(this.labelGrafico);
            this.Controls.Add(this.dgvPrincipaisErros);
            this.Controls.Add(this.chartErros);
            this.Name = "MDesempenho";
            this.Text = "Monitoramento de Desempenho";
            this.Load += new EventHandler(this.MDesempenho_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartErros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrincipaisErros)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private Chart chartErros;
        private DataGridView dgvPrincipaisErros;
        private Label labelGrafico;
        private Label labelErros;
    }
}
