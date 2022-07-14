using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aviones
{
    internal class Avion
    {
        private string nombre;
        private string modelo;
        private float pesomax;
        private Persona[] tripulacion;
        
        public Avion()
        {
            nombre = "aqui va el nombre del avion";
            modelo = "aqui va el modelo del avion";
            pesomax = 35.3f;
            tripulacion = new Persona[6];
        }
        
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
    }
}
