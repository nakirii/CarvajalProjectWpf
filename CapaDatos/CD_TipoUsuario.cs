using CapaDatos.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace CapaDatos
{
    public class CD_TipoUsuario
    {
  

        private CD_Conexion CD_Conexion = new CD_Conexion();
        private SqlCommand comando = new SqlCommand();
        private SqlDataReader leer;

        public DataTable ListarTipoUsuario()
        {
            try
            {
                DataTable tabla = new DataTable();
                comando.Connection = CD_Conexion.OpenConnection();
                comando.CommandText = "CargarTipoUsuario";
                comando.CommandType = CommandType.StoredProcedure;
                leer = comando.ExecuteReader();
                tabla.Load(leer);
                leer.Close();
                CD_Conexion.CloseConnection();
                return tabla;
            }
            catch (Exception)
            {

                MessageBox.Show("Hubo Problemas al Cargar los datos");
                return null;
            }
        }

    }
}
