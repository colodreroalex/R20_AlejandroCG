using FigurasGeometricas;
using System.Drawing;

namespace PruebasClase
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Punto coordenada;
            Forma figura;
            Rectangulo rectangulo1; 

            //PRUEBAS CLASE PUNTO
            coordenada = new Punto();
            Console.WriteLine(coordenada);

            coordenada = new Punto(10, 20); 
            Console.WriteLine(coordenada.ToString()); //Se puede poner de forma explicita que no variara en nada(toString)

            coordenada.X = 100;
            coordenada.Y = -100; 
            Console.WriteLine(coordenada);

            Console.WriteLine("");





            //PRUEBAS CLASE FORMA
            figura = new Forma();
            Console.WriteLine(figura);


            //PRUEBAS CLASE RECTANGULO

            //Console.WriteLine("");
            //Console.WriteLine("CONSTRUCTOR POR DEFECTO");
            //rectangulo1 = new Rectangulo();
            //Console.WriteLine(rectangulo1);

            Console.WriteLine("\nCONSTRUCTOR 2");
            rectangulo1 = new Rectangulo("Rectangulo del angulo", "Rojo", new Punto(), 8, 9);
            Console.WriteLine(rectangulo1);

            Console.WriteLine("\nESTABLECER VALORES");
            rectangulo1 = new Rectangulo();
            rectangulo1.LadoMenor = 15;
            rectangulo1.LadoMayor = 20;
            Console.WriteLine(rectangulo1);

            Console.WriteLine("\nCAMBIO TAMAÑO");
            rectangulo1.CambiarTamanoRec(0.5f);
            Console.WriteLine(rectangulo1);



        }
    }
}