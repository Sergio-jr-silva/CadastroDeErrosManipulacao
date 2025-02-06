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

        private void CarregarDados()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT idmanipuladores, COUNT(*) AS total_erros FROM ERROS GROUP BY idmanipuladores;";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Nenhum dado encontrado no banco.");
                        return;
                    }

                    int totalErrosSistema = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        totalErrosSistema += Convert.ToInt32(row["total_erros"]);
                    }

                    lblTotalErros.Text = $"Total de erros no sistema: {totalErrosSistema}";

                    chartErros.Series.Clear();

                    Series seriesErros = new Series("Total de Erros")
                    {
                        ChartType = SeriesChartType.Pie
                    };
                    chartErros.Series.Add(seriesErros);

                    foreach (DataRow row in dt.Rows)
                    {
                        string manipulador = row["idmanipuladores"].ToString();
                        int totalErros = Convert.ToInt32(row["total_erros"]);
                        double percentual = (totalErros / (double)totalErrosSistema) * 100;

                        DataPoint dpErros = new DataPoint();
                        dpErros.SetValueXY(manipulador, totalErros);
                        dpErros.Label = $"{manipulador}: {percentual:F2}%";
                        seriesErros.Points.Add(dpErros);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao carregar dados: {ex.Message}");
                }
            }
        }

        private void chartErros_Click(object sender, EventArgs e) { }
    }
}
