using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CadastroDeErros.Supervisor
{
    partial class Monitorar
    {
        private System.ComponentModel.IContainer components = null;

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
            ChartArea chartArea1 = new ChartArea();
            Legend legend1 = new Legend();
            Series series1 = new Series();
            chartErros = new Chart();
            lblTotalErros = new Label();
            ((System.ComponentModel.ISupportInitialize)chartErros).BeginInit();
            SuspendLayout();
            // 
            // chartErros
            // 
            chartArea1.Name = "ChartArea1";
            chartErros.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chartErros.Legends.Add(legend1);
            chartErros.Location = new Point(18, 18);
            chartErros.Name = "chartErros";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chartErros.Series.Add(series1);
            chartErros.Size = new Size(966, 421);
            chartErros.TabIndex = 1;
            chartErros.Text = "chart1";
            // 
            // lblTotalErros
            // 
            lblTotalErros.AutoSize = true;
            lblTotalErros.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalErros.Location = new Point(59, 473);
            lblTotalErros.Name = "lblTotalErros";
            lblTotalErros.Size = new Size(66, 28);
            lblTotalErros.TabIndex = 3;
            lblTotalErros.Text = "label2";
            // 
            // Monitorar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1056, 617);
            Controls.Add(lblTotalErros);
            Controls.Add(chartErros);
            Name = "Monitorar";
            Text = "Monitoramento de Erros";
            ((System.ComponentModel.ISupportInitialize)chartErros).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Chart chartErros;
        private Label lblTotalErros;
    }
}
