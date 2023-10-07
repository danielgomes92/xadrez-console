namespace xadrez_console.Boards
{
    public class Peca
    {
        public Posicao Position { get; set; }
        public Cor Color { get; protected set; }
        public int qtMovimentos { get; protected set; }
        public Tabuleiro Board { get; protected set; }

        public Peca(Posicao posicao, Cor cor, Tabuleiro tab)
        {
            Position = posicao;
            Color = cor;
            Board = tab;
            qtMovimentos = 0;
        }
    }
}
