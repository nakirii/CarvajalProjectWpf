using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Entities
{
    public class E_TipoUsuario
    {
        private int _IdTipo;
        private string _TipoUsuario;

        public int IdTipo { get => _IdTipo; set => _IdTipo = value; }
        public string TipoUsuario { get => _TipoUsuario; set => _TipoUsuario = value; }
    }
}
