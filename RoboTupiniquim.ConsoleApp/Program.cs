using System.Globalization;

namespace RoboTupiniquim.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string entCoord;

            int[] coordArea = new int[2];

            int[] coordRoboI;
            string entradaCoordRoboI;
            char direcaoRoboI;
            int direcaoRoboINumero;

            int[] coordRoboII;
            string entradaCoordRoboII;
            char direcaoRoboII;
            int direcaoRoboIINumero;

            bool fecharApp = false;
            while (fecharApp == false)
            {
                Console.WriteLine("----------------------------------- Robô Tupiniquim I -----------------------------------");
                Console.WriteLine("Programa destinado para guiar e controlar os robôs tripulantes da Tupiniquim I por Marte.");
                Console.WriteLine("-----------------------------------------------------------------------------------------");
                Console.WriteLine("-----------------------------------------------------------------------------------------");
                Console.WriteLine("-----------------------------------------------------------------------------------------");
                Console.WriteLine("Segue as instrucoes para utilização dos robôs: ");
                Console.WriteLine("-----------------------------------------------------------------------------------------");
                Console.WriteLine("Digite a letra 'D' parao robô virar 90 graus à direita.");
                Console.WriteLine("Digite a letra 'E' parao robô virar 90 graus à esquerda.");
                Console.WriteLine("Digite a letra 'M' parao robô seguir em frente.");
                Console.WriteLine("-----------------------------------------------------------------------------------------");
                Console.WriteLine("-----------------------------------------------------------------------------------------");
                Console.WriteLine("-----------------------------------------------------------------------------------------");
                Console.WriteLine("Informe as intruções referente as coordenadas da área do robô: ");

                Console.Write("Digite os valores inteiros das coordenadas da área, separados por virgula (X, Y): ");
                entCoord = Console.ReadLine();
                string[] entCoordArray = entCoord.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                coordArea[0] = int.Parse(entCoordArray[0]);
                coordArea[1] = int.Parse(entCoordArray[1]);
            }




                //string[] coordenadas = Console.ReadLine().Split(" ");
                //double x = double.Parse(coordenadas[0],CultureInfo.InvariantCulture);
                //double y = double.Parse(coordenadas[1],CultureInfo.InvariantCulture);
                //
                //if ( x == 0 & y == 0)
                //{
                //    Console.WriteLine("Origem: ");
                //    Console.Read();
                //}
                //
                //else if (x != 0 & y == 0)
                //{
                //    Console.WriteLine("Eixo X");
                //    Console.Read();
                //}
                //
                //else if (x == 0 & y != 0)
                //{
                //    Console.WriteLine("Eixo Y");
                //    Console.Read();
                //}
                //
                //else if (x == 0 & y != 0)
                //{
                //    Console.WriteLine("Eixo Y");
                //    Console.Read();
                //}
                //
                //Console.WriteLine("Informe uma das opções: \n'N' = Norte\nS = Sul\nL = Leste\nO = Oeste");
                //Console.Read();
                //
                //
                //Console.WriteLine("Hello, World!");
        }
    }
}
