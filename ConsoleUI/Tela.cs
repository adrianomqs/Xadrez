using System;
using TabLib;

namespace ConsoleUI
{
    public class Tela
    {
        public static void ImprimirTabuleiro(Tabuleiro tab)
        {
            for (int i=0; i<tab.Linhas; i++)
            {
                for (int j=0; j<tab.Colunas; j++)
                {
                    if (tab.Get(i, j) == null)
                    {
                        Console.Write("_ ");
                    }
                    else
                    {
                        Console.Write(tab.Get(i, j) + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
