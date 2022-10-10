using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_de_datos;
using Capa_Entidad;
namespace Capa_de_negocios
{
    public class CN_Grupos
    {
        CD_Grupos cD_grupos = new CD_Grupos();
        CE_Grupos cE_grupos = new CE_Grupos();

        #region Listar grupos
        public List<string> ListarGrupos()
        {
            return cD_grupos.ListarGrupos();
        }
        #endregion

        #region Nonbre grupo
        public CE_Grupos Nombre(int IdGrupo)
        {
            return cD_grupos.Nombre(IdGrupo);
        }
        #endregion

        #region id Grupos
        public int IdGrupo(string nombre)
        {
            return cD_grupos.IdGrupo(nombre);
        }
        #endregion
    }
}
