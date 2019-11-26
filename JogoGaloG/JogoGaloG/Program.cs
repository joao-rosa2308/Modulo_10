using System;

namespace JogoGaloG
{
    class Program
    {
        static string[] QuadroJogo = new string[9];
        
        static string peca = "X";

        static void Main(string[] args)
        {
            /*
            QuadroJogo[0] = "1";
            QuadroJogo[1] = "2";
            */

            for (int i = 0; i < 9; ++i)
            {
                QuadroJogo[i] = (i + 1).ToString();
                //QuadroJogo[i] = Convert.ToString(i + 1);
            }

            bool fimJogo = false;
            bool posicaoLivre = false;
            do
            {
                EscreveQuadro(posicaoLivre);
                posicaoLivre = true;

                string lerTeclado = Console.ReadLine();
                int posicaoLida;
                bool posicaoValida = false;
                posicaoValida = int.TryParse(lerTeclado, out posicaoLida);

                if (QuadroJogo[posicaoLida - 1] == "X" || QuadroJogo[posicaoLida - 1] == "O")
                {
                    Console.Clear();
                    Console.WriteLine("Posição Ocupada");
                    posicaoLivre = false;
                    continue;
                }
                
                QuadroJogo[posicaoLida - 1] = peca;
                EscreveQuadro();

                if (ExisteVitoria() )
                {
                    Console.WriteLine($"Vitoria do Jogador {peca}");
                    fimJogo = true;
                    continue;
                }

                if (ExisteEmpate())
                {
                    Console.WriteLine($"Empate");
                    fimJogo = true;
                    continue;
                }

                /*
                if (peca == "X")
                {
                    peca = "O";
                }
                else
                {
                    peca = "X";
                }

                */

                // mudar peça
                peca = (peca == "X") ? "O" : "X";

            } while (!fimJogo);
        }

        private static void EscreveQuadro(bool limpar=true)
        {
            if(limpar)
            {
                Console.Clear();
            }
            Console.WriteLine($" {QuadroJogo[0]} | {QuadroJogo[1]} | {QuadroJogo[2]}");
            Console.WriteLine($"-------------");
            Console.WriteLine($" {QuadroJogo[3]} | {QuadroJogo[4]} | {QuadroJogo[5]}");
            Console.WriteLine($"-------------");
            Console.WriteLine($" {QuadroJogo[6]} | {QuadroJogo[7]} | {QuadroJogo[8]}");
        }


        private static bool ExisteVitoria()
        {
            if ( // linhas
                    (QuadroJogo[0] == peca && QuadroJogo[1] == peca && QuadroJogo[2] == peca) ||
                    (QuadroJogo[3] == peca && QuadroJogo[4] == peca && QuadroJogo[5] == peca) ||
                    (QuadroJogo[6] == peca && QuadroJogo[7] == peca && QuadroJogo[8] == peca) ||

                    // diagonais
                    (QuadroJogo[0] == peca && QuadroJogo[4] == peca && QuadroJogo[8] == peca) ||
                    (QuadroJogo[2] == peca && QuadroJogo[4] == peca && QuadroJogo[6] == peca) ||

                    // colunas
                    (QuadroJogo[0] == peca && QuadroJogo[3] == peca && QuadroJogo[6] == peca) ||
                    (QuadroJogo[1] == peca && QuadroJogo[4] == peca && QuadroJogo[7] == peca) ||
                    (QuadroJogo[2] == peca && QuadroJogo[5] == peca && QuadroJogo[8] == peca)
                 )
            {
                return true;
            }
            return false;
        }

        public static bool ExisteEmpate()
        {
            for (int x = 0; x <= 8; ++x)
            {
                if (QuadroJogo[x] != "X" && QuadroJogo[x] != "O")
                {
                    return false;
                }
            }
            return true;
        }
    }
}
