
using System.Data;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using static B_Sync_Pro.Models.Class_cliente;
using System.Data.SqlClient;
using static B_Sync_Pro.Models.Class_Produtos;
using Spire.Doc;
using System.Diagnostics;
using B_Sync_Pro.Models;
using Spire.Doc.Documents;
using HorizontalAlignment = Spire.Doc.Documents.HorizontalAlignment;
using Spire.Doc.Fields;
using NPOI.XWPF.UserModel;
using Document = Spire.Doc.Document;

namespace B_Sync_Pro.Forms
{
    public partial class Form_GerarOrcamentos : Form
    {
        private Form_Menu Menu;
        string Banco = "BANCODEDADOS";
        string Instancia = @"SERVIDOR";
        string Senha = "SENHA";
        string Usuario = "sa";

        string Pedido = "";
        string accessToken = "";
        string Status = "";

        private string acessoriosSelecionados;
        private int AlinhamentoModelo = 0;
        private int qtdSelecionada;
        int numeroDeLinhasCriadas;



        public Form_GerarOrcamentos(string token, string pedido, string status)
        {
            InitializeComponent();
            accessToken = token;
            Pedido = pedido;
            Status = status;
        }
        private void Form_GerarOrcamentos_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            CarregarTemperatura();

            if (Status == "novo")
            {
                VerificarUltimoOrcamento();
                //return;
            }
            else if (Status == "editar")
            {
                EditarOrcamento();
            }
            MostrarValorTotal();
            MostrarDadosNoDataGridView();
            FillComboBoxWithContacts(accessToken);
            FillComboBoxWithVendedors(accessToken);
            Cursor.Current = Cursors.Default;
        }

