using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EAS.Core
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<Empresa> Empresas { get; set; }

        public ApplicationUser()
            :base()
        {
            Empresas = new List<Empresa>();
        }
    }
}
