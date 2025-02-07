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
            ChartArea chartArea2 = new ChartArea();
            Legend legend2 = new Legend();
            Series series2 = new Series();
            chartErros = new Chart();
            lblTotalErros = new Label();
            chartDesistenciasProdutos = new Chart();
            lblTotalDesistencias = new Label();
            ((System.ComponentModel.ISupportInitialize)chartErros).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartDesistenciasProdutos).BeginInit();
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
            chartErros.Size = new Size(629, 342);
            chartErros.TabIndex = 1;
            chartErros.Text = "chart1";
            // 
            // lblTotalErros
            // 
            lblTotalErros.AutoSize = true;
            lblTotalErros.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalErros.Location = new Point(785, 33);
            lblTotalErros.Name = "lblTotalErros";
            lblTotalErros.Size = new Size(66, 28);
            lblTotalErros.TabIndex = 3;
            lblTotalErros.Text = "label2";
            // 
            // chartDesistenciasProdutos
            // 
            chartArea2.Name = "ChartArea1";
            chartDesistenciasProdutos.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            chartDesistenciasProdutos.Legends.Add(legend2);
            chartDesistenciasProdutos.Location = new Point(18, 414);
            chartDesistenciasProdutos.Name = "chartDesistenciasProdutos";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            chartDesistenciasProdutos.Series.Add(series2);
            chartDesistenciasProdutos.Size = new Size(674, 295);
            chartDesistenciasProdutos.TabIndex = 4;
            chartDesistenciasProdutos.Text = "chart1";
            // 
            // lblTotalDesistencias
            // 
            lblTotalDesistencias.AutoSize = true;
            lblTotalDesistencias.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalDesistencias.Location = new Point(801, 443);
            lblTotalDesistencias.Name = "lblTotalDesistencias";
            lblTotalDesistencias.Size = new Size(63, 28);
            lblTotalDesistencias.TabIndex = 5;
            lblTotalDesistencias.Text = "label1";
            // 
            // Monitorar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1206, 757);
            Controls.Add(lblTotalDesistencias);
            Controls.Add(chartDesistenciasProdutos);
            Controls.Add(lblTotalErros);
            Controls.Add(chartErros);
            Name = "Monitorar";
            Text = "Monitoramento de Erros";
            ((System.ComponentModel.ISupportInitialize)chartErros).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartDesistenciasProdutos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Chart chartErros;
        private Label lblTotalErros;
        private Chart chartDesistenciasProdutos;
        private Label lblTotalDesistencias;
    }
}
