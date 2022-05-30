using CapaDatos.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CapaDatos
{
    public class CD_Vuelo
    {
        private CD_Conexion CD_Conexion = new CD_Conexion();
        SqlCommand comando = new SqlCommand();
        DataTable tabla = new DataTable();
        E_Vuelo e_Vuelo = new E_Vuelo();



        public E_Vuelo ConsultarVuelo(string NoVuelo)
        {

            try
            {
                comando.Connection = CD_Conexion.OpenConnection();
                SqlDataAdapter da = new SqlDataAdapter("ConsultarVuelo", comando.Connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@NoVuelo", SqlDbType.VarChar).Value = NoVuelo;
                DataSet ds = new DataSet();
                ds.Clear();
                da.Fill(ds);
                DataTable dt;
                dt = ds.Tables[0];
                DataRow row = dt.Rows[0];

                e_Vuelo.NoVuelo = Convert.ToString(row[0]);
                e_Vuelo.FechaSalida = Convert.ToDateTime(row[1]);
                e_Vuelo.FechaLlegada = Convert.ToDateTime(row[2]);
                var HoraLlegada = row[3].ToString();
                var HoraSalida = row[4].ToString();
                e_Vuelo.HoraLlegada = Convert.ToDateTime(HoraLlegada);
                e_Vuelo.HoraSalida = Convert.ToDateTime(HoraSalida);
                e_Vuelo.CiudadOrigen = Convert.ToInt32(row[5]);
                e_Vuelo.CiudadDestino = Convert.ToInt32(row[6]);
                e_Vuelo.IdEstado = Convert.ToInt32(row[7]);
                e_Vuelo.IdAerolinea = Convert.ToInt32(row[8]);
                return e_Vuelo;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo Problemas al Cargar los datos");
                return null;
            }
        }

        #region Insertar
        public void CD_Insertar(E_Vuelo e_Vuelo)
        {
            try
            {
                comando.Connection = CD_Conexion.OpenConnection();
                comando.CommandText = "RegistrarVuelo";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@NoVuelo", e_Vuelo.NoVuelo);
                comando.Parameters.AddWithValue("@FechaSalida", e_Vuelo.FechaSalida);
                comando.Parameters.AddWithValue("@FechaLlegada", e_Vuelo.FechaLlegada);
                comando.Parameters.AddWithValue("@HoraLlegada", e_Vuelo.HoraLlegada);
                comando.Parameters.AddWithValue("@HoraSalida", e_Vuelo.HoraSalida);
                comando.Parameters.AddWithValue("@CiudadOrigen", e_Vuelo.CiudadOrigen);
                comando.Parameters.AddWithValue("@CiudadDestino", e_Vuelo.CiudadDestino);
                comando.Parameters.AddWithValue("@IdEstado", e_Vuelo.IdEstado);
                comando.Parameters.AddWithValue("@IdAerolinea", e_Vuelo.IdAerolinea);
                comando.ExecuteNonQuery();
                comando.Parameters.Clear();
                CD_Conexion.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo Problemas al Cargar los datos");
            }
        }
        #endregion



        public void CD_Editar(E_Vuelo e_Vuelo)
        {
            try
            {
                comando.Connection = CD_Conexion.OpenConnection();
                comando.CommandText = "[EditarVuelo]";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@FechaSalida", e_Vuelo.FechaSalida);
                comando.Parameters.AddWithValue("@FechaLlegada", e_Vuelo.FechaLlegada);
                comando.Parameters.AddWithValue("@HoraLlegada", e_Vuelo.HoraLlegada);
                comando.Parameters.AddWithValue("@HoraSalida", e_Vuelo.HoraSalida);
                comando.Parameters.AddWithValue("@CiudadOrigen", e_Vuelo.CiudadOrigen);
                comando.Parameters.AddWithValue("@CiudadDestino", e_Vuelo.CiudadDestino);
                comando.Parameters.AddWithValue("@IdEstado", e_Vuelo.IdEstado);
                comando.Parameters.AddWithValue("@IdAerolinea", e_Vuelo.IdAerolinea);
                comando.Parameters.AddWithValue("@NoVuelo", e_Vuelo.NoVuelo);
                comando.ExecuteNonQuery();
                comando.Parameters.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo Problemas al Cargar los datos");
            }
        }



        public DataTable CargarVuelos()
        {
            try
            {
                comando.Connection = CD_Conexion.OpenConnection();
                SqlDataAdapter da = new SqlDataAdapter("ListarDetallesVuelo", comando.Connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                ds.Clear();
                da.Fill(ds);
                tabla = ds.Tables[0];
                CD_Conexion.CloseConnection();
                return tabla;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo Problemas al Cargar los datos");
                return null;
            }
        }


        public E_Vuelo validarVuerloExiste(string NoVuelo)
        {
            try
            {
                comando.Connection = CD_Conexion.OpenConnection();
                SqlDataAdapter da = new SqlDataAdapter("ConsultarVuelo", comando.Connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@NoVuelo", SqlDbType.VarChar).Value = NoVuelo;
                DataSet ds = new DataSet();
                ds.Clear();
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                e_Vuelo.NoVuelo = null;
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    e_Vuelo.NoVuelo = Convert.ToString(row[0]);

                }
                return e_Vuelo;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo Problemas al Cargar los datos");
                return null;
            }
        }
    }
}
