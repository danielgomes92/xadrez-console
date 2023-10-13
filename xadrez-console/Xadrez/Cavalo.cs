using xadrez_console.Boards;

namespace xadrez_console.Xadrez
{
	public class Cavalo : Peca
	{
		public Cavalo(Tabuleiro tab, Cor cor) : base(tab, cor)
		{
		}

		public override string ToString()
		{
			return "C";
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
			pos.DefinirValores(PosicaoPeca.Linha - 1, PosicaoPeca.Coluna - 2);
			if (Board.posicaoValida(pos) && SePodeMover(pos))
				matriz[pos.Linha, pos.Coluna] = true;

			// posicao nordeste
			pos.DefinirValores(PosicaoPeca.Linha - 2, PosicaoPeca.Coluna - 1);
			if (Board.posicaoValida(pos) && SePodeMover(pos))
				matriz[pos.Linha, pos.Coluna] = true;

			// posicao sudeste
			pos.DefinirValores(PosicaoPeca.Linha - 2, PosicaoPeca.Coluna + 1);
			if (Board.posicaoValida(pos) && SePodeMover(pos))
				matriz[pos.Linha, pos.Coluna] = true;

			// posicao sudoeste
			pos.DefinirValores(PosicaoPeca.Linha - 1, PosicaoPeca.Coluna + 2);
			if (Board.posicaoValida(pos) && SePodeMover(pos))
				matriz[pos.Linha, pos.Coluna] = true;

			pos.DefinirValores(PosicaoPeca.Linha + 1, PosicaoPeca.Coluna + 2);
			if (Board.posicaoValida(pos) && SePodeMover(pos))
				matriz[pos.Linha, pos.Coluna] = true;

			pos.DefinirValores(PosicaoPeca.Linha + 2, PosicaoPeca.Coluna + 1);
			if (Board.posicaoValida(pos) && SePodeMover(pos))
				matriz[pos.Linha, pos.Coluna] = true;

			pos.DefinirValores(PosicaoPeca.Linha + 2, PosicaoPeca.Coluna - 1);
			if (Board.posicaoValida(pos) && SePodeMover(pos))
				matriz[pos.Linha, pos.Coluna] = true;

			pos.DefinirValores(PosicaoPeca.Linha + 1, PosicaoPeca.Coluna - 2);
			if (Board.posicaoValida(pos) && SePodeMover(pos))
				matriz[pos.Linha, pos.Coluna] = true;

			return matriz;
		}
	}
}
