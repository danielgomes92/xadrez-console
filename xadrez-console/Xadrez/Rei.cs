using xadrez_console.Boards;

namespace xadrez_console.Xadrez
{
    class Rei : Peca
    {
        private PartidaDeXadrez _partida;
        public Rei(Tabuleiro tab, Cor cor, PartidaDeXadrez partida) : base(tab, cor)
        {
            _partida = partida;
        }

        private bool SePodeMover(Posicao pos)
        {
            Peca p = Board.peca(pos);
            return p == null || p.CorPeca != CorPeca;
        }

        private bool TesteTorreParaRoque(Posicao pos)
		{
            Peca p = Board.peca(pos);
            return p != null && p is Torre && p.CorPeca == CorPeca && p.qtMovimentos == 0;
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

			// #JogadaEspecial Roque
			if (qtMovimentos == 0 && !_partida.Xeque)
			{
                // #JogadaEspecial Roque Pequeno
                Posicao posicaoTorre1 = new Posicao(PosicaoPeca.Linha, PosicaoPeca.Coluna + 3);
				if (TesteTorreParaRoque(posicaoTorre1))
				{
                    Posicao p1 = new Posicao(PosicaoPeca.Linha, PosicaoPeca.Coluna + 1);
                    Posicao p2 = new Posicao(PosicaoPeca.Linha, PosicaoPeca.Coluna + 2);
					if (Board.peca(p1) == null && Board.peca(p2) == null)
					{
                        matriz[PosicaoPeca.Linha, PosicaoPeca.Coluna + 2] = true;
					}
				}

                // #JogadaEspecial Roque Grande
                Posicao posicaoTorre2 = new Posicao(PosicaoPeca.Linha, PosicaoPeca.Coluna - 4);
                if (TesteTorreParaRoque(posicaoTorre2))
                {
                    Posicao p1 = new Posicao(PosicaoPeca.Linha, PosicaoPeca.Coluna - 1);
                    Posicao p2 = new Posicao(PosicaoPeca.Linha, PosicaoPeca.Coluna - 2);
                    Posicao p3 = new Posicao(PosicaoPeca.Linha, PosicaoPeca.Coluna - 3);
                    if (Board.peca(p1) == null && Board.peca(p2) == null && Board.peca(p3) == null)
                    {
                        matriz[PosicaoPeca.Linha, PosicaoPeca.Coluna - 2] = true;
                    }
                }
            }
            return matriz;
        }

        public override string ToString()
        {
            return "R";
        }
    }
}
