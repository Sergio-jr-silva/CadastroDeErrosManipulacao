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
            Login loginForm = new Login();

            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                // Verifica o tipo de usuário logado
                if (loginForm.UsuarioLogado == "Supervisor")
                {
                    // Abre a tela de supervisão
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
                Application.Exit(); // Fecha a aplicação se o login não for realizado
            }
        }
    }
}
