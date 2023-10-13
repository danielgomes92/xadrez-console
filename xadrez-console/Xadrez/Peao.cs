using xadrez_console.Boards;

namespace xadrez_console.Xadrez
{
	public class Peao : Peca
	{
		private PartidaDeXadrez _partida;

		public Peao(Tabuleiro tab, Cor cor, PartidaDeXadrez partida) : base(tab, cor)
		{
			_partida = partida;
		}

		public override string ToString()
		{
			return "P";
		}

		private bool SeExisteInimigo(Posicao pos)
		{
			Peca p = Board.peca(pos);
			return p != null && p.CorPeca != CorPeca;
		}

		private bool SeEstaLivre(Posicao pos)
		{
			return Board.peca(pos) == null;
		}

		public override bool[,] MovimentosPossiveis()
		{
			bool[,] matriz = new bool[Board.Linhas, Board.Colunas];

			Posicao pos = new Posicao(0, 0);

			if (CorPeca == Cor.Branca)
			{
				pos.DefinirValores(PosicaoPeca.Linha - 1, PosicaoPeca.Coluna);
				if (Board.posicaoValida(pos) && SeEstaLivre(pos))
					matriz[PosicaoPeca.Linha, PosicaoPeca.Coluna] = true;

				pos.DefinirValores(PosicaoPeca.Linha - 2, PosicaoPeca.Coluna);
				if (Board.posicaoValida(pos) && SeEstaLivre(pos) && qtMovimentos == 0)
					matriz[PosicaoPeca.Linha, PosicaoPeca.Coluna] = true;

				pos.DefinirValores(PosicaoPeca.Linha - 1, PosicaoPeca.Coluna - 1);
				if (Board.posicaoValida(pos) && SeExisteInimigo(pos))
					matriz[PosicaoPeca.Linha, PosicaoPeca.Coluna] = true;

				pos.DefinirValores(PosicaoPeca.Linha - 1, PosicaoPeca.Coluna + 1);
				if (Board.posicaoValida(pos) && SeExisteInimigo(pos))
					matriz[PosicaoPeca.Linha, PosicaoPeca.Coluna] = true;

				// #JogadaEspecial En Passant
				if (PosicaoPeca.Linha == 3)
				{
					Posicao esquerdaPeao = new Posicao(PosicaoPeca.Linha, PosicaoPeca.Coluna - 1);
					if (Board.posicaoValida(esquerdaPeao) && SeExisteInimigo(esquerdaPeao) && Board.peca(esquerdaPeao) == _partida.VulneravelEnPassant)
						matriz[esquerdaPeao.Linha - 1, esquerdaPeao.Coluna] = true;

					Posicao direitaPeao = new Posicao(PosicaoPeca.Linha, PosicaoPeca.Coluna + 1);
					if (Board.posicaoValida(direitaPeao) && SeExisteInimigo(direitaPeao) && Board.peca(direitaPeao) == _partida.VulneravelEnPassant)
						matriz[direitaPeao.Linha - 1, direitaPeao.Coluna] = true;
				}
			}
			else
			{
				pos.DefinirValores(PosicaoPeca.Linha + 1, PosicaoPeca.Coluna);
				if (Board.posicaoValida(pos) && SeEstaLivre(pos))
					matriz[PosicaoPeca.Linha, PosicaoPeca.Coluna] = true;

				pos.DefinirValores(PosicaoPeca.Linha + 2, PosicaoPeca.Coluna);
				if (Board.posicaoValida(pos) && SeEstaLivre(pos) && qtMovimentos == 0)
					matriz[PosicaoPeca.Linha, PosicaoPeca.Coluna] = true;

				pos.DefinirValores(PosicaoPeca.Linha + 1, PosicaoPeca.Coluna - 1);
				if (Board.posicaoValida(pos) && SeExisteInimigo(pos))
					matriz[PosicaoPeca.Linha, PosicaoPeca.Coluna] = true;

				pos.DefinirValores(PosicaoPeca.Linha + 1, PosicaoPeca.Coluna + 1);
				if (Board.posicaoValida(pos) && SeExisteInimigo(pos))
					matriz[PosicaoPeca.Linha, PosicaoPeca.Coluna] = true;

				// #JogadaEspecial En Passant
				if (PosicaoPeca.Linha == 4)
				{
					Posicao esquerdaPeao = new Posicao(PosicaoPeca.Linha, PosicaoPeca.Coluna - 1);
					if (Board.posicaoValida(esquerdaPeao) && SeExisteInimigo(esquerdaPeao) && Board.peca(esquerdaPeao) == _partida.VulneravelEnPassant)
						matriz[esquerdaPeao.Linha + 1, esquerdaPeao.Coluna] = true;

					Posicao direitaPeao = new Posicao(PosicaoPeca.Linha, PosicaoPeca.Coluna + 1);
					if (Board.posicaoValida(direitaPeao) && SeExisteInimigo(direitaPeao) && Board.peca(direitaPeao) == _partida.VulneravelEnPassant)
						matriz[direitaPeao.Linha + 1, direitaPeao.Coluna] = true;
				}
			}
			return matriz;
		}
	}
}
