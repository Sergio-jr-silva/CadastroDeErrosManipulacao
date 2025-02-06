using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CadastroDeErros.Supervisor
{
    partial class Monitorar
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartErros;

        /// <summary>
        /// Limpa os componentes usados.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Método gerado automaticamente pelo designer do Visual Studio.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.chartErros = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartErros)).BeginInit();
            this.SuspendLayout();

            // Configuração do ChartArea
            chartArea.Name = "ChartArea1";
            chartArea.AxisY.Title = "Total de Erros";
            chartArea.AxisY2.Title = "Percentual (%)";
            chartArea.AxisY2.Enabled = AxisEnabled.True;
            this.chartErros.ChartAreas.Add(chartArea);

            // Configuração da Legenda
            legend.Name = "Legenda";
            this.chartErros.Legends.Add(legend);

            // Configuração do Gráfico
            this.chartErros.Location = new System.Drawing.Point(10, 10);
            this.chartErros.Name = "chartErros";
            this.chartErros.Size = new System.Drawing.Size(780, 400);
            this.chartErros.TabIndex = 0;
            this.chartErros.Text = "Gráfico de Erros";

            // Configuração do Formulário
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.chartErros);
            this.Name = "Monitorar";
            this.Text = "Monitoramento de Erros";
            ((System.ComponentModel.ISupportInitialize)(this.chartErros)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
