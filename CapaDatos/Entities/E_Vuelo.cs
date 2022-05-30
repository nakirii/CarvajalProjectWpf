using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Entities
{
    public class E_Vuelo
    {
       private string _NoVuelo;
       private DateTime _FechaSalida;
       private DateTime _FechaLlegada;
       private DateTime _HoraLlegada;
       private DateTime _HoraSalida;
       private int _CiudadOrigen;
       private int _CiudadDestino;
       private int _IdEstado;
       private int _IdAerolinea;

        public string NoVuelo { get => _NoVuelo; set => _NoVuelo = value; }
        public DateTime FechaSalida { get => _FechaSalida; set => _FechaSalida = value; }
        public DateTime FechaLlegada { get => _FechaLlegada; set => _FechaLlegada = value; }
        public DateTime HoraLlegada { get => _HoraLlegada; set => _HoraLlegada = value; }
        public DateTime HoraSalida { get => _HoraSalida; set => _HoraSalida = value; }
        public int CiudadOrigen { get => _CiudadOrigen; set => _CiudadOrigen = value; }
        public int CiudadDestino { get => _CiudadDestino; set => _CiudadDestino = value; }
        public int IdEstado { get => _IdEstado; set => _IdEstado = value; }
        public int IdAerolinea { get => _IdAerolinea; set => _IdAerolinea = value; }
    }
}
