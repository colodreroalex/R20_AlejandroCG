using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigurasGeometricas
{
    //NEW --> PROPAGACION DE EXCEPCIONES : Propiedad LADO MAYOR Y METODO ComprobarLados
    public class InvalidValueLadosException : Exception
    {
        public InvalidValueLadosException() 
        {

        }

        public InvalidValueLadosException(string mensaje) : base(mensaje)
        {
            
        }
    }


    public class InvalidLadoException : Exception
    {
        public InvalidLadoException()
        {

        }

        public InvalidLadoException(string mensaje) : base (mensaje)
        {

        }
    }

    //public class InvalidMedidaException : Exception
    //{
    //    public InvalidMedidaException()
    //    {

    //    }

    //    public InvalidMedidaException(string mensaje) : base()
    //    {

    //    }

    //}

    public class InvalidEscalaException : Exception
    {
        public InvalidEscalaException()
        {

        }

        public InvalidEscalaException(string msg) : base (msg)
        {

        }

    }




    public class Rectangulo : Forma
    {
        //CONSTANTES
        private const float MEDIDA_MIN = 0f; 

        private float _ladoMenor;  
        private float _ladoMayor;

        #region CONSTRUCTORES
        
        public Rectangulo() : base() 
        {
            //Inicializacion de datos erroneos
            _ladoMenor = MEDIDA_MIN;
            _ladoMayor = MEDIDA_MIN;
        }


        public Rectangulo(string nombre, string color, Punto coordenada) : base (nombre, color, coordenada) 
        {
            //Inicializacion de datos erroneos
            _ladoMenor = MEDIDA_MIN;
            _ladoMayor = MEDIDA_MIN;
        }

        public Rectangulo(string name, string color , Punto coord, float tamMenor, float tamMayor) : this(name, color , coord)
        {
            LadoMayor = tamMayor;
            LadoMenor = tamMenor;
        }

        #endregion

        #region PROPIEDADES

        //Propiedad OPCIONAL para proteger metodos especificos

        public float CalculoArea
        {
            get { return CalcularArea(); }
        }

        public float CalculoSuperficie
        {
            get { return CalcularPerimetro(); }
        }

        public float Area   //Propiedad de solor lectura en vez de usar METODO para calcular el area . Asi no se sabra que es lo que hace esta propiedad = mas proteccion
        {
            get { return LadoMayor * LadoMenor; }
        } 

        public float LadoMenor
        {
            get 
            {
                if (_ladoMenor == MEDIDA_MIN) throw new InvalidLadoException("ERROR: Lado menor no establecido");
                //Devolucion
                return _ladoMenor; 
            }
            set 
            {
                try
                {
                    ComprobarLados(value);
                }
                catch (InvalidValueLadosException errMenor)
                {
                    throw new InvalidValueLadosException("ERROR: Medida Lado menor incorrecto");
                }

                //Asignacion
                _ladoMenor = value;
            }
        }

        public float LadoMayor
        {
            get 
            {
                if (_ladoMayor == MEDIDA_MIN) throw new InvalidLadoException("ERROR: Lado mayor no establecido");
                //Devolucion
                return _ladoMayor;
            }
            set
            {
                //Relanzar la excepcion con mensaje especifico para el lado mayor
                try
                    //captura la excepcion dentro del metodo y lanza otra personalizada
                {
                    ComprobarLados(value);
                }
                catch(InvalidValueLadosException medidaErr)
                {
                    throw new InvalidValueLadosException("Medida del lado mayor incorrecta");
                }
                finally
                {
                    
                }
                

                //Asignacion
                _ladoMayor = value;
            }
        }



        #endregion

        #region METODOS
        //PRIVADOS

        //NEW --> PROPAGACION DE EXCEPCIONES : Propiedad LADO MAYOR Y METODO ComprobarLados
        private void ComprobarLados(float valor)
        {
            if (valor == 0 || valor < 0) throw new InvalidValueLadosException("ERROR: Medida del lado incorrecta(Ni negativos ni 0)"); 
        }


        public float CalcularArea()
        {
            float area = 0f;

            area = LadoMenor * LadoMayor;

            return area;
        }

        public float CalcularPerimetro()
        {
            float perimetro = 0;

            perimetro = (2 * LadoMenor) + (2 * LadoMayor);

            return perimetro;
        }

        //PUBLICOS
        public override string ToString()
        {
            string cadena;

            cadena = $"\tRECTANGULO: \n";
            cadena += base.ToString();
            cadena += $"\nLados: Mayor--> ({LadoMayor}), Menor-->({LadoMenor}), Area --> ({Area})";
            
            return cadena;
        }

        //publico --> ya que deseamos cambiar el tamaño de la figura
        public void CambiarTamanoRec(float factorEscala)
        {
            if (factorEscala <= MEDIDA_MIN) throw new InvalidEscalaException("ERROR: El valor de la escala introducido no puede ser negativo");

            LadoMenor = (LadoMenor * factorEscala);
            LadoMayor = (LadoMayor * factorEscala); 
        }

        #endregion
    }
}
