using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Capa_de_negocios;
using Capa_Entidad;
using Microsoft.Win32;

namespace Capa_Presentacion.Views
{
    /// <summary>
    /// Lógica de interacción para CrudProductos.xaml
    /// </summary>
    public partial class CrudProductos : Page
    {
        public int IdProducto;
        public string Praton = "PatronXD";
        CN_Grupos obj_CN_Grupos = new CN_Grupos();
        CN_Productos obj_CN_Productos = new CN_Productos();
        CE_Productos obj_CE_Productos = new CE_Productos();

        #region Inicial
        public CrudProductos()
        {
            InitializeComponent();
            Cargar();
        }
        #endregion

        #region Regresar
        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            Content = new Productos();
        }

        #endregion

        #region llenar grupos
        void Cargar()
        {
            List<string> grupos = obj_CN_Grupos.ListarGrupos();
            for(int i = 0; i < grupos.Count; i++)
            {
                cbGrupo.Items.Add(grupos[i]);
            }
        }
        #endregion

        #region validar campos
        public bool CamposLlenos()
        {
            if(tbNombre.Text == "" || tbCodigo.Text == "" || cbGrupo.Text == "" || tbPrecio.Text == "" || tbCantidad.Text == "" || tbUnidadMedida.Text=="" || tbDescripcion.Text == "")
            {
                return false;
            }
            return true;
        }
        #endregion

        #region CRUD

        #region Crear Producto
        private void btnCrearProducto_Click(object sender, RoutedEventArgs e)
        {
            if (CamposLlenos())
            {
                int idgrupo = obj_CN_Grupos.IdGrupo(cbGrupo.Text);

                obj_CE_Productos.Nombre = tbNombre.Text;
                obj_CE_Productos.Codigo = tbCodigo.Text;
                obj_CE_Productos.Precio = double.Parse(tbPrecio.Text);
                obj_CE_Productos.Cantidad = double.Parse(tbCantidad.Text);
                obj_CE_Productos.Activo = (bool)tbActivo.IsChecked;
                obj_CE_Productos.UnidadMedia = tbUnidadMedida.Text;
                obj_CE_Productos.Img = data;
                obj_CE_Productos.Descripcion = tbDescripcion.Text;
                obj_CE_Productos.Grupo = idgrupo;

                obj_CN_Productos.Insertar(obj_CE_Productos);

                Content=new Productos();
            }
            else
            {
                MessageBox.Show("los campos no pueden qedar vacios");
            }
        }
        #endregion

        #region Read
        public void Consultar()
        {
            var a = obj_CN_Productos.Consulta(IdProducto);
            tbNombre.Text = a.Nombre.ToString();
            tbCodigo.Text = a.Codigo.ToString();
            tbPrecio.Text = a.Precio.ToString();
            tbActivo.IsChecked = a.Activo;
            tbCantidad.Text = a.Cantidad.ToString();
            tbUnidadMedida.Text = a.UnidadMedia.ToString();
            ImageSourceConverter imgs = new ImageSourceConverter();
            imagen.Source = (ImageSource)imgs.ConvertFrom(a.Img);
            tbDescripcion.Text = a.Descripcion.ToString();

            var b = obj_CN_Grupos.Nombre(a.Grupo);
            cbGrupo.Text = b.Nombre;
        }
        #endregion

        #region Borrar producto
        private void btnBorrarProducto_Click(object sender, RoutedEventArgs e)
        {
            obj_CE_Productos.IdArticulo = IdProducto;
            obj_CN_Productos.Eliminar(obj_CE_Productos);
            Content = new Productos();
        }
        #endregion

        #region Actualizar Producto
        private void btnModificarProducto_Click(object sender, RoutedEventArgs e)
        {
            if (CamposLlenos())
            {
                int idgrupo = obj_CN_Grupos.IdGrupo(cbGrupo.Text);

                obj_CE_Productos.IdArticulo = IdProducto;
                obj_CE_Productos.Nombre = tbNombre.Text;
                obj_CE_Productos.Codigo = tbCodigo.Text;
                obj_CE_Productos.Precio = double.Parse(tbPrecio.Text);
                obj_CE_Productos.Cantidad = double.Parse(tbCantidad.Text);
                obj_CE_Productos.Activo = (bool)tbActivo.IsChecked;
                obj_CE_Productos.UnidadMedia = tbUnidadMedida.Text;
                obj_CE_Productos.Descripcion = tbDescripcion.Text;
                obj_CE_Productos.Grupo = idgrupo;

                obj_CN_Productos.ActualizarDatos(obj_CE_Productos);

                Content = new Productos();
            }
            else
            {
                MessageBox.Show("los campos no pueden qedar vacios");
            }

            if (imagensubida == true)
            {
                obj_CE_Productos.IdArticulo = IdProducto;
                obj_CE_Productos.Img = data;

                obj_CN_Productos.ActualizarIMG(obj_CE_Productos);

                Content=new Productos();
            }
        }
        #endregion

        #endregion

        #region Cambiar imagen
        byte[] data;
        private bool imagensubida = false;
        private void btnCanbiarImagen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog()==true)
            {
                FileStream fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read);
                data = new byte[fs.Length];
                fs.Read(data, 0, Convert.ToInt32(fs.Length));
                fs.Close();
                ImageSourceConverter imgs = new ImageSourceConverter();
                imagen.SetValue(Image.SourceProperty, imgs.ConvertFromString(ofd.FileName.ToString()));
            }
            imagensubida = true;
        }
        #endregion
    }
}
