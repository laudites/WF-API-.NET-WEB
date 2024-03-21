using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using static B_Sync_Pro.Models.Class_Produtos;
using B_Sync_Pro.API.Services;

namespace B_Sync_Pro.API.Services
{
    internal static class ProdutosBling
    {
        public static async Task BuscarProdutosBling(string code)
        {
            string token = code; // Substitua pelo seu token de acesso
            string apiUrl = "https://www.bling.com.br/Api/v3/produtos?pagina=1&limite=100&cpo=P&nome=kit";            

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<ApiProdutos>(responseContent);
                    InserirDadosNoBanco(result);
                }
                else
                {
                    MessageBox.Show("Erro ao obter os dados da API.");
                }
            }
        }

        public static void InserirDadosNoBanco(ApiProdutos produtos)
        {
            var produtosService = new Produtos(); // Crie uma instância da classe Produtos
            produtosService.InserirProdutosNoBanco(produtos.data); // Chame o método na instância
        }

    }
}
