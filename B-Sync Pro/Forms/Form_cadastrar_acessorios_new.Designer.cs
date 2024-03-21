namespace B_Sync_Pro.Forms
{
    partial class Form_cadastrar_acessorios_new
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
            this.panel4 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel14 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.textBox_pesquisaComponente = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.button_cabeceira = new System.Windows.Forms.Button();
            this.button_Modulo = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.button_deletar = new System.Windows.Forms.Button();
            this.button_salvar = new System.Windows.Forms.Button();
            this.button_Atualizar = new System.Windows.Forms.Button();
            this.button_exportar = new System.Windows.Forms.Button();
            this.button_importar = new System.Windows.Forms.Button();
            this.button_voltar = new System.Windows.Forms.Button();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox_codigos = new System.Windows.Forms.TextBox();
            this.button_cadastrar = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_observacao = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.comboBox_Cores = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDown_qtd_nivel = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_chave_busca = new System.Windows.Forms.TextBox();
            this.textBox_componente_nome = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_componente = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_medida = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_modelo = new System.Windows.Forms.ComboBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel12.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_qtd_nivel)).BeginInit();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dataGridView1);
            this.panel4.Controls.Add(this.panel14);
            this.panel4.Controls.Add(this.panel12);
            this.panel4.Controls.Add(this.panel11);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Controls.Add(this.panel2);
            this.panel4.Controls.Add(this.panel7);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 10);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1158, 578);
            this.panel4.TabIndex = 9;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(335, 74);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(813, 449);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // panel14
            // 
            this.panel14.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel14.Location = new System.Drawing.Point(1148, 74);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(10, 449);
            this.panel14.TabIndex = 12;
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.textBox_pesquisaComponente);
            this.panel12.Controls.Add(this.label2);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel12.Location = new System.Drawing.Point(335, 35);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(823, 39);
            this.panel12.TabIndex = 11;
            // 
            // textBox_pesquisaComponente
            // 
            this.textBox_pesquisaComponente.Location = new System.Drawing.Point(130, 15);
            this.textBox_pesquisaComponente.Name = "textBox_pesquisaComponente";
            this.textBox_pesquisaComponente.Size = new System.Drawing.Size(394, 23);
            this.textBox_pesquisaComponente.TabIndex = 4;
            this.textBox_pesquisaComponente.TextChanged += new System.EventHandler(this.textBox_pesquisaComponente_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Pesquisa componente:";
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.button_cabeceira);
            this.panel11.Controls.Add(this.button_Modulo);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel11.Location = new System.Drawing.Point(335, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(823, 35);
            this.panel11.TabIndex = 10;
            // 
            // button_cabeceira
            // 
            this.button_cabeceira.Dock = System.Windows.Forms.DockStyle.Left;
            this.button_cabeceira.Location = new System.Drawing.Point(114, 0);
            this.button_cabeceira.Name = "button_cabeceira";
            this.button_cabeceira.Size = new System.Drawing.Size(114, 35);
            this.button_cabeceira.TabIndex = 15;
            this.button_cabeceira.Text = "Cabeceira";
            this.button_cabeceira.UseVisualStyleBackColor = true;
            this.button_cabeceira.Click += new System.EventHandler(this.button_cabeceira_Click);
            // 
            // button_Modulo
            // 
            this.button_Modulo.Dock = System.Windows.Forms.DockStyle.Left;
            this.button_Modulo.Location = new System.Drawing.Point(0, 0);
            this.button_Modulo.Name = "button_Modulo";
            this.button_Modulo.Size = new System.Drawing.Size(114, 35);
            this.button_Modulo.TabIndex = 14;
            this.button_Modulo.Text = "Modelo";
            this.button_Modulo.UseVisualStyleBackColor = true;
            this.button_Modulo.Click += new System.EventHandler(this.button_Modulo_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.button_deletar);
            this.panel5.Controls.Add(this.button_salvar);
            this.panel5.Controls.Add(this.button_Atualizar);
            this.panel5.Controls.Add(this.button_exportar);
            this.panel5.Controls.Add(this.button_importar);
            this.panel5.Controls.Add(this.button_voltar);
            this.panel5.Controls.Add(this.panel9);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(335, 523);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(823, 45);
            this.panel5.TabIndex = 9;
            // 
            // button_deletar
            // 
            this.button_deletar.Dock = System.Windows.Forms.DockStyle.Left;
            this.button_deletar.Location = new System.Drawing.Point(228, 10);
            this.button_deletar.Name = "button_deletar";
            this.button_deletar.Size = new System.Drawing.Size(114, 35);
            this.button_deletar.TabIndex = 8;
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
            this.button_salvar.TabIndex = 7;
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
            this.button_Atualizar.TabIndex = 6;
            this.button_Atualizar.Text = "Atualizar";
            this.button_Atualizar.UseVisualStyleBackColor = true;
            this.button_Atualizar.Click += new System.EventHandler(this.button_Atualizar_Click);
            // 
            // button_exportar
            // 
            this.button_exportar.Dock = System.Windows.Forms.DockStyle.Right;
            this.button_exportar.Location = new System.Drawing.Point(481, 10);
            this.button_exportar.Name = "button_exportar";
            this.button_exportar.Size = new System.Drawing.Size(114, 35);
            this.button_exportar.TabIndex = 10;
            this.button_exportar.Text = "Exportar";
            this.button_exportar.UseVisualStyleBackColor = true;
            this.button_exportar.Click += new System.EventHandler(this.button_exportar_Click);
            // 
            // button_importar
            // 
            this.button_importar.Dock = System.Windows.Forms.DockStyle.Right;
            this.button_importar.Location = new System.Drawing.Point(595, 10);
            this.button_importar.Name = "button_importar";
            this.button_importar.Size = new System.Drawing.Size(114, 35);
            this.button_importar.TabIndex = 11;
            this.button_importar.Text = "Importar";
            this.button_importar.UseVisualStyleBackColor = true;
            this.button_importar.Click += new System.EventHandler(this.button_importar_Click);
            // 
            // button_voltar
            // 
            this.button_voltar.Dock = System.Windows.Forms.DockStyle.Right;
            this.button_voltar.Location = new System.Drawing.Point(709, 10);
            this.button_voltar.Name = "button_voltar";
            this.button_voltar.Size = new System.Drawing.Size(114, 35);
            this.button_voltar.TabIndex = 12;
            this.button_voltar.Text = "Voltar";
            this.button_voltar.UseVisualStyleBackColor = true;
            this.button_voltar.Click += new System.EventHandler(this.button_voltar_Click);
            // 
            // panel9
            // 
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(823, 10);
            this.panel9.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.textBox_codigos);
            this.panel2.Controls.Add(this.button_cadastrar);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.textBox_observacao);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.comboBox_Cores);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.numericUpDown_qtd_nivel);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.textBox_chave_busca);
            this.panel2.Controls.Add(this.textBox_componente_nome);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.textBox_componente);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.comboBox_medida);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(335, 568);
            this.panel2.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 367);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 15);
            this.label10.TabIndex = 27;
            this.label10.Text = "Codigo:";
            // 
            // textBox_codigos
            // 
            this.textBox_codigos.Location = new System.Drawing.Point(12, 385);
            this.textBox_codigos.Name = "textBox_codigos";
            this.textBox_codigos.Size = new System.Drawing.Size(317, 23);
            this.textBox_codigos.TabIndex = 26;
            // 
            // button_cadastrar
            // 
            this.button_cadastrar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button_cadastrar.Location = new System.Drawing.Point(0, 533);
            this.button_cadastrar.Name = "button_cadastrar";
            this.button_cadastrar.Size = new System.Drawing.Size(335, 35);
            this.button_cadastrar.TabIndex = 24;
            this.button_cadastrar.Text = "Cadastrar";
            this.button_cadastrar.UseVisualStyleBackColor = true;
            this.button_cadastrar.Click += new System.EventHandler(this.button_cadastrar_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 411);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 15);
            this.label9.TabIndex = 23;
            this.label9.Text = "Observação:";
            // 
            // textBox_observacao
            // 
            this.textBox_observacao.Location = new System.Drawing.Point(12, 429);
            this.textBox_observacao.Multiline = true;
            this.textBox_observacao.Name = "textBox_observacao";
            this.textBox_observacao.Size = new System.Drawing.Size(317, 94);
            this.textBox_observacao.TabIndex = 22;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Location = new System.Drawing.Point(12, 316);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(317, 48);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mostrar para configurar:";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(248, 22);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(52, 19);
            this.checkBox2.TabIndex = 9;
            this.checkBox2.Text = "NÃO";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(6, 22);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(46, 19);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "SIM";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // comboBox_Cores
            // 
            this.comboBox_Cores.FormattingEnabled = true;
            this.comboBox_Cores.Location = new System.Drawing.Point(100, 286);
            this.comboBox_Cores.Name = "comboBox_Cores";
            this.comboBox_Cores.Size = new System.Drawing.Size(229, 23);
            this.comboBox_Cores.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(100, 268);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 15);
            this.label6.TabIndex = 19;
            this.label6.Text = "Cores:";
            // 
            // numericUpDown_qtd_nivel
            // 
            this.numericUpDown_qtd_nivel.Location = new System.Drawing.Point(12, 287);
            this.numericUpDown_qtd_nivel.Name = "numericUpDown_qtd_nivel";
            this.numericUpDown_qtd_nivel.Size = new System.Drawing.Size(80, 23);
            this.numericUpDown_qtd_nivel.TabIndex = 18;
            this.numericUpDown_qtd_nivel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 268);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 15);
            this.label5.TabIndex = 17;
            this.label5.Text = "Qtd. nivel:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 224);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 15);
            this.label8.TabIndex = 16;
            this.label8.Text = "Chave de busca:";
            // 
            // textBox_chave_busca
            // 
            this.textBox_chave_busca.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBox_chave_busca.Location = new System.Drawing.Point(12, 242);
            this.textBox_chave_busca.Name = "textBox_chave_busca";
            this.textBox_chave_busca.Size = new System.Drawing.Size(317, 23);
            this.textBox_chave_busca.TabIndex = 15;
            // 
            // textBox_componente_nome
            // 
            this.textBox_componente_nome.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBox_componente_nome.Location = new System.Drawing.Point(12, 198);
            this.textBox_componente_nome.Name = "textBox_componente_nome";
            this.textBox_componente_nome.Size = new System.Drawing.Size(317, 23);
            this.textBox_componente_nome.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 177);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(168, 15);
            this.label7.TabIndex = 13;
            this.label7.Text = "Nome componente completo:";
            // 
            // textBox_componente
            // 
            this.textBox_componente.Location = new System.Drawing.Point(12, 151);
            this.textBox_componente.Name = "textBox_componente";
            this.textBox_componente.Size = new System.Drawing.Size(317, 23);
            this.textBox_componente.TabIndex = 6;
            this.textBox_componente.TextChanged += new System.EventHandler(this.textBox_componente_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Componente:";
            // 
            // comboBox_medida
            // 
            this.comboBox_medida.FormattingEnabled = true;
            this.comboBox_medida.Location = new System.Drawing.Point(12, 107);
            this.comboBox_medida.Name = "comboBox_medida";
            this.comboBox_medida.Size = new System.Drawing.Size(317, 23);
            this.comboBox_medida.TabIndex = 4;
            this.comboBox_medida.SelectedIndexChanged += new System.EventHandler(this.comboBox_medida_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Medida:";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel6.Controls.Add(this.label1);
            this.panel6.Controls.Add(this.comboBox_modelo);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(335, 74);
            this.panel6.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Modelo:";
            // 
            // comboBox_modelo
            // 
            this.comboBox_modelo.FormattingEnabled = true;
            this.comboBox_modelo.Location = new System.Drawing.Point(12, 38);
            this.comboBox_modelo.Name = "comboBox_modelo";
            this.comboBox_modelo.Size = new System.Drawing.Size(317, 23);
            this.comboBox_modelo.TabIndex = 2;
            this.comboBox_modelo.SelectedIndexChanged += new System.EventHandler(this.comboBox_modelo_SelectedIndexChanged);
            // 
            // panel7
            // 
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(0, 568);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1158, 10);
            this.panel7.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1168, 10);
            this.panel1.TabIndex = 7;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(1158, 10);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(10, 578);
            this.panel3.TabIndex = 8;
            // 
            // Form_cadastrar_acessorios_new
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1168, 588);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(1184, 425);
            this.Name = "Form_cadastrar_acessorios_new";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_cadastrar_acessorios_new";
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_qtd_nivel)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel4;
        private DataGridView dataGridView1;
        private Panel panel14;
        private Panel panel12;
        private TextBox textBox_pesquisaComponente;
        private Label label2;
        private Panel panel11;
        private Button button_Modulo;
        private Panel panel5;
        private Button button_deletar;
        private Button button_salvar;
        private Button button_Atualizar;
        private Button button_exportar;
        private Button button_importar;
        private Button button_voltar;
        private Panel panel9;
        private Panel panel2;
        private Panel panel7;
        private Panel panel1;
        private Panel panel3;
        private Button button_cabeceira;
        private Label label1;
        private ComboBox comboBox_modelo;
        private Label label3;
        private ComboBox comboBox_medida;
        private Label label4;
        private TextBox textBox_componente;
        private TextBox textBox_componente_nome;
        private Label label7;
        private Label label8;
        private TextBox textBox_chave_busca;
        private NumericUpDown numericUpDown_qtd_nivel;
        private Label label5;
        private ComboBox comboBox_Cores;
        private Label label6;
        private GroupBox groupBox1;
        private CheckBox checkBox2;
        private CheckBox checkBox1;
        private Label label9;
        private TextBox textBox_observacao;
        private Button button_cadastrar;
        private Panel panel6;
        private Label label10;
        private TextBox textBox_codigos;
    }
}