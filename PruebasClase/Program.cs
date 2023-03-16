using FigurasGeometricas; 
namespace PruebasClase
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Punto coordenada;
            Forma figura; 

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

        }
    }
}