namespace B_Sync_Pro.Forms
{
    partial class Form_cadastrar_expositor
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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel12 = new System.Windows.Forms.Panel();
            this.textBox_pesquisaComponente = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.button_deletar = new System.Windows.Forms.Button();
            this.button_salvar = new System.Windows.Forms.Button();
            this.button_Atualizar = new System.Windows.Forms.Button();
            this.button_exportar = new System.Windows.Forms.Button();
            this.button_importar = new System.Windows.Forms.Button();
            this.button_Voltar = new System.Windows.Forms.Button();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_cabeceira = new System.Windows.Forms.Button();
            this.button_acessorios = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_observacao = new System.Windows.Forms.TextBox();
            this.textBox_skugeral = new System.Windows.Forms.TextBox();
            this.button_Cadastrar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_comprimento = new System.Windows.Forms.ComboBox();
            this.textBox_modelo = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_profundidade = new System.Windows.Forms.ComboBox();
            this.comboBox_tipo = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox_resfriamento = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox_linha = new System.Windows.Forms.ComboBox();
            this.comboBox_situacao = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel12.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1183, 600);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Expositor";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Controls.Add(this.panel12);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1177, 594);
            this.panel2.TabIndex = 9;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(262, 74);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(915, 475);
            this.dataGridView1.TabIndex = 27;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.textBox_pesquisaComponente);
            this.panel12.Controls.Add(this.label9);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel12.Location = new System.Drawing.Point(262, 35);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(915, 39);
            this.panel12.TabIndex = 28;
            // 
            // textBox_pesquisaComponente
            // 
            this.textBox_pesquisaComponente.Location = new System.Drawing.Point(109, 13);
            this.textBox_pesquisaComponente.Name = "textBox_pesquisaComponente";
            this.textBox_pesquisaComponente.Size = new System.Drawing.Size(394, 23);
            this.textBox_pesquisaComponente.TabIndex = 4;
            this.textBox_pesquisaComponente.TextChanged += new System.EventHandler(this.textBox_pesquisaComponente_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 15);
            this.label9.TabIndex = 1;
            this.label9.Text = "Pesquisa modelo:";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.button_deletar);
            this.panel5.Controls.Add(this.button_salvar);
            this.panel5.Controls.Add(this.button_Atualizar);
            this.panel5.Controls.Add(this.button_exportar);
            this.panel5.Controls.Add(this.button_importar);
            this.panel5.Controls.Add(this.button_Voltar);
            this.panel5.Controls.Add(this.panel9);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(262, 549);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(915, 45);
            this.panel5.TabIndex = 26;
            // 
            // button_deletar
            // 
            this.button_deletar.Dock = System.Windows.Forms.DockStyle.Left;
            this.button_deletar.Location = new System.Drawing.Point(228, 10);
            this.button_deletar.Name = "button_deletar";
            this.button_deletar.Size = new System.Drawing.Size(114, 35);
            this.button_deletar.TabIndex = 18;
            this.button_deletar.Text = "Deletar";
            this.button_deletar.UseVisualStyleBackColor = true;
            this.button_deletar.Click += new System.EventHandler(this.button_deletar_Click);
            // 
            // button_salvar
            // 
            this.button_salvar.Dock = System.Windows.Forms.DockStyle.Left;
            this.button_salvar.Location = new System.Drawing.Point(114, 10);
            this.button_salvar.Name = "button_salvar";
            this.button_salvar.Size = new System.Drawing.Size(114, 35);
            this.button_salvar.TabIndex = 17;
            this.button_salvar.Text = "Alterar";
            this.button_salvar.UseVisualStyleBackColor = true;
            this.button_salvar.Click += new System.EventHandler(this.button_salvar_Click);
            // 
            // button_Atualizar
            // 
            this.button_Atualizar.Dock = System.Windows.Forms.DockStyle.Left;
            this.button_Atualizar.Location = new System.Drawing.Point(0, 10);
            this.button_Atualizar.Name = "button_Atualizar";
            this.button_Atualizar.Size = new System.Drawing.Size(114, 35);
            this.button_Atualizar.TabIndex = 16;
            this.button_Atualizar.Text = "Atualizar";
            this.button_Atualizar.UseVisualStyleBackColor = true;
            this.button_Atualizar.Click += new System.EventHandler(this.button_Atualizar_Click);
            // 
            // button_exportar
            // 
            this.button_exportar.Dock = System.Windows.Forms.DockStyle.Right;
            this.button_exportar.Location = new System.Drawing.Point(573, 10);
            this.button_exportar.Name = "button_exportar";
            this.button_exportar.Size = new System.Drawing.Size(114, 35);
            this.button_exportar.TabIndex = 20;
            this.button_exportar.Text = "Exportar";
            this.button_exportar.UseVisualStyleBackColor = true;
            this.button_exportar.Click += new System.EventHandler(this.button_exportar_Click);
            // 
            // button_importar
            // 
            this.button_importar.Dock = System.Windows.Forms.DockStyle.Right;
            this.button_importar.Location = new System.Drawing.Point(687, 10);
            this.button_importar.Name = "button_importar";
            this.button_importar.Size = new System.Drawing.Size(114, 35);
            this.button_importar.TabIndex = 21;
            this.button_importar.Text = "Importar";
            this.button_importar.UseVisualStyleBackColor = true;
            this.button_importar.Click += new System.EventHandler(this.button_importar_Click);
            // 
            // button_Voltar
            // 
            this.button_Voltar.Dock = System.Windows.Forms.DockStyle.Right;
            this.button_Voltar.Location = new System.Drawing.Point(801, 10);
            this.button_Voltar.Name = "button_Voltar";
            this.button_Voltar.Size = new System.Drawing.Size(114, 35);
            this.button_Voltar.TabIndex = 15;
            this.button_Voltar.Text = "Voltar";
            this.button_Voltar.UseVisualStyleBackColor = true;
            this.button_Voltar.Click += new System.EventHandler(this.button_Voltar_Click);
            // 
            // panel9
            // 
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(915, 10);
            this.panel9.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button_cabeceira);
            this.panel1.Controls.Add(this.button_acessorios);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(262, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(915, 35);
            this.panel1.TabIndex = 25;
            // 
            // button_cabeceira
            // 
            this.button_cabeceira.Dock = System.Windows.Forms.DockStyle.Left;
            this.button_cabeceira.Location = new System.Drawing.Point(130, 0);
            this.button_cabeceira.Name = "button_cabeceira";
            this.button_cabeceira.Size = new System.Drawing.Size(130, 35);
            this.button_cabeceira.TabIndex = 22;
            this.button_cabeceira.Text = "Cabeceira";
            this.button_cabeceira.UseVisualStyleBackColor = true;
            this.button_cabeceira.Click += new System.EventHandler(this.button_cabeceira_Click);
            // 
            // button_acessorios
            // 
            this.button_acessorios.Dock = System.Windows.Forms.DockStyle.Left;
            this.button_acessorios.Location = new System.Drawing.Point(0, 0);
            this.button_acessorios.Name = "button_acessorios";
            this.button_acessorios.Size = new System.Drawing.Size(130, 35);
            this.button_acessorios.TabIndex = 21;
            this.button_acessorios.Text = "Acessorios";
            this.button_acessorios.UseVisualStyleBackColor = true;
            this.button_acessorios.Click += new System.EventHandler(this.button_acessorios_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.textBox_observacao);
            this.panel3.Controls.Add(this.textBox_skugeral);
            this.panel3.Controls.Add(this.button_Cadastrar);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.comboBox_comprimento);
            this.panel3.Controls.Add(this.textBox_modelo);
            this.panel3.Controls.Add(this.label19);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.comboBox_profundidade);
            this.panel3.Controls.Add(this.comboBox_tipo);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.comboBox_resfriamento);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.comboBox_linha);
            this.panel3.Controls.Add(this.comboBox_situacao);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(262, 594);
            this.panel3.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "SKU Geral:";
            // 
            // textBox_observacao
            // 
            this.textBox_observacao.Location = new System.Drawing.Point(5, 379);
            this.textBox_observacao.Multiline = true;
            this.textBox_observacao.Name = "textBox_observacao";
            this.textBox_observacao.Size = new System.Drawing.Size(251, 170);
            this.textBox_observacao.TabIndex = 22;
            // 
            // textBox_skugeral
            // 
            this.textBox_skugeral.Location = new System.Drawing.Point(5, 62);
            this.textBox_skugeral.Name = "textBox_skugeral";
            this.textBox_skugeral.Size = new System.Drawing.Size(251, 23);
            this.textBox_skugeral.TabIndex = 4;
            // 
            // button_Cadastrar
            // 
            this.button_Cadastrar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button_Cadastrar.Location = new System.Drawing.Point(0, 559);
            this.button_Cadastrar.Name = "button_Cadastrar";
            this.button_Cadastrar.Size = new System.Drawing.Size(262, 35);
            this.button_Cadastrar.TabIndex = 13;
            this.button_Cadastrar.Text = "Cadastrar";
            this.button_Cadastrar.UseVisualStyleBackColor = true;
            this.button_Cadastrar.Click += new System.EventHandler(this.button_Cadastrar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 361);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 15);
            this.label2.TabIndex = 23;
            this.label2.Text = "Observação:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Modelo:";
            // 
            // comboBox_comprimento
            // 
            this.comboBox_comprimento.FormattingEnabled = true;
            this.comboBox_comprimento.Location = new System.Drawing.Point(5, 286);
            this.comboBox_comprimento.Name = "comboBox_comprimento";
            this.comboBox_comprimento.Size = new System.Drawing.Size(251, 23);
            this.comboBox_comprimento.TabIndex = 20;
            // 
            // textBox_modelo
            // 
            this.textBox_modelo.Location = new System.Drawing.Point(5, 18);
            this.textBox_modelo.Name = "textBox_modelo";
            this.textBox_modelo.Size = new System.Drawing.Size(251, 23);
            this.textBox_modelo.TabIndex = 0;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(5, 268);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(85, 15);
            this.label19.TabIndex = 19;
            this.label19.Text = "Comprimento:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "Tipo:";
            // 
            // comboBox_profundidade
            // 
            this.comboBox_profundidade.FormattingEnabled = true;
            this.comboBox_profundidade.Location = new System.Drawing.Point(5, 242);
            this.comboBox_profundidade.Name = "comboBox_profundidade";
            this.comboBox_profundidade.Size = new System.Drawing.Size(251, 23);
            this.comboBox_profundidade.TabIndex = 18;
            // 
            // comboBox_tipo
            // 
            this.comboBox_tipo.FormattingEnabled = true;
            this.comboBox_tipo.Location = new System.Drawing.Point(5, 106);
            this.comboBox_tipo.Name = "comboBox_tipo";
            this.comboBox_tipo.Size = new System.Drawing.Size(251, 23);
            this.comboBox_tipo.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 224);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 15);
            this.label8.TabIndex = 17;
            this.label8.Text = "Profundidade:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 15);
            this.label5.TabIndex = 3;
            this.label5.Text = "Resfriamento:";
            // 
            // comboBox_resfriamento
            // 
            this.comboBox_resfriamento.FormattingEnabled = true;
            this.comboBox_resfriamento.Location = new System.Drawing.Point(5, 150);
            this.comboBox_resfriamento.Name = "comboBox_resfriamento";
            this.comboBox_resfriamento.Size = new System.Drawing.Size(251, 23);
            this.comboBox_resfriamento.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 180);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "Situação:";
            // 
            // comboBox_linha
            // 
            this.comboBox_linha.FormattingEnabled = true;
            this.comboBox_linha.Location = new System.Drawing.Point(5, 330);
            this.comboBox_linha.Name = "comboBox_linha";
            this.comboBox_linha.Size = new System.Drawing.Size(251, 23);
            this.comboBox_linha.TabIndex = 8;
            this.comboBox_linha.Visible = false;
            // 
            // comboBox_situacao
            // 
            this.comboBox_situacao.FormattingEnabled = true;
            this.comboBox_situacao.Location = new System.Drawing.Point(5, 198);
            this.comboBox_situacao.Name = "comboBox_situacao";
            this.comboBox_situacao.Size = new System.Drawing.Size(251, 23);
            this.comboBox_situacao.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 312);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 15);
            this.label7.TabIndex = 7;
            this.label7.Text = "Linha:";
            this.label7.Visible = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1191, 628);
            this.tabControl1.TabIndex = 0;
            // 
            // Form_cadastrar_expositor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1191, 628);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form_cadastrar_expositor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastrar expositores";
            this.tabPage1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private TabPage tabPage1;
        private Panel panel2;
        private Button button_Cadastrar;
        private ComboBox comboBox_linha;
        private Label label7;
        private ComboBox comboBox_situacao;
        private Label label6;
        private ComboBox comboBox_resfriamento;
        private Label label5;
        private ComboBox comboBox_tipo;
        private Label label4;
        private Label label1;
        private Label label3;
        private TextBox textBox_modelo;
        private TextBox textBox_skugeral;
        private TabControl tabControl1;
        private ComboBox comboBox_comprimento;
        private Label label19;
        private ComboBox comboBox_profundidade;
        private Label label8;
        private Button button_acessorios;
        private TextBox textBox_observacao;
        private Label label2;
        private Panel panel3;
        private Panel panel1;
        private Panel panel5;
        private Button button_Voltar;
        private Panel panel9;
        private DataGridView dataGridView1;
        private Panel panel12;
        private TextBox textBox_pesquisaComponente;
        private Label label9;
        private Button button_deletar;
        private Button button_salvar;
        private Button button_Atualizar;
        private Button button_exportar;
        private Button button_importar;
        private Button button_cabeceira;
    }
}