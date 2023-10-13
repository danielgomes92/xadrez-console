using xadrez_console.Boards;

namespace xadrez_console.Xadrez
{
	public class Bispo : Peca
	{
		public Bispo(Tabuleiro tab, Cor cor) : base(tab, cor)
		{
		}

		public override string ToString()
		{
			return "B";
		}

		public bool SePodeMover(Posicao pos)
		{
			Peca p = Board.peca(pos);
			return p == null || p.CorPeca != CorPeca;
		}

		public override bool[,] MovimentosPossiveis()
		{
            bool[,] matriz = new bool[Board.Linhas, Board.Colunas];

            Posicao pos = new Posicao(0, 0);

            // posicao noroeste
            pos.DefinirValores(PosicaoPeca.Linha - 1, PosicaoPeca.Coluna - 1);
            while (Board.posicaoValida(pos) && SePodeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
                if (Board.peca(pos) != null && Board.peca(pos).CorPeca != CorPeca)
                    break;

                pos.DefinirValores(pos.Linha - 1, pos.Coluna - 1);
            }

            // posicao nordeste
            pos.DefinirValores(PosicaoPeca.Linha - 1, PosicaoPeca.Coluna + 1);
            while (Board.posicaoValida(pos) && SePodeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
                if (Board.peca(pos) != null && Board.peca(pos).CorPeca != CorPeca)
                    break;

                pos.DefinirValores(pos.Linha - 1, pos.Coluna + 1);
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
