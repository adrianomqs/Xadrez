using System;
using TabLib;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Tabuleiro tab = new Tabuleiro(8, 8);
            //Console.WriteLine(tab);

            Tela.ImprimirTabuleiro(tab);

            Console.ReadLine();
        }
    }
}
