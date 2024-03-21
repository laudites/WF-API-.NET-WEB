using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_Sync_Pro.Models
{
    internal class Class_cliente
    {
        public class Contact
        {
            public long id { get; set; }
            public string nome { get; set; }
            public string codigo { get; set; }
            public string situacao { get; set; }
            public string numeroDocumento { get; set; }
            public string telefone { get; set; }
            public string celular { get; set; }
        }

        public class ApiResponse
        {
            public List<Contact> data { get; set; }
        }
        public class ApiResponseVendedor
        {
            public List<Vendedor> data { get; set; }
        }

        public class Vendedor
        {
            public Contato contato { get; set; }
        }

        public class Contato
        {
            public string nome { get; set; }
        }

    }
}
