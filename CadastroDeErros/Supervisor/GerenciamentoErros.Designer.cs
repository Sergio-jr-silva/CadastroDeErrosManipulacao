namespace CadastroDeErros.Supervisor
{
    partial class GerenciamentoErros
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            TbErros = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)TbErros).BeginInit();
            SuspendLayout();
            // 
            // TbErros
            // 
            TbErros.AllowUserToAddRows = false;
            TbErros.AllowUserToOrderColumns = true;
            TbErros.BackgroundColor = SystemColors.Control;
            TbErros.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            TbErros.Location = new Point(2, -1);
            TbErros.Name = "TbErros";
            TbErros.ReadOnly = true;
            TbErros.RowHeadersWidth = 51;
            TbErros.Size = new Size(906, 621);
            TbErros.TabIndex = 0;
            TbErros.CellContentClick += dataGridView1_CellContentClick;
            // 
            // GerenciamentoErros
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(933, 664);
            Controls.Add(TbErros);
            Name = "GerenciamentoErros";
            Text = "Gerenciamento De Erros";
            ((System.ComponentModel.ISupportInitialize)TbErros).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView TbErros;
    }
}