using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EAS.Core
{
    public class Endereco
    {
        public int Id { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string CEP { get; set; }
        public string Pais { get; set; }
        public string Tipo { get; set; }
        public string Observacao { get; set; }

        public int EstadoId { get; set; }
        public virtual Estado Estado { get; set; }

        public Endereco()
        {
            Pais = "Brasil";
        }
    }

    public class Estado
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }

    }
}
