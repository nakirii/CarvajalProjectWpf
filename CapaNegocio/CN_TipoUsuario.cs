using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaDatos.Entities;

namespace CapaNegocio
{
    public class CN_TipoUsuario
    {
        private CD_TipoUsuario CD_TipoUsuario= new CD_TipoUsuario();

        public ObservableCollection<E_TipoUsuario> GetTipoUsuario()
        {
            ObservableCollection<E_TipoUsuario> usuarios = new ObservableCollection<E_TipoUsuario>();

            foreach (DataRow item in MostrarEstadoVuelo().Rows)
            {
                var usuario = new E_TipoUsuario
                {
                    IdTipo = Convert.ToInt32(item["IdTipo"].ToString()),
                    TipoUsuario = item["TipoUsuario"].ToString()
                };

                usuarios.Add(usuario);
            }

            return usuarios;
        }

        public DataTable MostrarEstadoVuelo()
        {
            DataTable table = new DataTable();
            table = CD_TipoUsuario.ListarTipoUsuario();
            return table;

        }
    }
}
