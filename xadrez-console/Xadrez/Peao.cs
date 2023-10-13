using xadrez_console.Boards;

namespace xadrez_console.Xadrez
{
	public class Peao : Peca
	{
        public Peao(Tabuleiro tab, Cor cor) : base(tab, cor)
        {
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
            }
            return matriz;
        }
    }
}
