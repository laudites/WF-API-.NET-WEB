namespace B_Sync_Pro.Forms
{
    partial class Form_GerarOrcamentos
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            label1 = new Label();
            comboBox_cliente = new ComboBox();
            textBox_num_cotacao = new TextBox();
            label2 = new Label();
            comboBox_Temperatura = new ComboBox();
            label_temperatura = new Label();
            comboBox_expositor = new ComboBox();
            label_modelo_expositor = new Label();
            comboBox_largura_expositor = new ComboBox();
            label_largura_expositor = new Label();
            comboBox_tamanho_expositor = new ComboBox();
            label_tamanho_expositor = new Label();
            label7 = new Label();
            comboBox_cor_externa_rodape = new ComboBox();
            label_cor_externa_rodape = new Label();
            comboBox_cor_acabamento = new ComboBox();
            label_cor_externa_acabamento = new Label();
            comboBox_cor_interna = new ComboBox();
            label_cor_interna = new Label();
            comboBox_tipo_refrigeracao = new ComboBox();
            label_tipo_refrigeracao = new Label();
            comboBox_cabeceira_esq = new ComboBox();
            label_cabeceira_esquerda = new Label();
            button_adicionar = new Button();
            textBox_loja = new TextBox();
            label_cabeceira_dir = new Label();
            comboBox_cabeceira_dir = new ComboBox();
            panel3 = new Panel();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel16 = new Panel();
            numericUpDown_qtd_modelo = new NumericUpDown();
            label14 = new Label();
            panel2 = new Panel();
            textBox_observacao = new TextBox();
            label15 = new Label();
            panel7 = new Panel();
            panel9 = new Panel();
            textBox_endereco = new TextBox();
            label13 = new Label();
            label12 = new Label();
            textBox_UF = new TextBox();
            textBox_cidade = new TextBox();
            label8 = new Label();
            comboBox_vendedor = new ComboBox();
            label6 = new Label();
            panel4 = new Panel();
            label_calcular_novamente = new Label();
            panel1 = new Panel();
            button_calcular = new Button();
            panel15 = new Panel();
            txtPorcentagem = new TextBox();
            label10 = new Label();
            label11 = new Label();
            panel14 = new Panel();
            txtValorFechado = new TextBox();
            label9 = new Label();
            button_salvar = new Button();
            panel8 = new Panel();
            textBox_valor = new TextBox();
            label_valor = new Label();
            panel5 = new Panel();
            button_imprimir = new Button();
            button_deletar = new Button();
            button_voltar = new Button();
            panel11 = new Panel();
            label4 = new Label();
            dataGridView_Modelo = new DataGridView();
            panel12 = new Panel();
            label5 = new Label();
            dataGridView_Acessorios = new DataGridView();
            panel6 = new Panel();
            panel13 = new Panel();
            dataGridView_cabeceira = new DataGridView();
            panel10 = new Panel();
            label3 = new Label();
            panel3.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            panel16.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_qtd_modelo).BeginInit();
            panel2.SuspendLayout();
            panel7.SuspendLayout();
            panel9.SuspendLayout();
            panel4.SuspendLayout();
            panel1.SuspendLayout();
            panel15.SuspendLayout();
            panel14.SuspendLayout();
            panel8.SuspendLayout();
            panel5.SuspendLayout();
            panel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_Modelo).BeginInit();
            panel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_Acessorios).BeginInit();
            panel6.SuspendLayout();
            panel13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_cabeceira).BeginInit();
            panel10.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ControlDark;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(7, 3);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 0;
            label1.Text = "Cliente:";
            // 
            // comboBox_cliente
            // 
            comboBox_cliente.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            comboBox_cliente.FormattingEnabled = true;
            comboBox_cliente.Location = new Point(7, 21);
            comboBox_cliente.Name = "comboBox_cliente";
            comboBox_cliente.Size = new Size(199, 23);
            comboBox_cliente.TabIndex = 1;
            comboBox_cliente.DropDown += comboBox_cliente_DropDown;
            comboBox_cliente.SelectedIndexChanged += comboBox_cliente_SelectedIndexChanged;
            // 
            // textBox_num_cotacao
            // 
            textBox_num_cotacao.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox_num_cotacao.Location = new Point(482, 27);
            textBox_num_cotacao.Name = "textBox_num_cotacao";
            textBox_num_cotacao.Size = new Size(175, 29);
            textBox_num_cotacao.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(482, 3);
            label2.Name = "label2";
            label2.Size = new Size(125, 21);
            label2.TabIndex = 5;
            label2.Text = "Nº da cotacação:";
            // 
            // comboBox_Temperatura
            // 
            comboBox_Temperatura.Enabled = false;
            comboBox_Temperatura.FormattingEnabled = true;
            comboBox_Temperatura.Location = new Point(7, 159);
            comboBox_Temperatura.Name = "comboBox_Temperatura";
            comboBox_Temperatura.Size = new Size(185, 23);
            comboBox_Temperatura.TabIndex = 7;
            comboBox_Temperatura.SelectedIndexChanged += comboBox_Temperatura_SelectedIndexChanged;
            // 
            // label_temperatura
            // 
            label_temperatura.AutoSize = true;
            label_temperatura.Enabled = false;
            label_temperatura.Location = new Point(7, 141);
            label_temperatura.Name = "label_temperatura";
            label_temperatura.Size = new Size(76, 15);
            label_temperatura.TabIndex = 6;
            label_temperatura.Text = "Temperatura:";
            // 
            // comboBox_expositor
            // 
            comboBox_expositor.Enabled = false;
            comboBox_expositor.FormattingEnabled = true;
            comboBox_expositor.Location = new Point(7, 203);
            comboBox_expositor.Name = "comboBox_expositor";
            comboBox_expositor.Size = new Size(185, 23);
            comboBox_expositor.TabIndex = 10;
            comboBox_expositor.DropDown += comboBox_expositor_DropDown;
            comboBox_expositor.SelectedIndexChanged += comboBox_expositor_SelectedIndexChanged;
            // 
            // label_modelo_expositor
            // 
            label_modelo_expositor.AutoSize = true;
            label_modelo_expositor.Enabled = false;
            label_modelo_expositor.Location = new Point(7, 185);
            label_modelo_expositor.Name = "label_modelo_expositor";
            label_modelo_expositor.Size = new Size(103, 15);
            label_modelo_expositor.TabIndex = 9;
            label_modelo_expositor.Text = "Modelo Expositor:";
            // 
            // comboBox_largura_expositor
            // 
            comboBox_largura_expositor.Enabled = false;
            comboBox_largura_expositor.FormattingEnabled = true;
            comboBox_largura_expositor.Location = new Point(212, 203);
            comboBox_largura_expositor.Name = "comboBox_largura_expositor";
            comboBox_largura_expositor.Size = new Size(180, 23);
            comboBox_largura_expositor.TabIndex = 12;
            comboBox_largura_expositor.DropDown += comboBox_largura_expositor_DropDown;
            comboBox_largura_expositor.SelectedIndexChanged += comboBox_largura_expositor_SelectedIndexChanged;
            // 
            // label_largura_expositor
            // 
            label_largura_expositor.AutoSize = true;
            label_largura_expositor.Enabled = false;
            label_largura_expositor.Location = new Point(212, 185);
            label_largura_expositor.Name = "label_largura_expositor";
            label_largura_expositor.Size = new Size(102, 15);
            label_largura_expositor.TabIndex = 11;
            label_largura_expositor.Text = "Largura expositor:";
            // 
            // comboBox_tamanho_expositor
            // 
            comboBox_tamanho_expositor.Enabled = false;
            comboBox_tamanho_expositor.FormattingEnabled = true;
            comboBox_tamanho_expositor.Location = new Point(7, 247);
            comboBox_tamanho_expositor.Name = "comboBox_tamanho_expositor";
            comboBox_tamanho_expositor.Size = new Size(185, 23);
            comboBox_tamanho_expositor.TabIndex = 14;
            comboBox_tamanho_expositor.DropDown += comboBox_tamanho_expositor_DropDown;
            comboBox_tamanho_expositor.SelectedIndexChanged += comboBox_tamanho_expositor_SelectedIndexChanged;
            // 
            // label_tamanho_expositor
            // 
            label_tamanho_expositor.AutoSize = true;
            label_tamanho_expositor.Enabled = false;
            label_tamanho_expositor.Location = new Point(7, 229);
            label_tamanho_expositor.Name = "label_tamanho_expositor";
            label_tamanho_expositor.Size = new Size(128, 15);
            label_tamanho_expositor.TabIndex = 13;
            label_tamanho_expositor.Text = "Tamanho do expositor:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(6, 3);
            label7.Name = "label7";
            label7.Size = new Size(42, 21);
            label7.TabIndex = 21;
            label7.Text = "Loja:";
            // 
            // comboBox_cor_externa_rodape
            // 
            comboBox_cor_externa_rodape.Enabled = false;
            comboBox_cor_externa_rodape.FormattingEnabled = true;
            comboBox_cor_externa_rodape.Location = new Point(212, 291);
            comboBox_cor_externa_rodape.Name = "comboBox_cor_externa_rodape";
            comboBox_cor_externa_rodape.Size = new Size(179, 23);
            comboBox_cor_externa_rodape.TabIndex = 20;
            comboBox_cor_externa_rodape.DropDown += comboBox_cor_externa_rodape_DropDown;
            comboBox_cor_externa_rodape.SelectedIndexChanged += comboBox_cor_externa_rodape_SelectedIndexChanged;
            // 
            // label_cor_externa_rodape
            // 
            label_cor_externa_rodape.AutoSize = true;
            label_cor_externa_rodape.Enabled = false;
            label_cor_externa_rodape.Location = new Point(212, 273);
            label_cor_externa_rodape.Name = "label_cor_externa_rodape";
            label_cor_externa_rodape.Size = new Size(111, 15);
            label_cor_externa_rodape.TabIndex = 19;
            label_cor_externa_rodape.Text = "Cor externa rodape:";
            // 
            // comboBox_cor_acabamento
            // 
            comboBox_cor_acabamento.Enabled = false;
            comboBox_cor_acabamento.FormattingEnabled = true;
            comboBox_cor_acabamento.Location = new Point(7, 291);
            comboBox_cor_acabamento.Name = "comboBox_cor_acabamento";
            comboBox_cor_acabamento.Size = new Size(185, 23);
            comboBox_cor_acabamento.TabIndex = 18;
            comboBox_cor_acabamento.DropDown += comboBox_cor_acabamento_DropDown;
            comboBox_cor_acabamento.SelectedIndexChanged += comboBox_cor_acabamento_SelectedIndexChanged;
            // 
            // label_cor_externa_acabamento
            // 
            label_cor_externa_acabamento.AutoSize = true;
            label_cor_externa_acabamento.Enabled = false;
            label_cor_externa_acabamento.Location = new Point(7, 273);
            label_cor_externa_acabamento.Name = "label_cor_externa_acabamento";
            label_cor_externa_acabamento.Size = new Size(140, 15);
            label_cor_externa_acabamento.TabIndex = 17;
            label_cor_externa_acabamento.Text = "Cor externa acabamento:";
            // 
            // comboBox_cor_interna
            // 
            comboBox_cor_interna.Enabled = false;
            comboBox_cor_interna.FormattingEnabled = true;
            comboBox_cor_interna.Location = new Point(212, 247);
            comboBox_cor_interna.Name = "comboBox_cor_interna";
            comboBox_cor_interna.Size = new Size(180, 23);
            comboBox_cor_interna.TabIndex = 16;
            comboBox_cor_interna.DropDown += comboBox_cor_interna_DropDown;
            comboBox_cor_interna.SelectedIndexChanged += comboBox_cor_interna_SelectedIndexChanged;
            // 
            // label_cor_interna
            // 
            label_cor_interna.AutoSize = true;
            label_cor_interna.Enabled = false;
            label_cor_interna.Location = new Point(212, 229);
            label_cor_interna.Name = "label_cor_interna";
            label_cor_interna.Size = new Size(69, 15);
            label_cor_interna.TabIndex = 15;
            label_cor_interna.Text = "Cor interna:";
            // 
            // comboBox_tipo_refrigeracao
            // 
            comboBox_tipo_refrigeracao.Enabled = false;
            comboBox_tipo_refrigeracao.FormattingEnabled = true;
            comboBox_tipo_refrigeracao.Location = new Point(212, 159);
            comboBox_tipo_refrigeracao.Name = "comboBox_tipo_refrigeracao";
            comboBox_tipo_refrigeracao.Size = new Size(180, 23);
            comboBox_tipo_refrigeracao.TabIndex = 31;
            comboBox_tipo_refrigeracao.DropDown += comboBox_tipo_refrigeracao_DropDown;
            comboBox_tipo_refrigeracao.SelectedIndexChanged += comboBox_tipo_refrigeracao_SelectedIndexChanged;
            // 
            // label_tipo_refrigeracao
            // 
            label_tipo_refrigeracao.AutoSize = true;
            label_tipo_refrigeracao.Enabled = false;
            label_tipo_refrigeracao.Location = new Point(212, 141);
            label_tipo_refrigeracao.Name = "label_tipo_refrigeracao";
            label_tipo_refrigeracao.Size = new Size(99, 15);
            label_tipo_refrigeracao.TabIndex = 30;
            label_tipo_refrigeracao.Text = "Tipo refrigeração:";
            // 
            // comboBox_cabeceira_esq
            // 
            comboBox_cabeceira_esq.Enabled = false;
            comboBox_cabeceira_esq.FormattingEnabled = true;
            comboBox_cabeceira_esq.Location = new Point(7, 335);
            comboBox_cabeceira_esq.Name = "comboBox_cabeceira_esq";
            comboBox_cabeceira_esq.Size = new Size(385, 23);
            comboBox_cabeceira_esq.TabIndex = 27;
            comboBox_cabeceira_esq.DropDown += comboBox_cabeceira_esq_DropDown;
            comboBox_cabeceira_esq.SelectedIndexChanged += comboBox_cabeceira_esq_SelectedIndexChanged;
            // 
            // label_cabeceira_esquerda
            // 
            label_cabeceira_esquerda.AutoSize = true;
            label_cabeceira_esquerda.Enabled = false;
            label_cabeceira_esquerda.Location = new Point(7, 317);
            label_cabeceira_esquerda.Name = "label_cabeceira_esquerda";
            label_cabeceira_esquerda.Size = new Size(113, 15);
            label_cabeceira_esquerda.TabIndex = 26;
            label_cabeceira_esquerda.Text = "Cabeceira esquerda:";
            // 
            // button_adicionar
            // 
            button_adicionar.Dock = DockStyle.Bottom;
            button_adicionar.Location = new Point(0, 783);
            button_adicionar.Name = "button_adicionar";
            button_adicionar.Size = new Size(398, 35);
            button_adicionar.TabIndex = 32;
            button_adicionar.Text = "Adicionar";
            button_adicionar.UseVisualStyleBackColor = true;
            button_adicionar.Click += button_adicionar_Click;
            // 
            // textBox_loja
            // 
            textBox_loja.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox_loja.Location = new Point(6, 27);
            textBox_loja.Name = "textBox_loja";
            textBox_loja.Size = new Size(392, 29);
            textBox_loja.TabIndex = 35;
            // 
            // label_cabeceira_dir
            // 
            label_cabeceira_dir.AutoSize = true;
            label_cabeceira_dir.Enabled = false;
            label_cabeceira_dir.Location = new Point(7, 361);
            label_cabeceira_dir.Name = "label_cabeceira_dir";
            label_cabeceira_dir.Size = new Size(98, 15);
            label_cabeceira_dir.TabIndex = 28;
            label_cabeceira_dir.Text = "Cabeceira direita:";
            // 
            // comboBox_cabeceira_dir
            // 
            comboBox_cabeceira_dir.Enabled = false;
            comboBox_cabeceira_dir.FormattingEnabled = true;
            comboBox_cabeceira_dir.Location = new Point(7, 379);
            comboBox_cabeceira_dir.Name = "comboBox_cabeceira_dir";
            comboBox_cabeceira_dir.Size = new Size(385, 23);
            comboBox_cabeceira_dir.TabIndex = 29;
            comboBox_cabeceira_dir.DropDown += comboBox_cabeceira_dir_DropDown;
            // 
            // panel3
            // 
            panel3.Controls.Add(tabControl1);
            panel3.Controls.Add(panel16);
            panel3.Controls.Add(panel2);
            panel3.Controls.Add(button_adicionar);
            panel3.Controls.Add(panel7);
            panel3.Dock = DockStyle.Left;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(398, 818);
            panel3.TabIndex = 36;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 415);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(398, 247);
            tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(tableLayoutPanel1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(390, 219);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Acessorios";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoScroll = true;
            tableLayoutPanel1.BackColor = SystemColors.Control;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.Size = new Size(384, 213);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panel16
            // 
            panel16.Controls.Add(numericUpDown_qtd_modelo);
            panel16.Controls.Add(label14);
            panel16.Dock = DockStyle.Bottom;
            panel16.Location = new Point(0, 662);
            panel16.Name = "panel16";
            panel16.Size = new Size(398, 27);
            panel16.TabIndex = 34;
            // 
            // numericUpDown_qtd_modelo
            // 
            numericUpDown_qtd_modelo.Dock = DockStyle.Left;
            numericUpDown_qtd_modelo.Location = new Point(148, 0);
            numericUpDown_qtd_modelo.Name = "numericUpDown_qtd_modelo";
            numericUpDown_qtd_modelo.Size = new Size(120, 23);
            numericUpDown_qtd_modelo.TabIndex = 1;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Dock = DockStyle.Left;
            label14.Location = new Point(0, 0);
            label14.Margin = new Padding(3);
            label14.Name = "label14";
            label14.Padding = new Padding(0, 4, 0, 0);
            label14.Size = new Size(148, 19);
            label14.TabIndex = 0;
            label14.Text = "Quantidade desse modelo:";
            // 
            // panel2
            // 
            panel2.Controls.Add(textBox_observacao);
            panel2.Controls.Add(label15);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 689);
            panel2.Name = "panel2";
            panel2.Size = new Size(398, 94);
            panel2.TabIndex = 33;
            // 
            // textBox_observacao
            // 
            textBox_observacao.Dock = DockStyle.Fill;
            textBox_observacao.Location = new Point(0, 15);
            textBox_observacao.Multiline = true;
            textBox_observacao.Name = "textBox_observacao";
            textBox_observacao.Size = new Size(398, 79);
            textBox_observacao.TabIndex = 0;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Dock = DockStyle.Top;
            label15.Location = new Point(0, 0);
            label15.Margin = new Padding(3);
            label15.Name = "label15";
            label15.Size = new Size(72, 15);
            label15.TabIndex = 1;
            label15.Text = "Observação:";
            // 
            // panel7
            // 
            panel7.Controls.Add(panel9);
            panel7.Controls.Add(label_cabeceira_dir);
            panel7.Controls.Add(comboBox_cabeceira_dir);
            panel7.Controls.Add(label_temperatura);
            panel7.Controls.Add(label_modelo_expositor);
            panel7.Controls.Add(label_tamanho_expositor);
            panel7.Controls.Add(label_cabeceira_esquerda);
            panel7.Controls.Add(label_cor_externa_acabamento);
            panel7.Controls.Add(comboBox_cor_externa_rodape);
            panel7.Dock = DockStyle.Top;
            panel7.Location = new Point(0, 0);
            panel7.Name = "panel7";
            panel7.Size = new Size(398, 415);
            panel7.TabIndex = 0;
            // 
            // panel9
            // 
            panel9.BackColor = SystemColors.ControlDark;
            panel9.Controls.Add(textBox_endereco);
            panel9.Controls.Add(label13);
            panel9.Controls.Add(label12);
            panel9.Controls.Add(textBox_UF);
            panel9.Controls.Add(textBox_cidade);
            panel9.Controls.Add(label8);
            panel9.Controls.Add(comboBox_vendedor);
            panel9.Controls.Add(label6);
            panel9.Controls.Add(comboBox_cliente);
            panel9.Controls.Add(label1);
            panel9.Dock = DockStyle.Top;
            panel9.Location = new Point(0, 0);
            panel9.Name = "panel9";
            panel9.Size = new Size(398, 138);
            panel9.TabIndex = 30;
            // 
            // textBox_endereco
            // 
            textBox_endereco.Location = new Point(7, 109);
            textBox_endereco.Name = "textBox_endereco";
            textBox_endereco.Size = new Size(384, 23);
            textBox_endereco.TabIndex = 9;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = SystemColors.ControlDark;
            label13.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label13.Location = new Point(7, 91);
            label13.Name = "label13";
            label13.Size = new Size(59, 15);
            label13.TabIndex = 8;
            label13.Text = "Endereço:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = SystemColors.ControlDark;
            label12.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label12.Location = new Point(258, 47);
            label12.Name = "label12";
            label12.Size = new Size(24, 15);
            label12.TabIndex = 7;
            label12.Text = "UF:";
            // 
            // textBox_UF
            // 
            textBox_UF.Location = new Point(258, 65);
            textBox_UF.Name = "textBox_UF";
            textBox_UF.Size = new Size(134, 23);
            textBox_UF.TabIndex = 6;
            // 
            // textBox_cidade
            // 
            textBox_cidade.Location = new Point(7, 65);
            textBox_cidade.Name = "textBox_cidade";
            textBox_cidade.Size = new Size(245, 23);
            textBox_cidade.TabIndex = 5;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = SystemColors.ControlDark;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(7, 47);
            label8.Name = "label8";
            label8.Size = new Size(47, 15);
            label8.TabIndex = 4;
            label8.Text = "Cidade:";
            // 
            // comboBox_vendedor
            // 
            comboBox_vendedor.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            comboBox_vendedor.FormattingEnabled = true;
            comboBox_vendedor.Location = new Point(212, 21);
            comboBox_vendedor.Name = "comboBox_vendedor";
            comboBox_vendedor.Size = new Size(179, 23);
            comboBox_vendedor.TabIndex = 3;
            comboBox_vendedor.DropDown += comboBox_vendedor_DropDown;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = SystemColors.ControlDark;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(212, 3);
            label6.Name = "label6";
            label6.Size = new Size(60, 15);
            label6.TabIndex = 2;
            label6.Text = "Vendedor:";
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.ControlDark;
            panel4.Controls.Add(label_calcular_novamente);
            panel4.Controls.Add(panel1);
            panel4.Controls.Add(panel15);
            panel4.Controls.Add(panel14);
            panel4.Controls.Add(button_salvar);
            panel4.Controls.Add(panel8);
            panel4.Controls.Add(label7);
            panel4.Controls.Add(textBox_loja);
            panel4.Controls.Add(textBox_num_cotacao);
            panel4.Controls.Add(label2);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(398, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(1468, 59);
            panel4.TabIndex = 37;
            // 
            // label_calcular_novamente
            // 
            label_calcular_novamente.AutoSize = true;
            label_calcular_novamente.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label_calcular_novamente.ForeColor = Color.Red;
            label_calcular_novamente.Location = new Point(676, 34);
            label_calcular_novamente.Name = "label_calcular_novamente";
            label_calcular_novamente.Size = new Size(163, 21);
            label_calcular_novamente.TabIndex = 45;
            label_calcular_novamente.Text = "Calcular novamente";
            label_calcular_novamente.Visible = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(button_calcular);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(839, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(83, 59);
            panel1.TabIndex = 44;
            // 
            // button_calcular
            // 
            button_calcular.Location = new Point(3, 32);
            button_calcular.Name = "button_calcular";
            button_calcular.Size = new Size(75, 23);
            button_calcular.TabIndex = 39;
            button_calcular.Text = "Calcular";
            button_calcular.UseVisualStyleBackColor = true;
            button_calcular.Click += button_calcular_Click;
            // 
            // panel15
            // 
            panel15.Controls.Add(txtPorcentagem);
            panel15.Controls.Add(label10);
            panel15.Controls.Add(label11);
            panel15.Dock = DockStyle.Right;
            panel15.Location = new Point(922, 0);
            panel15.Name = "panel15";
            panel15.Size = new Size(199, 59);
            panel15.TabIndex = 39;
            // 
            // txtPorcentagem
            // 
            txtPorcentagem.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtPorcentagem.Location = new Point(35, 27);
            txtPorcentagem.Name = "txtPorcentagem";
            txtPorcentagem.Size = new Size(162, 29);
            txtPorcentagem.TabIndex = 38;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label10.ForeColor = SystemColors.ControlText;
            label10.Location = new Point(6, 35);
            label10.Name = "label10";
            label10.Size = new Size(24, 21);
            label10.TabIndex = 40;
            label10.Text = "%";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label11.ForeColor = SystemColors.ControlText;
            label11.Location = new Point(35, 3);
            label11.Name = "label11";
            label11.Size = new Size(115, 21);
            label11.TabIndex = 39;
            label11.Text = "Desconto/Over";
            // 
            // panel14
            // 
            panel14.Controls.Add(txtValorFechado);
            panel14.Controls.Add(label9);
            panel14.Dock = DockStyle.Right;
            panel14.Location = new Point(1121, 0);
            panel14.Name = "panel14";
            panel14.Size = new Size(172, 59);
            panel14.TabIndex = 38;
            // 
            // txtValorFechado
            // 
            txtValorFechado.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtValorFechado.Location = new Point(6, 27);
            txtValorFechado.Name = "txtValorFechado";
            txtValorFechado.Size = new Size(162, 29);
            txtValorFechado.TabIndex = 38;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label9.ForeColor = SystemColors.ControlText;
            label9.Location = new Point(6, 3);
            label9.Name = "label9";
            label9.Size = new Size(108, 21);
            label9.TabIndex = 39;
            label9.Text = "Valor fechado:";
            // 
            // button_salvar
            // 
            button_salvar.Location = new Point(401, 33);
            button_salvar.Name = "button_salvar";
            button_salvar.Size = new Size(75, 23);
            button_salvar.TabIndex = 37;
            button_salvar.Text = "Salvar";
            button_salvar.UseVisualStyleBackColor = true;
            button_salvar.Click += button_salvar_Click;
            // 
            // panel8
            // 
            panel8.Controls.Add(textBox_valor);
            panel8.Controls.Add(label_valor);
            panel8.Dock = DockStyle.Right;
            panel8.Location = new Point(1293, 0);
            panel8.Name = "panel8";
            panel8.Size = new Size(175, 59);
            panel8.TabIndex = 36;
            // 
            // textBox_valor
            // 
            textBox_valor.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox_valor.Location = new Point(6, 26);
            textBox_valor.Name = "textBox_valor";
            textBox_valor.ReadOnly = true;
            textBox_valor.Size = new Size(162, 29);
            textBox_valor.TabIndex = 38;
            // 
            // label_valor
            // 
            label_valor.AutoSize = true;
            label_valor.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label_valor.ForeColor = SystemColors.ControlText;
            label_valor.Location = new Point(6, 2);
            label_valor.Name = "label_valor";
            label_valor.Size = new Size(84, 21);
            label_valor.TabIndex = 39;
            label_valor.Text = "Valor total:";
            // 
            // panel5
            // 
            panel5.Controls.Add(button_imprimir);
            panel5.Controls.Add(button_deletar);
            panel5.Controls.Add(button_voltar);
            panel5.Dock = DockStyle.Bottom;
            panel5.Location = new Point(398, 783);
            panel5.Name = "panel5";
            panel5.Size = new Size(1468, 35);
            panel5.TabIndex = 38;
            // 
            // button_imprimir
            // 
            button_imprimir.Dock = DockStyle.Right;
            button_imprimir.Location = new Point(943, 0);
            button_imprimir.Name = "button_imprimir";
            button_imprimir.Size = new Size(175, 35);
            button_imprimir.TabIndex = 37;
            button_imprimir.Text = "Imprimir";
            button_imprimir.UseVisualStyleBackColor = true;
            button_imprimir.Click += button_imprimir_Click;
            // 
            // button_deletar
            // 
            button_deletar.Dock = DockStyle.Right;
            button_deletar.Location = new Point(1118, 0);
            button_deletar.Name = "button_deletar";
            button_deletar.Size = new Size(175, 35);
            button_deletar.TabIndex = 36;
            button_deletar.Text = "Deletar";
            button_deletar.UseVisualStyleBackColor = true;
            button_deletar.Click += button_deletar_Click;
            // 
            // button_voltar
            // 
            button_voltar.Dock = DockStyle.Right;
            button_voltar.Location = new Point(1293, 0);
            button_voltar.Name = "button_voltar";
            button_voltar.Size = new Size(175, 35);
            button_voltar.TabIndex = 35;
            button_voltar.Text = "Voltar";
            button_voltar.UseVisualStyleBackColor = true;
            button_voltar.Click += button_voltar_Click;
            // 
            // panel11
            // 
            panel11.Controls.Add(label4);
            panel11.Dock = DockStyle.Top;
            panel11.Location = new Point(0, 0);
            panel11.Name = "panel11";
            panel11.Size = new Size(1468, 28);
            panel11.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(3, 4);
            label4.Name = "label4";
            label4.Size = new Size(80, 21);
            label4.TabIndex = 0;
            label4.Text = "Modelos:";
            // 
            // dataGridView_Modelo
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView_Modelo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView_Modelo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView_Modelo.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView_Modelo.Dock = DockStyle.Top;
            dataGridView_Modelo.Location = new Point(0, 28);
            dataGridView_Modelo.Name = "dataGridView_Modelo";
            dataGridView_Modelo.RowTemplate.Height = 25;
            dataGridView_Modelo.Size = new Size(1468, 300);
            dataGridView_Modelo.TabIndex = 2;
            dataGridView_Modelo.CellFormatting += dataGridView_Modelo_CellFormatting;
            dataGridView_Modelo.SelectionChanged += dataGridView_Modelo_SelectionChanged;
            // 
            // panel12
            // 
            panel12.Controls.Add(label5);
            panel12.Dock = DockStyle.Top;
            panel12.Location = new Point(0, 328);
            panel12.Name = "panel12";
            panel12.Size = new Size(1468, 28);
            panel12.TabIndex = 3;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(3, 4);
            label5.Name = "label5";
            label5.Size = new Size(70, 21);
            label5.TabIndex = 0;
            label5.Text = "Interno:";
            // 
            // dataGridView_Acessorios
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dataGridView_Acessorios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridView_Acessorios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dataGridView_Acessorios.DefaultCellStyle = dataGridViewCellStyle4;
            dataGridView_Acessorios.Dock = DockStyle.Fill;
            dataGridView_Acessorios.Location = new Point(0, 356);
            dataGridView_Acessorios.Name = "dataGridView_Acessorios";
            dataGridView_Acessorios.RowTemplate.Height = 25;
            dataGridView_Acessorios.Size = new Size(1468, 368);
            dataGridView_Acessorios.TabIndex = 4;
            dataGridView_Acessorios.CellFormatting += dataGridView_Acessorios_CellFormatting;
            dataGridView_Acessorios.SelectionChanged += dataGridView_Acessorios_SelectionChanged;
            // 
            // panel6
            // 
            panel6.Controls.Add(dataGridView_Acessorios);
            panel6.Controls.Add(panel12);
            panel6.Controls.Add(dataGridView_Modelo);
            panel6.Controls.Add(panel11);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(398, 59);
            panel6.Name = "panel6";
            panel6.Size = new Size(1468, 724);
            panel6.TabIndex = 39;
            // 
            // panel13
            // 
            panel13.Controls.Add(dataGridView_cabeceira);
            panel13.Dock = DockStyle.Bottom;
            panel13.Location = new Point(398, 686);
            panel13.Name = "panel13";
            panel13.Size = new Size(1468, 97);
            panel13.TabIndex = 44;
            // 
            // dataGridView_cabeceira
            // 
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.Control;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dataGridView_cabeceira.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dataGridView_cabeceira.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Window;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dataGridView_cabeceira.DefaultCellStyle = dataGridViewCellStyle6;
            dataGridView_cabeceira.Dock = DockStyle.Fill;
            dataGridView_cabeceira.Location = new Point(0, 0);
            dataGridView_cabeceira.Name = "dataGridView_cabeceira";
            dataGridView_cabeceira.RowTemplate.Height = 25;
            dataGridView_cabeceira.Size = new Size(1468, 97);
            dataGridView_cabeceira.TabIndex = 0;
            dataGridView_cabeceira.CellFormatting += dataGridView_cabeceira_CellFormatting;
            dataGridView_cabeceira.SelectionChanged += dataGridView_cabeceira_SelectionChanged;
            // 
            // panel10
            // 
            panel10.Controls.Add(label3);
            panel10.Dock = DockStyle.Bottom;
            panel10.Location = new Point(398, 658);
            panel10.Name = "panel10";
            panel10.Size = new Size(1468, 28);
            panel10.TabIndex = 45;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(3, 4);
            label3.Name = "label3";
            label3.Size = new Size(89, 21);
            label3.TabIndex = 0;
            label3.Text = "Cabeceira:";
            // 
            // Form_GerarOrcamentos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1866, 818);
            Controls.Add(panel10);
            Controls.Add(panel13);
            Controls.Add(panel6);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(comboBox_tipo_refrigeracao);
            Controls.Add(label_tipo_refrigeracao);
            Controls.Add(comboBox_cabeceira_esq);
            Controls.Add(label_cor_externa_rodape);
            Controls.Add(comboBox_cor_acabamento);
            Controls.Add(comboBox_cor_interna);
            Controls.Add(label_cor_interna);
            Controls.Add(comboBox_tamanho_expositor);
            Controls.Add(comboBox_largura_expositor);
            Controls.Add(label_largura_expositor);
            Controls.Add(comboBox_expositor);
            Controls.Add(comboBox_Temperatura);
            Controls.Add(panel3);
            Name = "Form_GerarOrcamentos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form_GerarPedidos";
            WindowState = FormWindowState.Maximized;
            Load += Form_GerarOrcamentos_Load;
            panel3.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            panel16.ResumeLayout(false);
            panel16.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_qtd_modelo).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel1.ResumeLayout(false);
            panel15.ResumeLayout(false);
            panel15.PerformLayout();
            panel14.ResumeLayout(false);
            panel14.PerformLayout();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel5.ResumeLayout(false);
            panel11.ResumeLayout(false);
            panel11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_Modelo).EndInit();
            panel12.ResumeLayout(false);
            panel12.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_Acessorios).EndInit();
            panel6.ResumeLayout(false);
            panel13.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView_cabeceira).EndInit();
            panel10.ResumeLayout(false);
            panel10.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox comboBox_cliente;
        private TextBox textBox_num_cotacao;
        private Label label2;
        private ComboBox comboBox_Temperatura;
        private Label label_temperatura;
        private ComboBox comboBox_expositor;
        private Label label_modelo_expositor;
        private ComboBox comboBox_largura_expositor;
        private Label label_largura_expositor;
        private ComboBox comboBox_tamanho_expositor;
        private Label label_tamanho_expositor;
        private Label label7;
        private ComboBox comboBox_cor_externa_rodape;
        private Label label_cor_externa_rodape;
        private ComboBox comboBox_cor_acabamento;
        private Label label_cor_externa_acabamento;
        private ComboBox comboBox_cor_interna;
        private Label label_cor_interna;
        private ComboBox comboBox_tipo_refrigeracao;
        private Label label_tipo_refrigeracao;
        private ComboBox comboBox_cabeceira_esq;
        private Label label_cabeceira_esquerda;
        private Button button_adicionar;
        private TextBox textBox_loja;
        private Label label_cabeceira_dir;
        private ComboBox comboBox_cabeceira_dir;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Button button_voltar;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private Panel panel7;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel8;
        private TextBox textBox_valor;
        private Label label_valor;
        private Panel panel9;
        private Button button_deletar;
        private Button button_salvar;
        private Panel panel11;
        private Label label4;
        private DataGridView dataGridView_Modelo;
        private Panel panel12;
        private Label label5;
        private DataGridView dataGridView_Acessorios;
        private Panel panel6;
        private Panel panel13;
        private DataGridView dataGridView_cabeceira;
        private Panel panel10;
        private Label label3;
        private Label label6;
        private Panel panel14;
        private TextBox txtValorFechado;
        private Label label8;
        private Label label9;
        private Panel panel15;
        private TextBox txtPorcentagem;
        private Label label10;
        private Label label11;
        private Panel panel1;
        private Button button_calcular;
        private Label label_calcular_novamente;
        private Button button_imprimir;
        private ComboBox comboBox_vendedor;
        private Label label12;
        private TextBox textBox_UF;
        private TextBox textBox_cidade;
        private TextBox textBox_endereco;
        private Label label13;
        private Panel panel2;
        private NumericUpDown numericUpDown_qtd_modelo;
        private Label label14;
        private Panel panel16;
        private TextBox textBox_observacao;
        private Label label15;
    }
}