using ClosedXML.Excel;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace B_Sync_Pro.Forms
{
    public partial class Form_cadastrar_expositor : Form
    {
        string accessToken = "";
        private Form_Menu Menu;
        private Form_Cabeceira CadastrarCabeceira;
        private Form_cadastrar_acessorios_new CadastrarAcessorio;
        string Banco = "BANCODEDADOS";
        string Instancia = @"SERVIDOR";
        string Senha = "SENHA";
        string Usuario = "sa";
        private DataTable dataTable;
        int id;

        public Form_cadastrar_expositor(string token)
        {
            Cursor.Current = Cursors.WaitCursor;
            InitializeComponent();
            accessToken = token;
            dataTable = new DataTable();
            Carregar_Comprimento();
            //Carregar_Linha_Expositor();
            Carregar_Profundidade();
            Carregar_Resfriamento();
            Carregar_Situacao();    
            Carregar_Tipo();
            Atualizar();
            Cursor.Current = Cursors.Default;
        }

        private void FormMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit(); // ou Environment.Exit(0);
        }

        private void button_Cadastrar_Click(object sender, EventArgs e)
        {
            if (textBox_modelo.TextLength < 1)
            {
                MessageBox.Show("Modelo esta vazio!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Sai do método sem executar o procedimento
            }
            if (textBox_skugeral.TextLength < 1)
            {
                MessageBox.Show("SKU Geral esta vazio!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Sai do método sem executar o procedimento
            }
            if (comboBox_tipo.Text == "")
            {
                MessageBox.Show("Tipo esta vazio!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Sai do método sem executar o procedimento
            }
            if (comboBox_resfriamento.Text == "")
            {
                MessageBox.Show("Resfriamento esta vazio!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Sai do método sem executar o procedimento
            }
            if (comboBox_situacao.Text == "")
            {
                MessageBox.Show("Situação esta vazio!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Sai do método sem executar o procedimento
            }
            /*if (comboBox_linha.Text == "")
            {
                MessageBox.Show("Linha esta vazio!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Sai do método sem executar o procedimento
            }*/
            if (comboBox_profundidade.Text == "")
            {
                MessageBox.Show("Profundidade esta vazio!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Sai do método sem executar o procedimento
            }
            if (comboBox_comprimento.Text == "")
            {
                MessageBox.Show("Comprimento esta vazio!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Sai do método sem executar o procedimento
            }

            Cursor.Current = Cursors.WaitCursor;
            //SqlConnection con = new SqlConnection(@"Data Source=" + Instancia + ";Initial Catalog=" + Banco + ";Persist Security Info=True;User ID=" + Usuario + ";Password=" + Senha + "");
            //con.Open();
            DialogResult resultado = MessageBox.Show("Deseja realmente salvar?", "Salvar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                try
                {
                    // Deletar o registro do banco de dados
                    using (SqlConnection con = new SqlConnection(@"Data Source=" + Instancia + ";Initial Catalog=" + Banco + ";Persist Security Info=True;User ID=" + Usuario + ";Password=" + Senha))
                    {
                        con.Open();
                        using (SqlTransaction transaction = con.BeginTransaction())
                        {
                            string query = "INSERT INTO Modelo_Eng VALUES (@Modelo, @Tipo, @Resfriamento, @Situacao, @Linha, @Profundidade, @Comprimento, @SKU_Geral, @Observacao);";
                            using (SqlCommand cmd = new SqlCommand(query, con, transaction))
                            {
                                cmd.Parameters.AddWithValue("@Modelo", textBox_modelo.Text);
                                cmd.Parameters.AddWithValue("@Tipo", comboBox_tipo.Text);
                                cmd.Parameters.AddWithValue("@Resfriamento", comboBox_resfriamento.Text);
                                cmd.Parameters.AddWithValue("@Situacao", comboBox_situacao.Text);
                                cmd.Parameters.AddWithValue("@Linha", comboBox_linha.Text);
                                cmd.Parameters.AddWithValue("@Profundidade", comboBox_profundidade.Text);
                                cmd.Parameters.AddWithValue("@Comprimento", comboBox_comprimento.Text);
                                cmd.Parameters.AddWithValue("@SKU_Geral", textBox_skugeral.Text);
                                cmd.Parameters.AddWithValue("@Observacao", textBox_observacao.Text);
                                cmd.ExecuteNonQuery();
                            }
                            transaction.Commit();
                        }
                        con.Close();
                    }
                    
                    MessageBox.Show("Arquivo Criado!");
                    LimparCampo();
                    Atualizar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void LimparCampo()
        {
            textBox_modelo.Text = "";
            textBox_skugeral.Text = "";
            comboBox_tipo.Text = "";
            comboBox_resfriamento.Text = "";
            comboBox_situacao.Text = "";
            comboBox_linha.Text = "";
            comboBox_profundidade.Text = "";
            comboBox_comprimento.Text = "";
            textBox_observacao.Text = "";

        }

        private void button_Voltar_Click(object sender, EventArgs e)
        {
            Menu = new Form_Menu(accessToken);
            this.Hide();
            Menu.FormClosed += FormMenu_FormClosed;
            Menu.Show();
        }

        private void Carregar_Tipo()
        {
            string connectionString = @"Data Source=SERVIDOR;Initial Catalog=BANCODEDADOS;Persist Security Info=True;User ID=sa;Password=SENHA";
            string query = "select resfriamento from Modelo_Familia_Eng"; // Substitua pelo nome correto da coluna e tabela

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Limpe os itens existentes no ComboBox
                        comboBox_tipo.Items.Clear();

                        // Preencha o ComboBox com os dados do DataTable
                        foreach (DataRow row in dataTable.Rows)
                        {
                            comboBox_tipo.Items.Add(row["resfriamento"].ToString());
                        }
                    }
                }
                connection.Close();
            }
        }

        private void Carregar_Resfriamento()
        {
            string connectionString = @"Data Source=SERVIDOR;Initial Catalog=BANCODEDADOS;Persist Security Info=True;User ID=sa;Password=SENHA";
            string query = "select regime from Modelo_Regime_Eng"; // Substitua pelo nome correto da coluna e tabela

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Limpe os itens existentes no ComboBox
                        comboBox_resfriamento.Items.Clear();

                        // Preencha o ComboBox com os dados do DataTable
                        foreach (DataRow row in dataTable.Rows)
                        {
                            comboBox_resfriamento.Items.Add(row["regime"].ToString());
                        }
                    }
                }
                connection.Close();
            }
        }

        private void Carregar_Situacao()
        {
            string connectionString = @"Data Source=SERVIDOR;Initial Catalog=BANCODEDADOS;Persist Security Info=True;User ID=sa;Password=SENHA";
            string query = "SELECT [Situacao] FROM [BANCODEDADOS].[dbo].[Modelo_Situacao_Eng]"; // Substitua pelo nome correto da coluna e tabela

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Limpe os itens existentes no ComboBox
                        comboBox_situacao.Items.Clear();

                        // Preencha o ComboBox com os dados do DataTable
                        foreach (DataRow row in dataTable.Rows)
                        {
                            comboBox_situacao.Items.Add(row["Situacao"].ToString());
                        }
                    }
                }
                connection.Close();
            }
        }

        private void Carregar_Linha_Expositor()
        {
            string connectionString = @"Data Source=SERVIDOR;Initial Catalog=BANCODEDADOS;Persist Security Info=True;User ID=sa;Password=SENHA";
            string query = "SELECT [Linha] FROM [BANCODEDADOS].[dbo].[Linha_Expositor]"; // Substitua pelo nome correto da coluna e tabela

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Limpe os itens existentes no ComboBox
                        comboBox_linha.Items.Clear();

                        // Preencha o ComboBox com os dados do DataTable
                        foreach (DataRow row in dataTable.Rows)
                        {
                            comboBox_linha.Items.Add(row["Linha"].ToString());
                        }
                    }
                }
                connection.Close();
            }
        }

        private void Carregar_Profundidade()
        {
            string connectionString = @"Data Source=SERVIDOR;Initial Catalog=BANCODEDADOS;Persist Security Info=True;User ID=sa;Password=SENHA";
            string query = "SELECT [Profundidade] FROM [BANCODEDADOS].[dbo].[Modelo_Profundidade]"; // Substitua pelo nome correto da coluna e tabela

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Limpe os itens existentes no ComboBox
                        comboBox_profundidade.Items.Clear();

                        // Preencha o ComboBox com os dados do DataTable
                        foreach (DataRow row in dataTable.Rows)
                        {
                            comboBox_profundidade.Items.Add(row["Profundidade"].ToString());
                        }
                    }
                }
                connection.Close();
            }
        }

        private void Carregar_Comprimento()
        {
            string connectionString = @"Data Source=SERVIDOR;Initial Catalog=BANCODEDADOS;Persist Security Info=True;User ID=sa;Password=SENHA";
            string query = "SELECT [Medida] FROM [BANCODEDADOS].[dbo].[Modelo_Comprimento]"; // Substitua pelo nome correto da coluna e tabela

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Limpe os itens existentes no ComboBox
                        comboBox_comprimento.Items.Clear();

                        // Preencha o ComboBox com os dados do DataTable
                        foreach (DataRow row in dataTable.Rows)
                        {
                            comboBox_comprimento.Items.Add(row["Medida"].ToString());
                        }
                    }
                }
                connection.Close();
            }
        }

        private void Atualizar()
        {
            string selectedItemsQuery = "";

          

            SqlConnection con = new SqlConnection(@"Data Source=" + Instancia + ";Initial Catalog=" + Banco + ";Persist Security Info=True;User ID=" + Usuario + ";Password=" + Senha + "");
            Cursor.Current = Cursors.WaitCursor;
            con.Open();
            string query = "select * from Modelo_Eng";
            dataTable.Clear();

            using (SqlCommand command = new SqlCommand(query, con))
            {
               // command.Parameters.AddWithValue("@Linha", Linha);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    dataTable.Load(reader);
                }
            }

            con.Close();
            Cursor.Current = Cursors.Default;
            dataGridView1.DataSource = dataTable;
        }

        private void textBox_pesquisaComponente_TextChanged(object sender, EventArgs e)
        {
            // Atualizar o filtro sempre que o texto do TextBox mudar
            string filterText = textBox_pesquisaComponente.Text;
            filterText = filterText.Replace("'", "''"); // Tratar as aspas para evitar problemas no filtro
            dataTable.DefaultView.RowFilter = $"Modelo LIKE '%{filterText}%'";
        }

        private void button_Atualizar_Click(object sender, EventArgs e)
        {
            Atualizar();
        }

        private void button_salvar_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=" + Instancia + ";Initial Catalog=" + Banco + ";Persist Security Info=True;User ID=" + Usuario + ";Password=" + Senha + "");
            Cursor.Current = Cursors.WaitCursor;
            con.Open();
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult resultado = MessageBox.Show("Deseja realmente alterar as " + dataGridView1.SelectedRows.Count + " linhas selecionadas?", "Salvar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    {
                        if (!row.IsNewRow)
                        {
                            int id = Convert.ToInt32(row.Cells["ID"].Value);
                       
                            string query_update = "UPDATE [Modelo_Eng] SET Modelo = '" + textBox_modelo.Text + "', Tipo = '" + comboBox_tipo.Text + "', Resfriamento = '" + comboBox_resfriamento.Text + "' \n" +
                            ",Situacao = '" + comboBox_situacao.Text + "' \n" +
                            ",Linha = '" + comboBox_linha.Text + "' \n" +
                            ",Profundidade = '" + comboBox_profundidade.Text + "' \n" +
                            ",Comprimento = '" + comboBox_comprimento.Text + "' \n" +
                            ",SKU_Geral = '" + textBox_skugeral.Text + "' \n" +
                            ",Observacao = '" + textBox_observacao.Text + "' \n" +
                            "WHERE ID = " + id + "";
                            SqlTransaction transaction = con.BeginTransaction();
                            SqlCommand updateCmd = new SqlCommand(query_update, con, transaction);
                            updateCmd.ExecuteNonQuery();
                            transaction.Commit();
                            string query_log_de1 = "SELECT * FROM Modelo_Eng WHERE ID = '" + id + "'";
                            SqlCommand cmd_log_de1 = new SqlCommand(query_log_de1, con);
                            SqlDataReader reader_log_de1 = cmd_log_de1.ExecuteReader();
                            reader_log_de1.Close();

                        }
                    }
                    con.Close();
                    Atualizar();
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("As alterações foram salvas no banco de dados.", "Salvar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (resultado == DialogResult.No)
                {

                }
            }
            else
            {
                MessageBox.Show("Favor selecionar uma linha para alterar!");
            }
        }

        private void button_deletar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult resultado = MessageBox.Show("Deseja realmente deletar as linhas selecionadas?", "Deletar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    SqlConnection con = new SqlConnection(@"Data Source=" + Instancia + ";Initial Catalog=" + Banco + ";Persist Security Info=True;User ID=" + Usuario + ";Password=" + Senha + "");
                    con.Open();
                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    {
                        int id = Convert.ToInt32(row.Cells["id"].Value);
                        string query_log_de = "SELECT * FROM Modelo_Eng WHERE ID = '" + id + "'";
                        SqlCommand cmd_log_de = new SqlCommand(query_log_de, con);
                        SqlDataReader reader_log_de = cmd_log_de.ExecuteReader();
                        DeletarRegistroDoBancoDeDados(id);
                    }
                    con.Close();
                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    {
                        dataGridView1.Rows.RemoveAt(row.Index);
                    }
                    MessageBox.Show("Arquivos deletados!");
                    LimparCampo();
                }
            }
            else
            {
                MessageBox.Show("Selecionar uma linha para deletar.");
            }
        }

        private void DeletarRegistroDoBancoDeDados(int id)
        {
            SqlConnection con = new SqlConnection(@"Data Source=" + Instancia + ";Initial Catalog=" + Banco + ";Persist Security Info=True;User ID=" + Usuario + ";Password=" + Senha);
            string query = "DELETE FROM Modelo_Eng WHERE id = '" + id + "'";
            con.Open();
            SqlTransaction transaction = con.BeginTransaction();
            SqlCommand cmd = new SqlCommand(query, con, transaction);
            cmd.ExecuteNonQuery();
            transaction.Commit();
            con.Close();
        }

        private void button_importar_Click(object sender, EventArgs e)
        {
            var dateString2 = DateTime.Now.ToString("yyyy-MM-dd-HHmmss");
            DeletarTabelaTemp();
            CriarTabelaTemp();
            FormatarPlanilha();
            ImportarExcel();
            InserirLinhasNovas();
            LimparTabelasInseridas();
            MargeTabelaImport();
            DeletarTabelaTemp();
            File.Move(@"C:\BANCODEDADOS\Aplicativos\Tabelas_excel\02-Importar\Modelo_Eng.xlsx", @"C:\BANCODEDADOS\Aplicativos\Tabelas_excel\03-Importados\Modelo_Eng-" + dateString2 + ".xlsx");
            Atualizar();
            MessageBox.Show("Importado com sucesso!");
        }
        private void DeletarTabelaTemp()
        {
            Cursor.Current = Cursors.WaitCursor;
            SqlConnection con = new SqlConnection(@"Data Source=" + Instancia + ";Initial Catalog=" + Banco + ";Persist Security Info=True;User ID=" + Usuario + ";Password=" + Senha);
            var query1 = "IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TempModelo_Eng]') AND type in (N'U')) \n" +
                            "DROP TABLE[dbo].[TempModelo_Eng] ";
            con.Open();
            SqlTransaction transaction = con.BeginTransaction();
            SqlCommand cmd = new SqlCommand(query1, con, transaction);
            cmd.ExecuteNonQuery();
            transaction.Commit();
            con.Close();
            Cursor.Current = Cursors.Default;
        }
        private void CriarTabelaTemp()
        {
            Cursor.Current = Cursors.WaitCursor;
            SqlConnection con = new SqlConnection(@"Data Source=" + Instancia + ";Initial Catalog=" + Banco + ";Persist Security Info=True;User ID=" + Usuario + ";Password=" + Senha);
            var query1 = "CREATE TABLE TempModelo_Eng ([ID] INT, [Modelo] VARCHAR(MAX), [Tipo] VARCHAR(MAX), [Resfriamento] VARCHAR(MAX), [Situacao] VARCHAR(MAX),[Linha] VARCHAR(MAX),[Profundidade] INT,[Comprimento] INT,[SKU_Geral] VARCHAR(MAX),[Observacao] [nvarchar](255) NULL)";
            con.Open();
            SqlTransaction transaction = con.BeginTransaction();
            SqlCommand cmd = new SqlCommand(query1, con, transaction);
            cmd.ExecuteNonQuery();
            transaction.Commit();
            con.Close();
            Cursor.Current = Cursors.Default;
        }
        private void FormatarPlanilha()
        {
            var file = new FileInfo(@"C:\BANCODEDADOS\Aplicativos\Tabelas_excel\02-Importar\Modelo_Eng.xlsx");
            using (var package = new ExcelPackage(file))
            {
                var worksheet = package.Workbook.Worksheets["Pagina1"];
                var column = worksheet.Cells["A:W"];
                column.Style.Numberformat.Format = "@";
                package.Save();
            }
        }

        private void ImportarExcel()
        {
            Cursor.Current = Cursors.WaitCursor;
            string sexcelconnectionstring = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source=" + @"C:\BANCODEDADOS\Aplicativos\Tabelas_excel\02-Importar\Modelo_Eng.xlsx" +
                                         ";Extended Properties = " + "\"Excel 12.0 Xml;HDR=YES;\"";
            string ssqlconnectionstring = @"Data Source=" + Instancia + ";Initial Catalog=" + Banco + ";Persist Security Info=True;User ID=" + Usuario + ";Password=" + Senha;
            string myexceldataquery = "select * from [Pagina1$]";
            OleDbConnection oledbconn = new OleDbConnection(sexcelconnectionstring);
            OleDbCommand oledbcmd = new OleDbCommand(myexceldataquery, oledbconn);
            oledbconn.Open();
            OleDbDataReader dr = oledbcmd.ExecuteReader();
            SqlBulkCopy bulkcopy = new SqlBulkCopy(ssqlconnectionstring);
            bulkcopy.DestinationTableName = "TempModelo_Eng";
            bulkcopy.WriteToServer(dr);
            oledbconn.Close();
            Cursor.Current = Cursors.Default;
        }
        private void InserirLinhasNovas()
        {
            Cursor.Current = Cursors.WaitCursor;
            var dataAtual = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            SqlConnection con = new SqlConnection(@"Data Source=" + Instancia + ";Initial Catalog=" + Banco + ";Persist Security Info=True;User ID=" + Usuario + ";Password=" + Senha);
            con.Open();
            string query_log_de = "select * from TempModelo_Eng where ID is null";
            SqlCommand cmd_log_de = new SqlCommand(query_log_de, con);
            SqlDataReader reader_log_de = cmd_log_de.ExecuteReader();
            string resultadoColuna1 = null;
            while (reader_log_de.Read())
            {
                StringBuilder linhaBuilder = new StringBuilder();
                string Modelo = null;

                for (int i = 0; i < reader_log_de.FieldCount; i++)
                {
                    object valorColuna = reader_log_de.GetValue(i);
                    string valorColunaStr = (valorColuna != null) ? valorColuna.ToString() : string.Empty;
                    if (i == 1)
                    {
                        Modelo = valorColunaStr;
                    }
                    linhaBuilder.Append(valorColunaStr);

                    if (i < reader_log_de.FieldCount - 1)
                    {
                        linhaBuilder.Append(",");
                    }
                }
            }

            reader_log_de.Close();

            var query1 = "insert into Modelo_Eng \n" +
                         "SELECT [Modelo],[Tipo],[Resfriamento],[Situacao],[Linha],[Profundidade],[Comprimento],[SKU_Geral],[Observacao] FROM [TempModelo_Eng] where ID is null and [Modelo] is not null";

            SqlTransaction transaction = con.BeginTransaction();
            SqlCommand cmd = new SqlCommand(query1, con, transaction);
            cmd.ExecuteNonQuery();
            transaction.Commit();
            con.Close();
            Cursor.Current = Cursors.Default;
        }
        private void LimparTabelasInseridas()
        {
            Cursor.Current = Cursors.WaitCursor;
            SqlConnection con = new SqlConnection(@"Data Source=" + Instancia + ";Initial Catalog=" + Banco + ";Persist Security Info=True;User ID=" + Usuario + ";Password=" + Senha);
            var query1 = "delete FROM [TempModelo_Eng] where ID is null";
            con.Open();
            SqlTransaction transaction = con.BeginTransaction();
            SqlCommand cmd = new SqlCommand(query1, con, transaction);
            cmd.ExecuteNonQuery();
            transaction.Commit();
            con.Close();
            Cursor.Current = Cursors.Default;
        }
        private void MargeTabelaImport()
        {
            Cursor.Current = Cursors.WaitCursor;
            SqlConnection con = new SqlConnection(@"Data Source=" + Instancia + ";Initial Catalog=" + Banco + ";Persist Security Info=True;User ID=" + Usuario + ";Password=" + Senha);
            var query1 = "SET IDENTITY_INSERT Modelo_Eng ON \n" +
                            "MERGE INTO Modelo_Eng AS Target \n" +
                            "USING TempModelo_Eng AS Source \n" +
                            "ON(Target.ID = Source.ID) \n" +
                            "WHEN MATCHED THEN \n" +
                            "UPDATE SET Target.Modelo = Source.Modelo, \n" +
                               "Target.Tipo = Source.Tipo, \n" +
                               "Target.Resfriamento = Source.Resfriamento, \n" +
                               "Target.Situacao = Source.Situacao, \n" +
                               "Target.Linha = Source.Linha, \n" +
                               "Target.Profundidade = Source.Profundidade, \n" +
                               "Target.Comprimento = Source.Comprimento, \n" +
                               "Target.SKU_Geral = Source.SKU_Geral, \n" +
                               "Target.Observacao = Source.Observacao \n" +
                                "WHEN NOT MATCHED THEN \n" +
                                    "INSERT(ID, Modelo, Tipo, Resfriamento, Situacao, Linha,Profundidade,Comprimento,SKU_Geral,Observacao) \n" +
                                    "VALUES(Source.ID, Source.Modelo, Source.Tipo, Source.Resfriamento, Source.Situacao, Source.Linha,Source.Profundidade,Source.Comprimento,Source.SKU_Geral, Source.Observacao); \n" +
                                    "SET IDENTITY_INSERT Modelo_Eng OFF;";
            con.Open();
            SqlTransaction transaction = con.BeginTransaction();
            SqlCommand cmd = new SqlCommand(query1, con, transaction);
            cmd.ExecuteNonQuery();
            transaction.Commit();
            con.Close();

            Cursor.Current = Cursors.Default;
        }

        private void button_exportar_Click(object sender, EventArgs e)
        {
            Atualizar();
            Cursor.Current = Cursors.WaitCursor;
            DataTable dt = new DataTable();
            List<string> resultadosSelecionados = new List<string>();
           
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                dt.Columns.Add(column.HeaderText, column.ValueType);
            }
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                dt.Rows.Add();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null)
                    {
                        dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value;
                    }
                }
            }
            string folderPath = @"C:\BANCODEDADOS\Aplicativos\Tabelas_excel\01-Exportar\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, "Pagina1");
                wb.SaveAs(folderPath + "Modelo_Eng.xlsx");
            }
            string resultadosSelecionadosString = string.Join("|", resultadosSelecionados);
            SqlConnection con = new SqlConnection(@"Data Source=" + Instancia + ";Initial Catalog=" + Banco + ";Persist Security Info=True;User ID=" + Usuario + ";Password=" + Senha + "");
            con.Open();
            Cursor.Current = Cursors.Default;
            MessageBox.Show("Tabela exportada com sucesso!");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Certifica-se de que uma linha válida foi selecionada
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Acessa os valores das colunas específicas do DataGridView
                id = Convert.ToInt32(row.Cells["ID"].Value);
                string valorColuna1 = row.Cells[1].Value.ToString();
                string valorColuna2 = row.Cells[2].Value.ToString();
                string valorColuna3 = row.Cells[3].Value.ToString();
                string valorColuna4 = row.Cells[4].Value.ToString();
                string valorColuna5 = row.Cells[5].Value.ToString();
                string valorColuna6 = row.Cells[6].Value.ToString();
                string valorColuna7 = row.Cells[7].Value.ToString();
                string valorColuna8 = row.Cells[8].Value.ToString();
                string valorColuna9 = row.Cells[9].Value.ToString();

                // Insere os valores nas ComboBox e TextBox correspondentes
                textBox_modelo.Text = valorColuna1;
                textBox_skugeral.Text = valorColuna8;
                comboBox_tipo.SelectedItem = valorColuna2;
                comboBox_resfriamento.SelectedItem = valorColuna3;
                comboBox_situacao.SelectedItem = valorColuna4;
                comboBox_linha.SelectedItem = valorColuna5;
                comboBox_profundidade.SelectedItem = valorColuna6;
                comboBox_comprimento.SelectedItem = valorColuna7;
                textBox_observacao.Text = valorColuna9;
           
            }
        }

        private void button_cabeceira_Click(object sender, EventArgs e)
        {
            CadastrarCabeceira = new Form_Cabeceira(accessToken);
            this.Hide();
            CadastrarCabeceira.FormClosed += FormMenu_FormClosed;
            CadastrarCabeceira.Show();
        }

        private void button_acessorios_Click(object sender, EventArgs e)
        {
            CadastrarAcessorio = new Form_cadastrar_acessorios_new(accessToken);
            this.Hide();
            CadastrarAcessorio.FormClosed += FormMenu_FormClosed;
            CadastrarAcessorio.Show();
        }
    }
}
