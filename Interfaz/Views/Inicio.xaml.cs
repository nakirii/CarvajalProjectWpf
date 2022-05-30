using CapaNegocio;
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

namespace Interfaz.Views
{
    /// <summary>
    /// Lógica de interacción para Inicio.xaml
    /// </summary>
    public partial class Inicio : UserControl
    {
        private readonly CN_Vuelos CN_Vuelos = new CN_Vuelos();
        
        public Inicio()
        {
            InitializeComponent();
            cargarDatos();
        }

        private void ConsultarVuelo(object sender, RoutedEventArgs e)
        {
            
            string id = (string)((Button)sender).CommandParameter;
            ProgramarVuelos programarVuelos = new ProgramarVuelos();
            programarVuelos.Consultar(id);
            programarVuelos.vista = true;
            programarVuelos.Titulo.Text = "Detalle de Vuelo";
            FrameInicioVuelo.Content = programarVuelos;
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

        void cargarDatos()
        {
            CN_Vuelos.CargarVuelosProgramados();
            GridVuelos.ItemsSource = CN_Vuelos.CargarVuelosProgramados().DefaultView;
        }
    }
}
