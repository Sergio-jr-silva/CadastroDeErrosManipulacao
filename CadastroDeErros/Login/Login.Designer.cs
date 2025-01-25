namespace CadastroDeErros
{
    partial class Login
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            senha = new TextBox();
            button1 = new Button();
            usuario = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(250, 151);
            label1.Name = "label1";
            label1.Size = new Size(84, 31);
            label1.TabIndex = 0;
            label1.Text = "Login: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(250, 239);
            label2.Name = "label2";
            label2.Size = new Size(89, 31);
            label2.TabIndex = 1;
            label2.Text = "Senha: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(247, 33);
            label3.Name = "label3";
            label3.Size = new Size(332, 46);
            label3.TabIndex = 2;
            label3.Text = "SISTEMA DE ERROS";
            // 
            // senha
            // 
            senha.Location = new Point(340, 245);
            senha.Name = "senha";
            senha.PasswordChar = '*';
            senha.Size = new Size(225, 27);
            senha.TabIndex = 2;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(340, 349);
            button1.Name = "button1";
            button1.Size = new Size(199, 50);
            button1.TabIndex = 5;
            button1.Text = "Entrar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // usuario
            // 
            usuario.Location = new Point(328, 157);
            usuario.Name = "usuario";
            usuario.Size = new Size(237, 27);
            usuario.TabIndex = 1;
           
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(819, 477);
            Controls.Add(usuario);
            Controls.Add(button1);
            Controls.Add(senha);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Login";
            Text = "Sistema De Erros";
            Load += Form2_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox senha;
        private Button button1;
        private TextBox usuario;
    }
}