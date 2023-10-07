using xadrez_console.Boards;

namespace xadrez_console.Xadrez
{
    public class PosicaoXadrez
    {
        public char Coluna { get; set; }
        public int Linha { get; set; }

        public PosicaoXadrez(char coluna, int linha)
        {
            Coluna = coluna;
            Linha = linha;
        }

        public Posicao ToPosicao()
        {
            return new Posicao(8 - Linha, Coluna - 'A');
        }

        public override string ToString()
        {
            return $"{Coluna}{Linha}";
        }
    }
}
