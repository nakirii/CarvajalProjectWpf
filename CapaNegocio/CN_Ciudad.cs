using CapaDatos.Entities;
using System.Collections.ObjectModel;
using System.Data;
using CapaDatos;
using System;

namespace CapaNegocio
{
    public class CN_Ciudad
    {
        CD_Ciudad CD_Ciudad = new CD_Ciudad();

        public ObservableCollection<E_Ciudad> GetCiudad()
        {
            ObservableCollection<E_Ciudad> ciudades = new ObservableCollection<E_Ciudad>();

            foreach (DataRow item in MostrarCiudad().Rows)
            {
                var ciudad = new E_Ciudad
                {
                    IdCiudad = Convert.ToInt32(item["IdCiudad"].ToString()),
                    Ciudad = item["Ciudad"].ToString()
                };

                ciudades.Add(ciudad);
            }

            return ciudades;
        }

        public DataTable MostrarCiudad()
        {
            DataTable table = new DataTable();
            table = CD_Ciudad.ListarCiudad();
            return table;

        }


    }
}
