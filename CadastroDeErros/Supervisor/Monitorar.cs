using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Windows.Forms.DataVisualization.Charting;

namespace CadastroDeErros.Supervisor
{
    public partial class Monitorar : Form
    {
        private string connectionString = "server=localhost;database=ControleErros;user=root;password=3477";

        public Monitorar()
        {
            InitializeComponent();
            CarregarDados();
        }

        /// <summary>
        /// Método para carregar os dados do banco de dados e exibir no gráfico.
        /// </summary>
        private void CarregarDados()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT Quantidade, COUNT(*) AS total_erros FROM erros GROUP BY Erros";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                int totalErrosSistema = 0;
                foreach (DataRow row in dt.Rows)
                {
                    totalErrosSistema += Convert.ToInt32(row["total_erros"]);
                }

                chartErros.Series.Clear();

                // Série para Total de Erros
                Series seriesErros = new Series("Total de Erros");
                seriesErros.ChartType = SeriesChartType.Column;
                chartErros.Series.Add(seriesErros);

                // Série para Percentual de Erros
                Series seriesPercentual = new Series("Percentual de Erros");
                seriesPercentual.ChartType = SeriesChartType.Line;
                seriesPercentual.YAxisType = AxisType.Secondary;
                chartErros.Series.Add(seriesPercentual);

                foreach (DataRow row in dt.Rows)
                {
                    string manipulador = row["manipulador"].ToString();
                    int totalErros = Convert.ToInt32(row["total_erros"]);
                    double percentual = (totalErros / (double)totalErrosSistema) * 100;

                    seriesErros.Points.AddXY(manipulador, totalErros);
                    seriesPercentual.Points.AddXY(manipulador, percentual);

                    seriesErros.Points[seriesErros.Points.Count - 1].Label = $"{totalErros}";
                    seriesPercentual.Points[seriesPercentual.Points.Count - 1].Label = $"{percentual:F2}%";
                }
            }
        }
    }
}
