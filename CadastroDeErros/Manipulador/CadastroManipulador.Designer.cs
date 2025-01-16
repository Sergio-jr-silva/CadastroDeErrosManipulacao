namespace CadastroDeErros
{
    partial class CadastroManipulador
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CadastroManipulador));
            label1 = new Label();
            label2 = new Label();
            Manipulador = new TextBox();
            Matricula = new TextBox();
            cadastrar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.Location = new Point(41, 39);
            label1.Name = "label1";
            label1.Size = new Size(57, 23);
            label1.TabIndex = 0;
            label1.Text = "Nome";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.Location = new Point(41, 112);
            label2.Name = "label2";
            label2.Size = new Size(81, 23);
            label2.TabIndex = 1;
            label2.Text = "Matricula";
            // 
            // Manipulador
            // 
            Manipulador.Location = new Point(119, 39);
            Manipulador.Name = "Manipulador";
            Manipulador.Size = new Size(191, 27);
            Manipulador.TabIndex = 1;
            // 
            // Matricula
            // 
            Matricula.Location = new Point(119, 112);
            Matricula.Name = "Matricula";
            Matricula.Size = new Size(185, 27);
            Matricula.TabIndex = 2;
            // 
            // cadastrar
            // 
            cadastrar.Font = new Font("Segoe UI", 10F);
            cadastrar.Location = new Point(143, 176);
            cadastrar.Name = "cadastrar";
            cadastrar.Size = new Size(137, 38);
            cadastrar.TabIndex = 3;
            cadastrar.Text = "Cadastrar";
            cadastrar.UseVisualStyleBackColor = true;
            cadastrar.Click += cadastrar_Click;
            // 
            // CadastroManipulador
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(436, 226);
            Controls.Add(cadastrar);
            Controls.Add(Matricula);
            Controls.Add(Manipulador);
            Controls.Add(label2);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "CadastroManipulador";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro de manipulador";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox Manipulador;
        private TextBox Matricula;
        private Button cadastrar;
    }
}