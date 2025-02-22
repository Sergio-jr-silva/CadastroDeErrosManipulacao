using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Windows.Forms.DataVisualization.Charting;

namespace CadastroDeErros.Supervisor;

    public partial class Monitorar : Form
    {
    private readonly string connectionString = "Server=junction.proxy.rlwy.net;Port=19537;Database=railway;User Id=root;Password=AQmzEpJAXIqpYUogVjawuxNxKQOPBAxc;SslMode=Required;";


    public Monitorar()
        {
            InitializeComponent();
            CarregarDados();
            CarregarDadosDesistencia();
        }

        private void CarregarDados()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                string query = "SELECT idmanipuladores, COUNT(*) AS total_erros, SUM(Valor) AS total_valor FROM Erros GROUP BY idmanipuladores;";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Nenhum dado encontrado no banco.");
                        return;
                    }

                decimal totalValorErros = 0;
                int totalErrosSistema = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        totalErrosSistema += Convert.ToInt32(row["total_erros"]);
                    totalValorErros += Convert.ToDecimal(row["total_valor"]);
                }

                    lblTotalErros.Text = $"Total de Tintas no sistema: {totalErrosSistema}";
                    Valor.Text  = $"Valor total: R$ {totalValorErros:F2}";



                chartErros.Series.Clear();

                    Series seriesErros = new Series("Total de Tintas")
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

        private void CarregarDadosDesistencia()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT EmpresaId, COUNT(*) AS total_desistencias FROM Erros WHERE TipoErroId = 'Desistencia' GROUP BY EmpresaId;";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Nenhum dado de desistências encontrado no banco.");
                        return;
                    }

                    int totalDesistencias = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        totalDesistencias += Convert.ToInt32(row["total_desistencias"]);
                    }

                    lblTotalDesistencias.Text = $"Total de desistências: {totalDesistencias}";

                    chartDesistenciasProdutos.Series.Clear();

                    Series seriesDesistencias = new Series("Total de Desistências")
                    {
                        ChartType = SeriesChartType.Pie
                    };
                    chartDesistenciasProdutos.Series.Add(seriesDesistencias);

                    foreach (DataRow row in dt.Rows)
                    {
                        string marca = row["EmpresaId"].ToString();
                        int totalDesistenciasMarca = Convert.ToInt32(row["total_desistencias"]);
                        double percentual = (totalDesistenciasMarca / (double)totalDesistencias) * 100;

                        DataPoint dpDesistencias = new DataPoint();
                        dpDesistencias.SetValueXY(marca, totalDesistenciasMarca);
                        dpDesistencias.Label = $"{marca}: {percentual:F2}%";
                        seriesDesistencias.Points.Add(dpDesistencias);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao carregar dados de desistências: {ex.Message}");
                }
            }
        }

        private void chartErros_Click(object sender, EventArgs e) { }
    }

