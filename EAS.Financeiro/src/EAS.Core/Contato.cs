using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EAS.Core
{
    public class Contato
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Tipo { get; set; }
        public virtual ICollection<FoneContato> Telefones { get; set; }

        public int EmpresaId { get; set; }
        public virtual Empresa Empresa { get; set; }

        public Contato()
        {
            Telefones = new List<FoneContato>();
        }
    }

    public class FoneContato
    {
        public int Id { get; set; }
        public string DDI { get; set; }
        public string DDD { get; set; }
        public string Ramal { get; set; }
        public string Numero { get; set; }
        public string Operadora { get; set; }
        public string Tipo { get; set; }
        public string Observacao { get; set; }

        public int ContatoId { get; set; }
        public virtual Contato Contato { get; set; }

        public FoneContato()
        {
            DDI = "55";
        }
    }
}
