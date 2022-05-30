using System.Windows;
using System.Windows.Controls;
using CapaNegocio;
using CapaDatos.Entities;
using System.Collections.Generic;

namespace Interfaz.Views
{
    /// <summary>
    /// Lógica de interacción para RegistrarUsuario.xaml
    /// </summary>
    public partial class RegistrarUsuario : Page
    {
       
        CN_Usuario CN_Usuario = new CN_Usuario();
        CN_TipoUsuario CN_TipoUsuario = new CN_TipoUsuario();
        E_Usuario E_Usuario = new E_Usuario();
       

        public RegistrarUsuario()
        {
            InitializeComponent();
            LlenarCombo();
        }

        private void Regresar(object sender, RoutedEventArgs e)
        {
            Content = new Usuarios();
        }

        private void Registrar(object sender, RoutedEventArgs e)
        {
            string user = tbDoc.Text;
            RegistrarUsuarios(user);
        }

        private void Modificar(object sender, RoutedEventArgs e)
        {
            Modificar();
        }

        public void LlenarCombo()
        {
            CbTipoUsuario.ItemsSource = CN_TipoUsuario.GetTipoUsuario();
            this.CbTipoUsuario.DisplayMemberPath = "TipoUsuario";
            this.CbTipoUsuario.SelectedValuePath = "IdTipo";
        }

        public bool comprobarcampos()
        {

            if (tbDoc.Text.Length == 0 || tbPrimerNombre.Text.Length == 0 ||
                tbPrimerApellido.Text.Length == 0 || tbContrasena.Text.Length == 0 || CbTipoUsuario.Text.Length == 0)
            {
                MessageBox.Show("Todos los campos Marcados con (*) son Obligatorios");
                return false;
            }
            else if(tbDoc.Text.Length > 15)
            {
                    MessageBox.Show("el Numero de documento no puede tener mas de 15 caracteres");
                return false;
            }
            else if (tbContrasena.Text.Length < 4)
            {
                MessageBox.Show("la contrasena debe tener por lo menos 4 caracteres");
                return false;
            }
            else
            {
                return true;
            }
            
                
         }
        

        private void RegistrarUsuarios(string user)
        {
            var datos = CN_Usuario.UserExiste(user);
            if (datos.NoDoc == null)
            {
                if (comprobarcampos())
                {
                    asignado();
                    CN_Usuario.InsertarUsuario(E_Usuario);
                    Content = new Usuarios();
                }
            }
            else
            {
                MessageBox.Show("Este Usuario ya esta registrado.");
            }
           
        }

        void asignado()
        {
            E_Usuario.NoDoc = tbDoc.Text;
            E_Usuario.PrimerNombre = tbPrimerNombre.Text;
            E_Usuario.SegundoNombre = tbSegundoNombre.Text;
            E_Usuario.PrimerApellido = tbPrimerApellido.Text;
            E_Usuario.SegundoApellido = tbSegundoApellido.Text;
            E_Usuario.Telefono = tbTelefono.Text;
            E_Usuario.Correo = tbEmail.Text;
            E_Usuario.Password = tbContrasena.Text;
            E_Usuario.TipoUsuario = CbTipoUsuario.SelectedIndex + 1;
        }

        public void Consultar(string IdUsuario)
        {
            var contra = CN_Usuario.ConsultarContraseba(IdUsuario);
            var datos =  CN_Usuario.ConsultarUsuario(IdUsuario);
            tbPrimerNombre.Text = datos.PrimerNombre;
            tbSegundoNombre.Text = datos.SegundoNombre;
            tbPrimerApellido.Text = datos.PrimerApellido;
            tbSegundoApellido.Text = datos.SegundoApellido;
            tbTelefono.Text = datos.Telefono;
            tbEmail.Text = datos.Correo;
            tbDoc.Text = IdUsuario;
            tbContrasena.Text = contra.Password;
            CbTipoUsuario.SelectedValue = datos.TipoUsuario;
        }

        public void Modificar()
        {
            if (comprobarcampos())
            {
                asignado();
                CN_Usuario.EditarUsuario(E_Usuario);
                Content = new Usuarios();
            }

        }
    }
}
