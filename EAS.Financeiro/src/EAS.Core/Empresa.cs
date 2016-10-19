using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EAS.Core
{
    public class Empresa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }
        public bool Ativa { get; set; }
        public DateTime DataCadastro { get; set; }

        public virtual ICollection<Contato> Contatos { get; set; }
        public virtual ICollection<Endereco> Enderecos { get; set; }

        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public Empresa()
        {
            Contatos = new List<Contato>();
            Enderecos = new List<Endereco>();
        }
    }
}
