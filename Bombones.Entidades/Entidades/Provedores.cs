using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones.Entidades.Entidades
{
    public class Provedores
    {
        public int ProvedorId { get; set; }
        public string NombreProvedor { get; set; } = null!;
        public string Email { get; set;} = null!;
        public string Telefono { get; set;} = null!;
    }
}
