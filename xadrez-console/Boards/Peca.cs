namespace xadrez_console.Boards
{
    public class Peca
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
    }
}
