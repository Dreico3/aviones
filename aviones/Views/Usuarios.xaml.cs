using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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

namespace aviones.Views
{
    /// <summary>
    /// Lógica de interacción para Usuarios.xaml
    /// </summary>
    public partial class Usuarios : UserControl
    {
        public Usuarios()
        {
            InitializeComponent();
            CargarDatos();
        }
        //aqui conectamos la base de datos con nuestra app
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString);
        void CargarDatos()
        {
            con.Open();
            //cmd = comando
            SqlCommand cmd = new SqlCommand("select IdUsuario,Nombres,Apellidos,Telefono, Correo, NombrePrivilegio from Usuarios inner join Privilegios on Usuarios.Privilegio=Privilegios.IdPrivilegios order by IdUsuario ASC", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGrid.ItemsSource = dt.DefaultView;
            con.Close();
        }
        private void btnCrearUsuario_Click(object sender, RoutedEventArgs e)
        {
            CrudUsuarios ventana = new CrudUsuarios();
            FrameUsuarios.Content = ventana;
            ventana.btnCrearUsuario.Visibility = Visibility.Visible;
        }

        private void btnConsultar_Click(object sender, RoutedEventArgs e)
        {
            int id = (int)((Button)sender).CommandParameter; 
            CrudUsuarios ventana=new CrudUsuarios();
            ventana.IdUsuario = id;
            ventana.Consultar();
            FrameUsuarios.Content= ventana;
            ventana.Titulo.Text = "Consultando Usuarios";
            ventana.tbNombre.IsEnabled = false;
            ventana.tbApellidos.IsEnabled = false;
            ventana.tbDui.IsEnabled = false;
            ventana.tbNit.IsEnabled = false;
            ventana.tbFchNacimiento.IsEnabled = false;
            ventana.tbCorreo.IsEnabled = false;
            ventana.tbTelefono.IsEnabled = false;
            ventana.CbPrivilegios.IsEnabled = false;
            ventana.tbUsuario.IsEnabled = false;
            ventana.tbContraseña.IsEnabled = false;
            ventana.btnCanbiarImagen.IsEnabled = false;
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            int id = (int)((Button)sender).CommandParameter;
            CrudUsuarios ventana = new CrudUsuarios();
            ventana.IdUsuario = id;
            ventana.Consultar();
            FrameUsuarios.Content = ventana;
            ventana.Titulo.Text = "Modificar Usuario";
            ventana.tbNombre.IsEnabled = true;
            ventana.tbApellidos.IsEnabled = true;
            ventana.tbDui.IsEnabled = true;
            ventana.tbNit.IsEnabled = true;
            ventana.tbFchNacimiento.IsEnabled = true;
            ventana.tbCorreo.IsEnabled = true;
            ventana.tbTelefono.IsEnabled = true;
            ventana.CbPrivilegios.IsEnabled = true;
            ventana.tbUsuario.IsEnabled = true;
            ventana.tbContraseña.IsEnabled = true;
            ventana.btnCanbiarImagen.IsEnabled = true;

            ventana.btnModificarUsuario.Visibility = Visibility.Visible;
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            int id = (int)((Button)sender).CommandParameter;
            CrudUsuarios ventana = new CrudUsuarios();
            ventana.IdUsuario = id;
            ventana.Consultar();
            FrameUsuarios.Content = ventana;
            ventana.Titulo.Text = "Eliminar Usuarios";
            ventana.tbNombre.IsEnabled = false;
            ventana.tbApellidos.IsEnabled = false;
            ventana.tbDui.IsEnabled = false;
            ventana.tbNit.IsEnabled = false;
            ventana.tbFchNacimiento.IsEnabled = false;
            ventana.tbCorreo.IsEnabled = false;
            ventana.tbTelefono.IsEnabled = false;
            ventana.CbPrivilegios.IsEnabled = false;
            ventana.tbUsuario.IsEnabled = false;
            ventana.tbContraseña.IsEnabled = false;
            ventana.btnCanbiarImagen.IsEnabled = false;

            ventana.btnBorrarUsuario.Visibility = Visibility.Visible;
        }
    }
}
