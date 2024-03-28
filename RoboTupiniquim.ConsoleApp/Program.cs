using System.Globalization;

namespace RoboTupiniquim.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string entradaCoordenadas;

            int[] coordenadasArea = new int[2];

            int[] coordenadasRoboI = new int[2];
            string entradaCoordenadasRoboI;
            string upperCaseCoordenadasRoboI;
            char direcaoRoboI;
            int direcaoRoboINumero;

            int[] coordenadasRoboII = new int[2];
            string entradaCoordenadasRoboII;
            string upperCaseCoordenadasRoboII;
            char direcaoRoboII;
            int direcaoRoboIINumero;

            char backupDirecaoRoboI;
            int[] backupCoordenadasRoboI = new int[2];
            char backupDirecaoRoboII;
            int[] backupCoordenadasRoboII = new int[2];

            string comandoStringI;
            string upperCaseComandoStringI;
            string comandoStringII;
            string upperCaseComandoStringII;

            bool fecharPrograma = false;
            while (fecharPrograma == false)
            {
                entradaCoordenadas = Console.ReadLine();
                Console.WriteLine();
                string[] entradaCoordenadasArray = entradaCoordenadas.Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);
                coordenadasArea[0] = int.Parse(entradaCoordenadasArray[0]);
                coordenadasArea[1] = int.Parse(entradaCoordenadasArray[1]);

                entradaCoordenadasRoboI = Console.ReadLine();
                Console.WriteLine();
                string[] entradaCoordenadasRoboIArray = entradaCoordenadasRoboI.Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);
                entradaCoordenadasRoboIArray[2] = entradaCoordenadasRoboIArray[2].Replace(" ", "");

                coordenadasRoboI[0] = int.Parse(entradaCoordenadasRoboIArray[0]);
                coordenadasRoboI[1] = int.Parse(entradaCoordenadasRoboIArray[1]);
                upperCaseComandoStringI = entradaCoordenadasRoboIArray[2].ToUpper();
                direcaoRoboI = char.Parse(upperCaseComandoStringI);

                if (coordenadasArea[0] <= 0 || coordenadasArea[1] <= 0)
                {
                    Console.WriteLine("Área inválida.");
                    Console.WriteLine("Digite ENTER para prosseguir.");
                    Console.ReadLine();
                    Console.Clear();

                }
                else if (coordenadasRoboI[0] < 0 || coordenadasRoboI[1] < 0 || coordenadasRoboI[0] > coordenadasArea[0] || coordenadasRoboI[1] > coordenadasArea[1])
                {
                    Console.WriteLine("Posição inicial do Robô I inválida.");
                    Console.WriteLine("Verifique as coordenadas informadas.");
                    Console.WriteLine("Digite ENTER para prosseguir.");
                    Console.ReadLine();
                    Console.Clear();
                }
                else if (direcaoRoboI != 'N' && direcaoRoboI != 'S' && direcaoRoboI != 'L' && direcaoRoboI != 'O')
                {
                    Console.WriteLine("Posição inicial do Robô I inválida.");
                    Console.WriteLine("Verifique a direção informada.");
                    Console.WriteLine("Digite ENTER para prosseguir.");
                    Console.ReadLine();
                    Console.Clear();
                }

                else
                {
                    direcaoRoboINumero = 0;
                    backupDirecaoRoboI = direcaoRoboI;
                    backupCoordenadasRoboI[0] = coordenadasRoboI[0];
                    backupCoordenadasRoboI[1] = coordenadasRoboI[1];

                    bool posicaoValidaI = false;
                    while (posicaoValidaI == false)
                    {
                        comandoStringI = Console.ReadLine();
                        Console.WriteLine();
                        upperCaseComandoStringI = comandoStringI.ToUpper();
                        char[] comandoSequenciaI = upperCaseComandoStringI.ToCharArray();

                        switch (direcaoRoboI)
                        {
                            case 'N':
                                direcaoRoboINumero = 1;
                                break;
                            case 'L':
                                direcaoRoboINumero = 2;
                                break;
                            case 'S':
                                direcaoRoboINumero = 3;
                                break;
                            case 'O':
                                direcaoRoboINumero = 4;
                                break;
                        }

                        for (int i = 0; i < comandoSequenciaI.Length; i++)
                        {
                            // Atribuir numeros a direções, como se fosse um relógio
                            // Caso seja sentido anti-horário (esquerada), você diminui o valor
                            // Caso seja sentido horário (direita), você aumenta o valor
                            // Se passar da quantidade de direções (0 ou 5), retonara para o valor da próxima direção (4 ou 1)
                            if (comandoSequenciaI[i] == 'E')
                            {
                                direcaoRoboINumero = direcaoRoboINumero - 1;
                                if (direcaoRoboINumero == 0)
                                {
                                    direcaoRoboINumero = 4;
                                }
                            }
                            else if (comandoSequenciaI[i] == 'D')
                            {
                                direcaoRoboINumero = direcaoRoboINumero + 1;
                                if (direcaoRoboINumero == 5)
                                {
                                    direcaoRoboINumero = 1;
                                }
                            }
                            else if (comandoSequenciaI[i] == 'M')
                            {
                                // Considere as direções como numeros e pense no plano cartesiano de X e Y.
                                // Se 1 = Norte, então a coordenada Y irá aumentar em 1 ao se movimentar.
                                // Se 2 = Leste, então a coordenada X irá aumentar em 1 ao se movimentar.
                                // Repita o mesmo fluxo porém negativamente para Sul e Oeste.
                                switch (direcaoRoboINumero)
                                {
                                    case 1:
                                        coordenadasRoboI[1] = coordenadasRoboI[1] + 1;
                                        break;
                                    case 2:
                                        coordenadasRoboI[0] = coordenadasRoboI[0] + 1;
                                        break;
                                    case 3:
                                        coordenadasRoboI[1] = coordenadasRoboI[1] - 1;
                                        break;
                                    case 4:
                                        coordenadasRoboI[0] = coordenadasRoboI[0] - 1;
                                        break;
                                }
                            }
                        }

                        // Retorna o número da direção após a movimentação para letra, para exibir o resultado.
                        switch (direcaoRoboINumero)
                        {
                            case 1:
                                direcaoRoboI = 'N';
                                break;
                            case 2:
                                direcaoRoboI = 'L';
                                break;
                            case 3:
                                direcaoRoboI = 'S';
                                break;
                            case 4:
                                direcaoRoboI = 'O';
                                break;
                        }

                        if (coordenadasRoboI[0] < 0 || coordenadasRoboI[1] < 0 || coordenadasRoboI[0] > coordenadasArea[0] || coordenadasRoboI[1] > coordenadasArea[1])
                        {
                            Console.WriteLine("Posicionamento do Robo I está inválido.");
                            Console.WriteLine("Verifique as coordenadas informadas.");
                            Console.WriteLine("Digite ENTER para prosseguir.");
                            Console.ReadLine();
                            Console.Clear();
                            direcaoRoboI = backupDirecaoRoboI;
                            coordenadasRoboI[0] = backupCoordenadasRoboI[0];
                            coordenadasRoboI[1] = backupCoordenadasRoboI[1];
                        }
                        else
                        {
                            posicaoValidaI = true;
                        }
                    }

                    entradaCoordenadasRoboII = Console.ReadLine();
                    Console.WriteLine();
                    string[] entradaCoordenadasRoboIIArray = entradaCoordenadasRoboII.Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);
                    entradaCoordenadasRoboIIArray[2] = entradaCoordenadasRoboIIArray[2].Replace(" ", "");

                    coordenadasRoboII[0] = int.Parse(entradaCoordenadasRoboIIArray[0]);
                    coordenadasRoboII[1] = int.Parse(entradaCoordenadasRoboIIArray[1]);
                    upperCaseComandoStringII = entradaCoordenadasRoboIIArray[2].ToUpper();
                    direcaoRoboII = char.Parse(upperCaseComandoStringII);

                    if (coordenadasRoboII[0] < 0 || coordenadasRoboII[1] < 0 || coordenadasRoboII[0] > coordenadasArea[0] || coordenadasRoboII[1] > coordenadasArea[1])
                    {
                        Console.WriteLine("Posição inicial do Robô II inválida.");
                        Console.WriteLine("Verifique as coordenadas informadas.");
                        Console.WriteLine("Digite ENTER para prosseguir.");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    else if (direcaoRoboII != 'N' && direcaoRoboII != 'S' && direcaoRoboII != 'L' && direcaoRoboII != 'O')
                    {
                        Console.WriteLine("Posição inicial do Robô II inválida.");
                        Console.WriteLine("Verifique a direção informada.");
                        Console.WriteLine("Digite ENTER para prosseguir.");
                        Console.ReadLine();
                        Console.Clear();
                    }

                    else
                    {
                        direcaoRoboIINumero = 0;
                        backupDirecaoRoboII = direcaoRoboII;
                        backupCoordenadasRoboII[0] = coordenadasRoboII[0];
                        backupCoordenadasRoboII[1] = coordenadasRoboII[1];

                        bool posicaoValidaII = false;
                        while (posicaoValidaII == false)
                        {
                            comandoStringII = Console.ReadLine();
                            Console.WriteLine();
                            upperCaseComandoStringII = comandoStringII.ToUpper();
                            char[] comandoSequenciaII = upperCaseComandoStringII.ToCharArray();

                            switch (direcaoRoboII)
                            {
                                case 'N':
                                    direcaoRoboIINumero = 1;
                                    break;
                                case 'L':
                                    direcaoRoboIINumero = 2;
                                    break;
                                case 'S':
                                    direcaoRoboIINumero = 3;
                                    break;
                                case 'O':
                                    direcaoRoboIINumero = 4;
                                    break;
                            }

                            for (int i = 0; i < comandoSequenciaII.Length; i++)
                            {
                                // Atribuir números a direções, como se fosse um relógio
                                // Caso seja sentido anti-horário (esquerda), você diminui o valor
                                // Caso seja sentido horário (direita), você aumenta o valor
                                // Se passar da quantidade de direções (0 ou 5), retonara para o valor da próxima direção (4 ou 1)
                                if (comandoSequenciaII[i] == 'E')
                                {
                                    direcaoRoboIINumero = direcaoRoboIINumero - 1;
                                    if (direcaoRoboIINumero == 0)
                                    {
                                        direcaoRoboIINumero = 4;
                                    }
                                }
                                else if (comandoSequenciaII[i] == 'D')
                                {
                                    direcaoRoboIINumero = direcaoRoboIINumero + 1;
                                    if (direcaoRoboIINumero == 5)
                                    {
                                        direcaoRoboIINumero = 1;
                                    }
                                }
                                else if (comandoSequenciaII[i] == 'M')
                                {
                                    // Considere as direções como números e pense no plano cartesiano de X e Y.
                                    // Se 1 = Norte, então a coordenada Y irá aumentar em 1 ao se movimentar.
                                    // Se 2 = Leste, então a coordenada X irá aumentar em 1 ao se movimentar.
                                    // Repita o mesmo fluxo porém negativamente para Sul e Oeste.
                                    switch (direcaoRoboIINumero)
                                    {
                                        case 1:
                                            coordenadasRoboII[1] = coordenadasRoboII[1] + 1;
                                            break;
                                        case 2:
                                            coordenadasRoboII[0] = coordenadasRoboII[0] + 1;
                                            break;
                                        case 3:
                                            coordenadasRoboII[1] = coordenadasRoboII[1] - 1;
                                            break;
                                        case 4:
                                            coordenadasRoboII[0] = coordenadasRoboII[0] - 1;
                                            break;
                                    }
                                }
                            }

                            // Retorna o número da direção após a movimentação para letra, para exibir o resultado.
                            switch (direcaoRoboIINumero)
                            {
                                case 1:
                                    direcaoRoboII = 'N';
                                    break;
                                case 2:
                                    direcaoRoboII = 'L';
                                    break;
                                case 3:
                                    direcaoRoboII = 'S';
                                    break;
                                case 4:
                                    direcaoRoboII = 'O';
                                    break;
                            }

                            if (coordenadasRoboII[0] < 0 || coordenadasRoboII[1] < 0 || coordenadasRoboII[0] > coordenadasArea[0] || coordenadasRoboII[1] > coordenadasArea[1])
                            {
                                Console.WriteLine("Posicionamento do Robo II está inválido.");
                                Console.WriteLine("Verifique as coordenadas informadas.");
                                Console.WriteLine("Digite ENTER para prosseguir.");
                                Console.ReadLine();
                                Console.Clear();
                                direcaoRoboII = backupDirecaoRoboII;
                                coordenadasRoboII[0] = backupCoordenadasRoboII[0];
                                coordenadasRoboII[1] = backupCoordenadasRoboII[1];
                            }
                            else
                            {
                                posicaoValidaII = true;
                            }
                        }

                        Console.Clear();
                        Console.WriteLine("{0} {1} {2}\n", coordenadasRoboI[0], coordenadasRoboI[1], direcaoRoboI);
                        Console.WriteLine("{0} {1} {2}", coordenadasRoboII[0], coordenadasRoboII[1], direcaoRoboII);



                        Console.Read();

                        // Variavel para manter o Loop aberto e adicionar uma possível verificação do programa caso necessário
                        bool opcaoValida = false;
                        while (opcaoValida == false)
                        {
                            string fecharBotao = Console.ReadLine();

                            if (fecharBotao != null)
                            {
                                Console.Clear();
                                opcaoValida = false;
                            }
                            else
                            {
                                Console.ReadLine();
                                continue;
                            }
                        }
                    }
                }
            }
        }
    }
}