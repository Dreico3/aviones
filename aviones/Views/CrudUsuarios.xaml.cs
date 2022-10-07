using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
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
using Capa_Entidad;
using Capa_de_negocios;

namespace aviones.Views
{
    /// <summary>
    /// Lógica de interacción para CrudUsuarios.xaml
    /// </summary>
    public partial class CrudUsuarios : Page
    {
        readonly CN_Usuarios objeto_CN_Usuario = new CN_Usuarios();
        readonly CE_Usuarios objeto_CE_Usuario = new CE_Usuarios();
        readonly CN_Privilegios objeto_CN_Privilegios = new CN_Privilegios();
        #region Inicial
        public CrudUsuarios()
        {
            InitializeComponent();
            CargarCb();
        }
        #endregion
        #region Regresar
        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            Content = new Usuarios();
        }
        #endregion
        //esta linea de abajo es una coneccion directa a la base de datos no recomendable
        //-->readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString);
        #region Cargar Privilegios
        void CargarCb()
        {
            #region Cargar comboBox de forma directa (No Recomendable)
            //con.Open();
            //SqlCommand cmd = new SqlCommand("select NombrePrivilegio from Privilegios", con);
            //SqlDataReader reader = cmd.ExecuteReader();
            //while (reader.Read())
            //{
            //    CbPrivilegios.Items.Add(reader["NombrePrivilegio"].ToString());
            //}
            //con.Close();
            #endregion
            List<string> privilegios = objeto_CN_Privilegios.ListarPrivilegios();
            for(int i = 0; i < privilegios.Count; i++)
            {
                CbPrivilegios.Items.Add(privilegios[i]);
            }
        }
        #endregion
        #region validar campos vacios
        public bool CamposLlenos()
        {
            if (tbNombre.Text == "" || tbApellidos.Text == "" || tbDui.Text == "" || tbNit.Text == "" || tbTelefono.Text == "" || tbCorreo.Text == "" || tbFchNacimiento.Text == "" || CbPrivilegios.Text == "" || tbUsuario.Text == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion
        #region CRUD (Crear ,leer ,actualizar ,borrar usuario)
        public int IdUsuario;
        public string patron = "patronXD";
        #region Create
        private void btnCrearUsuario_Click(object sender, RoutedEventArgs e)
        {
            #region boton de crear de forma directa (no recomendable)
            //TODO lo que esta comentado sirve para la coneccion directa
            //if (tbNombre.Text == "" || tbApellidos.Text == "" || tbDui.Text == "" || tbNit.Text == "" || tbTelefono.Text == "" || tbCorreo.Text == "" || tbFchNacimiento.Text == "" || CbPrivilegios.Text == "" || tbUsuario.Text == "" || tbContraseña.Text == "")
            //{
            //    MessageBox.Show("Los campos no pueden quedar vacios todos deen ser rellenados apropiadamente");
            //}
            //else
            //{
            //    con.Open();
            //    SqlCommand cmd = new SqlCommand("select IdPrivilegios from Privilegios where NombrePrivilegio = '" + CbPrivilegios.Text + "'", con);
            //    object valor = cmd.ExecuteScalar();
            //    int privilegio = (int)valor;
            //    //este patron sirve para encriptar la contraseña

            //    //, @img, @Usuario, (EncryptByPassPhrase('" + patron + "','" + tbContraseña.Text + "'
            //    //, img, Usuario, Contrasenia
            //    string patron = "patronXD";
            //    if (imagensubida)
            //    {
            //        //incertar datos a la base de datos
            //        SqlCommand cmd2 = new SqlCommand("insert into Usuarios (Nombres, Apellidos, DUI, NIT, Correo, Telefono, Fecha_Nac, Privilegio,img, Usuario, Contrasenia) values(@Nombres, @Apellidos, @DUI, @NIT, @Correo, @Telefono, @Fecha_Nac, @Privilegio,@img, @Usuario,(EncryptByPassPhrase('" + patron + "','" + tbContraseña.Text + "')))", con);
            //        cmd2.Parameters.Add("@Nombres", SqlDbType.VarChar).Value = tbNombre.Text;
            //        cmd2.Parameters.Add("@Apellidos", SqlDbType.VarChar).Value = tbApellidos.Text;
            //        cmd2.Parameters.Add("@DUI", SqlDbType.Int).Value = int.Parse(tbDui.Text);
            //        cmd2.Parameters.Add("@NIT", SqlDbType.Int).Value = int.Parse(tbNit.Text);
            //        cmd2.Parameters.Add("@Fecha_Nac", SqlDbType.Date).Value = tbFchNacimiento.Text;
            //        cmd2.Parameters.Add("@Telefono", SqlDbType.Int).Value = int.Parse(tbTelefono.Text);
            //        cmd2.Parameters.Add("@Correo", SqlDbType.VarChar).Value = tbCorreo.Text;
            //        cmd2.Parameters.Add("@Privilegio", SqlDbType.Int).Value = privilegio;
            //        cmd2.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = tbUsuario.Text;
            //        cmd2.Parameters.AddWithValue("@img", SqlDbType.VarBinary).Value = data;

            //        //ejecutamos el query 
            //        cmd2.ExecuteNonQuery();
            //        Content = new Usuarios();
            //    }
            //    else
            //    {
            //        MessageBox.Show("tiene que agregar una imagen para poder crear un usuario");
            //    }
            //    con.Close();
            //}
            #endregion

            if (CamposLlenos() && tbContraseña.Text != "")
            {
                int privilegio = objeto_CN_Privilegios.IdPrivilegio(CbPrivilegios.Text);

                objeto_CE_Usuario.Nombres = tbNombre.Text;
                objeto_CE_Usuario.Apellidos = tbApellidos.Text;
                objeto_CE_Usuario.DUI = int.Parse(tbDui.Text);
                objeto_CE_Usuario.NIT = int.Parse(tbNit.Text);
                objeto_CE_Usuario.Correo = tbCorreo.Text;
                objeto_CE_Usuario.Telefono = int.Parse(tbTelefono.Text);
                objeto_CE_Usuario.Fecha_Nac = DateTime.Parse(tbFchNacimiento.Text);
                objeto_CE_Usuario.Privilegio = privilegio;
                objeto_CE_Usuario.Img = data;
                objeto_CE_Usuario.Usuario = tbUsuario.Text;
                objeto_CE_Usuario.Contrasenia = tbContraseña.Text;
                objeto_CE_Usuario.Patron = patron;

                objeto_CN_Usuario.Insertar(objeto_CE_Usuario);
                
                Content=new Usuarios();
            }
            else
            {
                MessageBox.Show("Los campos no pueden quedar vacios¡¡");
            }

        }
        #endregion
        #region Read
        public void Consultar()
        {
            #region Consultar de forrma directa (no recomendable)
            //con.Open();
            //SqlCommand com = new SqlCommand("select * from Usuarios inner join Privilegios on Usuarios.Privilegio = Privilegios.IdPrivilegios where IdUsuario=" + IdUsuario, con);
            //SqlDataReader reader = com.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            //reader.Read();
            //this.tbNombre.Text = reader["Nombres"].ToString();
            //this.tbApellidos.Text = reader["Apellidos"].ToString();
            //this.tbDui.Text = reader["DUI"].ToString();
            //this.tbNit.Text = reader["NIT"].ToString();
            //this.tbFchNacimiento.Text = reader["Fecha_Nac"].ToString();
            //this.tbTelefono.Text = reader["telefono"].ToString();
            //this.tbCorreo.Text = reader["Correo"].ToString();
            //this.CbPrivilegios.SelectedItem = reader["NombrePrivilegio"];
            //this.tbUsuario.Text = reader["Usuario"].ToString();
            //MessageBox.Show(reader["Fecha_Nac"].ToString());
            //reader.Close();

            ////obteniendo la imagen de la base de datos
            //DataSet ds = new DataSet();
            //SqlDataAdapter adapter = new SqlDataAdapter("select img from Usuarios where IdUsuario=" + IdUsuario, con);
            //adapter.Fill(ds);
            //byte[] data = (byte[])ds.Tables[0].Rows[0][0];
            //MemoryStream strm = new MemoryStream();
            //strm.Write(data, 0, data.Length);
            //strm.Position = 0;
            //System.Drawing.Image img = System.Drawing.Image.FromStream(strm);
            //BitmapImage b1 = new BitmapImage();
            //b1.BeginInit();
            //MemoryStream ms = new MemoryStream();
            //img.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            //ms.Seek(0, SeekOrigin.Begin);
            //b1.StreamSource = ms;
            //b1.EndInit();
            //imagen.Source = b1;

            //con.Close();
            #endregion
            var a = objeto_CN_Usuario.Consulta(IdUsuario);
            tbNombre.Text = a.Nombres.ToString();
            tbApellidos.Text = a.Apellidos.ToString();
            tbDui.Text = a.DUI.ToString();
            tbNit.Text = a.NIT.ToString();
            tbCorreo.Text = a.Correo.ToString();
            tbTelefono.Text = a.Telefono.ToString();
            tbFchNacimiento.Text = a.Fecha_Nac.ToString();

            var b = objeto_CN_Privilegios.NombrePrivilegio(a.Privilegio);
            CbPrivilegios.Text = b.NombrePrivilegio;

            ImageSourceConverter imgs=new ImageSourceConverter();
            imagen.Source = (ImageSource)imgs.ConvertFrom(a.Img);
            tbUsuario.Text = a.Usuario.ToString();
        }
        #endregion
        #region Delete
        private void btnBorrarUsuario_Click(object sender, RoutedEventArgs e)
        {
            #region Eliminar de forma directa (No recomendable)
            //con.Open();
            //SqlCommand cmd =new SqlCommand("Delete from Usuarios where IdUsuario="+IdUsuario,con);
            //cmd.ExecuteNonQuery(); 
            //con.Close();
            //Content = new Usuarios();
            #endregion
            objeto_CE_Usuario.IdUsuario = IdUsuario;

            objeto_CN_Usuario.Eliminar(objeto_CE_Usuario);

            Content = new Usuarios();
        }
        #endregion
        #region Update
        private void btnModificarUsuario_Click(object sender, RoutedEventArgs e)
        {
            #region Actualizar datos de forma directa (No recomendable)
            //con.Open();
            //SqlCommand com = new SqlCommand("select IdPrivilegios from Privilegios where NombrePrivilegio='" + CbPrivilegios.Text + "'", con);
            //object valor = com.ExecuteScalar();
            //int privilegio = (int)valor;
            //string patron = "patronXD";
            //if (tbNombre.Text == "" || tbApellidos.Text == "" || tbDui.Text == "" || tbNit.Text == "" || tbTelefono.Text == "" || tbCorreo.Text == "" || tbFchNacimiento.Text == "" || CbPrivilegios.Text == "" || tbUsuario.Text == "")
            //{
            //    MessageBox.Show("Los campos no pueden quedar vacios todos deen ser rellenados apropiadamente");
            //}
            //else
            //{
            //    try
            //    {

            //    SqlCommand cmd = new SqlCommand("update Usuarios set Nombres='" + tbNombre.Text + "',Apellidos='" + tbApellidos.Text + "',DUI=" + int.Parse(tbDui.Text) + ",NIT=" + float.Parse(tbNit.Text) + ",Fecha_Nac='" + tbFchNacimiento.Text + "',telefono=" + int.Parse(tbTelefono.Text) + ",Correo='" + tbCorreo.Text + "',Privilegio=" + privilegio + ",Usuario='" + tbUsuario.Text + "' where IdUsuario="+IdUsuario, con);
            //    cmd.ExecuteNonQuery();
            //    if (imagensubida)
            //    {
            //        SqlCommand img = new SqlCommand("update Usuarios set img=@img where IdUsuario='" + IdUsuario + "'", con);
            //        img.Parameters.AddWithValue("@img", SqlDbType.VarBinary).Value = data;
            //        img.ExecuteNonQuery();
            //    }
            //    }
            //    catch (Exception err)
            //    {

            //        MessageBox.Show(err.Message);
            //    }

            //}
            //if (tbContraseña.Text != "")
            //{
            //    SqlCommand cmd = new SqlCommand("update Usuarios set Contrasenia=(EncryptByPassPhrase('" + patron + "','" + tbContraseña.Text + "')) where IdUsuario='"+IdUsuario+"'", con);
            //    cmd.ExecuteNonQuery();
            //}
            //con.Close();
            //Content = new Usuarios();
            #endregion
            if (CamposLlenos())
            {
                int privilegio = objeto_CN_Privilegios.IdPrivilegio(CbPrivilegios.Text);

                objeto_CE_Usuario.IdUsuario = IdUsuario;
                objeto_CE_Usuario.Nombres = tbNombre.Text;
                objeto_CE_Usuario.Apellidos = tbApellidos.Text;
                objeto_CE_Usuario.DUI = int.Parse(tbDui.Text);
                objeto_CE_Usuario.NIT = int.Parse(tbNit.Text);
                objeto_CE_Usuario.Correo = tbCorreo.Text;
                objeto_CE_Usuario.Telefono = int.Parse(tbTelefono.Text);
                objeto_CE_Usuario.Fecha_Nac = DateTime.Parse(tbFchNacimiento.Text);
                objeto_CE_Usuario.Privilegio = privilegio;
                objeto_CE_Usuario.Usuario = tbUsuario.Text;

                objeto_CN_Usuario.ActualizarDatos(objeto_CE_Usuario);

                Content = new Usuarios();
            }
            else
            {
                MessageBox.Show("los campos no pueden quedar vacios..!!");
            }
            if (tbContraseña.Text != "")
            {
                objeto_CE_Usuario.IdUsuario = IdUsuario;
                objeto_CE_Usuario.Contrasenia = tbContraseña.Text;
                objeto_CE_Usuario.Patron = patron;

                objeto_CN_Usuario.ActualizarPass(objeto_CE_Usuario);
                Content=new Usuarios();
            }
            if (imagensubida)
            {
                objeto_CE_Usuario.IdUsuario = IdUsuario;
                objeto_CE_Usuario.Img = data;

                objeto_CN_Usuario.ActualizarIMG(objeto_CE_Usuario);
                Content = new Usuarios();
            }
        }
        #endregion

        #endregion

        //tomar en cuenta este byte es para poder almacenar la imagen
        byte[] data;
        private bool imagensubida = false;
        private void btnCanbiarImagen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == true)
            {
                FileStream fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read);
                data = new byte[fs.Length];
                fs.Read(data, 0, System.Convert.ToInt32(fs.Length));
                fs.Close();
                ImageSourceConverter imgs = new ImageSourceConverter();
                imagen.SetValue(Image.SourceProperty, imgs.ConvertFromString(ofd.FileName.ToString()));
            }
            imagensubida = true;
        }
    }
}
