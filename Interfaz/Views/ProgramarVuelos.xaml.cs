using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CapaDatos.Entities;
using CapaNegocio;
namespace Interfaz.Views
{
    /// <summary>
    /// Lógica de interacción para ProgramarVuelos.xaml
    /// </summary>
    public partial class ProgramarVuelos : Page
    {
        private CN_Vuelos cN_Vuelos = new CN_Vuelos();
        private E_Vuelo e_Vuelo = new E_Vuelo();
        internal bool vista;

        public ProgramarVuelos()
        {
            InitializeComponent();
            LlenarCombos();
        }

        public void LlenarCombos()
        {
            CN_Ciudad cN_Ciudad = new CN_Ciudad();
            CN_EstadoVuelo cN_EstadoVuelo = new CN_EstadoVuelo();
            CN_Aerolinea cN_Aerolinea = new CN_Aerolinea();

            cbCiudadDestino.ItemsSource = cN_Ciudad.GetCiudad();
            this.cbCiudadDestino.DisplayMemberPath = "Ciudad";
            this.cbCiudadDestino.SelectedValuePath = "IdCiudad";

            cbCiudadOrigen.ItemsSource = cN_Ciudad.GetCiudad();
            this.cbCiudadOrigen.DisplayMemberPath = "Ciudad";
            this.cbCiudadOrigen.SelectedValuePath = "IdCiudad";

            cbEstadovuelo.ItemsSource = cN_EstadoVuelo.GetEstado();
            this.cbEstadovuelo.DisplayMemberPath = "Estado";
            this.cbEstadovuelo.SelectedValuePath = "IdEstado";

            cbAerolinea.ItemsSource = cN_Aerolinea.GetAerolinea();
            this.cbAerolinea.DisplayMemberPath = "Aerolinea";
            this.cbAerolinea.SelectedValuePath = "IdAerolinea";

        }

        internal void Consultar(string id)
        {
            var contra = cN_Vuelos.ConsultarVuelo(id);
            cbAerolinea.SelectedValue = contra.IdAerolinea;
            cbCiudadDestino.SelectedValue = contra.CiudadDestino;
            cbCiudadOrigen.SelectedValue = contra.CiudadOrigen;
            cbEstadovuelo.SelectedValue = contra.IdEstado;
            tbNoVuelo.Text = contra.NoVuelo;
            tmHoraSalida.Value = contra.HoraSalida;
            tmhorallegada.Value =contra.HoraLlegada;
            dtFechaSalida.Text = Convert.ToString(contra.FechaSalida);
            dtFechaLlegada.Text = Convert.ToString(contra.FechaLlegada);
        }

        private void RegistrarVuelo(object sender, RoutedEventArgs e)
        {
            string vuelo = tbNoVuelo.Text;
            regitrar(vuelo);
        }

        void asignado()
        {
            e_Vuelo.IdAerolinea = (int)cbAerolinea.SelectedValue;
            e_Vuelo.CiudadDestino = (int)cbCiudadDestino.SelectedValue;
            e_Vuelo.CiudadOrigen = (int)cbCiudadOrigen.SelectedValue;
            e_Vuelo.IdEstado = (int)cbEstadovuelo.SelectedValue;
            e_Vuelo.NoVuelo = tbNoVuelo.Text;
            e_Vuelo.HoraSalida = Convert.ToDateTime(tmHoraSalida.Text);
            e_Vuelo.HoraLlegada = Convert.ToDateTime(tmhorallegada.Text);
            e_Vuelo.FechaSalida = Convert.ToDateTime(dtFechaSalida.Text);
            e_Vuelo.FechaLlegada = Convert.ToDateTime(dtFechaLlegada.Text);
        }

        private void Regresar(object sender, RoutedEventArgs e)
        {
            if (vista)
            {
                Content = new Inicio();
            }
            else
            {
                Content = new Vuelos();
            }
        }

        public bool validarcampos()
        {
            if (cbAerolinea.Text.Length == 0 || cbCiudadDestino.Text.Length == 0 ||
                cbCiudadOrigen.Text.Length == 0 || cbEstadovuelo.Text.Length == 0 ||
                tbNoVuelo.Text.Length == 0 || tmHoraSalida.Text.Length == 0 ||
                tmhorallegada.Text.Length == 0 || dtFechaSalida.Text.Length == 0 || dtFechaLlegada.Text.Length == 0)
            {
                MessageBox.Show("Todos los campos son Obligatorios");
                return false;
            }
            else
            {
                TimeSpan tmHoraSalidav = new TimeSpan();
                TimeSpan tmhorallegadav = new TimeSpan();
                tmHoraSalidav = DateTime.Now.Subtract((DateTime)tmHoraSalida.Value);
                tmhorallegadav = DateTime.Now.Subtract((DateTime)tmhorallegada.Value);

                if (dtFechaLlegada.SelectedDate < dtFechaSalida.SelectedDate)
                {
                    MessageBox.Show("La Fecha de llegada no puede ser mayor a la fecha de Salida");
                    return false;
                }
                else if(dtFechaLlegada.SelectedDate == dtFechaSalida.SelectedDate && tmhorallegadav >= tmHoraSalidav)
                {
                    MessageBox.Show("La Hora de SALIDA no puede ser mayor a la Hora de LLEGADA \nYa que el vuelo se completara el Mismo dia");
                    return false;
                }

                if ((int)cbCiudadDestino.SelectedValue == (int)cbCiudadOrigen.SelectedValue)
                {
                    MessageBox.Show("La Ciudad Origen no puede ser la misma que la Ciudad Destino");
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public void regitrar(string vuelo)
        {

            var datos = cN_Vuelos.VueloExiste(vuelo);
            if (datos.NoVuelo == null)
            {
                if (validarcampos())
                {
                    asignado();
                    cN_Vuelos.RistrarVuelo(e_Vuelo);
                    Content = new Vuelos();
                }
            }
            else
            {
                MessageBox.Show("Este Vuelo ya esta registrado.");
            }

        }

        

        private void ModificarVuelo(object sender, RoutedEventArgs e)
        {
            if (validarcampos())
            {
                asignado();
                cN_Vuelos.ModifificarVuelo(e_Vuelo);
                Content = new Vuelos();
            }
        }
    }
}
