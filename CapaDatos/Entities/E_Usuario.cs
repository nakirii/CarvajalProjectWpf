using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Entities
{
    public class E_Usuario
    {
        private string _NoDoc;
        private string _PrimerNombre;
        private string _SegundoNombre;
        private string _PrimerApellido;
        private string _SegundoApellido;
        private string _Telefono;
        private string _Correo;
        private string _Password;
        private int _TipoUsuario;

        public string NoDoc { get => _NoDoc; set => _NoDoc = value; }
        public string PrimerNombre { get => _PrimerNombre; set => _PrimerNombre = value; }
        public string SegundoNombre { get => _SegundoNombre; set => _SegundoNombre = value; }
        public string PrimerApellido { get => _PrimerApellido; set => _PrimerApellido = value; }
        public string SegundoApellido { get => _SegundoApellido; set => _SegundoApellido = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public string Correo { get => _Correo; set => _Correo = value; }
        public string Password { get => _Password; set => _Password = value; }
        public int TipoUsuario { get => _TipoUsuario; set => _TipoUsuario = value; }
    }
}
