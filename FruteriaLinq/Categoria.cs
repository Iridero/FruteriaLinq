using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruteriaLinq
{
    public class Categoria
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        private bool eliminada;

        public bool Eliminada
        {
            get { return eliminada; }
            set { eliminada = value; }
        }

    }
}
