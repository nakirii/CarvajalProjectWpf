using System.Windows;
using CapaNegocio;

namespace Interfaz.Views
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            tbusuario.Focus();
        }

        private void Acceder(object sender, RoutedEventArgs e)
        {
            //MainWindow mainWindow = new MainWindow();
            //mainWindow.Show();
            //this.Close();
            string pass = tbcontrasena.Password;
            if(pass.Length!=0 && tbusuario.Text.Length != 0)
            {
                Logi(tbusuario.Text, pass);
            }
            else
            {
                MessageBox.Show("Los Campos no puden estar vacios!");
            }
        }

        void Logi(string usuario, string contrasena)
        {
            CN_Usuario cN_Usuario = new CN_Usuario();

            var datos = cN_Usuario.LogIn(usuario, contrasena);

            if (datos.NoDoc != null)
            {
                Properties.Settings.Default.Usuario = datos.NoDoc;
                Properties.Settings.Default.TipoUsuario = datos.TipoUsuario;
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Datos Incorrectos.");

            }
        }

        private void Cerrar(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
