namespace CadastroDeErros.Supervisor
{
    partial class editar
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
            Produto = new Label();
            txtDescricao = new TextBox();
            Empresa = new Label();
            label1 = new Label();
            btnsalvar = new Button();
            cmbProduto = new ComboBox();
            cmbEmpresa = new ComboBox();
            SuspendLayout();
            // 
            // Produto
            // 
            Produto.AutoSize = true;
            Produto.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Produto.Location = new Point(62, 76);
            Produto.Name = "Produto";
            Produto.Size = new Size(77, 25);
            Produto.TabIndex = 0;
            Produto.Text = "Produto";
            // 
            // txtDescricao
            // 
            txtDescricao.Location = new Point(142, 202);
            txtDescricao.Multiline = true;
            txtDescricao.Name = "txtDescricao";
            txtDescricao.Size = new Size(378, 52);
            txtDescricao.TabIndex = 3;
            // 
            // Empresa
            // 
            Empresa.AutoSize = true;
            Empresa.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Empresa.Location = new Point(59, 133);
            Empresa.Name = "Empresa";
            Empresa.Size = new Size(80, 25);
            Empresa.TabIndex = 4;
            Empresa.Text = "Empresa";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(59, 205);
            label1.Name = "label1";
            label1.Size = new Size(74, 20);
            label1.TabIndex = 5;
            label1.Text = "Descrição";
            // 
            // btnsalvar
            // 
            btnsalvar.Location = new Point(170, 308);
            btnsalvar.Name = "btnsalvar";
            btnsalvar.Size = new Size(204, 29);
            btnsalvar.TabIndex = 6;
            btnsalvar.Text = "Salvar Alteração";
            btnsalvar.UseVisualStyleBackColor = true;
            btnsalvar.Click += btnsalvar_Click;
            // 
            // cmbProduto
            // 
            cmbProduto.FormattingEnabled = true;
            cmbProduto.Location = new Point(145, 77);
            cmbProduto.Name = "cmbProduto";
            cmbProduto.Size = new Size(359, 28);
            cmbProduto.TabIndex = 7;
            // 
            // cmbEmpresa
            // 
            cmbEmpresa.FormattingEnabled = true;
            cmbEmpresa.Location = new Point(145, 134);
            cmbEmpresa.Name = "cmbEmpresa";
            cmbEmpresa.Size = new Size(210, 28);
            cmbEmpresa.TabIndex = 8;
            // 
            // editar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(559, 389);
            Controls.Add(cmbEmpresa);
            Controls.Add(cmbProduto);
            Controls.Add(btnsalvar);
            Controls.Add(label1);
            Controls.Add(Empresa);
            Controls.Add(txtDescricao);
            Controls.Add(Produto);
            Name = "editar";
            Text = "editar";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Produto;
        private TextBox txtDescricao;
        private Label Empresa;
        private Label label1;
        private Button btnsalvar;
        private ComboBox cmbProduto;
        private ComboBox cmbEmpresa;
    }
}