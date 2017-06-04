using System;
using TabLib;

namespace Xadrez
{
    public class PartidaXadrez
    {
        public Tabuleiro Tab { get; private set; }
        private int turno;
        private Cor jogadorAtual;
        public bool Terminado { get; private set; }

        public PartidaXadrez()
        {
            Tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branco;
            IniciarPecas();
        }

        public void ExecutaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = Tab.RetirarPeca(origem);
            p.IncrmentarMovimentos();
            Peca pecaCapturada = Tab.RetirarPeca(destino);
            Tab.ColocarPeca(p, destino);
            Terminado = false;
        }

        private void IniciarPecas()
        {   
            //Pecas Pretas
            Tab.ColocarPeca(new Torre(Tab, Cor.Preto), new PosicaoXadrez ('a',8).ToPosicao());
            Tab.ColocarPeca(new Torre(Tab, Cor.Preto), new PosicaoXadrez('h', 8).ToPosicao());
            Tab.ColocarPeca(new Rei(Tab, Cor.Preto), new PosicaoXadrez('d', 8).ToPosicao());

            //Pecas Brancas
            Tab.ColocarPeca(new Torre(Tab, Cor.Branco), new PosicaoXadrez('a', 1).ToPosicao());
            Tab.ColocarPeca(new Torre(Tab, Cor.Branco), new PosicaoXadrez('h', 1).ToPosicao());
            Tab.ColocarPeca(new Rei(Tab, Cor.Branco), new PosicaoXadrez('e', 1).ToPosicao());
        }
    }
}
