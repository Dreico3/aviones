using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Capa_de_datos;
using Capa_Entidad;

namespace Capa_de_negocios
{
    public class CN_Productos
    {
        readonly CD_Productos objProductos = new CD_Productos();

        #region Buscar
        public DataTable BuscarProducto(string buscar)
        {
            return objProductos.Buscar(buscar);
        }
        #endregion

        #region CRUD

        #region Consultar
        public CE_Productos Consulta(int IdArticulo)
        {
            return objProductos.Consulta(IdArticulo);
        }
        #endregion

        #region Insertar
        public void Insertar(CE_Productos productos)
        {
            objProductos.CD_Insertar(productos);
        }
        #endregion

        #region Eliminar
        public void Eliminar(CE_Productos cE_producctos)
        {
            objProductos.CD_Eliminar(cE_producctos);
        }
        #endregion

        #region Actualizar Datos
        public void ActualizarDatos(CE_Productos productos)
        {
            objProductos.CD_Actualizar(productos);
        }
        #endregion

        #region Actualizar IMG
        public void ActualizarIMG(CE_Productos productos)
        {
            objProductos.CD_ActualizarIMG(productos);
        }
        #endregion

        #endregion
    }
}
