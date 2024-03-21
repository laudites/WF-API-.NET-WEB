using B_Sync_Pro.API.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace B_Sync_Pro.Forms
{
    public partial class Form_Menu : Form
    {
        private Form_GerarOrcamentos gerarPedidos;
        private Form_cadastrar_expositor cadastrarProdutos;
        private Form_cadastrar_acessorios_new cadastrarAcessoriosNew;
        private Form_Cabeceira CadastrarCabeceira;

        string Banco = "BANCODEDADOS";
        string Instancia = @"SERVIDOR";
        string Senha = "SENHA";
        string Usuario = "sa";

        string token;
        public Form_Menu(string code)
        {
            Cursor.Current = Cursors.WaitCursor;
            InitializeComponent();
            token = code;
            CarregarProdutos();
            Cursor.Current = Cursors.Default;
        }

        private async void CarregarProdutos()
        {
            await ProdutosBling.BuscarProdutosBling(token);
        }

   
   
        private void button_GerarPedidos_Click(object sender, EventArgs e)
        {
            gerarPedidos = new Form_GerarOrcamentos(token,"novo","novo");
            this.Hide();
            gerarPedidos.FormClosed += FormMenu_FormClosed;
            gerarPedidos.Show();
        }
        private void FormMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit(); // ou Environment.Exit(0);
        }

        private void button_cadastrar_expositor_Click(object sender, EventArgs e)
        {
            cadastrarProdutos = new Form_cadastrar_expositor(token);
            this.Hide();
            cadastrarProdutos.FormClosed += FormMenu_FormClosed;
            cadastrarProdutos.Show();
        }

        private void button_produtos_Click(object sender, EventArgs e)
        {
            showSubMenu_produtos(SubPanel_produtos);
        }

       
        private void showSubMenu_produtos(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu_produtos();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }
        private void hideSubMenu_produtos()
        {
            if (SubPanel_produtos.Visible == true)
                SubPanel_produtos.Visible = false;
        }


        private void button_Cadastrar_acessorios_new_Click(object sender, EventArgs e)
        {
            cadastrarAcessoriosNew = new Form_cadastrar_acessorios_new(token);
            this.Hide();
            cadastrarAcessoriosNew.FormClosed += FormMenu_FormClosed;
            cadastrarAcessoriosNew.Show();
        }

        private void button_cabeceira_Click(object sender, EventArgs e)
        {
            CadastrarCabeceira = new Form_Cabeceira(token);
            this.Hide();
            CadastrarCabeceira.FormClosed += FormMenu_FormClosed;
            CadastrarCabeceira.Show();
        }

        private void Form_Menu_Load(object sender, EventArgs e)
        {
            Carregar_datagrid();
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
        }

        private void Carregar_datagrid()
        {
            // Defina sua string de conexão com o SQL Server
            string connectionString = @"Data Source=" + Instancia + ";Initial Catalog=" + Banco + ";Persist Security Info=True;User ID=" + Usuario + ";Password=" + Senha;

            // Crie uma conexão com o SQL Server
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Defina a consulta SQL que deseja executar
                    string query = "select Num_Cotacao,Cliente,Loja,Valor_total,Valor_fechado,porcent_desconto_over,Vendedor from OrcCabecalho order by Num_cotacao";

                    // Crie um adaptador SQL para executar a consulta
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                    // Crie um DataSet para armazenar os resultados da consulta
                    DataSet dataSet = new DataSet();

                    // Preencha o DataSet com os resultados da consulta
                    adapter.Fill(dataSet);

                    // Vincule o DataSet ao DataGridView
                    dataGridView1.DataSource = dataSet.Tables[0];
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro: " + ex.Message);
                }
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            // Verifique se há pelo menos uma linha selecionada
            if (dataGridView1.SelectedRows.Count == 1)
            {
                // Obtenha o valor da coluna "Num_Orcamento" da linha selecionada
                string numOrcamento = dataGridView1.SelectedRows[0].Cells["Num_cotacao"].Value.ToString();

                // Exiba o valor em um Label
                label_num_orcamento.Text = numOrcamento;
            }       
            button_Editar.Enabled = true;
            button_deletar.Enabled = true;
        }

        private void button_nova_rev_Click(object sender, EventArgs e)
        {
            // Verifique se há pelo menos uma linha selecionada no DataGridView
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Obtenha o valor da coluna "Num_Cotacao" da linha selecionada
                string numCotacao = dataGridView1.SelectedRows[0].Cells["Num_Cotacao"].Value.ToString();

                // Crie o formulário Form_GerarOrcamentos e passe o valor da coluna como argumento
                gerarPedidos = new Form_GerarOrcamentos(token, numCotacao,"revisao");
                this.Hide();
                gerarPedidos.FormClosed += FormMenu_FormClosed;
                gerarPedidos.Show();
            }
            else
            {
                MessageBox.Show("Nenhuma linha selecionada.");
            }
        }

        private void button_Editar_Click(object sender, EventArgs e)
        {
            // Verifique se há pelo menos uma linha selecionada no DataGridView
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string numCotacao = dataGridView1.SelectedRows[0].Cells["Num_Cotacao"].Value.ToString();
            gerarPedidos = new Form_GerarOrcamentos(token, numCotacao,"editar");
            this.Hide();
            gerarPedidos.FormClosed += FormMenu_FormClosed;
            gerarPedidos.Show();
            }
            else
            {
                MessageBox.Show("Nenhuma linha selecionada.");
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Verifique se a formatação é aplicada à coluna "Valor_total" (coluna 4)
            if (e.ColumnIndex == 3 && e.RowIndex >= 0)
            {
                if (e.Value != null && float.TryParse(e.Value.ToString(), out float valor))
                {
                    // Formate o valor como moeda
                    e.Value = valor.ToString("C");
                    e.FormattingApplied = true;
                }
            }
        }

        private void button_deletar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Obtém o número de cotação da linha selecionada no DataGridView
                string numCotacao = dataGridView1.SelectedRows[0].Cells["Num_Cotacao"].Value.ToString();

                // Configura a string de conexão com o banco de dados
                string connectionString = @"Data Source=" + Instancia + ";Initial Catalog=" + Banco + ";Persist Security Info=True;User ID=" + Usuario + ";Password=" + Senha;

                // Cria uma conexão com o banco de dados
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        // Abre a conexão
                        connection.Open();

                        // Cria a instrução SQL para excluir a linha com o número de cotação correspondente
                        string sql = "delete from OrcAcessorio where Num_cotacao = @NumCotacao \n" +
                                        "delete from OrcCabeceira where Num_cotacao = @NumCotacao \n" +
                                        "delete from OrcModelo where Num_cotacao = @NumCotacao \n" +
                                        "delete from OrcCabecalho where Num_cotacao = @NumCotacao";

                        // Cria um comando SQL
                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            // Define o parâmetro @NumCotacao
                            command.Parameters.AddWithValue("@NumCotacao", numCotacao);

                            // Executa o comando SQL
                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Registro excluído com sucesso.");
                            }
                            else
                            {
                                MessageBox.Show("Nenhum registro foi excluído.");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocorreu um erro: " + ex.Message);
                    }
                }
                Carregar_datagrid();
            }
            else
            {
                MessageBox.Show("Nenhuma linha selecionada.");
            }
        }


    }
}