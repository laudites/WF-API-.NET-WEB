using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_Sync_Pro.Models
{
    internal class Class_Produtos
    {
        public class PrdOrc
        {
            public long ID { get; set; }
            public string Componente { get; set; }
            public string Codigos { get; set; }
            public string Cores { get; set; }
            public int ID_B { get; set; }
            public decimal Preco { get; set; }
            public string Tipo { get; set; }
            public string Situacao { get; set; }
            public string Formato { get; set; }
            public string DescricaoCurta { get; set; }
            public string Imagem { get; set; }
            public string Origem { get; set; }
            public string Observacao { get; set; }
        }


        public class ApiProduto_Bling
        {
            public long id { get; set; }
            public string nome { get; set; }
            public string codigo { get; set; }
            public double preco { get; set; }
            public string tipo { get; set; }
            public string situacao { get; set; }
            public string formato { get; set; }
            public string descricaoCurta { get; set; }
        }

        public class ApiProdutos
        {
            public List<ApiProduto_Bling> data { get; set; }
        }

        public class ComponenteCor
        {
            public string Componente { get; set; }
            public string Cor { get; set; }
        }
    }
}
