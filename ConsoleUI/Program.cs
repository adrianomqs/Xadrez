using System;
using TabLib;
using Xadrez;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            
            PartidaXadrez partida = new PartidaXadrez();

            while (!partida.Terminado)
            {
                try
                {
                    Console.Clear();
                    Tela.ImprimirTabuleiro(partida.Tab);

                    Console.WriteLine();
                    Console.WriteLine("Turno: " + partida.Turno);
                    Console.WriteLine("Aguardando Jogada: " + partida.jogadorAtual);
                    Console.WriteLine();

                    Console.Write("Origem: ");
                    Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();
                    partida.ValidarOrigem(origem);

                    bool[,] posicoesPossiveis = partida.Tab.gPeca(origem).MovimentosPossiveis();

                    Console.Clear();
                    Tela.ImprimirTabuleiro(partida.Tab, posicoesPossiveis);

                    Console.WriteLine();
                    Console.WriteLine("Destino: ");
                    Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();
                    partida.ValidarDestino(origem, destino);

                    partida.RealizaJogada(origem, destino);
                }
                catch (TabuleiroException e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }
            }
            Console.ReadLine();
        }
    }
}
