namespace JogoDaForca
{


    class JogoDaForca
    {
        private string palavraChave;
        private List<char> letrasCorretas;
        private int tentativasRestantes;

        public JogoDaForca(string palavra)
        {
            palavraChave = palavra.ToUpper(); // Converte a palavra-chave para maiúsculas
            letrasCorretas = new List<char>();
            tentativasRestantes = 8; // Número máximo de tentativas
        }

        public void Jogar()
        {
            Console.WriteLine("Jogo da Forca iniciado!");
            Console.WriteLine($"A palavra tem {palavraChave.Length} letras.");

            while (tentativasRestantes > 0)
            {
                Console.WriteLine("\nDigite uma letra:");
                char letra = char.ToUpper(Console.ReadKey().KeyChar);

                if (VerificarLetra(letra))
                {
                    Console.WriteLine($"\nLetra '{letra}' está na palavra!");
                    MostrarPalavraChave();
                }
                else
                {
                    Console.WriteLine($"\nA letra '{letra}' não existe na palavra-chave.");
                    tentativasRestantes--;
                    Console.WriteLine($"Tentativas restantes: {tentativasRestantes}");
                }

                if (PalavraCompleta())
                {
                    Console.WriteLine("\nParabéns! Você acertou a palavra!");
                    return;
                }
            }

            Console.WriteLine($"\nGame Over! A palavra era: {palavraChave}");
        }

        private bool VerificarLetra(char letra)
        {
            if (palavraChave.Contains(letra))
            {
                letrasCorretas.Add(letra);
                return true;
            }
            return false;
        }

        private void MostrarPalavraChave()
        {
            foreach (char letra in palavraChave)
            {
                if (letrasCorretas.Contains(letra))
                    Console.Write(letra + " ");
                else
                    Console.Write("_ ");
            }
            Console.WriteLine();
        }

        private bool PalavraCompleta()
        {
            foreach (char letra in palavraChave)
            {
                if (!letrasCorretas.Contains(letra))
                    return false;
            }
            return true;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] palavras = { "CARRO", "CASA", "BANANA", "CELULAR", "CAMA", "COMPUTADOR", "AVIAO" };

            Random rnd = new Random();
            int indice = rnd.Next(0, palavras.Length);
            string palavraSelecionada = palavras[indice];

            JogoDaForca jogo = new JogoDaForca(palavraSelecionada);
            jogo.Jogar();
        }
    }

}
