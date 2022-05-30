using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Entities
{
    public class E_Aerolinea
    {
        private int _IdAerolinea;
        private string _Aerolinea;

        public int IdAerolinea { get => _IdAerolinea; set => _IdAerolinea = value; }
        public string Aerolinea { get => _Aerolinea; set => _Aerolinea = value; }
    }
}
