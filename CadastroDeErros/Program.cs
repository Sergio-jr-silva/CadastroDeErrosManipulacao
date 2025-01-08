using System;
using MySql.Data.MySqlClient;

namespace CadastroDeErros
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Exibe o formulário de login
            Form2 loginForm = new Form2();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                // Se o login for bem-sucedido, abre o formulário de cadastro
                Application.Run(new Form1());
            }
            else
            {
                // Fecha a aplicação se o login não for realizado
                Application.Exit();
            }
        }

    }
}