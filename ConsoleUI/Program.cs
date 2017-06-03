using System;
using TabLib;
using Xadrez;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Tabuleiro tab = new Tabuleiro(8, 8);

            tab.SetPeca(new Torre(tab, Cor.Preto), new Posicao(0, 0));
            tab.SetPeca(new Torre(tab, Cor.Preto), new Posicao(1, 3));
            tab.SetPeca(new Rei(tab, Cor.Preto), new Posicao(2, 4));

            Tela.ImprimirTabuleiro(tab);
            
            Console.ReadLine();
        }
    }
}
