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
            SqlCommand cmd= new SqlCommand("select IdUsuario,Nombres,Apellidos,Telefono, Correo, NombrePrivilegio from Usuarios inner join Privilegios on Usuarios.Privilegio=Privilegios.IdPrivilegios order by IdUsuario ASC", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGrid.ItemsSource = dt.DefaultView;
            con.Close();
        }
        private void btnCrearUsuario_Click(object sender, RoutedEventArgs e)
        {
            CrudUsuarios ventana = new CrudUsuarios();
            FrameUsuarios.Content= ventana;
            ventana.btnCrearUsuario.Visibility = Visibility.Visible;
        }

        private void btnConsultar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
