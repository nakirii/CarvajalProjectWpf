using CapaDatos.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaDatos
{
    public class CD_Usuario
    {
        private CD_Conexion CD_Conexion = new CD_Conexion();
        E_Usuario E_Usuario = new E_Usuario();
        SqlCommand comando = new SqlCommand();
        DataTable tabla = new DataTable();

        public void CD_Insertar(E_Usuario e_Usuario)
        {
            try
            {
                comando.Connection = CD_Conexion.OpenConnection();
                comando.CommandText = "RegistrarUsuario";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@NoDoc", e_Usuario.NoDoc);
                comando.Parameters.AddWithValue("@PrimerNombre", e_Usuario.PrimerNombre);
                comando.Parameters.AddWithValue("@SegundoNombre", e_Usuario.SegundoNombre);
                comando.Parameters.AddWithValue("@PrimerApellido", e_Usuario.PrimerApellido);
                comando.Parameters.AddWithValue("@SegundoApellido", e_Usuario.SegundoApellido);
                comando.Parameters.AddWithValue("@Telefono", e_Usuario.Telefono);
                comando.Parameters.AddWithValue("@Correo", e_Usuario.Correo);
                comando.Parameters.AddWithValue("@Password", e_Usuario.Password);
                comando.Parameters.AddWithValue("@TipoUsuario", e_Usuario.TipoUsuario);
                comando.ExecuteNonQuery();
                comando.Parameters.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo Problemas al Cargar los datos"+ ex.Message);
            }
        }

        public void CD_Editar(E_Usuario e_Usuario)
        {
            try
            {
                comando.Connection = CD_Conexion.OpenConnection();
                comando.CommandText = "EditarUsuario";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@PrimerNombre", e_Usuario.PrimerNombre);
                comando.Parameters.AddWithValue("@SegundoNombre", e_Usuario.SegundoNombre);
                comando.Parameters.AddWithValue("@PrimerApellido", e_Usuario.PrimerApellido);
                comando.Parameters.AddWithValue("@SegundoApellido", e_Usuario.SegundoApellido);
                comando.Parameters.AddWithValue("@Telefono", e_Usuario.Telefono);
                comando.Parameters.AddWithValue("@Correo", e_Usuario.Correo);
                comando.Parameters.AddWithValue("@Password", e_Usuario.Password);
                comando.Parameters.AddWithValue("@TipoUsuario", e_Usuario.TipoUsuario);
                comando.Parameters.AddWithValue("@NoDoc", e_Usuario.NoDoc);
                comando.ExecuteNonQuery();
                comando.Parameters.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo Problemas al Cargar los datos");
            }
            
        }

        public E_Usuario MostrarDetalleUsuario(string id)
        {
            try
            {
                comando.Connection = CD_Conexion.OpenConnection();
                SqlDataAdapter da = new SqlDataAdapter("ConsultarUsuarios", comando.Connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@NoDoc", SqlDbType.VarChar).Value = id;
                DataSet ds = new DataSet();
                ds.Clear();
                da.Fill(ds);
                DataTable dt;
                dt = ds.Tables[0];
                DataRow row = dt.Rows[0];
                E_Usuario.PrimerNombre = Convert.ToString(row[1]);
                E_Usuario.SegundoNombre = Convert.ToString(row[2]);
                E_Usuario.PrimerApellido = Convert.ToString(row[3]);
                E_Usuario.SegundoApellido = Convert.ToString(row[4]);
                E_Usuario.Telefono = Convert.ToString(row[5]);
                E_Usuario.Correo = Convert.ToString(row[6]);
                E_Usuario.TipoUsuario = Convert.ToInt32(row[8]);

                return E_Usuario;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo Problemas al Cargar los datos");
                return null;
            }
        }

        public E_Usuario Login(string usuario, string contrasena)
        {
            try
            {
                string patron = "password";
                comando.Connection = CD_Conexion.OpenConnection();
                SqlDataAdapter da = new SqlDataAdapter("ValidarLogin", comando.Connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = usuario;
                da.SelectCommand.Parameters.Add("@Password", SqlDbType.VarChar).Value = contrasena;
                da.SelectCommand.Parameters.Add("@Patron", SqlDbType.VarChar).Value = patron;

                DataSet ds = new DataSet();
                ds.Clear();
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    E_Usuario.NoDoc = Convert.ToString(row[0]);
                    E_Usuario.TipoUsuario = Convert.ToInt32(row[1]);

                }
                return E_Usuario;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo Problemas al Cargar los datos");
                return null;
            }
        }

        public E_Usuario Vercontrasena(string id)
        {
            try
            {
                comando.Connection = CD_Conexion.OpenConnection();
                SqlDataAdapter da = new SqlDataAdapter("Vercontrasena", comando.Connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@NoDoc", SqlDbType.VarChar).Value = id;
                DataSet ds = new DataSet();
                ds.Clear();
                da.Fill(ds);
                DataTable dt;
                dt = ds.Tables[0];
                DataRow row = dt.Rows[0];
                E_Usuario.Password = Convert.ToString(row[0]);

                return E_Usuario;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo Problemas al Cargar los datos");
                return null;
            }
        }

        public DataTable CargarUsuarios()
        {
            try
            {
                comando.Connection = CD_Conexion.OpenConnection();
                SqlDataAdapter da = new SqlDataAdapter("ListarUsuarios", comando.Connection);
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
    }
}
