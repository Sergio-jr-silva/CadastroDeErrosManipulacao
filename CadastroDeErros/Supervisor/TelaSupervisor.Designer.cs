namespace CadastroDeErros
{
    partial class TelaSupervisor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaSupervisor));
            pictureBox1 = new PictureBox();
            label1 = new Label();
            pictureBox3 = new PictureBox();
            label3 = new Label();
            pictureBox4 = new PictureBox();
            label4 = new Label();
            comboBox1 = new ComboBox();
            pictureBox2 = new PictureBox();
            label2 = new Label();
            pictureBox5 = new PictureBox();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.ButtonHighlight;
            pictureBox1.Image = Properties.Resources.pdf;
            pictureBox1.Location = new Point(71, 74);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(76, 81);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(71, 158);
            label1.Name = "label1";
            label1.Size = new Size(76, 20);
            label1.TabIndex = 1;
            label1.Text = "Relatórios";
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.manipulador;
            pictureBox3.Location = new Point(240, 74);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(127, 71);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 4;
            pictureBox3.TabStop = false;
            pictureBox3.Click += pictureBox3_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(223, 158);
            label3.Name = "label3";
            label3.Size = new Size(156, 20);
            label3.TabIndex = 5;
            label3.Text = "Cadastro Colaborador";
            // 
            // pictureBox4
            // 
            pictureBox4.Image = Properties.Resources.sair;
            pictureBox4.Location = new Point(424, 74);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(119, 81);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 6;
            pictureBox4.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(433, 158);
            label4.Name = "label4";
            label4.Size = new Size(110, 20);
            label4.TabIndex = 7;
            label4.Text = "Sair do sistema";
            // 
            // comboBox1
            // 
            comboBox1.ForeColor = SystemColors.MenuText;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(51, 21);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(336, 28);
            comboBox1.TabIndex = 8;
            comboBox1.Text = "Digite o nome do Programa";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(114, 202);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(121, 71);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 9;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(91, 286);
            label2.Name = "label2";
            label2.Size = new Size(168, 20);
            label2.TabIndex = 10;
            label2.Text = "Gerenciamento de Erros";
            // 
            // pictureBox5
            // 
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new Point(333, 211);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(140, 62);
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.TabIndex = 11;
            pictureBox5.TabStop = false;
            pictureBox5.Click += pictureBox5_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(303, 286);
            label5.Name = "label5";
            label5.Size = new Size(226, 20);
            label5.TabIndex = 12;
            label5.Text = "Monitoramento de Desempenho";
            // 
            // TelaSupervisor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(627, 367);
            Controls.Add(label5);
            Controls.Add(pictureBox5);
            Controls.Add(label2);
            Controls.Add(pictureBox2);
            Controls.Add(comboBox1);
            Controls.Add(label4);
            Controls.Add(pictureBox4);
            Controls.Add(label3);
            Controls.Add(pictureBox3);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "TelaSupervisor";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Supervisão De Erros";
            Load += TelaSupervisor_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private PictureBox pictureBox3;
        private Label label3;
        private PictureBox pictureBox4;
        private Label label4;
        private ComboBox comboBox1;
        private PictureBox pictureBox2;
        private Label label2;
        private PictureBox pictureBox5;
        private Label label5;
    }
}