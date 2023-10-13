using xadrez_console.Boards;

namespace xadrez_console.Xadrez
{
	public class Dama : Peca
	{
        public Dama(Tabuleiro tab, Cor cor) : base(tab, cor)
        {
        }

        public override string ToString()
        {
            return "D";
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

            // posicao esquerda
            pos.DefinirValores(PosicaoPeca.Linha, PosicaoPeca.Coluna - 1);
            while (Board.posicaoValida(pos) && SePodeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
                if (Board.peca(pos) != null && Board.peca(pos).CorPeca != CorPeca)
                    break;

                pos.DefinirValores(pos.Linha, pos.Coluna - 1);
            }

            // posicao direita
            pos.DefinirValores(PosicaoPeca.Linha, PosicaoPeca.Coluna + 1);
            while (Board.posicaoValida(pos) && SePodeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
                if (Board.peca(pos) != null && Board.peca(pos).CorPeca != CorPeca)
                    break;

                pos.DefinirValores(pos.Linha, pos.Coluna + 1);
            }

            // posicao acima
            pos.DefinirValores(PosicaoPeca.Linha - 1, PosicaoPeca.Coluna);
            while (Board.posicaoValida(pos) && SePodeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
                if (Board.peca(pos) != null && Board.peca(pos).CorPeca != CorPeca)
                    break;

                pos.DefinirValores(pos.Linha - 1, pos.Coluna);
            }

            // posicao abaixo
            pos.DefinirValores(PosicaoPeca.Linha + 1, PosicaoPeca.Coluna);
            while (Board.posicaoValida(pos) && SePodeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
                if (Board.peca(pos) != null && Board.peca(pos).CorPeca != CorPeca)
                    break;

                pos.DefinirValores(pos.Linha + 1, pos.Coluna);
            }

            // posicao noroeste
            pos.DefinirValores(PosicaoPeca.Linha - 1, PosicaoPeca.Coluna - 1);
            while (Board.posicaoValida(pos) && SePodeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
                if (Board.peca(pos) != null && Board.peca(pos).CorPeca != CorPeca)
                    break;

                pos.DefinirValores(pos.Linha - 1, pos.Coluna - 1);
            }

            // posicao sudeste
            pos.DefinirValores(PosicaoPeca.Linha + 1, PosicaoPeca.Coluna + 1);
            while (Board.posicaoValida(pos) && SePodeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
                if (Board.peca(pos) != null && Board.peca(pos).CorPeca != CorPeca)
                    break;

                pos.DefinirValores(pos.Linha + 1, pos.Coluna + 1);
            }

            // posicao sudoeste
            pos.DefinirValores(PosicaoPeca.Linha + 1, PosicaoPeca.Coluna - 1);
            while (Board.posicaoValida(pos) && SePodeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
                if (Board.peca(pos) != null && Board.peca(pos).CorPeca != CorPeca)
                    break;

                pos.DefinirValores(pos.Linha + 1, pos.Coluna - 1);
            }
            return matriz;
        }
    }
}
