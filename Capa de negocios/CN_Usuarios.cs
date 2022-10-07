using System.Data;
using Capa_de_datos;
using Capa_Entidad;
namespace Capa_de_negocios
{
    public class CN_Usuarios
    {
        private readonly CD_Usuarios objDatos = new CD_Usuarios();
        //CRUD usuarios
        #region Consultar
        public CE_Usuarios Consulta(int IdUsuario)
        {
            return objDatos.CD_Consulta(IdUsuario);
        }
        #endregion

        #region Insertar
        public void Insertar(CE_Usuarios Usuarios)
        {
            objDatos.CD_Insertar(Usuarios);
        }
        #endregion

        #region Eliminar
        public void Eliminar(CE_Usuarios Usuarios)
        {
            objDatos.CD_ELiminar(Usuarios);
        }
        #endregion

        #region Actualizar datos
        public void ActualizarDatos(CE_Usuarios Usuarios)
        {
            objDatos.CD_ActualizarDatos(Usuarios);
        }
        #endregion

        #region Actualizar Pass
        public void ActualizarPass(CE_Usuarios Usuarios)
        {
            objDatos.CD_ActualizarPass(Usuarios);
        }
        #endregion

        #region Actualizar Imagen
        public void ActualizarIMG(CE_Usuarios Usuarios)
        {
            objDatos.CD_ActualizarIMG(Usuarios);
        }
        #endregion

        //Vista Usuarios
        #region cargar Usuarios
        public DataTable CargarUsuarios()
        {
            return objDatos.CargarUsuarios();
        }
        #endregion
    }
}
