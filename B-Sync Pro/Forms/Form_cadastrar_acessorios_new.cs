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
    public partial class Form_cadastrar_acessorios_new : Form
    {
        private Form_Menu Menu;
        string accessToken = "";
        string Banco = "BANCODEDADOS";
        string Instancia = @"SERVIDOR";
        string Senha = "SENHA";
        string Usuario = "sa";
        private DataTable dataTable;
        private Form_cadastrar_expositor cadastarExpositor;
        private Form_Cabeceira CadastrarCabeceira;
        bool mostrar_config = false;
        int id;

        public Form_cadastrar_acessorios_new(string token)
        {
            InitializeComponent();
            accessToken = token;
            dataTable = new DataTable();
            Atualizar(comboBox_modelo.Text);
            Carregar_Modelo();
            Carregar_Cores();
            //textBox_chave_busca.Text = chaveBusca;
            textBox_componente_nome.Text = "Kit " + textBox_componente.Text + " " + comboBox_modelo.Text + " " + comboBox_medida.Text;
        }

        private void Carregar_Modelo()
        {
            string connectionString = @"Data Source=SERVIDOR;Initial Catalog=BANCODEDADOS;Persist Security Info=True;User ID=sa;Password=SENHA";
            string query = "SELECT distinct [Modelo] FROM [BANCODEDADOS].[dbo].[Modelo_Eng]"; // Substitua pelo nome correto da coluna e tabela

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
                        comboBox_modelo.Items.Clear();

                        // Preencha o ComboBox com os dados do DataTable
                        foreach (DataRow row in dataTable.Rows)
                        {
                            comboBox_modelo.Items.Add(row["Modelo"].ToString());
                        }
                    }
                }
                connection.Close();
            }
        }

        private void Carregar_Cores()
        {
            string connectionString = @"Data Source=SERVIDOR;Initial Catalog=BANCODEDADOS;Persist Security Info=True;User ID=sa;Password=SENHA";
            string query = "SELECT DISTINCT [Grupo_Cor] FROM [BANCODEDADOS].[dbo].[Gen_GrupoCores]"; // Substitua pelo nome correto da coluna e tabela

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
                        comboBox_Cores.Items.Clear();

                        // Preencha o ComboBox com os dados do DataTable
                        foreach (DataRow row in dataTable.Rows)
                        {
                            comboBox_Cores.Items.Add(row["Grupo_Cor"].ToString());
                        }
                    }
                }
                connection.Close();
            }
        }

        private void Carregar_Medidas()
        {
            string connectionString = @"Data Source=SERVIDOR;Initial Catalog=BANCODEDADOS;Persist Security Info=True;User ID=sa;Password=SENHA";
            string query = "select distinct Comprimento from Modelo_Eng where Modelo = '" + comboBox_modelo.Text + "'"; // Substitua pelo nome correto da coluna e tabela

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
                        comboBox_medida.Items.Clear();

                        // Preencha o ComboBox com os dados do DataTable
                        foreach (DataRow row in dataTable.Rows)
                        {
                            comboBox_medida.Items.Add(row["Comprimento"].ToString());
                        }
                    }
                }
                connection.Close();
            }
        }

        private void button_voltar_Click(object sender, EventArgs e)
        {
            Menu = new Form_Menu(accessToken);
            this.Hide();
            Menu.FormClosed += FormMenu_FormClosed;
            Menu.Show();
        }
        private void FormMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit(); // ou Environment.Exit(0);
        }

        private void button_Atualizar_Click(object sender, EventArgs e)
        {
            Atualizar(comboBox_modelo.Text);
        }

        private void Atualizar(string modelo)
        {
            string selectedItemsQuery = "";

            SqlConnection con = new SqlConnection(@"Data Source=" + Instancia + ";Initial Catalog=" + Banco + ";Persist Security Info=True;User ID=" + Usuario + ";Password=" + Senha + "");
            Cursor.Current = Cursors.WaitCursor;
            con.Open();
            string query = "";
            if (modelo == "")
            {
                query = "select * from Modelo_Acessorios";
            }
            else
            {
                query = "select * from Modelo_Acessorios where Modelo = '"+modelo+"'";
            }
            
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

        private void button_Modulo_Click(object sender, EventArgs e)
        {
            cadastarExpositor = new Form_cadastrar_expositor(accessToken);
            this.Hide();
            cadastarExpositor.FormClosed += FormMenu_FormClosed;
            cadastarExpositor.Show();
        }

    
        private void comboBox_modelo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Carregar_Medidas();
            textBox_componente_nome.Text = "Kit " + textBox_componente.Text + " " + comboBox_modelo.Text + " " + comboBox_medida.Text;
            if (comboBox_medida.Text != "")
            {
                textBox_chave_busca.Text = "Kit " + textBox_componente.Text + " <MODELO> <MEDIDA>";
            }
            else
            {
                textBox_chave_busca.Text = "Kit " + textBox_componente.Text + " <MODELO>";
            }
            Atualizar(comboBox_modelo.Text);
        }

        private void comboBox_medida_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox_componente_nome.Text = "Kit " + textBox_componente.Text + " " + comboBox_modelo.Text + " " + comboBox_medida.Text;
            if (comboBox_medida.Text != "")
            {
                textBox_chave_busca.Text = "Kit " + textBox_componente.Text + " <MODELO> <MEDIDA>";
            }
            else
            {
                textBox_chave_busca.Text = "Kit " + textBox_componente.Text + " <MODELO>";
            }
        }

        private void textBox_componente_TextChanged(object sender, EventArgs e)
        {
            textBox_componente_nome.Text = "Kit " + textBox_componente.Text + " " + comboBox_modelo.Text + " " + comboBox_medida.Text;
            if (comboBox_medida.Text != "")
            {
                textBox_chave_busca.Text = "Kit " + textBox_componente.Text + " <MODELO> <MEDIDA>";
            }
            else
            {
                textBox_chave_busca.Text = "Kit " + textBox_componente.Text + " <MODELO>";
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            checkBox2.Checked = !checkBox1.Checked;
            if (checkBox2.Checked)
            {
                mostrar_config = false;
            }
            else
            {
                mostrar_config = true;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = !checkBox2.Checked;
            if (checkBox1.Checked)
            {
                mostrar_config = true;
            }
            else
            {
                mostrar_config = false;
            }
        }

        private void button_cadastrar_Click(object sender, EventArgs e)
        {
            if (comboBox_modelo.Text == "")
            {
                MessageBox.Show("Modelo esta vazio!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Sai do método sem executar o procedimento
            }
            if (comboBox_medida.Text == "")
            {
                MessageBox.Show("Medida esta vazio!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Sai do método sem executar o procedimento
            }
            if (textBox_componente.Text == "")
            {
                MessageBox.Show("Componente esta vazio!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Sai do método sem executar o procedimento
            }
            if (numericUpDown_qtd_nivel.Text == "")
            {
                MessageBox.Show("Quantidade por nivel esta vazio!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Sai do método sem executar o procedimento
            }
            if (textBox_chave_busca.Text == "")
            {
                MessageBox.Show("Chave de busca esta vazio!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Sai do método sem executar o procedimento
            }
            if (checkBox1.Checked == false && checkBox2.Checked == false)
            {
                MessageBox.Show("Mostrar para configurar esta vazio!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Sai do método sem executar o procedimento
            }
            if (comboBox_Cores.Text == "")
            {
                MessageBox.Show("Cores esta vazio!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                            string query = "INSERT INTO [dbo].[Modelo_Acessorios] ([Modelo],[Componente],[Chave_Busca],[Medida],[Qtd_nivel],[Mostrar_Config],[Cores],[Codigos],[Observacao]) VALUES (" +
                                "@Modelo,@Componente,@Chave_Busca,@Medida,@Qtd_nivel,@Mostrar_Config, @Cores, @Observacao);";
                            using (SqlCommand cmd = new SqlCommand(query, con, transaction))
                            {
                                cmd.Parameters.AddWithValue("@Modelo", comboBox_modelo.Text);
                                cmd.Parameters.AddWithValue("@Componente", textBox_componente_nome.Text);
                                cmd.Parameters.AddWithValue("@Chave_Busca", textBox_chave_busca.Text);
                                cmd.Parameters.AddWithValue("@Medida", comboBox_medida.Text);
                                cmd.Parameters.AddWithValue("@Qtd_nivel", numericUpDown_qtd_nivel.Text);
                                cmd.Parameters.AddWithValue("@Mostrar_Config", mostrar_config);
                                cmd.Parameters.AddWithValue("@Cores", comboBox_Cores.Text);
                                cmd.Parameters.AddWithValue("@Codigos", textBox_codigos.Text);
                                cmd.Parameters.AddWithValue("@Observacao", textBox_observacao.Text);
                                cmd.ExecuteNonQuery();
                            }
                            transaction.Commit();
                        }
                        con.Close();
                    }
                    Atualizar(comboBox_modelo.Text);
                    MessageBox.Show("Acessorios criado com sucesso!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void textBox_pesquisaComponente_TextChanged(object sender, EventArgs e)
        {
            // Atualizar o filtro sempre que o texto do TextBox mudar
            string filterText = textBox_pesquisaComponente.Text;
            filterText = filterText.Replace("'", "''"); // Tratar as aspas para evitar problemas no filtro
            dataTable.DefaultView.RowFilter = $"Modelo LIKE '%{filterText}%'";
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
                            string query_update = "";

                            if (checkBox1.Checked == true && checkBox2.Checked == false)
                            {
                                query_update = "UPDATE [Modelo_Acessorios] SET Modelo = '" + comboBox_modelo.Text + "', Componente = '" + textBox_componente_nome.Text + "', Chave_Busca = '" + textBox_chave_busca.Text + "' \n" +
                                                 ",Medida = '" + comboBox_medida.Text + "' \n" +
                                                 ",Qtd_nivel = '" + numericUpDown_qtd_nivel.Text + "' \n" +
                                                 ",Mostrar_Config = '1' \n" +
                                                 ",Cores = '" + comboBox_Cores.Text + "' \n" +
                                                 ",Codigos = '" + textBox_codigos.Text + "' \n" +
                                                 ",Observacao = '" + textBox_observacao.Text + "' WHERE ID = " + id + "";
                            }
                            else if(checkBox2.Checked == true && checkBox1.Checked == false)
                            {
                                query_update = "UPDATE [Modelo_Acessorios] SET Modelo = '" + comboBox_modelo.Text + "', Componente = '" + textBox_componente_nome.Text + "', Chave_Busca = '" + textBox_chave_busca.Text + "' \n" +
                                                ",Medida = '" + comboBox_medida.Text + "' \n" +
                                                ",Qtd_nivel = '" + numericUpDown_qtd_nivel.Text + "' \n" +
                                                ",Mostrar_Config = '0' \n" + 
                                                ",Cores = '" + comboBox_Cores.Text + "' \n" +
                                                  ",Codigos = '" + textBox_codigos.Text + "' \n" +
                                                ",Observacao = '" + textBox_observacao.Text + "' WHERE ID = " + id + "";
                            }
                                

                            SqlTransaction transaction = con.BeginTransaction();
                            SqlCommand updateCmd = new SqlCommand(query_update, con, transaction);
                            updateCmd.ExecuteNonQuery();
                            transaction.Commit();
                            string query_log_de1 = "SELECT * FROM Modelo_Acessorios WHERE ID = '" + id + "'";
                            SqlCommand cmd_log_de1 = new SqlCommand(query_log_de1, con);
                            SqlDataReader reader_log_de1 = cmd_log_de1.ExecuteReader();
                            reader_log_de1.Close();

                        }
                    }
                    con.Close();
                    Atualizar(comboBox_modelo.Text);
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

                // Insere os valores nas ComboBox e TextBox correspondentes
                comboBox_modelo.Text = valorColuna1;
                comboBox_medida.Text = valorColuna4;
                textBox_componente.Text = "";
                textBox_componente_nome.Text = valorColuna2;
                textBox_chave_busca.Text = valorColuna3;
                numericUpDown_qtd_nivel.Text = valorColuna5;
                comboBox_Cores.Text = valorColuna7;
                if(valorColuna6 == "True")
                {
                    checkBox1.Checked = true;
                    checkBox2.Checked = false;
                }
                else
                {
                    checkBox1.Checked = false;
                    checkBox2.Checked = true;
                }
                
                textBox_observacao.Text = valorColuna8;

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
                        string query_log_de = "SELECT * FROM Modelo_Acessorios WHERE ID = '" + id + "'";
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
            string query = "DELETE FROM Modelo_Acessorios WHERE id = '" + id + "'";
            con.Open();
            SqlTransaction transaction = con.BeginTransaction();
            SqlCommand cmd = new SqlCommand(query, con, transaction);
            cmd.ExecuteNonQuery();
            transaction.Commit();
            con.Close();
        }

        private void button_exportar_Click(object sender, EventArgs e)
        {
            Atualizar(comboBox_modelo.Text);
            Cursor.Current = Cursors.WaitCursor;
            DataTable dt = new DataTable();
            //List<string> resultadosSelecionados = new List<string>();

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
                wb.SaveAs(folderPath + "Modelo_Acessorios.xlsx");
            }
           
            Cursor.Current = Cursors.Default;
            MessageBox.Show("Tabela exportada com sucesso!");
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
            File.Move(@"C:\BANCODEDADOS\Aplicativos\Tabelas_excel\02-Importar\Modelo_Acessorios.xlsx", @"C:\BANCODEDADOS\Aplicativos\Tabelas_excel\03-Importados\Modelo_Acessorios-" + dateString2 + ".xlsx");
            Atualizar(comboBox_modelo.Text);
            MessageBox.Show("Importado com sucesso!");
        }
        private void DeletarTabelaTemp()
        {
            Cursor.Current = Cursors.WaitCursor;
            SqlConnection con = new SqlConnection(@"Data Source=" + Instancia + ";Initial Catalog=" + Banco + ";Persist Security Info=True;User ID=" + Usuario + ";Password=" + Senha);
            var query1 = "IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TempModelo_Acessorios]') AND type in (N'U')) \n" +
                            "DROP TABLE[dbo].[TempModelo_Acessorios] ";
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
            var query1 = "CREATE TABLE TempModelo_Acessorios ([ID] INT, [Modelo] VARCHAR(MAX), [Componente] VARCHAR(MAX), [Chave_Busca] VARCHAR(MAX), [Medida] INT,[Qtd_nivel] INT,[Mostrar_Config] bit,[Cores] VARCHAR(MAX),[Codigos] VARCHAR(MAX),[Observacao] VARCHAR(MAX))";
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
            var file = new FileInfo(@"C:\BANCODEDADOS\Aplicativos\Tabelas_excel\02-Importar\Modelo_Acessorios.xlsx");
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
            string sexcelconnectionstring = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source=" + @"C:\BANCODEDADOS\Aplicativos\Tabelas_excel\02-Importar\Modelo_Acessorios.xlsx" +
                                         ";Extended Properties = " + "\"Excel 12.0 Xml;HDR=YES;\"";
            string ssqlconnectionstring = @"Data Source=" + Instancia + ";Initial Catalog=" + Banco + ";Persist Security Info=True;User ID=" + Usuario + ";Password=" + Senha;
            string myexceldataquery = "select * from [Pagina1$]";
            OleDbConnection oledbconn = new OleDbConnection(sexcelconnectionstring);
            OleDbCommand oledbcmd = new OleDbCommand(myexceldataquery, oledbconn);
            oledbconn.Open();
            OleDbDataReader dr = oledbcmd.ExecuteReader();
            SqlBulkCopy bulkcopy = new SqlBulkCopy(ssqlconnectionstring);
            bulkcopy.DestinationTableName = "TempModelo_Acessorios";
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
            string query_log_de = "select * from TempModelo_Acessorios where ID is null";
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

            var query1 = "insert into Modelo_Acessorios \n" +
                         "SELECT [Modelo],[Componente],[Chave_Busca],[Medida],[Qtd_nivel],[Mostrar_Config],[Cores],[Codigos],[Observacao] FROM [TempModelo_Acessorios] where ID is null and [Modelo] is not null";

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
            var query1 = "delete FROM [TempModelo_Acessorios] where ID is null";
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
            var query1 = "SET IDENTITY_INSERT Modelo_Acessorios ON \n" +
                            "MERGE INTO Modelo_Acessorios AS Target \n" +
                            "USING TempModelo_Acessorios AS Source \n" +
                            "ON(Target.ID = Source.ID) \n" +
                            "WHEN MATCHED THEN \n" +
                            "UPDATE SET Target.Modelo = Source.Modelo, \n" +
                               "Target.Componente = Source.Componente, \n" +
                               "Target.Chave_Busca = Source.Chave_Busca, \n" +
                               "Target.Medida = Source.Medida, \n" +
                               "Target.Qtd_nivel = Source.Qtd_nivel, \n" +
                               "Target.Mostrar_Config = Source.Mostrar_Config, \n" +
                               "Target.Cores = Source.Cores, \n" +
                               "Target.Codigos = Source.Codigos, \n" +
                               "Target.Observacao = Source.Observacao \n" +
                                "WHEN NOT MATCHED THEN \n" +
                                    "INSERT(ID, Modelo, Componente, Chave_Busca, Medida, Qtd_nivel,Mostrar_Config,Cores,Codigos,Observacao) \n" +
                                    "VALUES(Source.ID, Source.Modelo, Source.Componente, Source.Chave_Busca, Source.Medida, Source.Qtd_nivel,Source.Mostrar_Config,Source.Cores,Source.Codigos, Source.Observacao); \n" +
                                    "SET IDENTITY_INSERT Modelo_Acessorios OFF;";
            con.Open();
            SqlTransaction transaction = con.BeginTransaction();
            SqlCommand cmd = new SqlCommand(query1, con, transaction);
            cmd.ExecuteNonQuery();
            transaction.Commit();
            con.Close();

            Cursor.Current = Cursors.Default;
        }

        private void button_cabeceira_Click(object sender, EventArgs e)
        {
            CadastrarCabeceira = new Form_Cabeceira(accessToken);
            this.Hide();
            CadastrarCabeceira.FormClosed += FormMenu_FormClosed;
            CadastrarCabeceira.Show();
        }
    }
}
