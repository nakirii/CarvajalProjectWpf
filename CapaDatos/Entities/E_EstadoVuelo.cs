using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Entities
{
    public class E_EstadoVuelo
    {
        private int _IdEstado;
        private string _Estado;

        public int IdEstado { get => _IdEstado; set => _IdEstado = value; }
        public string Estado { get => _Estado; set => _Estado = value; }
    }
}
