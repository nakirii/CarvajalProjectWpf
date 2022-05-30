using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CapaDatos;
using CapaDatos.Entities;

namespace CapaNegocio
{
    public class CN_Usuario
    {
        private CD_Usuario CD_Usuario = new CD_Usuario();

        public void InsertarUsuario(E_Usuario e_Usuario)
        {  
            CD_Usuario.CD_Insertar(e_Usuario);
        }


        public void EditarUsuario(E_Usuario e_Usuario)
        {
            CD_Usuario.CD_Editar(e_Usuario);
        }


        public E_Usuario ConsultarUsuario(string id)
        {
            return CD_Usuario.MostrarDetalleUsuario(id);
        }

        public E_Usuario LogIn(string usuario, string contrasena)
        {
            return CD_Usuario.Login(usuario,contrasena);
        }

        public E_Usuario UserExiste(string usuario)
        {
            return CD_Usuario.validarUsuarioExiste(usuario);
        }

        public E_Usuario ConsultarContraseba(string id)
        {
            return CD_Usuario.Vercontrasena(id);
        }

        public DataTable CargarUsuarios()
        {
            return CD_Usuario.CargarUsuarios();
        }
    }

}
