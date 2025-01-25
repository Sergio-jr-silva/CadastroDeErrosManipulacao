using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CadastroDeErros.Supervisor
{
    partial class MonitoramentoDesempenho : Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Construtor da classe.
        /// </summary>
        public MonitoramentoDesempenho()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // MonitoramentoDesempenho
            // 
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(800, 450);
            this.Name = "MonitoramentoDesempenho";
            this.Text = "Monitoramento de Desempenho";
            this.Load += new EventHandler(this.MonitoramentoDesempenho_Load);
            this.ResumeLayout(false);
        }

        #endregion

        /// <summary>
        /// Evento chamado quando o formulário é carregado.
        /// </summary>
        private void MonitoramentoDesempenho_Load(object sender, EventArgs e)
        {
            // Lógica a ser executada ao carregar o formulário
            MessageBox.Show("Formulário carregado com sucesso!");
        }
    }
}
