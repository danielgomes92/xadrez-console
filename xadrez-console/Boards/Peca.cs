namespace xadrez_console.Boards
{
    public abstract class Peca
    {
        public Posicao PosicaoPeca { get; set; }
        public Cor CorPeca { get; protected set; }
        public int qtMovimentos { get; protected set; }
        public Tabuleiro Board { get; protected set; }

        public Peca(Cor cor, Tabuleiro tab)
        {
            PosicaoPeca = null;
            CorPeca = cor;
            Board = tab;
            qtMovimentos = 0;
        }

        public void IncrementarQuantidadeDeMovimento()
        {
            qtMovimentos++;
        }
        
        public void DecrementarQuantidadeDeMovimento()
        {
            qtMovimentos--;
        }

        public bool SeExisteMovimentosPossiveis()
        {
            bool[,] matriz = MovimentosPossiveis();
            for (int i = 0; i < Board.Linhas; i++)
            {
                for (int j = 0; j < Board.Colunas; j++)
                {
                    if (matriz[i, j])
                        return true;
                }
            }
            return false;
        }

        public bool MovimentoPossivel(Posicao pos)
        {
            return MovimentosPossiveis()[pos.Linha, pos.Coluna];
        }

        public abstract bool[,] MovimentosPossiveis();
    }
}
