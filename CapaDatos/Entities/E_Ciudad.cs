using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Entities
{
    public class E_Ciudad
    {
        private int _IdCiudad;
        private string _Ciudad;

        public int IdCiudad { get => _IdCiudad; set => _IdCiudad = value; }
        public string Ciudad { get => _Ciudad; set => _Ciudad = value; }
    }
}
