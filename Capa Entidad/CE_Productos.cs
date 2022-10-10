using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
    public class CE_Productos
    {
        private int _IdArticulo;
        private string _Nombre;
        private int _Grupo;
        private string _Codigo;
        private double _Precio;
        private bool _Activo;
        private double _Cantidad;
        private string _UnidadMedia;
        private byte[] _Img;
        private string _Descripcion;

        public int IdArticulo { get => _IdArticulo; set => _IdArticulo = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public int Grupo { get => _Grupo; set => _Grupo = value; }
        public string Codigo { get => _Codigo; set => _Codigo = value; }
        public double Precio { get => _Precio; set => _Precio = value; }
        public bool Activo { get => _Activo; set => _Activo = value; }
        public double Cantidad { get => _Cantidad; set => _Cantidad = value; }
        public string UnidadMedia { get => _UnidadMedia; set => _UnidadMedia = value; }
        public byte[] Img { get => _Img; set => _Img = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
    }
}
