using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
    public class CE_Grupos
    {
        private int _IdGrupos;
        private string _Nombre;

        public int IdGrupos { get => _IdGrupos; set => _IdGrupos = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
    }
}
