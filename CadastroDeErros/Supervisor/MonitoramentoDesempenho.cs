using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MonitoramentoDeDesempenho
{
    public partial class Monitoramento : Form
    {
        public Monitoramento()
        {
            InitializeComponent();
        }

        private void Monitoramento_Load(object sender, EventArgs e)
        {
            ConfigurarGrafico();
            CarregarDados();
        }

        private void ConfigurarGrafico()
        {
            // Limpa e configura o gráfico
            chartErros.Titles.Clear();
            chartErros.Series.Clear();
            chartErros.ChartAreas.Clear();

            chartErros.Titles.Add("Porcentagem de Erros por Manipulador");
            chartErros.ChartAreas.Add(new ChartArea("MainArea"));

            // Adicionar série
            var serie = new Series("Erros")
            {
                ChartType = SeriesChartType.Pie,
                IsValueShownAsLabel = true
            };
            chartErros.Series.Add(serie);
        }

        private void CarregarDados()
        {
            // Dados simulados
            var dtErros = new DataTable();
            dtErros.Columns.Add("Manipulador", typeof(string));
            dtErros.Columns.Add("Porcentagem", typeof(double));

            dtErros.Rows.Add("Sergio", 25);
            dtErros.Rows.Add("Morais", 30);
            dtErros.Rows.Add("Denise", 45);

            // Adiciona dados ao gráfico
            var serie = chartErros.Series["Erros"];
            serie.Points.DataBind(dtErros.AsEnumerable(), "Manipulador", "Porcentagem", "");

            // Dados para o DataGridView
            var dtPrincipaisErros = new DataTable();
            dtPrincipaisErros.Columns.Add("Erro", typeof(string));
            dtPrincipaisErros.Columns.Add("Frequência", typeof(int));

            dtPrincipaisErros.Rows.Add("Erro 1: Falha na validação", 15);
            dtPrincipaisErros.Rows.Add("Erro 2: Entrada inválida", 10);
            dtPrincipaisErros.Rows.Add("Erro 3: Conexão perdida", 8);

            dgvPrincipaisErros.DataSource = dtPrincipaisErros;
        }

        private void InitializeComponent()
        {
            this.chartErros = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dgvPrincipaisErros = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
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
            this.chartErros.Text = "chart1";
            // 
            // dgvPrincipaisErros
            // 
            this.dgvPrincipaisErros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrincipaisErros.Location = new System.Drawing.Point(430, 37);
            this.dgvPrincipaisErros.Name = "dgvPrincipaisErros";
            this.dgvPrincipaisErros.Size = new System.Drawing.Size(300, 300);
            this.dgvPrincipaisErros.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Porcentagem de Erros por Usuário:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(430, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Principais Erros:";
            // 
            // Monitoramento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 351);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvPrincipaisErros);
            this.Controls.Add(this.chartErros);
            this.Name = "Monitoramento";
            this.Text = "Monitoramento de Desempenho";
            this.Load += new System.EventHandler(this.Monitoramento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartErros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrincipaisErros)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.DataVisualization.Charting.Chart chartErros;
        private System.Windows.Forms.DataGridView dgvPrincipaisErros;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
