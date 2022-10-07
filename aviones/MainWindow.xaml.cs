using aviones.Views;
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

namespace aviones
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TBshow(object sender, RoutedEventArgs e)
        {
            GridContend.Opacity = 0.5;
        }

        private void TBhide(object sender, RoutedEventArgs e)
        {
            GridContend.Opacity = 1;
        }

        private void previewMouselef(object sender, MouseButtonEventArgs e)
        {
            BtnShowHide.IsChecked = false;
        }

        private void btnMinimizar_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnUsuarios(object sender, RoutedEventArgs e)
        {
            DataContext = new Usuarios();
            //MessageBox.Show("hola torola");
        }

        //esta funcion esparapoder mover la ventana de la aplicacion
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}
