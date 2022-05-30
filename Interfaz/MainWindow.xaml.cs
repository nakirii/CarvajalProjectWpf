using Interfaz.Views;
using System.Windows;
using System.Windows.Input;

namespace Interfaz
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new Inicio();
            if (Properties.Settings.Default.TipoUsuario!=1)
            {
                lvProgramar.Visibility = Visibility.Hidden;
                lvUsuario.Visibility = Visibility.Hidden;
                
            }
        }

        private void TBShow(object sender, RoutedEventArgs e)
        {
            GrindContent.Opacity = 0.5;
        }

        private void TBHide(object sender, RoutedEventArgs e)
        {
            GrindContent.Opacity = 1;
        }

        private void PrewiewMouseLeftDawnBG(object sender, MouseButtonEventArgs e)
        {
            BtnShowHide.IsChecked = false;
        }

        private void Minimizar(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Cerrar(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void Usuarios_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new Usuarios();
        }

        private void Programar_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new Vuelos();
        }

        private void Incio_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new Inicio();
        }

       

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
    }
}
