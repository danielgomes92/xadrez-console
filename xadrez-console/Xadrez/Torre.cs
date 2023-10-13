using xadrez_console.Boards;

namespace xadrez_console.Xadrez
{
    internal class Torre : Peca
    {
        public Torre(Tabuleiro tab, Cor cor) : base(tab, cor)
        {
        }

        public override string ToString()
        {
            return "T";
        }

        private bool SePodeMover(Posicao pos)
        {
            Peca p = Board.peca(pos);
            return p == null || p.CorPeca != CorPeca;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] matriz = new bool[Board.Linhas, Board.Colunas];

            Posicao pos = new Posicao(0, 0);

            // posicao acima
            pos.DefinirValores(PosicaoPeca.Linha - 1, PosicaoPeca.Coluna);
            while (Board.posicaoValida(pos) && SePodeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
                if(Board.peca(pos) != null && Board.peca(pos).CorPeca != CorPeca)
                {
                    break;
                }
                pos.Linha = pos.Linha - 1;
            }

            // posicao abaixo
            pos.DefinirValores(PosicaoPeca.Linha + 1, PosicaoPeca.Coluna);
            while (Board.posicaoValida(pos) && SePodeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
                if (Board.peca(pos) != null && Board.peca(pos).CorPeca != CorPeca)
                {
                    break;
                }
                pos.Linha = pos.Linha + 1;
            }

            // posicao direita
            pos.DefinirValores(PosicaoPeca.Linha, PosicaoPeca.Coluna + 1);
            while (Board.posicaoValida(pos) && SePodeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
                if (Board.peca(pos) != null && Board.peca(pos).CorPeca != CorPeca)
                {
                    break;
                }
                pos.Coluna = pos.Coluna + 1;
            }

            // posicao esquerda
            pos.DefinirValores(PosicaoPeca.Linha, PosicaoPeca.Coluna - 1);
            while (Board.posicaoValida(pos) && SePodeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
                if (Board.peca(pos) != null && Board.peca(pos).CorPeca != CorPeca)
                {
                    break;
                }
                pos.Coluna = pos.Coluna - 1;
            }
            return matriz;
        }
    }
}
