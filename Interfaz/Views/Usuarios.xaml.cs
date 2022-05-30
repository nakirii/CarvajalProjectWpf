using CapaDatos;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using CapaNegocio;

namespace Interfaz.Views
{
    /// <summary>
    /// Lógica de interacción para Usuarios.xaml
    /// </summary>
    public partial class Usuarios : UserControl
    {
        public Usuarios()
        {
            InitializeComponent();
            cargarDatos();
        }

        private CD_Conexion CD_Conexion = new CD_Conexion();
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();
        CN_Usuario cN_Usuario = new CN_Usuario();

        void  cargarDatos()
        {
            cN_Usuario.CargarUsuarios();
            GridDatos.ItemsSource = cN_Usuario.CargarUsuarios().DefaultView;
        }

        private void Agregar(object sender, RoutedEventArgs e)
        {
            RegistrarUsuario registrarUsuario = new RegistrarUsuario();
            FrameUsario.Content = registrarUsuario;
            registrarUsuario.BtnRegistrar.Visibility = Visibility.Visible;
        }

        private void Consultar(object sender, RoutedEventArgs e)
        {
            string id = (string)((Button)sender).CommandParameter;
            RegistrarUsuario registrarUsuario = new RegistrarUsuario();
         
            registrarUsuario.Consultar(id);
            FrameUsario.Content = registrarUsuario;
            registrarUsuario.Titulo.Text = "Informacion del Usuario";
            registrarUsuario.tbContrasena.IsEnabled = false;
            registrarUsuario.tbDoc.IsEnabled = false;
            registrarUsuario.tbEmail.IsEnabled = false;
            registrarUsuario.tbPrimerApellido.IsEnabled = false;
            registrarUsuario.tbPrimerNombre.IsEnabled = false;
            registrarUsuario.tbSegundoApellido.IsEnabled = false;
            registrarUsuario.tbSegundoNombre.IsEnabled = false;
            registrarUsuario.tbTelefono.IsEnabled = false;
            registrarUsuario.CbTipoUsuario.IsEnabled = false;
        }

        private void Modificar(object sender, RoutedEventArgs e)
        {
            string id = (string)((Button)sender).CommandParameter;
            RegistrarUsuario registrarUsuario = new RegistrarUsuario();
            registrarUsuario.Consultar(id);
            FrameUsario.Content = registrarUsuario;
            registrarUsuario.Titulo.Text = "Modificar Usuario del Usuario";
            registrarUsuario.tbDoc.IsEnabled = false;
            registrarUsuario.BtnModificar.Visibility = Visibility.Visible;

        }
    }
}
