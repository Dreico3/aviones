using System.Windows;
using System.Windows.Controls;
using Capa_de_negocios;

namespace Capa_Presentacion.Views
{

    public partial class Productos : UserControl
    {
        #region Inicio
        public Productos()
        {
            InitializeComponent();
            Buscar("");
        }
        #endregion

        readonly CN_Productos obj_CN_Productos = new CN_Productos();
        #region Buscar

        public void Buscar(string buscar)
        {
            dataGrid.ItemsSource = obj_CN_Productos.BuscarProducto(buscar).DefaultView;
        }
        #endregion

        #region Buscando
        private void Buscando(object sender, TextChangedEventArgs e)
        {
            Buscar(tbBuscar.Text);
        }

        #endregion

        #region CRUD

        #region Crear producto

        private void btnCrearProducto_Click(object sender, RoutedEventArgs e)
        {
            CrudProductos ventana =new CrudProductos();
            FrameProductos.Content = ventana;
            ventana.btnCrearProducto.Visibility = Visibility.Visible;
        }

        #endregion

        #region Read
        private void btnConsultar_Click(object sender, RoutedEventArgs e)
        {
            int id = (int)((Button)sender).CommandParameter;
            CrudProductos ventana = new CrudProductos();
            FrameProductos.Content = ventana;
            //gridProductos.Visibility = Visibility.Hidden;
            ventana.IdProducto = id;
            ventana.Consultar();
            ventana.Titulo.Text = "Consulta de productos";
            ventana.tbNombre.IsEnabled = false;
            ventana.tbCodigo.IsEnabled = false;
            ventana.tbCantidad.IsEnabled = false;
            ventana.tbActivo.IsEnabled = false;
            ventana.tbPrecio.IsEnabled = false;
            ventana.cbGrupo.IsEnabled = false;
            ventana.tbUnidadMedida.IsEnabled = false;
            ventana.tbDescripcion.IsEnabled = false;
            ventana.btnCanbiarImagen.IsEnabled = false;
        }
        #endregion

        #region update
        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {

            int id = (int)((Button)sender).CommandParameter;
            CrudProductos ventana = new CrudProductos();
            FrameProductos.Content = ventana;
            //gridProductos.Visibility = Visibility.Hidden;
            ventana.IdProducto = id;
            ventana.Consultar();
            ventana.Titulo.Text = "Actualizar de productos";
            ventana.tbNombre.IsEnabled = true;
            ventana.tbCodigo.IsEnabled = true;
            ventana.tbCantidad.IsEnabled = true;
            ventana.tbActivo.IsEnabled = true;
            ventana.tbPrecio.IsEnabled = true;
            ventana.cbGrupo.IsEnabled = true;
            ventana.tbUnidadMedida.IsEnabled = true;
            ventana.tbDescripcion.IsEnabled = true;
            ventana.btnCanbiarImagen.IsEnabled = true;

            ventana.btnModificarProducto.Visibility = Visibility.Visible;
        }
        #endregion

        #region Delete
        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {

            int id = (int)((Button)sender).CommandParameter;
            CrudProductos ventana = new CrudProductos();
            FrameProductos.Content = ventana;
           //gridProductos.Visibility = Visibility.Hidden;
            ventana.IdProducto = id;
            ventana.Consultar();
            ventana.Titulo.Text = "Eliminar de productos";
            ventana.tbNombre.IsEnabled = false;
            ventana.tbCodigo.IsEnabled = false;
            ventana.tbCantidad.IsEnabled = false;
            ventana.tbActivo.IsEnabled = false;
            ventana.tbPrecio.IsEnabled = false;
            ventana.cbGrupo.IsEnabled = false;
            ventana.tbUnidadMedida.IsEnabled = false;
            ventana.tbDescripcion.IsEnabled = false;
            ventana.btnCanbiarImagen.IsEnabled = false;

            ventana.btnBorrarProducto.Visibility = Visibility.Visible;
        }
        #endregion
        #endregion
    }
}