        private void EditarOrcamento()
        {

            Cursor.Current = Cursors.WaitCursor;
            string connectionString = @"Data Source=" + Instancia + ";Initial Catalog=" + Banco + ";Persist Security Info=True;User ID=" + Usuario + ";Password=" + Senha + "";
            string query = "select * from OrcCabecalho where Num_cotacao = @Num_cotacao and (Revisao = '' or Revisao is null)"; // Substitua pelo nome correto da coluna e tabela

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Num_cotacao", Pedido);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Preencha o ComboBox com os dados do DataTable                        
                        comboBox_vendedor.Items.Add(dataTable.Rows[0]["Vendedor"].ToString());
                        comboBox_cliente.Items.Add(dataTable.Rows[0]["Cliente"].ToString());
                        textBox_loja.Text = dataTable.Rows[0]["Loja"].ToString();
                        textBox_num_cotacao.Text = dataTable.Rows[0]["Num_cotacao"].ToString();
                        textBox_valor.Text = dataTable.Rows[0]["Valor_total"].ToString();
                        textBox_cidade.Text = dataTable.Rows[0]["Cidade"].ToString();
                        textBox_UF.Text = dataTable.Rows[0]["UF"].ToString();
                        textBox_endereco.Text = dataTable.Rows[0]["Endereco"].ToString();

                        // Verifique se há itens na ComboBox e, em seguida, selecione o primeiro
                        if (comboBox_cliente.Items.Count > 0)
                        {
                            comboBox_cliente.SelectedIndex = 0; // Seleciona o primeiro item
                        }
                        if (comboBox_vendedor.Items.Count > 0)
                        {
                            comboBox_vendedor.SelectedIndex = 0; // Seleciona o primeiro item
                        }
                    }
                }
                connection.Close();
            }
            Cursor.Current = Cursors.Default;
        }

        private void VerificarUltimoOrcamento()
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=" + Instancia + ";Initial Catalog=" + Banco + ";Persist Security Info=True;User ID=" + Usuario + ";Password=" + Senha + ""))
            {
                connection.Open();

                // Consulta SQL para obter o último número de cotação
                string query = "select top 1 Num_cotacao from OrcCabecalho  ORDER BY Num_cotacao DESC";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string ultimoNumeroCotacao = reader["Num_cotacao"].ToString();
                        string novoNumeroCotacao = IncrementarNumeroCotacao(ultimoNumeroCotacao);
                        textBox_num_cotacao.Text = novoNumeroCotacao;
                    }
                    else
                    {
                        textBox_num_cotacao.Text = "FRIG00001";
                    }

                    reader.Close();
                }
            }
        }

        private string IncrementarNumeroCotacao(string numeroCotacao)
        {
            // Extrair o número atual e incrementar
            string numero = numeroCotacao.Substring(4); // Supondo que os 4 primeiros caracteres são fixos
            int numeroAtual = int.Parse(numero);
            int novoNumero = numeroAtual + 1;

            // Formatar o novo número com zeros à esquerda
            string novoNumeroFormatado = novoNumero.ToString("D5"); // 5 é o número de dígitos no número

            // Concatenar com os caracteres fixos
            string novoNumeroCotacao = "FRIG" + novoNumeroFormatado;

            return novoNumeroCotacao;
        }

        private void CarregarModelo()
        {
            Cursor.Current = Cursors.WaitCursor;
            string connectionString = @"Data Source=" + Instancia + ";Initial Catalog=" + Banco + ";Persist Security Info=True;User ID=" + Usuario + ";Password=" + Senha + "";
            string query = "select distinct Modelo from Modelo_Eng where Resfriamento like '" + comboBox_Temperatura.Text + "'"; // Substitua pelo nome correto da coluna e tabela

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
                        comboBox_expositor.Items.Clear();

                        // Preencha o ComboBox com os dados do DataTable
                        foreach (DataRow row in dataTable.Rows)
                        {
                            comboBox_expositor.Items.Add(row["Modelo"].ToString());
                        }
                    }
                }
                connection.Close();
            }
            Cursor.Current = Cursors.Default;
        }

        private void CarregarTemperatura()
        {
            Cursor.Current = Cursors.WaitCursor;
            string connectionString = @"Data Source=" + Instancia + ";Initial Catalog=" + Banco + ";Persist Security Info=True;User ID=" + Usuario + ";Password=" + Senha + "";
            string query = "select Regime from Modelo_Regime_Eng"; // Substitua pelo nome correto da coluna e tabela

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
                        comboBox_Temperatura.Items.Clear();

                        // Preencha o ComboBox com os dados do DataTable
                        foreach (DataRow row in dataTable.Rows)
                        {
                            comboBox_Temperatura.Items.Add(row["Regime"].ToString());
                        }
                    }
                }
                connection.Close();
            }
            Cursor.Current = Cursors.Default;
        }

        private async Task FillComboBoxWithContacts(string code)
        {
            string token = code; // Substitua pelo seu token de acesso
            string apiUrl = "https://www.bling.com.br/Api/v3/contatos?pagina=1&limite=100&criterio=1&idTipoContato=14572024033";

            // Armazena o nome atualmente selecionado
            string nomeSelecionado = comboBox_cliente.SelectedItem as string;

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<ApiResponse>(responseContent);

                    comboBox_cliente.Items.Clear(); // Limpa os itens antigos

                    // Preencher a ComboBox com os nomes
                    foreach (var contato in result.data)
                    {
                        comboBox_cliente.Items.Add(contato.nome);
                    }

                    // Restaura a seleção anterior se o nome ainda estiver na lista
                    if (!string.IsNullOrEmpty(nomeSelecionado) && comboBox_cliente.Items.Contains(nomeSelecionado))
                    {
                        comboBox_cliente.SelectedItem = nomeSelecionado;
                    }
                    else
                    {
                        comboBox_cliente.SelectedItem = ""; // Seleciona o primeiro item se o nome anterior não estiver na lista
                    }
                }
                else
                {
                    MessageBox.Show("Erro ao obter os dados da API contatos.");
                }
            }
        }


        private async Task FillComboBoxWithVendedors(string code)
        {
            string token = code; // Substitua pelo seu token de acesso
            string apiUrl = "https://www.bling.com.br/Api/v3/vendedores?pagina=1&limite=100&situacaoContato=A";

            // Armazena o nome atualmente selecionado
            string nomeSelecionado = comboBox_vendedor.SelectedItem as string;

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<ApiResponseVendedor>(responseContent);

                    comboBox_vendedor.Items.Clear(); // Limpa os itens anteriores

                    // Preenche a ComboBox com os nomes dos vendedores
                    foreach (var vendedor in result.data)
                    {
                        string nome = vendedor.contato.nome;
                        comboBox_vendedor.Items.Add(nome);
                    }

                    // Restaura a seleção anterior se o nome ainda estiver na lista
                    if (!string.IsNullOrEmpty(nomeSelecionado) && comboBox_vendedor.Items.Contains(nomeSelecionado))
                    {
                        comboBox_vendedor.SelectedItem = nomeSelecionado;
                    }
                    else
                    {
                        comboBox_vendedor.SelectedItem = ""; // Seleciona o primeiro item se o nome anterior não estiver na lista
                    }
                }
                else
                {
                    MessageBox.Show("Erro ao obter os dados da API.");
                }
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

        private void comboBox_cliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verifique se o item selecionado em comboBox1 é o que você deseja
            if (comboBox_cliente.SelectedItem != null)
            {
                // Se for o item desejado, habilite comboBox2
                comboBox_Temperatura.Enabled = true;
                label_temperatura.Enabled = true;
            }
            else
            {
                // Caso contrário, desabilite comboBox2
                comboBox_Temperatura.Enabled = false;
                label_temperatura.Enabled = false;
                // Você também pode limpar a seleção em comboBox2, se desejar
                comboBox_Temperatura.SelectedIndex = -1;
            }
        }



        private void comboBox_Temperatura_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verifique se o item selecionado em comboBox1 é o que você deseja
            if (comboBox_Temperatura.SelectedItem != null)
            {
                // Se for o item desejado, habilite comboBox2
                comboBox_tipo_refrigeracao.Enabled = true;
                label_tipo_refrigeracao.Enabled = true;
            }
            else
            {
                // Caso contrário, desabilite comboBox2
                comboBox_tipo_refrigeracao.Enabled = false;
                label_tipo_refrigeracao.Enabled = false;
                // Você também pode limpar a seleção em comboBox2, se desejar
                comboBox_tipo_refrigeracao.SelectedIndex = -1;
            }
            comboBox_tipo_refrigeracao.SelectedIndex = -1;

        }

        private void comboBox_expositor_DropDown(object sender, EventArgs e)
        {
            CarregarModelo();
        }

        private void comboBox_expositor_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimparTableLayoutPanel(tableLayoutPanel1);
            // Verifique se o item selecionado em comboBox1 é o que você deseja
            if (comboBox_expositor.SelectedItem != null)
            {
                // Se for o item desejado, habilite comboBox2
                comboBox_largura_expositor.Enabled = true;
                label_largura_expositor.Enabled = true;
                comboBox_largura_expositor.SelectedIndex = -1;
                comboBox_tamanho_expositor.SelectedIndex = -1;
            }
            else
            {
                // Caso contrário, desabilite comboBox2
                comboBox_largura_expositor.Enabled = false;
                label_largura_expositor.Enabled = false;
                // Você também pode limpar a seleção em comboBox2, se desejar
                comboBox_largura_expositor.SelectedIndex = -1;
                comboBox_tamanho_expositor.SelectedIndex = -1;
            }

            if (comboBox_expositor.SelectedItem != null && comboBox_tamanho_expositor != null)
            {
                CarregarAcessorios();
            }
        }

        private void comboBox_largura_expositor_DropDown(object sender, EventArgs e)
        {
            CarregarLarguraExpositor();
        }
        private void CarregarLarguraExpositor()
        {
            Cursor.Current = Cursors.WaitCursor;
            string connectionString = @"Data Source=" + Instancia + ";Initial Catalog=" + Banco + ";Persist Security Info=True;User ID=" + Usuario + ";Password=" + Senha + "";
            string query = "select distinct Profundidade from Modelo_Eng where Modelo = '" + comboBox_expositor.Text + "'"; // Substitua pelo nome correto da coluna e tabela

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
                        comboBox_largura_expositor.Items.Clear();

                        // Preencha o ComboBox com os dados do DataTable
                        foreach (DataRow row in dataTable.Rows)
                        {
                            comboBox_largura_expositor.Items.Add(row["Profundidade"].ToString());
                        }
                    }
                }
                connection.Close();
            }
            Cursor.Current = Cursors.Default;
        }

        private void comboBox_largura_expositor_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimparTableLayoutPanel(tableLayoutPanel1);
            // Verifique se o item selecionado em comboBox1 é o que você deseja
            if (comboBox_largura_expositor.SelectedItem != null)
            {
                // Se for o item desejado, habilite comboBox2
                comboBox_tamanho_expositor.Enabled = true;
                label_tamanho_expositor.Enabled = true;
                comboBox_tamanho_expositor.SelectedIndex = -1;
            }
            else
            {
                // Caso contrário, desabilite comboBox2
                comboBox_tamanho_expositor.Enabled = false;
                label_tamanho_expositor.Enabled = false;
                // Você também pode limpar a seleção em comboBox2, se desejar
                comboBox_tamanho_expositor.SelectedIndex = -1;
            }
        }

        private void comboBox_tamanho_expositor_DropDown(object sender, EventArgs e)
        {
            CarregarComprimentoExpositor();
        }
        private void CarregarComprimentoExpositor()
        {
            Cursor.Current = Cursors.WaitCursor;
            string connectionString = @"Data Source=" + Instancia + ";Initial Catalog=" + Banco + ";Persist Security Info=True;User ID=" + Usuario + ";Password=" + Senha + "";
            string query = "select distinct Comprimento from Modelo_Eng where Modelo = '" + comboBox_expositor.Text + "' and Profundidade = '" + comboBox_largura_expositor.Text + "'"; // Substitua pelo nome correto da coluna e tabela

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
                        comboBox_tamanho_expositor.Items.Clear();

                        // Preencha o ComboBox com os dados do DataTable
                        foreach (DataRow row in dataTable.Rows)
                        {
                            comboBox_tamanho_expositor.Items.Add(row["Comprimento"].ToString());
                        }
                    }
                }
                connection.Close();
            }
            Cursor.Current = Cursors.Default;
        }

        private void comboBox_tamanho_expositor_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimparTableLayoutPanel(tableLayoutPanel1);
            // Verifique se o item selecionado em comboBox1 é o que você deseja
            if (comboBox_tamanho_expositor.SelectedItem != null)
            {
                // Se for o item desejado, habilite comboBox2
                comboBox_cor_interna.Enabled = true;
                label_cor_interna.Enabled = true;
            }
            else
            {
                // Caso contrário, desabilite comboBox2
                comboBox_cor_interna.Enabled = false;
                label_cor_interna.Enabled = false;
                // Você também pode limpar a seleção em comboBox2, se desejar
                comboBox_cor_interna.SelectedIndex = -1;
            }
            if (comboBox_expositor.SelectedItem != null && comboBox_tamanho_expositor != null)
            {
                CarregarAcessorios();
            }
        }

        private void comboBox_cor_interna_DropDown(object sender, EventArgs e)
        {
            CarregarCorInterna();
        }
        private void CarregarCorInterna()
        {
            Cursor.Current = Cursors.WaitCursor;
            string connectionString = @"Data Source=" + Instancia + ";Initial Catalog=" + Banco + ";Persist Security Info=True;User ID=" + Usuario + ";Password=" + Senha + "";
            string query = "select Cores from Gen_GrupoCores where Grupo_Cor = 'Interno'"; // Substitua pelo nome correto da coluna e tabela

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
                        comboBox_cor_interna.Items.Clear();

                        // Preencha o ComboBox com os dados do DataTable
                        foreach (DataRow row in dataTable.Rows)
                        {
                            comboBox_cor_interna.Items.Add(row["Cores"].ToString());
                        }
                    }
                }
                connection.Close();
            }
            Cursor.Current = Cursors.Default;
        }

        private void comboBox_cor_interna_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verifique se o item selecionado em comboBox1 é o que você deseja
            if (comboBox_cor_interna.SelectedItem != null)
            {
                // Se for o item desejado, habilite comboBox2
                comboBox_cor_acabamento.Enabled = true;
                label_cor_externa_acabamento.Enabled = true;
            }
            else
            {
                // Caso contrário, desabilite comboBox2
                comboBox_cor_acabamento.Enabled = false;
                label_cor_externa_acabamento.Enabled = false;
                // Você também pode limpar a seleção em comboBox2, se desejar
                comboBox_cor_acabamento.SelectedIndex = -1;
            }
        }



        private void comboBox_cor_externa_rodape_DropDown(object sender, EventArgs e)
        {
            CarregarCorExternaRodape();
        }
        private void CarregarCorExternaRodape()
        {
            Cursor.Current = Cursors.WaitCursor;
            string connectionString = @"Data Source=" + Instancia + ";Initial Catalog=" + Banco + ";Persist Security Info=True;User ID=" + Usuario + ";Password=" + Senha + "";
            string query = "select Cores from Gen_GrupoCores where Grupo_Cor = 'externo rodape'"; // Substitua pelo nome correto da coluna e tabela

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
                        comboBox_cor_externa_rodape.Items.Clear();

                        // Preencha o ComboBox com os dados do DataTable
                        foreach (DataRow row in dataTable.Rows)
                        {
                            comboBox_cor_externa_rodape.Items.Add(row["Cores"].ToString());
                        }
                    }
                }
                connection.Close();
            }
            Cursor.Current = Cursors.Default;
        }

        private void comboBox_cor_externa_rodape_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verifique se o item selecionado em comboBox1 é o que você deseja
            if (comboBox_cor_externa_rodape.SelectedItem != null)
            {
                // Se for o item desejado, habilite comboBox2
                comboBox_cabeceira_esq.Enabled = true;
                label_cabeceira_esquerda.Enabled = true;
            }
            else
            {
                // Caso contrário, desabilite comboBox2
                comboBox_cabeceira_esq.Enabled = false;
                label_cabeceira_esquerda.Enabled = false;
                // Você também pode limpar a seleção em comboBox2, se desejar
                comboBox_cabeceira_esq.SelectedIndex = -1;
            }
        }

        private void CarregarAcessorios()
        {

            // Percorra todas as células do TableLayoutPanel
            for (int row = 0; row < tableLayoutPanel1.RowCount; row++)
            {
                for (int col = 0; col < tableLayoutPanel1.ColumnCount; col++)
                {
                    // Obtenha o controle na célula
                    Control control = tableLayoutPanel1.GetControlFromPosition(col, row);

                    // Verifique se há um controle na célula
                    if (control != null)
                    {
                        // Remova o controle da célula
                        tableLayoutPanel1.Controls.Remove(control);

                        // Libere os recursos do controle (se necessário)
                        control.Dispose();
                    }
                }
            }


            string consultaSql = "select distinct grp_caracteristica from Modelo_Acessorios where Modelo = '" + comboBox_expositor.Text + "' and Profundidade = '" + comboBox_largura_expositor.Text + "' and Comprimento = '" + comboBox_tamanho_expositor.Text + "' and Mostrar_Config = '1' and grp_caracteristica is not null";

            DataTable tabelaResultados = new DataTable();

            using (SqlConnection conexao = new SqlConnection(@"Data Source=" + Instancia + ";Initial Catalog=" + Banco + ";Persist Security Info=True;User ID=" + Usuario + ";Password=" + Senha + ""))
            {
                conexao.Open();

                using (SqlCommand comando = new SqlCommand(consultaSql, conexao))
                {
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        tabelaResultados.Load(reader);

                    }
                }
            }


            numeroDeLinhasCriadas = tabelaResultados.Rows.Count;
            // Adicione os cabeçalhos à primeira linha (linha 0)
            Label labelGrupo = new Label();
            labelGrupo.Text = "Grupo";
            labelGrupo.BackColor = SystemColors.ControlDark;
            labelGrupo.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(labelGrupo, 0, 0);

            Label labelAcessorios = new Label();
            labelAcessorios.Text = "Acessórios";
            labelAcessorios.BackColor = SystemColors.ControlDark;
            labelAcessorios.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(labelAcessorios, 1, 0);

            Label labelQtd = new Label();
            labelQtd.Text = "Qtd";
            labelQtd.BackColor = SystemColors.ControlDark;
            labelQtd.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(labelQtd, 2, 0);

            for (int i = 0; i < tabelaResultados.Rows.Count; i++)
            {
                int rowIndex = i + 1; // Começando na linha 1 após o cabeçalho

                // Adicione os dados à primeira coluna (coluna 0)
                Label label = new Label();
                label.Text = tabelaResultados.Rows[i]["grp_caracteristica"].ToString();
                tableLayoutPanel1.Controls.Add(label, 0, rowIndex);

                // Adicione o ComboBox à segunda coluna (coluna 1)
                ComboBox comboBox = new ComboBox();
                comboBox.Dock = DockStyle.Fill; // Preenche toda a célula
                                                // Configure as propriedades do ComboBox conforme necessário
                                                //comboBox.Items.Add(""); // Adicione um item em branco

                // Configure as propriedades do ComboBox conforme necessário
                tableLayoutPanel1.Controls.Add(comboBox, 1, rowIndex);

                // Adicione um NumericUpDown para a terceira coluna (coluna 2) para a quantidade (Qtd)
                NumericUpDown numericUpDownQtd = new NumericUpDown();
                numericUpDownQtd.Dock = DockStyle.Fill; // Preenche toda a célula
                                                        // Configure as propriedades do NumericUpDown conforme necessário
                numericUpDownQtd.Minimum = 0; // Define o valor mínimo
                                              //numericUpDownQtd.Maximum = 100; // Define o valor máximo
                                              // Define o valor inicial
                numericUpDownQtd.DecimalPlaces = 0; // Define a quantidade de casas decimais (0 para números inteiros)
                numericUpDownQtd.Increment = 1; // Define o incremento/decremento
                tableLayoutPanel1.Controls.Add(numericUpDownQtd, 2, rowIndex);


                // Adicione o evento DropDown para executar a consulta
                comboBox.DropDown += (sender, e) =>
                {
                    // Recupere o valor do Label associado a este ComboBox
                    int rowIndex = tableLayoutPanel1.GetRow(comboBox);
                    Control labelControl = tableLayoutPanel1.GetControlFromPosition(0, rowIndex);
                    string valorLabel = (labelControl as Label)?.Text;

                    // Execute a consulta SQL
                    string consultaSql = "SELECT DISTINCT Componente FROM Modelo_Acessorios WHERE Modelo = @Modelo and Profundidade = @Profundidade AND Comprimento = @Medida AND Mostrar_Config = '1' AND grp_caracteristica = @ValorLabel";

                    using (SqlConnection conexao = new SqlConnection(@"Data Source=" + Instancia + ";Initial Catalog=" + Banco + ";Persist Security Info=True;User ID=" + Usuario + ";Password=" + Senha + ""))
                    {
                        conexao.Open();

                        using (SqlCommand comando = new SqlCommand(consultaSql, conexao))
                        {
                            comando.Parameters.AddWithValue("@Modelo", comboBox_expositor.Text);
                            comando.Parameters.AddWithValue("@Medida", comboBox_tamanho_expositor.Text);
                            comando.Parameters.AddWithValue("@Profundidade", comboBox_largura_expositor.Text);
                            comando.Parameters.AddWithValue("@ValorLabel", valorLabel);

                            using (SqlDataReader reader = comando.ExecuteReader())
                            {
                                comboBox.Items.Clear(); // Limpe os itens existentes
                                                        // Adicione o item em branco novamente
                                comboBox.Items.Add("");

                                while (reader.Read())
                                {
                                    string componente = reader["Componente"].ToString();
                                    comboBox.Items.Add(componente);
                                }
                            }
                        }
                    }



                    comboBox.SelectedIndexChanged += (s, args) =>
                    {
                        if (comboBox.SelectedIndex > 0)
                        {
                            acessoriosSelecionados = comboBox.SelectedItem.ToString();

                            string consultaValorMaximo = "SELECT Qtd_nivel FROM Modelo_Acessorios WHERE Modelo = @Modelo AND Profundidade = @Profundidade AND Comprimento = @Comprimento AND Componente = @Componente";

                            using (SqlConnection conexao = new SqlConnection(@"Data Source=" + Instancia + ";Initial Catalog=" + Banco + ";Persist Security Info=True;User ID=" + Usuario + ";Password=" + Senha + ""))
                            {
                                conexao.Open();

                                using (SqlCommand comandoValorMaximo = new SqlCommand(consultaValorMaximo, conexao))
                                {
                                    comandoValorMaximo.Parameters.AddWithValue("@Modelo", comboBox_expositor.Text);
                                    comandoValorMaximo.Parameters.AddWithValue("@Profundidade", comboBox_largura_expositor.Text);
                                    comandoValorMaximo.Parameters.AddWithValue("@Comprimento", comboBox_tamanho_expositor.Text);
                                    comandoValorMaximo.Parameters.AddWithValue("@Componente", acessoriosSelecionados); // Substitua isso pelo valor correto selecionado no ComboBox

                                    // Execute a consulta e obtenha o valor máximo
                                    object resultado = comandoValorMaximo.ExecuteScalar();

                                    if (resultado != null && resultado != DBNull.Value)
                                    {
                                        // Defina o valor máximo do NumericUpDown com base no resultado da consulta
                                        int valorMaximo = Convert.ToInt32(resultado);
                                        numericUpDownQtd.Minimum = 1;
                                        numericUpDownQtd.Maximum = valorMaximo;
                                        numericUpDownQtd.Value = valorMaximo;
                                    }
                                    else
                                    {
                                        // Se o resultado da consulta for nulo, defina um valor padrão, se necessário
                                        numericUpDownQtd.Maximum = 100; // Valor padrão
                                    }
                                    int qtd = (int)resultado;
                                    qtdSelecionada = qtd;
                                }
                            }

                            // Obtém o valor do NumericUpDown
                            //int qtd = (int)numericUpDownQtd.Value;


                        }
                        else
                        {
                            numericUpDownQtd.Minimum = 0;
                            numericUpDownQtd.Maximum = 0;
                            numericUpDownQtd.Value = 0;
                        }
                    };
                    // Event handler para o NumericUpDown
                    numericUpDownQtd.ValueChanged += (sender, e) =>
                    {
                        // Obtém o valor do NumericUpDown quando ele é alterado
                        int qtd = (int)numericUpDownQtd.Value;
                        qtdSelecionada = qtd;
                    };

                };

                // Altere as cores de fundo das células alternadamente
                if (i % 2 == 0)
                {
                    // Cor para linhas pares (controlLight)
                    label.BackColor = SystemColors.ControlLight;
                    comboBox.BackColor = SystemColors.ControlLight;
                    numericUpDownQtd.BackColor = SystemColors.ControlLight;
                }
                else
                {
                    // Cor para linhas ímpares (control)
                    label.BackColor = SystemColors.Control;
                    comboBox.BackColor = SystemColors.Control;
                    numericUpDownQtd.BackColor = SystemColors.Control;
                }
            }


        }



        private void comboBox_tipo_refrigeracao_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verifique se o item selecionado em comboBox1 é o que você deseja
            if (comboBox_tipo_refrigeracao.SelectedItem != null)
            {
                // Se for o item desejado, habilite comboBox2
                comboBox_expositor.Enabled = true;
                label_modelo_expositor.Enabled = true;
            }
            else
            {
                // Caso contrário, desabilite comboBox2
                comboBox_expositor.Enabled = false;
                label_modelo_expositor.Enabled = false;
                // Você também pode limpar a seleção em comboBox2, se desejar
                comboBox_expositor.SelectedIndex = -1;
            }
        }

        private void comboBox_cor_acabamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verifique se o item selecionado em comboBox1 é o que você deseja
            if (comboBox_cor_acabamento.SelectedItem != null)
            {
                // Se for o item desejado, habilite comboBox2
                comboBox_cor_externa_rodape.Enabled = true;
                label_cor_externa_rodape.Enabled = true;
            }
            else
            {
                // Caso contrário, desabilite comboBox2
                comboBox_cor_externa_rodape.Enabled = false;
                label_cor_externa_rodape.Enabled = false;
                // Você também pode limpar a seleção em comboBox2, se desejar
                comboBox_cor_externa_rodape.SelectedIndex = -1;
            }
        }

        private void comboBox_cabeceira_esq_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verifique se o item selecionado em comboBox1 é o que você deseja
            if (comboBox_cabeceira_esq.SelectedItem != null)
            {
                // Se for o item desejado, habilite comboBox2
                comboBox_cabeceira_dir.Enabled = true;
                label_cabeceira_dir.Enabled = true;
            }
            else
            {
                // Caso contrário, desabilite comboBox2
                comboBox_cabeceira_dir.Enabled = false;
                label_cabeceira_dir.Enabled = false;
                // Você também pode limpar a seleção em comboBox2, se desejar
                comboBox_cabeceira_dir.SelectedIndex = -1;
            }
        }

        private void comboBox_tipo_refrigeracao_DropDown(object sender, EventArgs e)
        {
            CarregarTipoRefrigeracao();
        }
        private void CarregarTipoRefrigeracao()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string connectionString = @"Data Source=" + Instancia + ";Initial Catalog=" + Banco + ";Persist Security Info=True;User ID=" + Usuario + ";Password=" + Senha + "";
                string query = "select Tipo_Refrigeracao from Modelo_Tipo_Refrigeracao where Regime = @Regime"; // Substitua pelo nome correto da coluna e tabela

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Regime", comboBox_Temperatura.Text);
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            // Limpe os itens existentes no ComboBox
                            comboBox_tipo_refrigeracao.Items.Clear();


                            // Preencha o ComboBox com os dados do DataTable
                            foreach (DataRow row in dataTable.Rows)
                            {
                                comboBox_tipo_refrigeracao.Items.Add(row["Tipo_Refrigeracao"].ToString());
                            }
                        }
                    }
                    connection.Close();
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox_cor_acabamento_DropDown(object sender, EventArgs e)
        {
            CarregarCorAcabamento();
        }

        private void CarregarCorAcabamento()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string connectionString = @"Data Source=" + Instancia + ";Initial Catalog=" + Banco + ";Persist Security Info=True;User ID=" + Usuario + ";Password=" + Senha + "";
                string query = "select Cores from Gen_GrupoCores where Grupo_Cor = 'externo acab'"; // Substitua pelo nome correto da coluna e tabela

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        //command.Parameters.AddWithValue("@Regime", comboBox_Temperatura.Text);
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            // Limpe os itens existentes no ComboBox
                            comboBox_cor_acabamento.Items.Clear();

                            // Preencha o ComboBox com os dados do DataTable
                            foreach (DataRow row in dataTable.Rows)
                            {
                                comboBox_cor_acabamento.Items.Add(row["Cores"].ToString());
                            }
                        }
                    }
                    connection.Close();
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox_cabeceira_esq_DropDown(object sender, EventArgs e)
        {
            CarregarCabeceiraEsq();
        }
        private void CarregarCabeceiraEsq()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string connectionString = @"Data Source=" + Instancia + ";Initial Catalog=" + Banco + ";Persist Security Info=True;User ID=" + Usuario + ";Password=" + Senha + "";
                string query = "select Cabeceira from Modelo_Cabeceira where Modelo = @Modelo and Profundidade = @Profundidade and Comprimento = @Medida and (Lado = 'A' or Lado = 'E')"; // Substitua pelo nome correto da coluna e tabela

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Modelo", comboBox_expositor.Text);
                        command.Parameters.AddWithValue("@Medida", comboBox_tamanho_expositor.Text);
                        command.Parameters.AddWithValue("@Profundidade", comboBox_largura_expositor.Text);
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            // Limpe os itens existentes no ComboBox
                            comboBox_cabeceira_esq.Items.Clear();

                            comboBox_cabeceira_esq.Items.Add("");

                            // Preencha o ComboBox com os dados do DataTable
                            foreach (DataRow row in dataTable.Rows)
                            {
                                comboBox_cabeceira_esq.Items.Add(row["Cabeceira"].ToString());
                            }
                        }
                    }
                    connection.Close();
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox_cabeceira_dir_DropDown(object sender, EventArgs e)
        {
            CarregarCabeceiraDir();
        }
        private void CarregarCabeceiraDir()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string connectionString = @"Data Source=" + Instancia + ";Initial Catalog=" + Banco + ";Persist Security Info=True;User ID=" + Usuario + ";Password=" + Senha + "";
                string query = "select Cabeceira from Modelo_Cabeceira where Modelo = @Modelo and Profundidade = @Profundidade and Comprimento = @Medida and (Lado = 'A' or Lado = 'D')"; // Substitua pelo nome correto da coluna e tabela

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Modelo", comboBox_expositor.Text);
                        command.Parameters.AddWithValue("@Medida", comboBox_tamanho_expositor.Text);
                        command.Parameters.AddWithValue("@Profundidade", comboBox_largura_expositor.Text);
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            // Limpe os itens existentes no ComboBox
                            comboBox_cabeceira_dir.Items.Clear();

                            comboBox_cabeceira_dir.Items.Add("");

                            // Preencha o ComboBox com os dados do DataTable
                            foreach (DataRow row in dataTable.Rows)
                            {
                                comboBox_cabeceira_dir.Items.Add(row["Cabeceira"].ToString());
                            }
                        }
                    }
                    connection.Close();
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void button_adicionar_Click(object sender, EventArgs e)
        {


            Cursor.Current = Cursors.WaitCursor;
            VerificarAlinhamento();
            if (numericUpDown_qtd_modelo.Value == 0)
            {
                MessageBox.Show("Quantidade de expositor esta zerado!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Sai do método sem executar o procedimento
            }
            if (textBox_cidade.Text == "")
            {
                MessageBox.Show("Cidade esta vazio!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Sai do método sem executar o procedimento
            }
            if (textBox_UF.Text == "")
            {
                MessageBox.Show("UF esta vazio!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Sai do método sem executar o procedimento
            }
            if (textBox_endereco.Text == "")
            {
                MessageBox.Show("Endereço esta vazio!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Sai do método sem executar o procedimento
            }

            if (comboBox_vendedor.Text == "")
            {
                MessageBox.Show("Vendedor esta vazio!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Sai do método sem executar o procedimento
            }
            if (comboBox_vendedor.Text == "")
            {
                MessageBox.Show("Vendedor esta vazio!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Sai do método sem executar o procedimento
            }

            if (comboBox_vendedor.Text == "")
            {
                MessageBox.Show("Vendedor esta vazio!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Sai do método sem executar o procedimento
            }
            if (comboBox_cliente.Text == "")
            {
                MessageBox.Show("Cliente esta vazio!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Sai do método sem executar o procedimento
            }
            if (textBox_loja.Text == "")
            {
                MessageBox.Show("Loja esta vazio!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Sai do método sem executar o procedimento
            }
            if (comboBox_Temperatura.Text == "")
            {
                MessageBox.Show("Temperatura esta vazio!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Sai do método sem executar o procedimento
            }
            if (comboBox_tipo_refrigeracao.Text == "")
            {
                MessageBox.Show("Tipo refrigeração esta vazio!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Sai do método sem executar o procedimento
            }
            if (comboBox_expositor.Text == "")
            {
                MessageBox.Show("Modelo esta vazio!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Sai do método sem executar o procedimento
            }
            if (comboBox_largura_expositor.Text == "")
            {
                MessageBox.Show("Largura do expositor esta vazio!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Sai do método sem executar o procedimento
            }
            if (comboBox_tamanho_expositor.Text == "")
            {
                MessageBox.Show("Tamanho do expositor esta vazio!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Sai do método sem executar o procedimento
            }
            if (comboBox_cor_interna.Text == "")
            {
                MessageBox.Show("Cor interna esta vazio!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Sai do método sem executar o procedimento
            }
            if (comboBox_cor_acabamento.Text == "")
            {
                MessageBox.Show("Cor externa acabamento esta vazio!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Sai do método sem executar o procedimento
            }
            if (comboBox_cor_externa_rodape.Text == "")
            {
                MessageBox.Show("Cor externa rodapé esta vazio!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Sai do método sem executar o procedimento
            }
            if (comboBox_cabeceira_esq.Text == "")
            {
                MessageBox.Show("Cabeceira esquerda esta vazio!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Sai do método sem executar o procedimento
            }
            if (comboBox_cabeceira_dir.Text == "")
            {
                MessageBox.Show("Cabeceira direita esta vazio!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Sai do método sem executar o procedimento
            }
            if (!string.IsNullOrEmpty(acessoriosSelecionados) && qtdSelecionada != 0)
            {
                for (int row = 1; row <= numeroDeLinhasCriadas; row++) // Comece na linha 1 para evitar o cabeçalho
                {
                    // Obtenha o ComboBox "Acessórios" da linha atual
                    ComboBox comboBoxAcessorios = tableLayoutPanel1.GetControlFromPosition(1, row) as ComboBox;

                    // Obtenha o TextBox "Qtd" da linha atual
                    NumericUpDown textBoxQtd = tableLayoutPanel1.GetControlFromPosition(2, row) as NumericUpDown;

                    // Verifique se o ComboBox "Acessórios" e o TextBox "Qtd" estão disponíveis
                    if (comboBoxAcessorios != null && textBoxQtd != null)
                    {
                        string acessorios = comboBoxAcessorios.Text;
                        string cor = VerificarCor(acessorios);

                        // Tente converter o valor da caixa de texto em um inteiro
                        if (int.TryParse(textBoxQtd.Text, out int qtd))
                        {
                            if (cor == "Sem cor")
                            {
                                CadastrarAcessorios(acessorios, qtd, "");
                            }
                            else if (cor == "Interno")
                            {
                                CadastrarAcessorios(acessorios, qtd, comboBox_cor_interna.Text);
                            }
                            else if (cor == "externo rodape")
                            {
                                CadastrarAcessorios(acessorios, qtd, comboBox_cor_externa_rodape.Text);
                            }
                            else if (cor == "externo acab")
                            {
                                CadastrarAcessorios(acessorios, qtd, comboBox_cor_acabamento.Text);
                            }
                            // Chame o método CadastrarAcessorios para cada linha

                        }
                        else
                        {
                            MessageBox.Show("Quantidade de acessório na linha " + row + " é inválida!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return; // Sai do método em caso de erro
                        }
                    }
                    else
                    {
                        MessageBox.Show("Acessório ou quantidade não encontrados na linha " + row + "!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // Sai do método em caso de erro
                    }
                }
            }

            CadastrarCabeceiraesq();
            CadastrarCabeceiradir();
            CadastrarAcessoriosObrigatorio();
            CadastrarModelo();
            CadastrarCabecalhoOrcamento();
            MostrarValorTotal();
            MostrarDadosNoDataGridView();
            LimparCampos();
            if (txtPorcentagem.Text != "" || txtValorFechado.Text != "")
            {
                label_calcular_novamente.Visible = true;
                button_imprimir.Enabled = false;
            }
            Cursor.Current = Cursors.Default;
        }

        private void LimparCampos()
        {
            Cursor.Current = Cursors.WaitCursor;

            // Limpar os ComboBoxes definindo o índice selecionado como -1
            comboBox_Temperatura.SelectedIndex = -1;
            comboBox_tipo_refrigeracao.SelectedIndex = -1;
            comboBox_expositor.SelectedIndex = -1;
            comboBox_largura_expositor.SelectedIndex = -1;
            comboBox_tamanho_expositor.SelectedIndex = -1;
            comboBox_cor_interna.SelectedIndex = -1;
            comboBox_cor_acabamento.SelectedIndex = -1;
            comboBox_cor_externa_rodape.SelectedIndex = -1;
            comboBox_cabeceira_esq.SelectedIndex = -1;
            comboBox_cabeceira_dir.SelectedIndex = -1;
            numericUpDown_qtd_modelo.Value = 0;
            Cursor.Current = Cursors.Default;
        }

        private string VerificarCor(string acessorio)
        {
            // Defina sua string de conexão com o banco de dados SQL Server
            string connectionString = @"Data Source=" + Instancia + ";Initial Catalog=" + Banco + ";Persist Security Info=True;User ID=" + Usuario + ";Password=" + Senha + "";

            // Crie uma conexão com o banco de dados
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Abra a conexão
                    connection.Open();

                    // Defina a consulta SQL para buscar a cor do acessório
                    string query = "select Cores from Modelo_Acessorios \n" +
                                    "where Modelo = @Modelo and Profundidade = @Profundidade and Comprimento = @Comprimento \n" +
                                    "and Componente = @Acessorio \n" +
                                    "union all \n" +
                                    "select Cor from Modelo_Cabeceira where Modelo = @Modelo and Profundidade = @Profundidade and Comprimento = @Comprimento \n" +
                                    "and Cabeceira = @Acessorio";

                    // Crie um comando SQL com parâmetros
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Adicione o parâmetro para o nome do acessório
                        command.Parameters.AddWithValue("@Modelo", comboBox_expositor.Text);
                        command.Parameters.AddWithValue("@Profundidade", comboBox_largura_expositor.Text);
                        command.Parameters.AddWithValue("@Comprimento", comboBox_tamanho_expositor.Text);
                        command.Parameters.AddWithValue("@Acessorio", acessorio);

                        // Execute a consulta e obtenha o resultado
                        object result = command.ExecuteScalar();

                        // Verifique se a consulta retornou algum valor
                        if (result != null)
                        {
                            return result.ToString(); // Retorna a cor como uma string
                        }
                        else
                        {
                            return "Cor não encontrada"; // Acessório não encontrado no banco de dados
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Trate qualquer exceção que possa ocorrer durante a consulta
                    Console.WriteLine("Ocorreu um erro: " + ex.Message);
                    return "Erro ao consultar a cor";
                }
            }
        }

        private void MostrarDadosNoDataGridView()
        {
            try
            {
                if (Pedido == "novo")
                {
                    Pedido = textBox_num_cotacao.Text;
                }
                using (SqlConnection con = new SqlConnection(@"Data Source=" + Instancia + ";Initial Catalog=" + Banco + ";Persist Security Info=True;User ID=" + Usuario + ";Password=" + Senha))
                {
                    con.Open();

                    string query = "SELECT Alinhamento, Temperatura, Tipo_Refrigeracao, Modelo_Expositor, Largura_Expositor, Tamanho_Expositor, Cor_Interna, Cor_Externa_acabamento, Cor_Externa_Rodape, Valor as Valor_uni,Preco_Desc_Over,Qtde,Valor_X_Qtd,Preco_Desc_Over_X_Qtd FROM OrcModelo WHERE Num_cotacao = @Num_cotacao AND Revisao = ''";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Num_cotacao", Pedido);
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataSet dataSet = new DataSet();

                        adapter.Fill(dataSet, "OrcModelo"); // Preenche o DataSet com os dados da consulta

                        // Define o DataSource do DataGridView para o DataTable dentro do DataSet
                        dataGridView_Modelo.DataSource = dataSet.Tables["OrcModelo"];
                    }

                    con.Close();
                }
                ConfigurarDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ConfigurarDataGridView()
        {
            // Certifique-se de chamar este método antes de configurar os dados no DataGridView.

            // Define o DataGridView para ajustar automaticamente o tamanho das colunas com base no conteúdo.
            foreach (DataGridViewColumn column in dataGridView_Modelo.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            // Outras configurações do DataGridView, se necessário.
            dataGridView_Modelo.AutoGenerateColumns = false; // Desligue a geração automática de colunas se você tiver definido as colunas manualmente.
            dataGridView_Modelo.AllowUserToAddRows = false; // Desligue a linha em branco no final, se necessário.
        }



        private void CadastrarCabecalhoOrcamento()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=" + Instancia + ";Initial Catalog=" + Banco + ";Persist Security Info=True;User ID=" + Usuario + ";Password=" + Senha))
                {
                    con.Open();
                    using (SqlTransaction transaction = con.BeginTransaction())
                    {
                        string query = "create table #temp1 (valor float,valor_fechado float, desconto float) \n" +
                                        "insert into #temp1    \n" +
                                        "select Valor*OrcModelo.Qtde as Valor, Preco_Desc_Over*OrcModelo.Qtde as Preco_Desc_Over,(select porcent_desconto_over from OrcCabecalho where Num_cotacao = @Num_cotacao) as porcent from OrcModelo \n" +
                                        "WHERE Num_cotacao = @Num_cotacao \n" +
                                        "AND Revisao = @Revisao \n" +
                                        "delete from OrcCabecalho where Num_cotacao = @Num_cotacao and Revisao = @Revisao \n" +
                                        "insert into OrcCabecalho values(@Num_cotacao,@Revisao,@Cliente,@Loja,(select round(SUM(Valor), 2) as valor from #temp1),(select round(SUM(valor_fechado),2) as valor_fechado from #temp1),(select distinct desconto from #temp1),@Vendedor,@Cidade,@UF,@Endereco)  \n" +
                                        "drop table #temp1";
                        using (SqlCommand cmd = new SqlCommand(query, con, transaction))
                        {
                            cmd.Parameters.AddWithValue("@Num_cotacao", textBox_num_cotacao.Text);
                            cmd.Parameters.AddWithValue("@Revisao", "");
                            cmd.Parameters.AddWithValue("@Modelo", comboBox_expositor.Text);
                            cmd.Parameters.AddWithValue("@Cliente", comboBox_cliente.Text);
                            cmd.Parameters.AddWithValue("@Loja", textBox_loja.Text);
                            cmd.Parameters.AddWithValue("@Vendedor", comboBox_vendedor.Text);

                            cmd.Parameters.AddWithValue("@Cidade", textBox_cidade.Text);
                            cmd.Parameters.AddWithValue("@UF", textBox_UF.Text);
                            cmd.Parameters.AddWithValue("@Endereco", textBox_endereco.Text);
                            cmd.ExecuteNonQuery();
                        }
                        transaction.Commit();
                    }
                    con.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CadastrarAcessoriosObrigatorio()
        {
            List<ComponenteCor> listaComponentesCores = ConsultarComponenteECor();
            foreach (ComponenteCor componenteCor in listaComponentesCores)
            {
                if (componenteCor.Cor == "Sem cor")
                {
                    CadastrarAcessorios(componenteCor.Componente, 1, "");
                }
                else if (componenteCor.Cor == "Interno")
                {
                    CadastrarAcessorios(componenteCor.Componente, 1, comboBox_cor_interna.Text);
                }
                else if (componenteCor.Cor == "externo rodape")
                {
                    CadastrarAcessorios(componenteCor.Componente, 1, comboBox_cor_externa_rodape.Text);
                }
                else if (componenteCor.Cor == "externo acab")
                {
                    CadastrarAcessorios(componenteCor.Componente, 1, comboBox_cor_acabamento.Text);
                }
            }

        }

        private List<ComponenteCor> ConsultarComponenteECor()
        {
            List<ComponenteCor> componentesCores = new List<ComponenteCor>();

            // Defina sua string de conexão com o banco de dados SQL Server
            string connectionString = @"Data Source=" + Instancia + ";Initial Catalog=" + Banco + ";Persist Security Info=True;User ID=" + Usuario + ";Password=" + Senha + "";

            // Crie uma conexão com o banco de dados
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Abra a conexão
                    connection.Open();

                    // Defina a consulta SQL
                    string query = @"SELECT Modelo_Acessorios.Componente
                             FROM Modelo_Acessorios
                             WHERE Mostrar_Config = 0 
                             AND Modelo_Acessorios.Modelo = @Modelo 
                             AND Modelo_Acessorios.Comprimento = @Comprimento 
                             AND Modelo_Acessorios.profundidade = @Profundidade";

                    // Crie um comando SQL
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Modelo", comboBox_expositor.Text);
                        command.Parameters.AddWithValue("@Comprimento", comboBox_tamanho_expositor.Text);
                        command.Parameters.AddWithValue("@Profundidade", comboBox_largura_expositor.Text);
                        // Execute a consulta e obtenha o resultado em um leitor de dados (DataReader)
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Verifique se há linhas retornadas
                            if (reader.HasRows)
                            {
                                // Itere pelas linhas resultantes da consulta
                                while (reader.Read())
                                {
                                    // Obtenha o valor da coluna "Componente"
                                    string componente = reader["Componente"].ToString();

                                    // Chame a função VerificarCor para obter a cor do componente
                                    string cor = VerificarCor(componente);

                                    // Crie um objeto ComponenteCor e adicione à lista
                                    ComponenteCor componenteCor = new ComponenteCor
                                    {
                                        Componente = componente,
                                        Cor = cor
                                    };

                                    componentesCores.Add(componenteCor);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Trate qualquer exceção que possa ocorrer durante a consulta
                    Console.WriteLine("Ocorreu um erro: " + ex.Message);
                }
            }

            return componentesCores;
        }


        private void VerificarAlinhamento()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=" + Instancia + ";Initial Catalog=" + Banco + ";Persist Security Info=True;User ID=" + Usuario + ";Password=" + Senha))
                {
                    con.Open();
                    using (SqlTransaction transaction = con.BeginTransaction())
                    {
                        string query = "select TOP 1 alinhamento from OrcAcessorio where Num_cotacao = @Num_cotacao and Revisao = @Revisao ORDER BY alinhamento DESC";
                        using (SqlCommand cmd = new SqlCommand(query, con, transaction))
                        {
                            cmd.Parameters.AddWithValue("@Num_cotacao", textBox_num_cotacao.Text);
                            cmd.Parameters.AddWithValue("@Revisao", "");

                            // Execute a consulta e obtenha o resultado
                            object result = cmd.ExecuteScalar();

                            if (result != null && result != DBNull.Value)
                            {
                                int alinhamento = Convert.ToInt32(result);

                                // Adicione 1 ao resultado
                                AlinhamentoModelo = alinhamento + 1;
                            }
                            else
                            {
                                // Se o resultado for nulo ou vazio, adicione 1
                                AlinhamentoModelo = 1;
                            }
                        }
                        transaction.Commit();
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CadastrarAcessorios(string acessorio, int qtd, string cor)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=" + Instancia + ";Initial Catalog=" + Banco + ";Persist Security Info=True;User ID=" + Usuario + ";Password=" + Senha))
                {
                    con.Open();
                    using (SqlTransaction transaction = con.BeginTransaction())
                    {
                        string query = "insert into OrcAcessorio values \n" +
                                        "(@Num_cotacao, @Revisao, @alinhamento, @Modelo, @Profundidade, @Medida, @Acessorio, \n" +
                                        "(select Codigos from Modelo_Acessorios where Modelo = @Modelo and Comprimento = @Medida and Profundidade = @Profundidade and Componente = @Acessorio ),  \n" +
                                        "@Quantidade,(select PrdOrc.Preco from Modelo_Acessorios \n" +
                                        "inner join PrdOrc on Modelo_Acessorios.Codigos = PrdOrc.Codigos \n" +
                                        "where Modelo = @Modelo and Comprimento = @Medida and Profundidade = @Profundidade and Modelo_Acessorios.Componente = @Acessorio and PrdOrc.Cores = @Cor\n" +
                                        "),(select round(sum(PrdOrc.Preco * " + qtd + "),2) as Preco from Modelo_Acessorios \n" +
                                        "inner join PrdOrc on Modelo_Acessorios.Codigos = PrdOrc.Codigos \n" +
                                        "where Modelo = @Modelo and Comprimento = @Medida and Profundidade = @Profundidade and Modelo_Acessorios.Componente = @Acessorio and PrdOrc.Cores = @Cor),@Cor,0,0); ";
                        using (SqlCommand cmd = new SqlCommand(query, con, transaction))
                        {
                            cmd.Parameters.AddWithValue("@Num_cotacao", textBox_num_cotacao.Text);
                            cmd.Parameters.AddWithValue("@Revisao", "");
                            cmd.Parameters.AddWithValue("@Modelo", comboBox_expositor.Text);
                            cmd.Parameters.AddWithValue("@Acessorio", acessorio);
                            cmd.Parameters.AddWithValue("@alinhamento", AlinhamentoModelo);
                            cmd.Parameters.AddWithValue("@Medida", comboBox_tamanho_expositor.Text);
                            cmd.Parameters.AddWithValue("@Profundidade", comboBox_largura_expositor.Text);
                            cmd.Parameters.AddWithValue("@Quantidade", qtd);
                            //Corrigir para trazer a cor correta
                            cmd.Parameters.AddWithValue("@Cor", cor);
                            cmd.ExecuteNonQuery();
                        }
                        transaction.Commit();
                    }
                    con.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CadastrarCabeceiradir()
        {
            try
            {
                string cor = VerificarCor(comboBox_cabeceira_dir.Text);
                if (cor == "Sem cor")
                {
                    cor = "";
                }
                else if (cor == "Interno")
                {
                    cor = comboBox_cor_interna.Text;
                }
                else if (cor == "externo rodape")
                {
                    cor = comboBox_cor_externa_rodape.Text;
                }
                else if (cor == "externo acab")
                {
                    cor = comboBox_cor_acabamento.Text;
                }
                // Deletar o registro do banco de dados
                using (SqlConnection con = new SqlConnection(@"Data Source=" + Instancia + ";Initial Catalog=" + Banco + ";Persist Security Info=True;User ID=" + Usuario + ";Password=" + Senha))
                {
                    con.Open();
                    using (SqlTransaction transaction = con.BeginTransaction())
                    {
                        string query = "INSERT INTO [dbo].[OrcCabeceira] " +
                                           "([Num_cotacao] " +
                                           ",[Revisao] " +
                                          ",[Cabeceira] " +
                                          ",[Lado] " +
                                          ",[Alinhamento] " +
                                          ",[Modelo] " +
                                          ",[Profundidade] " +
                                          ",[Comprimento] " +
                                          ",[Codigo] " +
                                          ",[Valor]" +
                                          ",[Cor]) " +
                                     "VALUES(@Num_cotacao,@Revisao" +
                                     ",@Cabeceira,@Lado,@Alinhamento,@Modelo,@Profundidade,@Medida,(select Modelo_Cabeceira.Codigos from Modelo_Cabeceira \n" +
                                     "where Modelo = @Modelo and Comprimento = @Medida and Cabeceira = @Cabeceira ) \n" +
                                     ",(select PrdOrc.Preco from Modelo_Cabeceira \n" +
                                     "inner join PrdOrc on Modelo_Cabeceira.Codigos = PrdOrc.Codigos \n" +
                                     "where Modelo = @Modelo and Comprimento = @Medida and Cabeceira = @Cabeceira and PrdOrc.Situacao = 'A' and PrdOrc.Cores = @Cor ),@Cor)";
                        using (SqlCommand cmd = new SqlCommand(query, con, transaction))
                        {
                            cmd.Parameters.AddWithValue("@Num_cotacao", textBox_num_cotacao.Text);
                            cmd.Parameters.AddWithValue("@Revisao", "");
                            cmd.Parameters.AddWithValue("@Cabeceira", comboBox_cabeceira_esq.Text);
                            cmd.Parameters.AddWithValue("@Lado", 'D');

                            cmd.Parameters.AddWithValue("@Alinhamento", AlinhamentoModelo);
                            cmd.Parameters.AddWithValue("@Profundidade", comboBox_largura_expositor.Text);

                            cmd.Parameters.AddWithValue("@Modelo", comboBox_expositor.Text);
                            cmd.Parameters.AddWithValue("@Medida", comboBox_tamanho_expositor.Text);
                            //Corrigir COR
                            cmd.Parameters.AddWithValue("@Cor", cor);
                            cmd.ExecuteNonQuery();
                        }
                        transaction.Commit();
                    }
                    con.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CadastrarCabeceiraesq()
        {
            try
            {
                string cor = VerificarCor(comboBox_cabeceira_esq.Text);
                if (cor == "Sem cor")
                {
                    cor = "";
                }
                else if (cor == "Interno")
                {
                    cor = comboBox_cor_interna.Text;
                }
                else if (cor == "externo rodape")
                {
                    cor = comboBox_cor_externa_rodape.Text;
                }
                else if (cor == "externo acab")
                {
                    cor = comboBox_cor_acabamento.Text;
                }
                // Deletar o registro do banco de dados
                using (SqlConnection con = new SqlConnection(@"Data Source=" + Instancia + ";Initial Catalog=" + Banco + ";Persist Security Info=True;User ID=" + Usuario + ";Password=" + Senha))
                {
                    con.Open();
                    using (SqlTransaction transaction = con.BeginTransaction())
                    {
                        string query = "INSERT INTO [dbo].[OrcCabeceira] " +
                                           "([Num_cotacao] " +
                                           ",[Revisao] " +
                                          ",[Cabeceira] " +
                                          ",[Lado] " +
                                          ",[Alinhamento] " +
                                          ",[Modelo] " +
                                          ",[Profundidade] " +
                                          ",[Comprimento] " +
                                          ",[Codigo] " +
                                          ",[Valor]" +
                                          ",[Cor]) " +
                                     "VALUES(@Num_cotacao,@Revisao" +
                                     ",@Cabeceira,@Lado,@Alinhamento,@Modelo,@Profundidade,@Medida,(select Modelo_Cabeceira.Codigos from Modelo_Cabeceira \n" +
                                     "where Modelo = @Modelo and Comprimento = @Medida and Cabeceira = @Cabeceira ) \n" +
                                     ",(select PrdOrc.Preco from Modelo_Cabeceira \n" +
                                     "inner join PrdOrc on Modelo_Cabeceira.Codigos = PrdOrc.Codigos \n" +
                                     "where Modelo = @Modelo and Comprimento = @Medida and Cabeceira = @Cabeceira and PrdOrc.Situacao = 'A' and PrdOrc.Cores = @Cor ),@Cor)";
                        using (SqlCommand cmd = new SqlCommand(query, con, transaction))
                        {
                            cmd.Parameters.AddWithValue("@Num_cotacao", textBox_num_cotacao.Text);
                            cmd.Parameters.AddWithValue("@Revisao", "");
                            cmd.Parameters.AddWithValue("@Cabeceira", comboBox_cabeceira_esq.Text);
                            cmd.Parameters.AddWithValue("@Lado", 'E');

                            cmd.Parameters.AddWithValue("@Alinhamento", AlinhamentoModelo);
                            cmd.Parameters.AddWithValue("@Profundidade", comboBox_largura_expositor.Text);

                            cmd.Parameters.AddWithValue("@Modelo", comboBox_expositor.Text);
                            cmd.Parameters.AddWithValue("@Medida", comboBox_tamanho_expositor.Text);
                            //Corrigir COR
                            cmd.Parameters.AddWithValue("@Cor", cor);
                            cmd.ExecuteNonQuery();
                        }
                        transaction.Commit();
                    }
                    con.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CadastrarModelo()
        {
            try
            {
                // Deletar o registro do banco de dados
                using (SqlConnection con = new SqlConnection(@"Data Source=" + Instancia + ";Initial Catalog=" + Banco + ";Persist Security Info=True;User ID=" + Usuario + ";Password=" + Senha))
                {
                    con.Open();
                    using (SqlTransaction transaction = con.BeginTransaction())
                    {
                        string query = "create table #temp1 (valor float); \n" +
                                        "insert into #temp1   \n" +
                                        "SELECT valor as ValorTotal FROM OrcCabeceira \n" +
                                        "WHERE Num_cotacao = @Num_cotacao \n" +
                                        "AND Revisao = @Revisao \n" +
                                        "AND alinhamento = @Alinhamento \n" +
                                                "AND modelo = @Modelo \n" +
                                                "AND Profundidade = @Profundidade \n" +
                                                "AND comprimento = @Medida \n" +
                                            "UNION ALL \n" +
                                            "SELECT Valor_total FROM OrcAcessorio \n" +
                                            "WHERE Num_cotacao = @Num_cotacao \n" +
                                                "AND Revisao = @Revisao \n" +
                                                "AND alinhamento = @Alinhamento \n" +
                                                "AND modelo = @Modelo \n" +
                                                "AND Profundidade = @Profundidade \n" +
                                                "AND comprimento = @Medida; \n" +
                                                                "INSERT INTO[dbo].[orcModelo] \n" +
                                                                "([Num_cotacao] \n" +
                                                                ",[Revisao] \n" +
                                                                ",[Temperatura] \n" +
                                                                ",[Tipo_Refrigeracao] \n" +
                                                                ",[Modelo_Expositor] \n" +
                                                                ",[Largura_Expositor] \n" +
                                                                ",[Tamanho_Expositor] \n" +
                                                                ",[Cor_Interna] \n" +
                                                                ",[Cor_Externa_acabamento] \n" +
                                                                ",[Cor_Externa_Rodape] \n" +
                                                                ",[Valor],[Alinhamento],[Qtde],[Valor_X_Qtd]) \n" +
                                        "VALUES(@Num_cotacao, @Revisao \n" +
                                        ", @Temperatura, @Tipo_Refrigeracao, @Modelo, @Profundidade, @Medida, @Cor_Interna, @Cor_Externa_acabamento, @Cor_Externa_Rodape, (select round(SUM(valor),2) as Valor from #temp1),@Alinhamento,@Qtde,(select round(SUM(valor),2)*" + numericUpDown_qtd_modelo.Value + " as Valor from #temp1));  \n" +
                                        "drop table #temp1;";
                        using (SqlCommand cmd = new SqlCommand(query, con, transaction))
                        {

                            cmd.Parameters.AddWithValue("@Num_cotacao", textBox_num_cotacao.Text);
                            cmd.Parameters.AddWithValue("@Revisao", "");
                            cmd.Parameters.AddWithValue("@Alinhamento", AlinhamentoModelo);
                            cmd.Parameters.AddWithValue("@Profundidade", comboBox_largura_expositor.Text);
                            cmd.Parameters.AddWithValue("@Medida", comboBox_tamanho_expositor.Text);
                            cmd.Parameters.AddWithValue("@Temperatura", comboBox_Temperatura.Text);
                            cmd.Parameters.AddWithValue("@Tipo_Refrigeracao", comboBox_tipo_refrigeracao.Text);
                            cmd.Parameters.AddWithValue("@Modelo", comboBox_expositor.Text);
                            cmd.Parameters.AddWithValue("@Cor_Interna", comboBox_cor_interna.Text);
                            cmd.Parameters.AddWithValue("@Cor_Externa_acabamento", comboBox_cor_acabamento.Text);
                            cmd.Parameters.AddWithValue("@Cor_Externa_Rodape", comboBox_cor_externa_rodape.Text);
                            cmd.Parameters.AddWithValue("@Valor", textBox_valor.Text);
                            cmd.Parameters.AddWithValue("@Qtde", numericUpDown_qtd_modelo.Value);
                            cmd.ExecuteNonQuery();
                        }
                        transaction.Commit();
                    }
                    con.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox_cliente_DropDown(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            //FillComboBoxWithContacts(accessToken);
            Cursor.Current = Cursors.Default;
        }

        private void MostrarValorTotal()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=" + Instancia + ";Initial Catalog=" + Banco + ";Persist Security Info=True;User ID=" + Usuario + ";Password=" + Senha))
                {
                    con.Open();

                    string query = "SELECT Valor_total, Valor_fechado, porcent_desconto_over FROM OrcCabecalho WHERE Num_cotacao = @Num_cotacao AND Revisao = @Revisao";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Num_cotacao", textBox_num_cotacao.Text);
                        cmd.Parameters.AddWithValue("@Revisao", "");

                        SqlDataReader reader = cmd.ExecuteReader(); // Executa a consulta e obtém o resultado

                        if (reader.Read()) // Verifica se há resultados
                        {
                            // Preencha o TextBox "textBox_valor" com "Valor_total" formatado como moeda
                            if (!reader.IsDBNull(0))
                            {
                                double valorTotal = reader.GetDouble(0);
                                textBox_valor.Text = valorTotal.ToString("C");
                            }

                            // Preencha o TextBox "txtValorFechado" com "Valor_fechado" formatado como moeda
                            if (!reader.IsDBNull(1))
                            {
                                double valorFechado = reader.GetDouble(1);
                                txtValorFechado.Text = valorFechado.ToString("C");
                            }

                            // Preencha o TextBox "txtPorcentagem" com "porcent_desconto_over"
                            if (!reader.IsDBNull(2))
                            {
                                double porcentagemDesconto = reader.GetDouble(2);
                                txtPorcentagem.Text = porcentagemDesconto.ToString();
                            }
                        }
                        else
                        {
                            // Caso não haja resultado, você pode tratar como necessário
                            textBox_valor.Text = "Nenhum resultado encontrado";
                            txtValorFechado.Text = "";
                            txtPorcentagem.Text = "";
                        }

                        reader.Close();
                    }

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView_Modelo_SelectionChanged(object sender, EventArgs e)
        {
            // Verifica se há pelo menos uma linha selecionada
            if (dataGridView_Modelo.SelectedRows.Count > 0)
            {
                // Obtém o valor da coluna "Alinhamento" da linha selecionada
                string alinhamento = dataGridView_Modelo.SelectedRows[0].Cells["Alinhamento"].Value.ToString();

                // Chama o método MostrarDadosNoDataGridViewInterno com o valor de alinhamento como parâmetro
                MostrarDadosNoDataGridViewInterno(alinhamento);
                MostrarDadosDatagridCabeceira(alinhamento);
            }
        }

        private void MostrarDadosNoDataGridViewInterno(string alinhamento)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=" + Instancia + ";Initial Catalog=" + Banco + ";Persist Security Info=True;User ID=" + Usuario + ";Password=" + Senha))
                {
                    con.Open();

                    string query = "select ID,Alinhamento, Acessorio, Codigo, qtde, Valor_uni, Valor_total,Preco_Desc_Over_uni, Preco_Desc_Over_total from OrcAcessorio where Num_cotacao = @Num_cotacao and Revisao = @Revisao and Alinhamento = @Alinhamento";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Num_cotacao", textBox_num_cotacao.Text);
                        cmd.Parameters.AddWithValue("@Revisao", "");
                        cmd.Parameters.AddWithValue("@Alinhamento", alinhamento);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataSet dataSet = new DataSet();

                        adapter.Fill(dataSet, "OrcModelo"); // Preenche o DataSet com os dados da consulta

                        // Define o DataSource do DataGridView para o DataTable dentro do DataSet
                        dataGridView_Acessorios.DataSource = dataSet.Tables["OrcModelo"];
                    }

                    con.Close();
                }
                ConfigurarDataGridViewAcessorios();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ConfigurarDataGridViewAcessorios()
        {
            // Certifique-se de chamar este método antes de configurar os dados no DataGridView.

            // Define o DataGridView para ajustar automaticamente o tamanho das colunas com base no conteúdo.
            foreach (DataGridViewColumn column in dataGridView_Acessorios.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            // Outras configurações do DataGridView, se necessário.
            dataGridView_Acessorios.AutoGenerateColumns = false; // Desligue a geração automática de colunas se você tiver definido as colunas manualmente.
            dataGridView_Acessorios.AllowUserToAddRows = false; // Desligue a linha em branco no final, se necessário.
        }

        private void MostrarDadosDatagridCabeceira(string alinhamento)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=" + Instancia + ";Initial Catalog=" + Banco + ";Persist Security Info=True;User ID=" + Usuario + ";Password=" + Senha))
                {
                    con.Open();

                    string query = "select ID,Alinhamento,Cabeceira,Codigo,(select Qtde from OrcModelo where Num_cotacao = @Num_cotacao and Revisao = @Revisao and Alinhamento = @Alinhamento) as Qtde,Valor as Valor_uni,((select Qtde from OrcModelo where Num_cotacao = @Num_cotacao and Revisao = @Revisao and Alinhamento = @Alinhamento)*Valor) as Valor_total,Preco_Desc_Over as Preco_Desc_Over_uni,((select Qtde from OrcModelo where Num_cotacao = @Num_cotacao and Revisao = @Revisao and Alinhamento = @Alinhamento)*Preco_Desc_Over) as Preco_Desc_Over_total from OrcCabeceira where Num_cotacao = @Num_cotacao and Revisao = @Revisao and Alinhamento = @Alinhamento";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Num_cotacao", textBox_num_cotacao.Text);
                        cmd.Parameters.AddWithValue("@Revisao", "");
                        cmd.Parameters.AddWithValue("@Alinhamento", alinhamento);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataSet dataSet = new DataSet();

                        adapter.Fill(dataSet, "OrcModelo"); // Preenche o DataSet com os dados da consulta

                        // Define o DataSource do DataGridView para o DataTable dentro do DataSet
                        dataGridView_cabeceira.DataSource = dataSet.Tables["OrcModelo"];
                    }

                    con.Close();
                }
                ConfigurarDataGridViewCabeceira();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ConfigurarDataGridViewCabeceira()
        {
            // Certifique-se de chamar este método antes de configurar os dados no DataGridView.

            // Define o DataGridView para ajustar automaticamente o tamanho das colunas com base no conteúdo.
            foreach (DataGridViewColumn column in dataGridView_cabeceira.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            // Outras configurações do DataGridView, se necessário.
            dataGridView_cabeceira.AutoGenerateColumns = false; // Desligue a geração automática de colunas se você tiver definido as colunas manualmente.
            dataGridView_cabeceira.AllowUserToAddRows = false; // Desligue a linha em branco no final, se necessário.
        }

        private void button_salvar_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=" + Instancia + ";Initial Catalog=" + Banco + ";Persist Security Info=True;User ID=" + Usuario + ";Password=" + Senha))
                {
                    con.Open();

                    string query = "update OrcCabecalho set Cliente = @Cliente, Loja = @Loja, Vendedor = @Vendedor where Num_cotacao = @Num_cotacao";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Num_cotacao", textBox_num_cotacao.Text);
                        cmd.Parameters.AddWithValue("@Cliente", comboBox_cliente.Text);
                        cmd.Parameters.AddWithValue("@Loja", textBox_loja.Text);
                        cmd.Parameters.AddWithValue("@Vendedor", comboBox_vendedor.Text);
                        cmd.ExecuteNonQuery(); // Execute a consulta SQL.
                    }
                }
                MessageBox.Show("Salvo com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_deletar_Click(object sender, EventArgs e)
        {
            label_calcular_novamente.Visible = true;
            // Verifique se há uma linha selecionada em qualquer um dos DataGridViews
            if (dataGridView_Modelo.SelectedRows.Count > 0)
            {
                // Obtenha o valor da coluna "ID" da linha selecionada no DataGridView Modelo
                string idToDelete = dataGridView_Modelo.SelectedRows[0].Cells["Alinhamento"].Value.ToString();

                DeletarLinhaModelo(idToDelete);
                dataGridView_cabeceira.DataSource = null;
                dataGridView_cabeceira.Rows.Clear();
                dataGridView_Acessorios.DataSource = null;
                dataGridView_Acessorios.Rows.Clear();
            }
            else if (dataGridView_Acessorios.SelectedRows.Count > 0)
            {
                // Obtenha o valor da coluna "ID" da linha selecionada no DataGridView Acessórios
                string idToDelete = dataGridView_Acessorios.SelectedRows[0].Cells["ID"].Value.ToString();
                string NumAlinhamento = dataGridView_Acessorios.SelectedRows[0].Cells["Alinhamento"].Value.ToString();
                DeletarLinhaAcessorios(idToDelete);
                AlterarPrecos(NumAlinhamento);
            }
            else if (dataGridView_cabeceira.SelectedRows.Count > 0)
            {
                // Obtenha o valor da coluna "ID" da linha selecionada no DataGridView Acessórios
                string idToDelete = dataGridView_cabeceira.SelectedRows[0].Cells["ID"].Value.ToString();
                string NumAlinhamento = dataGridView_cabeceira.SelectedRows[0].Cells["Alinhamento"].Value.ToString();
                DeletarLinhaCabeceira(idToDelete);
                AlterarPrecos(NumAlinhamento);
            }
            else
            {
                MessageBox.Show("Por favor, selecione uma linha para deletar.");
            }
            CadastrarCabecalhoOrcamento();

            MostrarValorTotal();
        }
        private void AlterarPrecos(string idToDelete)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=" + Instancia + ";Initial Catalog=" + Banco + ";Persist Security Info=True;User ID=" + Usuario + ";Password=" + Senha))
                {
                    con.Open();

                    // Execute a consulta SQL DELETE na tabela Modelo com base no valor do ID
                    string query = "create table #temp1 (valor float); \n" +
                                    "insert into #temp1    \n" +
                                        "SELECT valor as ValorTotal FROM OrcCabeceira \n" +
                                        "WHERE Num_cotacao = @Num_cotacao \n" +
                                        "AND Revisao = '' \n" +
                                        "AND alinhamento = @Alinhamento \n" +
                                        "AND modelo = 'AFR' \n" +
                                        "UNION ALL \n" +
                                        "SELECT Valor_total FROM OrcAcessorio \n" +
                                        "WHERE Num_cotacao = @Num_cotacao \n" +
                                        "AND Revisao = '' \n" +
                                        "AND alinhamento = @Alinhamento \n" +
                                    "update OrcModelo set Valor = (select round(sum(Valor),2) as valor from #temp1)  WHERE Num_cotacao = @Num_cotacao  \n" +
                                        "AND Revisao = '' \n" +
                                        "AND alinhamento = @Alinhamento";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Num_cotacao", textBox_num_cotacao.Text);

                        cmd.Parameters.AddWithValue("@Alinhamento", idToDelete);
                        cmd.ExecuteNonQuery();
                    }

                    // Atualize o DataGridView Modelo após a exclusão
                    MostrarDadosNoDataGridView(); // Função para atualizar o DataGridView Modelo
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeletarLinhaModelo(string idToDelete)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=" + Instancia + ";Initial Catalog=" + Banco + ";Persist Security Info=True;User ID=" + Usuario + ";Password=" + Senha))
                {
                    con.Open();

                    // Execute a consulta SQL DELETE na tabela Modelo com base no valor do ID
                    string query = "DELETE FROM OrcModelo WHERE Alinhamento = @Alinhamento";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Alinhamento", idToDelete);
                        cmd.ExecuteNonQuery();
                    }

                    // Atualize o DataGridView Modelo após a exclusão
                    MostrarDadosNoDataGridView(); // Função para atualizar o DataGridView Modelo
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeletarLinhaAcessorios(string idToDelete)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=" + Instancia + ";Initial Catalog=" + Banco + ";Persist Security Info=True;User ID=" + Usuario + ";Password=" + Senha))
                {
                    con.Open();

                    // Execute a consulta SQL DELETE na tabela Acessórios com base no valor do ID
                    string query = "DELETE FROM OrcAcessorio WHERE ID = @ID";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@ID", idToDelete);
                        cmd.ExecuteNonQuery();
                    }
                    string alinhamento = dataGridView_Acessorios.SelectedRows[0].Cells["Alinhamento"].Value.ToString();
                    // Atualize o DataGridView Acessórios após a exclusão
                    MostrarDadosNoDataGridViewInterno(alinhamento);       // Função para atualizar o DataGridView Acessórios
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeletarLinhaCabeceira(string idToDelete)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=" + Instancia + ";Initial Catalog=" + Banco + ";Persist Security Info=True;User ID=" + Usuario + ";Password=" + Senha))
                {
                    con.Open();

                    // Execute a consulta SQL DELETE na tabela Acessórios com base no valor do ID
                    string query = "DELETE FROM OrcCabeceira WHERE ID = @ID";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@ID", idToDelete);
                        cmd.ExecuteNonQuery();
                    }
                    string alinhamento = dataGridView_cabeceira.SelectedRows[0].Cells["Alinhamento"].Value.ToString();
                    // Atualize o DataGridView Acessórios após a exclusão
                    MostrarDadosDatagridCabeceira(alinhamento);       // Função para atualizar o DataGridView Acessórios
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView_Acessorios_SelectionChanged(object sender, EventArgs e)
        {
            // Verifique se há uma linha selecionada no dataGridView_Acessorios
            if (dataGridView_Acessorios.SelectedRows.Count > 0)
            {
                // Limpe a seleção no dataGridView_Modelo
                dataGridView_Modelo.ClearSelection();
                dataGridView_cabeceira.ClearSelection();
            }
        }

        private void dataGridView_cabeceira_SelectionChanged(object sender, EventArgs e)
        {
            // Verifique se há uma linha selecionada no dataGridView_Acessorios
            if (dataGridView_cabeceira.SelectedRows.Count > 0)
            {
                // Limpe a seleção no dataGridView_Modelo
                dataGridView_Modelo.ClearSelection();
                dataGridView_Acessorios.ClearSelection();
            }
        }

        private void dataGridView_Modelo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Verifique se a formatação é aplicada à coluna "Valor_total" (coluna 4)
            if (e.ColumnIndex >= 9 && e.RowIndex >= 0 && e.ColumnIndex != 11)
            {
                if (e.Value != null && float.TryParse(e.Value.ToString(), out float valor))
                {
                    // Formate o valor como moeda
                    e.Value = valor.ToString("C");
                    e.FormattingApplied = true;
                }
            }
        }

        private void dataGridView_Acessorios_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Verifique se a formatação é aplicada à coluna "Valor_total" (coluna 4)
            if (e.ColumnIndex >= 5 && e.RowIndex >= 0)
            {
                if (e.Value != null && float.TryParse(e.Value.ToString(), out float valor))
                {
                    // Formate o valor como moeda
                    e.Value = valor.ToString("C");
                    e.FormattingApplied = true;
                }
            }
        }

        private void dataGridView_cabeceira_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Verifique se a formatação é aplicada à coluna "Valor_total" (coluna 4)
            if (e.ColumnIndex >= 5 && e.RowIndex >= 0)
            {
                if (e.Value != null && float.TryParse(e.Value.ToString(), out float valor))
                {
                    // Formate o valor como moeda
                    e.Value = valor.ToString("C");
                    e.FormattingApplied = true;
                }
            }
        }

        private void LimparTableLayoutPanel(TableLayoutPanel tableLayoutPanel)
        {
            // Remove todos os controles das células do TableLayoutPanel
            foreach (Control control in tableLayoutPanel.Controls.OfType<Control>().ToArray())
            {
                tableLayoutPanel.Controls.Remove(control);
                control.Dispose();
            }

            // Remove todas as colunas e linhas
            tableLayoutPanel.RowStyles.Clear();
            tableLayoutPanel.ColumnStyles.Clear();
            tableLayoutPanel.RowCount = 0;
            tableLayoutPanel.ColumnCount = 0;
        }

        private void button_calcular_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                label_calcular_novamente.Visible = false;
                button_imprimir.Enabled = true;
                
                CalcularDescontoCabecalho();
                CalcularDescontoModelo();
                CalcularDescontoCabeceira();
                CalcularDescontoAcessorios();
                MostrarDadosNoDataGridView();

                dataGridView_cabeceira.DataSource = null;
                dataGridView_cabeceira.Rows.Clear();
                dataGridView_Acessorios.DataSource = null;
                dataGridView_Acessorios.Rows.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Text, ex.Message);
            }
            Cursor = Cursors.Default;
        }



        private void CalcularDescontoAcessorios()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=" + Instancia + ";Initial Catalog=" + Banco + ";Persist Security Info=True;User ID=" + Usuario + ";Password=" + Senha))
                {
                    con.Open();

                    // Execute a consulta SQL DELETE na tabela Acessórios com base no valor do ID
                    string query = "UPDATE OrcAcessorio \n" +
                                    "SET OrcAcessorio.Preco_Desc_Over_uni = OrcAcessorio.Valor_uni - (OrcAcessorio.Valor_uni * OrcCabecalho.porcent_desconto_over / 100), \n" +
                                    "OrcAcessorio.Preco_Desc_Over_total = OrcAcessorio.Valor_total - (OrcAcessorio.Valor_total * OrcCabecalho.porcent_desconto_over / 100) \n" +
                                    "FROM OrcAcessorio \n" +
                                    "INNER JOIN OrcCabecalho ON OrcCabecalho.Num_cotacao = OrcAcessorio.Num_cotacao \n" +
                                    "WHERE OrcCabecalho.Num_cotacao = @Num_cotacao;";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Num_cotacao", textBox_num_cotacao.Text);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CalcularDescontoCabeceira()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=" + Instancia + ";Initial Catalog=" + Banco + ";Persist Security Info=True;User ID=" + Usuario + ";Password=" + Senha))
                {
                    con.Open();

                    // Execute a consulta SQL DELETE na tabela Acessórios com base no valor do ID
                    string query = "UPDATE OrcCabeceira \n" +
                                    "SET OrcCabeceira.Preco_Desc_Over = OrcCabeceira.Valor - (OrcCabeceira.Valor * OrcCabecalho.porcent_desconto_over / 100) \n" +
                                    "FROM OrcCabeceira \n" +
                                    "INNER JOIN OrcCabecalho ON OrcCabecalho.Num_cotacao = OrcCabeceira.Num_cotacao \n" +
                                    "WHERE OrcCabecalho.Num_cotacao = @Num_cotacao;";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Num_cotacao", textBox_num_cotacao.Text);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CalcularDescontoModelo()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=" + Instancia + ";Initial Catalog=" + Banco + ";Persist Security Info=True;User ID=" + Usuario + ";Password=" + Senha))
                {
                    con.Open();

                    // Execute a consulta SQL DELETE na tabela Acessórios com base no valor do ID
                    string query = "UPDATE OrcModelo \n" +
                                    "SET OrcModelo.Preco_Desc_Over = OrcModelo.Valor - (OrcModelo.Valor * OrcCabecalho.porcent_desconto_over / 100) \n" +
                                    ",orcModelo.Preco_Desc_Over_X_Qtd = (OrcModelo.Valor - OrcModelo.Valor * (OrcCabecalho.porcent_desconto_over / 100))*Qtde \n" +
                                    "FROM OrcModelo \n" +
                                    "INNER JOIN OrcCabecalho ON OrcCabecalho.Num_cotacao = OrcModelo.Num_cotacao \n" +
                                    "WHERE OrcCabecalho.Num_cotacao = @Num_cotacao; ";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Num_cotacao", textBox_num_cotacao.Text);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void CalcularDescontoCabecalho()
        {
            // Verifique se o TextBox de Porcentagem não está vazio
            if (txtPorcentagem.Text == "0" && txtValorFechado.Text == "0" || txtPorcentagem.Text == "" && txtValorFechado.Text == "")
            {
                // Obtenha o valor da porcentagem inserida
                decimal porcentagem;

                // Calcule o valor fechado com base na porcentagem e no valor sem desconto
                string valorSemDescontoTexto = textBox_valor.Text.Replace("R$", "").Trim(); // Remove o "R$" e espaços em branco
                decimal valorSemDesconto;
                if (!string.IsNullOrEmpty(valorSemDescontoTexto) &&
                    decimal.TryParse(valorSemDescontoTexto, out valorSemDesconto))
                {
                    decimal valorFechado = (0 / 100) * valorSemDesconto;
                    decimal valorFinal = valorSemDesconto - valorFechado;

                    // Preencha o TextBox de Valor Fechado com formatação de moeda
                    txtValorFechado.Text = valorFinal.ToString("C");

                    try
                    {
                        using (SqlConnection con = new SqlConnection(@"Data Source=" + Instancia + ";Initial Catalog=" + Banco + ";Persist Security Info=True;User ID=" + Usuario + ";Password=" + Senha))
                        {
                            con.Open();

                            // Execute a consulta SQL DELETE na tabela Acessórios com base no valor do ID
                            string query = " update OrcCabecalho set Valor_fechado = @Valor_fechado , porcent_desconto_over = @porcent_desconto_over where Num_cotacao = @Num_cotacao";

                            using (SqlCommand cmd = new SqlCommand(query, con))
                            {
                                cmd.Parameters.AddWithValue("@Num_cotacao", textBox_num_cotacao.Text);
                                // Converte o valor da string txtPorcentagem.Text para decimal
                                cmd.Parameters.AddWithValue("@Valor_fechado", valorFinal);
                                cmd.Parameters.AddWithValue("@porcent_desconto_over", 0);
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Digite um valor sem desconto válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return;
            }
            if (txtPorcentagem.Text != "0")
            {
                // Obtenha o valor da porcentagem inserida
                decimal porcentagem;
                if (decimal.TryParse(txtPorcentagem.Text, out porcentagem))
                {
                    // Calcule o valor fechado com base na porcentagem e no valor sem desconto
                    string valorSemDescontoTexto = textBox_valor.Text.Replace("R$", "").Trim(); // Remove o "R$" e espaços em branco
                    decimal valorSemDesconto;
                    if (!string.IsNullOrEmpty(valorSemDescontoTexto) &&
                        decimal.TryParse(valorSemDescontoTexto, out valorSemDesconto))
                    {
                        decimal valorFechado = (porcentagem / 100) * valorSemDesconto;
                        decimal valorFinal = valorSemDesconto - valorFechado;
                        // Preencha o TextBox de Valor Fechado com formatação de moeda
                        txtValorFechado.Text = valorFinal.ToString("C");
                        try
                        {
                            using (SqlConnection con = new SqlConnection(@"Data Source=" + Instancia + ";Initial Catalog=" + Banco + ";Persist Security Info=True;User ID=" + Usuario + ";Password=" + Senha))
                            {
                                con.Open();

                                // Execute a consulta SQL DELETE na tabela Acessórios com base no valor do ID
                                string query = " update OrcCabecalho set Valor_fechado = @Valor_fechado , porcent_desconto_over = @porcent_desconto_over where Num_cotacao = @Num_cotacao";

                                using (SqlCommand cmd = new SqlCommand(query, con))
                                {
                                    cmd.Parameters.AddWithValue("@Num_cotacao", textBox_num_cotacao.Text);
                                    // Converte o valor da string txtPorcentagem.Text para decimal
                                    decimal porcentagem1;
                                    if (decimal.TryParse(txtPorcentagem.Text, out porcentagem1))
                                    {
                                        if (txtPorcentagem.Text == "0" || txtPorcentagem.Text == "")
                                        {
                                            cmd.Parameters.AddWithValue("@Valor_fechado", valorFechado);
                                        }
                                        else
                                        {
                                            cmd.Parameters.AddWithValue("@Valor_fechado", valorFinal);
                                        }

                                        cmd.Parameters.AddWithValue("@porcent_desconto_over", porcentagem1);
                                        cmd.ExecuteNonQuery();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Digite uma porcentagem válida.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Digite um valor sem desconto válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Digite uma porcentagem válida.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (txtValorFechado.Text != "R$ 0,00")
            {
                // Obtenha o valor fechado inserido
                decimal valorFechado;
                if (decimal.TryParse(txtValorFechado.Text, out valorFechado))
                {
                    // Calcule a porcentagem de desconto com base no valor fechado e no valor sem desconto
                    string valorSemDescontoTexto = textBox_valor.Text.Replace("R$", "").Trim(); // Remove o "R$" e espaços em branco
                    decimal valorSemDesconto;
                    if (!string.IsNullOrEmpty(valorSemDescontoTexto) &&
                        decimal.TryParse(valorSemDescontoTexto, out valorSemDesconto))
                    {
                        decimal porcentagem = ((valorSemDesconto - valorFechado) / valorSemDesconto) * 100;

                        // Preencha o TextBox de Porcentagem
                        txtPorcentagem.Text = porcentagem.ToString("0.00");
                        // Preencha o TextBox de Valor Fechado com formatação de moeda
                        txtValorFechado.Text = valorFechado.ToString("C");
                        try
                        {
                            using (SqlConnection con = new SqlConnection(@"Data Source=" + Instancia + ";Initial Catalog=" + Banco + ";Persist Security Info=True;User ID=" + Usuario + ";Password=" + Senha))
                            {
                                con.Open();

                                // Execute a consulta SQL DELETE na tabela Acessórios com base no valor do ID
                                string query = " update OrcCabecalho set Valor_fechado = @Valor_fechado , porcent_desconto_over = @porcent_desconto_over where Num_cotacao = @Num_cotacao";

                                using (SqlCommand cmd = new SqlCommand(query, con))
                                {
                                    cmd.Parameters.AddWithValue("@Num_cotacao", textBox_num_cotacao.Text);
                                    decimal porcentagem1;
                                    if (decimal.TryParse(txtPorcentagem.Text, out porcentagem1))
                                    {
                                        cmd.Parameters.AddWithValue("@Valor_fechado", valorFechado);
                                        cmd.Parameters.AddWithValue("@porcent_desconto_over", porcentagem1);
                                        cmd.ExecuteNonQuery();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Digite uma porcentagem válida.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Digite um valor sem desconto válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Digite um valor fechado válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }



        private void comboBox_vendedor_DropDown(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            // FillComboBoxWithVendedors(accessToken);
            Cursor.Current = Cursors.Default;
        }

        private async Task<List<Class_cliente.Contact>> infoContato(string code)
        {
            string token = code; // Substitua pelo seu token de acesso
            string apiUrl = "https://www.bling.com.br/Api/v3/contatos?pagina=1&limite=100&criterio=1&idTipoContato=14572024033";

            List<Class_cliente.Contact> contatos = new List<Class_cliente.Contact>();

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<ApiResponse>(responseContent);

                    contatos = result.data; // Atribua a propriedade diretamente à lista contatos.
                }
                else
                {
                    MessageBox.Show("Erro ao obter os dados da API contatos.");
                }
            }

            return contatos;
        }


        private async void button_imprimir_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            string connectionString = @"Data Source=" + Instancia + ";Initial Catalog=" + Banco + ";Persist Security Info=True;User ID=" + Usuario + ";Password=" + Senha + ";MultipleActiveResultSets=True;";
            // Chame a função infoContato passando o token e aguarde o resultado.
            List<Class_cliente.Contact> contatos = await infoContato(accessToken);

            try
            {
                string docxFilePath = Path.Combine(Application.StartupPath, "OrcamentoEXP.docx");
                string pdfFilePath = Path.Combine(Application.StartupPath, "OrcamentoEXP.pdf");
                int index = 0;
                // Obtém a data atual
                DateTime dataAtual = DateTime.Now;

                // Formata a data como uma string no formato desejado (por exemplo, "dd/MM/yyyy")
                string dataFormatada = dataAtual.ToString("dd/MM/yyyy");

                // Crie um novo documento Spire.Doc a partir do arquivo DOCX
                Document doc = new Document(docxFilePath);
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Consulta para obter os dados do cabeçalho
                    string queryCabecalho = "SELECT Num_cotacao, Cliente, Loja, Vendedor, Valor_total, Valor_fechado,Cidade,UF,Endereco FROM OrcCabecalho WHERE Num_cotacao = '" + textBox_num_cotacao.Text + "'";
                    SqlCommand commandCabecalho = new SqlCommand(queryCabecalho, connection);
                    SqlDataReader readerCabecalho = commandCabecalho.ExecuteReader();
                    if (readerCabecalho.Read())
                    {
                        string numCotacao = readerCabecalho["Num_cotacao"].ToString();
                        string cliente = readerCabecalho["Cliente"].ToString();
                        string loja = readerCabecalho["Loja"].ToString();
                        string vendedor = readerCabecalho["Vendedor"].ToString();
                        string valorTotal = readerCabecalho["Valor_total"].ToString();
                        string valorFechado = readerCabecalho["Valor_fechado"].ToString();
                        string cidade = readerCabecalho["Cidade"].ToString();
                        string uf = readerCabecalho["UF"].ToString();
                        string endereco = readerCabecalho["Endereco"].ToString();
                        

                        // Encontre e substitua "#NOME#" pelo valor de comboBox_cliente.Text
                        doc.Replace("#NOME_CLIENTE#", cliente, true, true);
                        doc.Replace("#N_PEDIDO#", numCotacao, true, true);
                        doc.Replace("#DATA#", dataFormatada, true, true);
                        doc.Replace("#NOME_LOJA#", loja, true, true);
                        doc.Replace("#CIDADE#", cidade, true, true);
                        doc.Replace("#UF#", uf, true, true);
                        doc.Replace("#ENDERECO#", endereco, true, true);
                        doc.Replace("#VENDEDOR#", vendedor, true, true);
                        doc.Replace("#OBS#", textBox_observacao.Text, true, true);
                        foreach (var contato in contatos)
                        {
                            doc.Replace("#TELEFONE#", $"{contato.telefone}\t{contato.celular}", true, true);
                        }
                        

                        doc.Replace("#OBS#", "Observacao caso queira inserir", true, true);

                        if (valorFechado == "0" || valorFechado == "")
                        {
                            doc.Replace("#VALOR_TOTAL#", double.Parse(valorTotal).ToString("C"), true, true); // Formato de moeda
                        }
                        else
                        {
                            doc.Replace("#VALOR_TOTAL#", double.Parse(valorFechado).ToString("C"), true, true); // Formato de moeda
                        }

                        readerCabecalho.Close();

                        // Consulta para obter os dados dos modelos
                        string queryModelo = "SELECT Alinhamento,Modelo_Expositor, Tamanho_Expositor, Largura_Expositor,Qtde, (Valor*Qtde) as Valor,(Preco_Desc_Over*Qtde) as Valor_Desc,Temperatura,Tipo_Refrigeracao,Tipo FROM OrcModelo inner join Modelo_Eng on OrcModelo.Modelo_Expositor = Modelo_Eng.Modelo and OrcModelo.Tamanho_Expositor = Modelo_Eng.Comprimento and OrcModelo.Largura_Expositor = Modelo_Eng.Profundidade WHERE Num_cotacao = '" + textBox_num_cotacao.Text + "'";
                        SqlCommand commandModelo = new SqlCommand(queryModelo, connection);
                        SqlDataReader readerModelo = commandModelo.ExecuteReader();


                        // Antes de entrar no loop while, crie uma lista para armazenar os nomes dos marcadores
                        List<string> placeholders = new List<string>();

                        while (readerModelo.Read())
                        {
                            string alinhamentoExpositor = readerModelo["Alinhamento"].ToString();
                            string modeloExpositor = readerModelo["Modelo_Expositor"].ToString();
                            string comprimento = readerModelo["Tamanho_Expositor"].ToString();
                            string profundidade = readerModelo["Largura_Expositor"].ToString();
                            string quantidade = readerModelo["Qtde"].ToString();

                            string temperatura = readerModelo["Temperatura"].ToString();
                            string tipoRefrigeracao = readerModelo["Tipo_Refrigeracao"].ToString();
                            string tipo = readerModelo["Tipo"].ToString();

                            string valor = "";

                            if (readerModelo["Valor_Desc"].ToString() == "0" || readerModelo["Valor_Desc"].ToString() == "")
                            {
                                valor = double.Parse(readerModelo["Valor"].ToString()).ToString("C"); // Formato de moeda
                            }
                            else
                            {
                                valor = double.Parse(readerModelo["Valor_Desc"].ToString()).ToString("C"); // Formato de moeda
                            }

                            doc.Replace("#DESCRITIVO#", $"{alinhamentoExpositor}\t{modeloExpositor}-{comprimento}-{profundidade}\t{temperatura}\t{tipoRefrigeracao}\t{tipo}\n#DESCRITIVO#", true, true);
                            doc.Replace("#QTDE#", $"{quantidade}\n#QTDE#", true, true);

                            // Consulta para obter os dados dos acessórios para este modelo
                            string queryAcessorios = "select \n" +
                                                        "OrcModelo.Alinhamento, \n" +
                                                        "OrcModelo.Modelo_Expositor, \n" +
                                                        "OrcModelo.Tamanho_Expositor, \n" +
                                                        "OrcModelo.Largura_Expositor, \n" +
                                                        "OrcModelo.Qtde, \n" +
                                                        "OrcModelo.Valor_X_Qtd, \n" +
                                                        "OrcModelo.Preco_Desc_Over_X_Qtd, \n" +
                                                        "OrcAcessorio.Acessorio,	 \n" +
                                                        "OrcAcessorio.Cor, \n" +
                                                        "OrcAcessorio.qtde as Qtd_acessorio\n" +
                                                    "from OrcModelo \n" +
                                                    "inner join OrcAcessorio on \n" +
                                                        "OrcModelo.Num_cotacao = OrcAcessorio.Num_cotacao and \n" +
                                                        "OrcModelo.Alinhamento = OrcAcessorio.Alinhamento and \n" +
                                                        "OrcModelo.Modelo_Expositor = OrcAcessorio.Modelo and \n" +
                                                        "OrcModelo.Tamanho_Expositor = OrcAcessorio.Comprimento and \n" +
                                                        "OrcModelo.Largura_Expositor = OrcAcessorio.Profundidade where \n" +
                                                        "OrcModelo.Num_cotacao = '" + textBox_num_cotacao.Text + "' and \n" +
                                                        $"OrcModelo.Alinhamento = '{quantidade}' and \n" +
                                                        $"OrcModelo.Modelo_Expositor = '{modeloExpositor}' and \n" +
                                                        $"OrcModelo.Tamanho_Expositor = '{comprimento}' and \n" +
                                                        $"OrcModelo.Largura_Expositor = '{profundidade}' \n" +
                                                    "union all \n" +
                                                        "select \n" +
                                                        "OrcModelo.Alinhamento, \n" +
                                                        "OrcModelo.Modelo_Expositor, \n" +
                                                        "OrcModelo.Tamanho_Expositor, \n" +
                                                        "OrcModelo.Largura_Expositor, \n" +
                                                        "OrcModelo.Qtde, \n" +
                                                        "OrcModelo.Valor_X_Qtd, \n" +
                                                        "OrcModelo.Preco_Desc_Over_X_Qtd, \n" +
                                                        "OrcCabeceira.Cabeceira, \n" +
                                                        "OrcCabeceira.Cor, \n" +
                                                        "1 \n" +
                                                    "from OrcModelo \n" +
                                                    "inner join OrcCabeceira on \n" +
                                                        "OrcModelo.Num_cotacao = OrcCabeceira.Num_cotacao and \n" +
                                                        "OrcModelo.Alinhamento = OrcCabeceira.Alinhamento and \n" +
                                                        "OrcModelo.Modelo_Expositor = OrcCabeceira.Modelo and \n" +
                                                        "OrcModelo.Tamanho_Expositor = OrcCabeceira.Comprimento and \n" +
                                                        "OrcModelo.Largura_Expositor = OrcCabeceira.Profundidade where \n" +
                                                        "OrcModelo.Num_cotacao = '" + textBox_num_cotacao.Text + "' and \n" +
                                                        $"OrcModelo.Alinhamento = '{quantidade}' and \n" +
                                                        $"OrcModelo.Modelo_Expositor = '{modeloExpositor}' and \n" +
                                                        $"OrcModelo.Tamanho_Expositor = '{comprimento}' and \n" +
                                                        $"OrcModelo.Largura_Expositor = '{profundidade}'";
                            SqlCommand commandAcessorios = new SqlCommand(queryAcessorios, connection);
                            SqlDataReader readerAcessorios = commandAcessorios.ExecuteReader();
                            while (readerAcessorios.Read())
                            {
                                string acessorio = readerAcessorios["Acessorio"].ToString();
                                string corAcessorio = readerAcessorios["Cor"].ToString();
                                string quantidadeAcessorio = readerAcessorios["Qtd_acessorio"].ToString();
                                string valorTotalAcessorio = "";

                                if (readerAcessorios["Preco_Desc_Over_X_Qtd"].ToString() == "0" || readerAcessorios["Preco_Desc_Over_X_Qtd"].ToString() == "")
                                {
                                    valorTotalAcessorio = double.Parse(readerAcessorios["Valor_X_Qtd"].ToString()).ToString("C");
                                }
                                else
                                {
                                    valorTotalAcessorio = double.Parse(readerAcessorios["Preco_Desc_Over_X_Qtd"].ToString()).ToString("C");
                                }

                                doc.Replace("#DESCRITIVO#", $"\t\t{acessorio}\t{corAcessorio}\n#DESCRITIVO#", true, true);
                                doc.Replace("#QTDE#", $"{quantidadeAcessorio}\n#QTDE#", true, true);
                            }

                            // Substitua os placeholders pelos valores acumulados
                            doc.Replace("#DESCRITIVO#", $"Valor: {valor}\n\n#DESCRITIVO#", true, true);


                            doc.Replace("#QTDE#", $"\n\n#QTDE#", true, true);
                            readerAcessorios.Close();

                        }
                        doc.Replace("#DESCRITIVO#", $"", true, true);
                        doc.Replace("#QTDE#", $"", true, true);
                    }
                }
                // Salve o documento como PDF
                //doc.SaveToFile(pdfFilePath, FileFormat.PDF);
                doc.SaveToFile(Path.Combine(Application.StartupPath, "OrcamentoEXPTemp.docx"), FileFormat.Docx);

                AlinharValorDireita();

                // Abra o arquivo PDF recém-criado com o leitor de PDF padrão.
                string pdfFilePath1 = Path.Combine(Application.StartupPath, "OrcamentoEXP.pdf");
                ConverterDocxParaPDF(pdfFilePath1);
                try
                {
                    // Verifique se o arquivo PDF existe antes de tentar abri-lo
                    if (File.Exists(pdfFilePath1))
                    {
                        // Abra o arquivo PDF com o programa associado a arquivos PDF no sistema
                        Process.Start(new ProcessStartInfo
                        {
                            FileName = pdfFilePath1,
                            UseShellExecute = true
                        });
                    }
                    else
                    {
                        MessageBox.Show("O arquivo PDF não foi encontrado.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            Cursor.Current = Cursors.Default;
        }

        private void ConverterDocxParaPDF(string path)
        {
            // Caminho do arquivo DOCX de entrada e saída PDF
            string inputDocxPath = Path.Combine(Application.StartupPath, "OrcamentoEXPTemp.docx");
            string outputPdfPath = path;

            // Crie uma instância do Document
            Document document = new Document();

            // Carregue o documento DOCX
            document.LoadFromFile(inputDocxPath);

            // Salve o documento como PDF
            document.SaveToFile(outputPdfPath, FileFormat.PDF);

            // Feche o documento
            document.Close();

        }
        private void AlinharValorDireita()
        {
            string caminhoDoArquivo = Path.Combine(Application.StartupPath, "OrcamentoEXPTemp.docx");
            string textoProcurado = "Valor:";

            using (FileStream fileStream = new FileStream(caminhoDoArquivo, FileMode.Open, FileAccess.ReadWrite))
            {
                XWPFDocument doc = new XWPFDocument(fileStream);

                foreach (XWPFTable table in doc.Tables)
                {
                    foreach (XWPFTableRow row in table.Rows)
                    {
                        foreach (XWPFTableCell cell in row.GetTableCells())
                        {
                            foreach (XWPFParagraph paragraph in cell.Paragraphs)
                            {
                                if (paragraph.Text.Contains(textoProcurado))
                                {
                                    // Alinhar à direita
                                    paragraph.Alignment = ParagraphAlignment.RIGHT;
                                }
                            }
                        }
                    }
                }                

                // Salvar as alterações no arquivo
                using (FileStream fs = new FileStream(caminhoDoArquivo, FileMode.Create, FileAccess.Write))
                {
                    doc.Write(fs);
                }
            }
        }

    }
}