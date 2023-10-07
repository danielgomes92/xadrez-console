using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xadrez_console.Tabuleiro;

namespace xadrez_console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Posicao posicao = new Posicao(3, 4);
            Console.WriteLine("Posicao: " + posicao);
            Console.ReadLine();
        }
    }
}
