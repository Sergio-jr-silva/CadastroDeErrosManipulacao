using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CadastroDeErros.Supervisor
{
    public partial class Monitoramento : Form
    {
        public Monitoramento()
        {
            InitializeComponent();
            CarregarDados(); // Carregar dados no gráfico e DataGridView
        }

        private void Monitoramento_Load(object sender, EventArgs e)
        {
            ConfigurarGrafico(); // Configurar propriedades iniciais do gráfico
        }

        private void ConfigurarGrafico()
        {
            // Limpa e configura o gráfico
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
            // Simulação de dados dos manipuladores e suas porcentagens de erro
            var dtErros = new DataTable();
            dtErros.Columns.Add("Manipulador", typeof(string));
            dtErros.Columns.Add("Porcentagem", typeof(double));

            dtErros.Rows.Add("Carlos", 40);
            dtErros.Rows.Add("Ana", 30);
            dtErros.Rows.Add("João", 20);
            dtErros.Rows.Add("Marcos", 10);

            // Carregar dados no gráfico
            chartErros.Series["Erros"].Points.DataBind(dtErros.AsEnumerable(), "Manipulador", "Porcentagem", "");

            // Simulação de dados de principais erros
            var dtPrincipaisErros = new DataTable();
            dtPrincipaisErros.Columns.Add("Erro", typeof(string));
            dtPrincipaisErros.Columns.Add("Frequência", typeof(int));

            dtPrincipaisErros.Rows.Add("Erro de manipulação", 25);
            dtPrincipaisErros.Rows.Add("Desistência", 15);

            // Carregar dados no DataGridView
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
            this.chartErros.Location = new System.Drawing.Point(12, 37);
            this.chartErros.Name = "chartErros";
            this.chartErros.Size = new System.Drawing.Size(400, 300);
            this.chartErros.TabIndex = 0;
            this.chartErros.Text = "chartErros";
            // 
            // dgvPrincipaisErros
            // 
            this.dgvPrincipaisErros.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrincipaisErros.Location = new System.Drawing.Point(430, 37);
            this.dgvPrincipaisErros.Name = "dgvPrincipaisErros";
            this.dgvPrincipaisErros.Size = new System.Drawing.Size(300, 300);
            this.dgvPrincipaisErros.TabIndex = 1;
            // 
            // labelGrafico
            // 
            this.labelGrafico.AutoSize = true;
            this.labelGrafico.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelGrafico.Location = new System.Drawing.Point(12, 9);
            this.labelGrafico.Name = "labelGrafico";
            this.labelGrafico.Size = new System.Drawing.Size(202, 21);
            this.labelGrafico.TabIndex = 2;
            this.labelGrafico.Text = "Erros por Manipuladores:";
            // 
            // labelErros
            // 
            this.labelErros.AutoSize = true;
            this.labelErros.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelErros.Location = new System.Drawing.Point(430, 9);
            this.labelErros.Name = "labelErros";
            this.labelErros.Size = new System.Drawing.Size(131, 21);
            this.labelErros.TabIndex = 3;
            this.labelErros.Text = "Principais Erros:";
            // 
            // Monitoramento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 351);
            this.Controls.Add(this.labelErros);
            this.Controls.Add(this.labelGrafico);
            this.Controls.Add(this.dgvPrincipaisErros);
            this.Controls.Add(this.chartErros);
            this.Name = "Monitoramento";
            this.Text = "Monitoramento de Manipulação de Tintas";
            this.Load += new EventHandler(this.Monitoramento_Load);
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
