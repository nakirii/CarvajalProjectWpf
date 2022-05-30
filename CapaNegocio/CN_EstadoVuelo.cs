using CapaDatos;
using CapaDatos.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_EstadoVuelo
    {
        CD_EstadoVuelo CD_EstadoVuelo = new CD_EstadoVuelo();

        public ObservableCollection<E_EstadoVuelo> GetEstado()
        {
            ObservableCollection<E_EstadoVuelo> vuelos = new ObservableCollection<E_EstadoVuelo>();

            foreach (DataRow item in MostrarEstadoVuelo().Rows)
            {
                var vuelo = new E_EstadoVuelo
                {
                    IdEstado = Convert.ToInt32(item["IdEstado"].ToString()),
                    Estado = item["Estado"].ToString()
                };

                vuelos.Add(vuelo);
            }

            return vuelos;
        }

        public DataTable MostrarEstadoVuelo()
        {
            DataTable table = new DataTable();
            table = CD_EstadoVuelo.ListarEstadoVuelo();
            return table;

        }
    }
}
