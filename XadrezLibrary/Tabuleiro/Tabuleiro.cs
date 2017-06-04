namespace TabLib
{
    public class Tabuleiro
    {
        public int Linhas { get; set; }
        public int Colunas { get; set; }
        public Peca[,] Pecas { get; set; }

        public Tabuleiro(int linhas, int colunas)
        {
            Linhas = linhas;
            Colunas = colunas;
            Pecas = new Peca[linhas, colunas];
        }

        public Peca Get(int linha, int coluna)
        {
            return Pecas[linha, coluna];
        }

        public Peca Get(Posicao pos)
        {
            return Pecas[pos.Linha, pos.Coluna];
        }

        public void ColocarPeca (Peca p, Posicao pos)
        {
            if (ExistePeca(pos))
            {
                throw new TabuleiroException("Ja existe uma peca nessa posicao! Posicao:" + pos.Linha + "," + pos.Coluna);
            }
            Pecas[pos.Linha, pos.Coluna] = p;
            p.Posicao = pos;
        }

        public Peca RetirarPeca(Posicao pos)
        {
            if (Get(pos) == null)
            {
                return null;
            }
            else
            {
                Peca aux = Get(pos);
                aux.Posicao = null;
                Pecas[pos.Linha, pos.Coluna] = null;
                return aux;
            }
        }

        public bool ExistePeca(Posicao pos)
        {
            ValidarPosicao(pos);
            return Get(pos) != null;
        }

        public bool PosicaoValida(Posicao pos)
        {
            if (pos.Linha<0 || pos.Linha>=Linhas || pos.Coluna<0|| pos.Coluna>=Colunas)
            {
                return false;
            }
            return true;
        }

        public void ValidarPosicao(Posicao pos)
        {
            if (!PosicaoValida(pos))
            {
                throw new TabuleiroException("Posicao Invalida! Posicao:" + pos.Linha + "," + pos.Coluna);
            }
        }
    }
}
