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
using CapaDatos;
using CapaDatos.Entities;
using CapaNegocio;
namespace Interfaz.Views
{
    /// <summary>
    /// Lógica de interacción para Vuelos.xaml
    /// </summary>
    public partial class Vuelos : UserControl
    {
        private readonly CN_Vuelos CN_Vuelos = new CN_Vuelos();
        
        public Vuelos()
        {
            InitializeComponent();
            cargarDatos();
        }


        private void Consultar(object sender, RoutedEventArgs e)
        {
            string id = (string)((Button)sender).CommandParameter;
            ProgramarVuelos programarVuelos = new ProgramarVuelos();
            programarVuelos.Consultar(id);
            FrameVuelo.Content = programarVuelos;
            programarVuelos.vista = false;
            programarVuelos.Titulo.Text = "Detalle de Vuelo";
            programarVuelos.tbNoVuelo.IsEnabled = false;
            programarVuelos.cbAerolinea.IsEnabled = false;
            programarVuelos.cbEstadovuelo.IsEnabled = false;
            programarVuelos.cbCiudadDestino.IsEnabled = false;
            programarVuelos.cbCiudadOrigen.IsEnabled = false;
            programarVuelos.tmhorallegada.IsEnabled = false;
            programarVuelos.tmHoraSalida.IsEnabled = false;
            programarVuelos.dtFechaLlegada.IsEnabled = false;
            programarVuelos.dtFechaSalida.IsEnabled = false;
        }

        private void Modificar(object sender, RoutedEventArgs e)
        {
            string id = (string)((Button)sender).CommandParameter;
            ProgramarVuelos programarVuelos = new ProgramarVuelos();
            programarVuelos.Consultar(id);
            FrameVuelo.Content = programarVuelos;
            programarVuelos.Titulo.Text = "Modificar Vuelo";
            programarVuelos.btnModificar.Visibility = Visibility.Visible;
            programarVuelos.tbNoVuelo.IsEnabled = false;
        }

        private void Programar(object sender, RoutedEventArgs e)
        {
            ProgramarVuelos programarVuelos = new ProgramarVuelos();
            FrameVuelo.Content = programarVuelos;
            programarVuelos.btnProgramar.Visibility = Visibility.Visible;
        }



        void cargarDatos()
        {
            CN_Vuelos.CargarVuelosProgramados();
            GridVuelos.ItemsSource = CN_Vuelos.CargarVuelosProgramados().DefaultView;
        }
    }
}
