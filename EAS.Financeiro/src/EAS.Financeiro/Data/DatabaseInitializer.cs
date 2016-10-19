using EAS.Core;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EAS.Financeiro.Data
{
    public class DatabaseInitializer
    {
        ApplicationDbContext _ctx;
        UserManager<ApplicationUser> _userManager;

        public DatabaseInitializer(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _ctx = context;
            _userManager = userManager;
        }

        public async Task EnsureInitialize()
        {
            _ctx.Database.EnsureCreated();

            if(!_ctx.Users.Any())
            {
                await _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "elvisdeandrade",
                    Email = "elvisdeandrade@gmail.com"
                },
                "Zaq!2wsx");
            }

            if (_ctx.Estados.Any())
                return;

            #region estados

            _ctx.Estados.Add(new Estado
            {
                Nome = "Acre",
                Sigla = "AC"
            });

            _ctx.Estados.Add(new Estado
            {
                Nome = "Alagoas",
                Sigla = "AL"
            });

            _ctx.Estados.Add(new Estado
            {
                Nome = "Amapá",
                Sigla = "AP"
            });

            _ctx.Estados.Add(new Estado
            {
                Nome = "Amazonas",
                Sigla = "AM"
            });

            _ctx.Estados.Add(new Estado
            {
                Nome = "Bahia",
                Sigla = "BA"
            });

            _ctx.Estados.Add(new Estado
            {
                Nome = "Ceará",
                Sigla = "CE"
            });

            _ctx.Estados.Add(new Estado
            {
                Nome = "Distrito Federal",
                Sigla = "DF"
            });

            _ctx.Estados.Add(new Estado
            {
                Nome = "Espírito Santo",
                Sigla = "ES"
            });

            _ctx.Estados.Add(new Estado
            {
                Nome = "Goiás",
                Sigla = "GO"
            });

            _ctx.Estados.Add(new Estado
            {
                Nome = "Maranhão",
                Sigla = "MA"
            });

            _ctx.Estados.Add(new Estado
            {
                Nome = "Mato Grosso",
                Sigla = "MT"
            });

            _ctx.Estados.Add(new Estado
            {
                Nome = "Mato Grosso do Sul",
                Sigla = "MS"
            });

            _ctx.Estados.Add(new Estado
            {
                Nome = "Minas Gerais",
                Sigla = "MG"
            });

            _ctx.Estados.Add(new Estado
            {
                Nome = "Pará",
                Sigla = "PA"
            });

            _ctx.Estados.Add(new Estado
            {
                Nome = "Paraíba",
                Sigla = "PB"
            });

            _ctx.Estados.Add(new Estado
            {
                Nome = "Paraná",
                Sigla = "PR"
            });

            _ctx.Estados.Add(new Estado
            {
                Nome = "Pernambuco",
                Sigla = "PE"
            });

            _ctx.Estados.Add(new Estado
            {
                Nome = "Piauí",
                Sigla = "PI"
            });

            _ctx.Estados.Add(new Estado
            {
                Nome = "Rio de Janeiro",
                Sigla = "RJ"
            });

            _ctx.Estados.Add(new Estado
            {
                Nome = "Rio Grande do Norte",
                Sigla = "RN"
            });

            _ctx.Estados.Add(new Estado
            {
                Nome = "Rio Grande do Sul",
                Sigla = "RS"
            });

            _ctx.Estados.Add(new Estado
            {
                Nome = "Rondônia",
                Sigla = "RO"
            });

            _ctx.Estados.Add(new Estado
            {
                Nome = "Roraima",
                Sigla = "RR"
            });

            _ctx.Estados.Add(new Estado
            {
                Nome = "Santa Catarina",
                Sigla = "SC"
            });

            _ctx.Estados.Add(new Estado
            {
                Nome = "São Paulo",
                Sigla = "SP"
            });

            _ctx.Estados.Add(new Estado
            {
                Nome = "Sergipe",
                Sigla = "SE"
            });

            _ctx.Estados.Add(new Estado
            {
                Nome = "Tocantins",
                Sigla = "TO"
            });

            _ctx.SaveChanges();

            #endregion

            Estado sp = _ctx.Estados.FirstOrDefault(t => t.Sigla == "SP");
            Empresa empresa = new Empresa();

            empresa.Nome = "EAS Photobooth";
            empresa.RazaoSocial = "EAS Photobooth LTDA";
            empresa.CNPJ = "432838110001-50";
            empresa.Ativa = true;
            empresa.DataCadastro = DateTime.Now;
            empresa.Enderecos.Add(new Endereco
            {
                Rua = "Carlos Stênio Costa Barros 71",
                Bairro = "Jardim Nena",
                Cidade = "Suzano",
                Pais = "Brasil",
                EstadoId = sp.Id
            });
            empresa.Contatos.Add(new Contato {
                Nome="Elvis de Andrade Santos",
                Email="elvisdeandrade@outlook.com",
                Telefones = new List<FoneContato>
                {
                    new FoneContato
                    {
                        Numero = "953795227",
                        DDD="11",
                        Operadora="TIM",
                        Tipo="Cel"
                    }
                }
            });

            _ctx.Empresas.Add(empresa);
            await _ctx.SaveChangesAsync();
        }
    }
}
