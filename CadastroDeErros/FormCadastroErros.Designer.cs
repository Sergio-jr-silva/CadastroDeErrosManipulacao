namespace CadastroDeErros
{
    partial class FormCadastroErros
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCadastroErros));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            cmbManipulador = new ComboBox();
            TipoErro = new ComboBox();
            label4 = new Label();
            desc = new Label();
            DescErro = new TextBox();
            btnCadastrar = new Button();
            label6 = new Label();
            label7 = new Label();
            Fornecedor = new ComboBox();
            Produto = new ComboBox();
            DataCadastro = new DateTimePicker();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Emoji", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(24, 60);
            label1.Name = "label1";
            label1.Size = new Size(122, 24);
            label1.TabIndex = 0;
            label1.Text = "Manipulador";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(97, 123);
            label2.Name = "label2";
            label2.Size = new Size(0, 20);
            label2.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Emoji", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(418, 61);
            label3.Name = "label3";
            label3.Size = new Size(62, 24);
            label3.TabIndex = 3;
            label3.Text = "Data: ";
            // 
            // cmbManipulador
            // 
            cmbManipulador.FormattingEnabled = true;
            cmbManipulador.Items.AddRange(new object[] { "26674- SÉRGIO JUNIO GONÇALVES", "23778 - LUIZ FERNANDO", "25651 - GLEIBSON MORAIS", "OUTROS" });
            cmbManipulador.Location = new Point(152, 61);
            cmbManipulador.Name = "cmbManipulador";
            cmbManipulador.Size = new Size(217, 28);
            cmbManipulador.TabIndex = 0;
            // 
            // TipoErro
            // 
            TipoErro.FormattingEnabled = true;
            TipoErro.Items.AddRange(new object[] { "DESISTÊNCIA", "ERRO DE MANIPULAÇÃO" });
            TipoErro.Location = new Point(621, 119);
            TipoErro.Name = "TipoErro";
            TipoErro.Size = new Size(111, 28);
            TipoErro.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(567, 118);
            label4.Name = "label4";
            label4.Size = new Size(57, 25);
            label4.TabIndex = 6;
            label4.Text = "Erro: ";
            // 
            // desc
            // 
            desc.AutoSize = true;
            desc.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            desc.Location = new Point(44, 178);
            desc.Name = "desc";
            desc.Size = new Size(171, 25);
            desc.TabIndex = 7;
            desc.Text = "Descrição do Erro: ";
            // 
            // DescErro
            // 
            DescErro.Location = new Point(44, 206);
            DescErro.Multiline = true;
            DescErro.Name = "DescErro";
            DescErro.Size = new Size(515, 133);
            DescErro.TabIndex = 6;
            // 
            // btnCadastrar
            // 
            btnCadastrar.Font = new Font("Segoe UI Emoji", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCadastrar.Location = new Point(257, 395);
            btnCadastrar.Name = "btnCadastrar";
            btnCadastrar.Size = new Size(196, 36);
            btnCadastrar.TabIndex = 9;
            btnCadastrar.Text = "Cadastrar";
            btnCadastrar.UseVisualStyleBackColor = true;
            btnCadastrar.Click += button1_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Emoji", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(26, 117);
            label6.Name = "label6";
            label6.Size = new Size(110, 24);
            label6.TabIndex = 10;
            label6.Text = "Fornecedor";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Emoji", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(277, 117);
            label7.Name = "label7";
            label7.Size = new Size(82, 24);
            label7.TabIndex = 11;
            label7.Text = "Produto";
            // 
            // Fornecedor
            // 
            Fornecedor.FormattingEnabled = true;
            Fornecedor.Items.AddRange(new object[] { "IQUINE", "SUVINIL", "CORAL" });
            Fornecedor.Location = new Point(142, 116);
            Fornecedor.Name = "Fornecedor";
            Fornecedor.Size = new Size(112, 28);
            Fornecedor.TabIndex = 2;
           
            // 
            // Produto
            // 
            Produto.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            Produto.DropDownHeight = 200;
            Produto.FormattingEnabled = true;
            Produto.IntegralHeight = false;
            Produto.Location = new Point(365, 117);
            Produto.Name = "Produto";
            Produto.Size = new Size(183, 28);
            Produto.TabIndex = 3;
            // 
            // DataCadastro
            // 
            DataCadastro.Location = new Point(482, 61);
            DataCadastro.Name = "DataCadastro";
            DataCadastro.Size = new Size(250, 27);
            DataCadastro.TabIndex = 12;
            // 
            // FormCadastroErros
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 224, 224);
            ClientSize = new Size(753, 512);
            Controls.Add(DataCadastro);
            Controls.Add(Produto);
            Controls.Add(Fornecedor);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(btnCadastrar);
            Controls.Add(DescErro);
            Controls.Add(desc);
            Controls.Add(label4);
            Controls.Add(TipoErro);
            Controls.Add(cmbManipulador);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormCadastroErros";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro de erros Manipulação";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private ComboBox cmbManipulador;
        private ComboBox TipoErro;
        private Label label4;
        private Label desc;
        private TextBox DescErro;
        private Button btnCadastrar;
        private Label label6;
        private Label label7;
        private ComboBox Fornecedor;
        private ComboBox Produto;
        private DateTimePicker DataCadastro;
    }
}
