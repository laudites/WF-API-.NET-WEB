using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static B_Sync_Pro.Models.Class_Produtos;

namespace B_Sync_Pro.API.Services
{
    internal class Produtos
    {

        string Banco = "BANCODEDADOS";
        string Instancia = @"SERVIDOR";
        string Senha = "SENHA";
        string Usuario = "sa";

        public void InserirProdutosNoBanco(List<ApiProduto_Bling> produtos)
        {
            string connectionString = @"Data Source=" + Instancia + ";Initial Catalog=" + Banco + ";Persist Security Info=True;User ID=" + Usuario + ";Password=" + Senha + "";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // Limpar a tabela antes da inserção
                string deleteQuery = "DELETE FROM PrdOrc where Origem = 'B'";
                using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, con))
                {
                    deleteCommand.ExecuteNonQuery();
                }

                // Inserir novos dados
                foreach (var produto in produtos)
                {
                    // Extrair o código e a cor do código
                    string codigo = produto.codigo;
                    string[] codigoParts = codigo.Split(new[] { "FP" }, StringSplitOptions.None);

                    // Definir o código e a cor como vazios por padrão
                    string codigoProduto = "";
                    string cor = "";

                    // Verificar se há pelo menos duas partes (antes e depois de "FP")
                    if (codigoParts.Length >= 2)
                    {
                        codigoProduto = codigoParts[0]; // A primeira parte é o código
                        cor = "FP" + codigoParts[1]; // A segunda parte é a cor
                    }
                    else
                    {
                        // Se não houver "FP", o código completo é considerado o código do produto
                        codigoProduto = codigo;
                    }

                    string insertQuery = "INSERT INTO PrdOrc (Componente " +
                                          ", Codigos " +
                                          ", Cores " +
                                          ", ID_B " +
                                          ", Preco " +
                                          ", Tipo " +
                                          ", Situacao " +
                                          ", Formato " +
                                          ", DescricaoCurta " +
                                          ", Imagem " +
                                          ", Origem " +
                                          ", Observacao) VALUES (@Componente " +
                                          ", @Codigos " +
                                          ", @Cores " +
                                          ", @ID_B " +
                                          ", @Preco " +
                                          ", @Tipo " +
                                          ", @Situacao " +
                                          ", @Formato " +
                                          ", @DescricaoCurta " +
                                          ", @Imagem " +
                                          ", @Origem " +
                                          ", @Observacao)";

                        using (SqlCommand command = new SqlCommand(insertQuery, con))
                        {
                            //command.Parameters.AddWithValue("@ID", produto.id);
                            command.Parameters.AddWithValue("@Componente", produto.nome);
                            command.Parameters.AddWithValue("@Codigos", codigoProduto);
                            command.Parameters.AddWithValue("@Cores", cor); // Substitua pelo nome real da propriedade.
                            command.Parameters.AddWithValue("@ID_B", produto.id); // Substitua pelo nome real da propriedade.
                            command.Parameters.AddWithValue("@Preco", produto.preco);
                            command.Parameters.AddWithValue("@Tipo", produto.tipo);
                            command.Parameters.AddWithValue("@Situacao", produto.situacao);
                            command.Parameters.AddWithValue("@Formato", produto.formato);
                            command.Parameters.AddWithValue("@DescricaoCurta", produto.descricaoCurta);
                            command.Parameters.AddWithValue("@Imagem", ""); // Substitua pelo nome real da propriedade.
                            command.Parameters.AddWithValue("@Origem", "B");
                            command.Parameters.AddWithValue("@Observacao", "Importado do Bling");

                            command.ExecuteNonQuery();
                        }
                    }
                
                con.Close();
            }
        }

    }
}
