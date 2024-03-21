namespace B_Sync_Pro.Forms
{
    partial class Form_Menu
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button_deletar = new System.Windows.Forms.Button();
            this.button_Editar = new System.Windows.Forms.Button();
            this.button_GerarOrcamentos = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label_num_orcamento = new System.Windows.Forms.Label();
            this.SubPanel_produtos = new System.Windows.Forms.Panel();
            this.button_Cadastrar_acessorios_new = new System.Windows.Forms.Button();
            this.button_cabeceira = new System.Windows.Forms.Button();
            this.button_cadastrar_expositor = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button_produtos = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SubPanel_produtos.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.SubPanel_produtos);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(150, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1131, 566);
            this.panel1.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridView1);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(150, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(981, 566);
            this.panel3.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 48);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(981, 518);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.button_deletar);
            this.panel4.Controls.Add(this.button_Editar);
            this.panel4.Controls.Add(this.button_GerarOrcamentos);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(981, 48);
            this.panel4.TabIndex = 0;
            // 
            // button_deletar
            // 
            this.button_deletar.Enabled = false;
            this.button_deletar.Location = new System.Drawing.Point(168, 11);
            this.button_deletar.Name = "button_deletar";
            this.button_deletar.Size = new System.Drawing.Size(75, 23);
            this.button_deletar.TabIndex = 5;
            this.button_deletar.Text = "Deletar";
            this.button_deletar.UseVisualStyleBackColor = true;
            this.button_deletar.Click += new System.EventHandler(this.button_deletar_Click);
            // 
            // button_Editar
            // 
            this.button_Editar.Enabled = false;
            this.button_Editar.Location = new System.Drawing.Point(87, 11);
            this.button_Editar.Name = "button_Editar";
            this.button_Editar.Size = new System.Drawing.Size(75, 23);
            this.button_Editar.TabIndex = 4;
            this.button_Editar.Text = "Editar";
            this.button_Editar.UseVisualStyleBackColor = true;
            this.button_Editar.Click += new System.EventHandler(this.button_Editar_Click);
            // 
            // button_GerarOrcamentos
            // 
            this.button_GerarOrcamentos.Location = new System.Drawing.Point(6, 11);
            this.button_GerarOrcamentos.Name = "button_GerarOrcamentos";
            this.button_GerarOrcamentos.Size = new System.Drawing.Size(75, 23);
            this.button_GerarOrcamentos.TabIndex = 3;
            this.button_GerarOrcamentos.Text = "Novo";
            this.button_GerarOrcamentos.UseVisualStyleBackColor = true;
            this.button_GerarOrcamentos.Click += new System.EventHandler(this.button_GerarPedidos_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label_num_orcamento);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(869, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(112, 48);
            this.panel5.TabIndex = 2;
            // 
            // label_num_orcamento
            // 
            this.label_num_orcamento.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_num_orcamento.AutoSize = true;
            this.label_num_orcamento.Location = new System.Drawing.Point(15, 15);
            this.label_num_orcamento.Name = "label_num_orcamento";
            this.label_num_orcamento.Size = new System.Drawing.Size(82, 15);
            this.label_num_orcamento.TabIndex = 0;
            this.label_num_orcamento.Text = "N. Orcamento";
            // 
            // SubPanel_produtos
            // 
            this.SubPanel_produtos.Controls.Add(this.button_Cadastrar_acessorios_new);
            this.SubPanel_produtos.Controls.Add(this.button_cabeceira);
            this.SubPanel_produtos.Controls.Add(this.button_cadastrar_expositor);
            this.SubPanel_produtos.Dock = System.Windows.Forms.DockStyle.Left;
            this.SubPanel_produtos.Location = new System.Drawing.Point(0, 0);
            this.SubPanel_produtos.Name = "SubPanel_produtos";
            this.SubPanel_produtos.Size = new System.Drawing.Size(150, 566);
            this.SubPanel_produtos.TabIndex = 1;
            this.SubPanel_produtos.Visible = false;
            // 
            // button_Cadastrar_acessorios_new
            // 
            this.button_Cadastrar_acessorios_new.Dock = System.Windows.Forms.DockStyle.Top;
            this.button_Cadastrar_acessorios_new.Location = new System.Drawing.Point(0, 60);
            this.button_Cadastrar_acessorios_new.Name = "button_Cadastrar_acessorios_new";
            this.button_Cadastrar_acessorios_new.Size = new System.Drawing.Size(150, 30);
            this.button_Cadastrar_acessorios_new.TabIndex = 8;
            this.button_Cadastrar_acessorios_new.Text = "Cadastrar acessorios";
            this.button_Cadastrar_acessorios_new.UseVisualStyleBackColor = true;
            this.button_Cadastrar_acessorios_new.Click += new System.EventHandler(this.button_Cadastrar_acessorios_new_Click);
            // 
            // button_cabeceira
            // 
            this.button_cabeceira.Dock = System.Windows.Forms.DockStyle.Top;
            this.button_cabeceira.Location = new System.Drawing.Point(0, 30);
            this.button_cabeceira.Name = "button_cabeceira";
            this.button_cabeceira.Size = new System.Drawing.Size(150, 30);
            this.button_cabeceira.TabIndex = 7;
            this.button_cabeceira.Text = "Cadastrar cabeceira";
            this.button_cabeceira.UseVisualStyleBackColor = true;
            this.button_cabeceira.Click += new System.EventHandler(this.button_cabeceira_Click);
            // 
            // button_cadastrar_expositor
            // 
            this.button_cadastrar_expositor.Dock = System.Windows.Forms.DockStyle.Top;
            this.button_cadastrar_expositor.Location = new System.Drawing.Point(0, 0);
            this.button_cadastrar_expositor.Name = "button_cadastrar_expositor";
            this.button_cadastrar_expositor.Size = new System.Drawing.Size(150, 30);
            this.button_cadastrar_expositor.TabIndex = 3;
            this.button_cadastrar_expositor.Text = "Cadastrar expositor";
            this.button_cadastrar_expositor.UseVisualStyleBackColor = true;
            this.button_cadastrar_expositor.Click += new System.EventHandler(this.button_cadastrar_expositor_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button_produtos);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(150, 566);
            this.panel2.TabIndex = 3;
            // 
            // button_produtos
            // 
            this.button_produtos.Dock = System.Windows.Forms.DockStyle.Top;
            this.button_produtos.Location = new System.Drawing.Point(0, 0);
            this.button_produtos.Name = "button_produtos";
            this.button_produtos.Size = new System.Drawing.Size(150, 30);
            this.button_produtos.TabIndex = 1;
            this.button_produtos.Text = "Produtos";
            this.button_produtos.UseVisualStyleBackColor = true;
            this.button_produtos.Click += new System.EventHandler(this.button_produtos_Click);
            // 
            // Form_Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1281, 566);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "Form_Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_Produto";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form_Menu_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.SubPanel_produtos.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Panel panel1;
        private Panel panel2;
        private Button button_GerarOrcamentos;
        private Button button_produtos;
        private Button button_cadastrar_expositor;
        private Panel SubPanel_produtos;
        private Button button_Cadastrar_acessorios_new;
        private Button button_cabeceira;
        private Panel panel3;
        private DataGridView dataGridView1;
        private Panel panel4;
        private Panel panel5;
        private Label label_num_orcamento;
        private Button button_nova_rev;
        private Button button_Editar;
        private Button button_deletar;
    }
}