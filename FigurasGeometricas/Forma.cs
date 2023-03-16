using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;

namespace FigurasGeometricas
{
    //EXCEPCIONES PERSONALIZADAS
    #region Excepcion para el nombre
    public class NombreException : Exception
        //Derivara de la clase : "EXCEPTION"
    {
        public NombreException() //Constructor por defecto
        {
            
        }

        public NombreException(string message) : base(message)  
                                //Mensaje que le pase : Llama a la clase base(EXCEPTION) para asignarle el mensaje q le pase
        {

        }
    }
    #endregion

    #region Excepcion para el color
    public class ColorException : Exception
    {
        public ColorException() //Constructor por defecto
        {

        }

        public ColorException(string mensaje) : base(mensaje)
        //Mensaje que le pase : Llama a la clase base(EXCEPTION) para asignarle el mensaje q le pase
        {

        }
    }
    #endregion

    #region Excepcion para el Punto
    public class MoverPuntoException: Exception
    {
        public MoverPuntoException()
        {

        }

        public MoverPuntoException(string msg) : base(msg)
        {

        }
    }
    #endregion


    public class Forma
    {

        private string _color; 
        private string _name;
        private Punto _coordCentro;
        //Composicion : Yo tengo/creo una clase , dentro de otra clase , genero un miembro de la clase generada anteriormente.

        #region CONSTRUCTORES
        public Forma()
        {
            _color = "Unknow"; 
            _name = "Unknow";
            _coordCentro = new Punto();
        }

        public Forma(string nombre, string color, Punto coordenada) : this()    //this(): Hace referencia al 1er constructor para coger los valores por defecto
        {
            Nombre = nombre;
            Color = color;
            //Al no tener "SET" y ser de solo lectura , establezco un metodo que haga como la funcion del "SET"
            MoverCentro(coordenada);
        }

        

        #endregion

        #region PROPIEDADES

        public string Nombre 
        {
            get { return _name;  }
            set
            {                                           //Excepcion Personalizada
                if (String.IsNullOrEmpty(value)) throw new NombreException("El nombre no puede ser nulo o la cadena vacia");

                //Asignacion --> Quitando Espacios en blanco y convirtiendo a MAYUS
                _name = value.Trim().ToUpper(); 
            }
        }

        public string Color
        {
            get { return _color; }
            set
            {                                          //Excepcion Personalizada
                if (String.IsNullOrEmpty(value)) throw new ColorException("El color no puede ser nulo o la cadena vacia");
                
                //Asignacion --> Quitando Espacios en blanco y convirtiendo a MAYUS
                _color = value.Trim().ToUpper();
            }
        }


        //Propiedad 
        public Punto Centro
        {
            get { return _coordCentro; }
        }

        #endregion

        #region METODOS
        //PRIVADOS

        //PUBLICOS
        public void MoverCentro(Punto coordenada)
        {
            if (coordenada == null) throw new MoverPuntoException("Coordenada no establecida");

            _coordCentro = coordenada; 
        }

        public override string ToString()
        {
            string salida;

            salida = "FORMA: \n";
            salida += $"Nombre: {Nombre}\n";
            salida += $"Color: {Color}\n";
            salida += $"Posicion: {Centro}";


            return salida; 
        }

        #endregion
    }
}