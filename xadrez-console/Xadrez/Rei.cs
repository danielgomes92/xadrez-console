using xadrez_console.Boards;

namespace xadrez_console.Xadrez
{
    class Rei : Peca
    {
        public Rei(Cor cor, Tabuleiro tab) : base(cor, tab)
        {
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
            if(Board.posicaoValida(pos) && SePodeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
            }

            // posicao nordeste
            pos.DefinirValores(PosicaoPeca.Linha - 1, PosicaoPeca.Coluna + 1);
            if (Board.posicaoValida(pos) && SePodeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
            }

            // posicao direita
            pos.DefinirValores(PosicaoPeca.Linha, PosicaoPeca.Coluna + 1);
            if (Board.posicaoValida(pos) && SePodeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
            }

            // posicao sudeste
            pos.DefinirValores(PosicaoPeca.Linha + 1, PosicaoPeca.Coluna + 1);
            if (Board.posicaoValida(pos) && SePodeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
            }

            // posicao abaixo
            pos.DefinirValores(PosicaoPeca.Linha + 1, PosicaoPeca.Coluna);
            if (Board.posicaoValida(pos) && SePodeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
            }

            // posicao sudoeste
            pos.DefinirValores(PosicaoPeca.Linha + 1, PosicaoPeca.Coluna - 1);
            if (Board.posicaoValida(pos) && SePodeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
            }

            // posicao esquerda
            pos.DefinirValores(PosicaoPeca.Linha, PosicaoPeca.Coluna -1);
            if (Board.posicaoValida(pos) && SePodeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
            }

            // posicao noroeste
            pos.DefinirValores(PosicaoPeca.Linha - 1, PosicaoPeca.Coluna - 1);
            if (Board.posicaoValida(pos) && SePodeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
            }
            return matriz;
        }

        public override string ToString()
        {
            return "R";
        }
    }
}
