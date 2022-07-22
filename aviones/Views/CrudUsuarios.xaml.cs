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
    /// Lógica de interacción para CrudUsuarios.xaml
    /// </summary>
    public partial class CrudUsuarios : Page
    {
        public CrudUsuarios()
        {
            InitializeComponent();
            CargarCb();
        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            Content = new Usuarios();
        }

        readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString);

        //cargar los privilegios -> vendedor administreador
        void CargarCb()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select NombrePrivilegio from Privilegios",con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                CbPrivilegios.Items.Add(reader["NombrePrivilegio"].ToString());
            }
            con.Close();
        }
        private void btnCrearUsuario_Click(object sender, RoutedEventArgs e)
        {
            if (tbNombre.Text==""||tbApellidos.Text==""||tbDui.Text==""||tbNit.Text==""||tbTelefono.Text==""||tbCorreo.Text==""||tbFchNacimiento.Text==""||CbPrivilegios.Text==""||tbUsuario.Text==""||tbContraseña.Text=="")
            {
                MessageBox.Show("Los campos no pueden quedar vacios todos deen ser rellenados apropiadamente");
            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select IdPrivilegios from Privilegios where NombrePrivilegio = '"+CbPrivilegios.Text+"'",con);
                object valor =cmd.ExecuteScalar();
                int privilegio = (int)valor;
                //incertar datos a la base de datos
                SqlCommand cmd2 = new SqlCommand("insert into Usuarios (Nombres, Apellidos, DUI, NIT, Correo, Telefono, Fecha_Nac, Privilegio, img, Usuario, Contrasenia) values(@Nombres, @Apellidos, @DUI, @NIT, @Correo, @Telefono, @Fecha_Nac, @Privilegio, @img, @Usuario, @Contrasenia)",con);
                cmd2.Parameters.Add("@Nombres",SqlDbType.VarChar).Value = tbNombre.Text;
                cmd2.Parameters.Add("@Apellidos",SqlDbType.VarChar).Value=tbApellidos.Text;
                cmd2.Parameters.Add("@DUI",SqlDbType.Int).Value= int.Parse(tbDui.Text);
                cmd2.Parameters.Add("@NIT",SqlDbType.Int).Value = int.Parse(tbNit.Text);
                cmd2.Parameters.Add("@Fecha_Nac", SqlDbType.Date).Value = tbFchNacimiento.Text;
                cmd2.Parameters.Add("@Telefono", SqlDbType.Int).Value = int.Parse(tbTelefono.Text);
                cmd2.Parameters.Add("@Correo", SqlDbType.VarChar).Value = tbCorreo.Text;
                cmd2.Parameters.Add("@Privilegio", SqlDbType.Int).Value = privilegio;
                cmd2.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = tbUsuario.Text;
                //me falto para la imagen uy contraseña no hay tiepo
               

            }
        }

        private void btnBorrarUsuario_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnModificarUsuario_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
