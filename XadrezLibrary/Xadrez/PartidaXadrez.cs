using System;
using TabLib;

namespace Xadrez
{
    public class PartidaXadrez
    {
        public Tabuleiro Tab { get; private set; }
        public int Turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool Terminado { get; private set; }

        public PartidaXadrez()
        {
            Tab = new Tabuleiro(8, 8);
            Turno = 1;
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

        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            ExecutaMovimento(origem, destino);
            Turno++;
            MudaJogador();
        }

        public void ValidarOrigem(Posicao pos)
        {
            if (Tab.gPeca(pos) == null)
            {
                throw new TabuleiroException("Nao Existe Peca na posicao de origem escolhida");
            }

            if (Tab.gPeca(pos).Cor != jogadorAtual)
            {
                throw new TabuleiroException("A Peca escolhida nao e' sua");
            }

            if (!Tab.gPeca(pos).ExisteMovimentosPossiveis() )
            {
                throw new TabuleiroException("Nao Existe Movimentos possivel para essa peca");
            }
        }

        public void ValidarDestino(Posicao origem, Posicao destino)
        {
            if (!Tab.gPeca(origem).PodeMover(destino))
            {
                throw new TabuleiroException("Posicao de Destino Invalida");
            }
        }

        private void MudaJogador()
        {
            if (jogadorAtual == Cor.Branco)
            {
                jogadorAtual = Cor.Preto;
            }
            else
            {
                jogadorAtual = Cor.Branco;
            }
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
