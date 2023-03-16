using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigurasGeometricas
{
    public class Punto
    {
        private int _coordX; 
        private int _coordY;

        

        #region CONSTRUCTORES
        public Punto()
        {
            _coordX = 0;
            _coordY = 0;
        }

        public Punto(int x, int y)
        {
            X = x; 
            Y = y;
        }
        #endregion

        #region PROPIEDADES
        public int X
        {
            get { return _coordX;}
            set { _coordX = value; }
        }

        public int Y
        {
            get { return _coordY; }
            set { _coordY = value; }
        }

        #endregion

        #region METODOS

        public override string ToString()
        {
            return $"({X}, {Y})"; 
        }

        //public override bool Equals (object? obj)

        public bool Equals(Punto? obj)
        {
            bool igual;

            if(obj == null) throw new ArgumentNullException($"{obj} is null"); //de q vale aqui definir un tipo de excepcion

            igual = (this.X == obj.X) && (this.Y == obj.Y);

            return igual;
            //True: Si son iguales
            //False: Si no lo son
        }

        //public override bool Equals(object? obj)
        //{
        //    return this.Equals((Punto)obj);
        //}

        #endregion

    }
}



