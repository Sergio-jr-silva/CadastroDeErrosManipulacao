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

            // Exibe o formul�rio de login
            Login loginForm = new Login();

            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                // Verifica o tipo de usu�rio logado
                if (loginForm.UsuarioLogado == "Supervisor")
                {
                    // Abre a tela de supervis�o
                    Application.Run(new TelaSupervisor());
                }
                else
                {
                    // Abre a tela de cadastro de erros
                    Application.Run(new FormCadastroErros());
                }
            }
            else
            {
                Application.Exit(); // Fecha a aplica��o se o login n�o for realizado
            }
        }
    }
}
