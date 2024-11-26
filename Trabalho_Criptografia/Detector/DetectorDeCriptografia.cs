using System;
using System.Collections.Generic;
using System.Linq;

namespace Trabalho_Criptografia.DetectorDeCriptografia
{
    public class DetectorDeCriptografia
    {
        // Conjunto de palavras válidas para validar o texto decifrado
        private static readonly HashSet<string> PalavrasValidas = new()
        {
            // Adicione palavras comuns para validação de textos decifrados
            "A", "AS", "EU", "ELA", "ELE", "ESTÁ",
            "COUNTRY", "JOURNEY", "TRAVEL", "VACATION"
        };


        /// Verifica se o texto foi criptografado usando a Cifra de César.
        /// Tenta todos os deslocamentos de 1 a 25 para descriptografar.

        public static bool EhCifraDeCesar(string texto)
        {
            texto = NormalizarTexto(texto);

            for (int deslocamento = 1; deslocamento < 26; deslocamento++)
            {
                // Tenta descriptografar com o deslocamento atual
                string tentativa = DescriptografarCesar(texto, deslocamento);

                // Verifica se o texto contém palavras válidas
                if (ContemPalavraValida(tentativa))
                {
                    Console.WriteLine($"Texto decifrado com deslocamento {deslocamento}: {tentativa}");
                    return true; // Texto parece ser uma Cifra de César
                }
            }

            // Nenhum deslocamento produziu texto válido
            return false;
        }


        /// Descriptografa um texto usando a Cifra de César com base no deslocamento fornecido.

        public static string DescriptografarCesar(string texto, int deslocamento)
        {
            return new string(texto.Select(c =>
            {
                if (!char.IsLetter(c)) return c; // Não modifica caracteres não alfabéticos

                char baseLetra = char.IsUpper(c) ? 'A' : 'a'; // Determina a base (A ou a)
                return (char)((c - baseLetra - deslocamento + 26) % 26 + baseLetra); // Realiza o cálculo circular
            }).ToArray());
        }

        /// Verifica se o texto contém pelo menos uma palavra válida.
  
        private static bool ContemPalavraValida(string texto)
        {
            return PalavrasValidas.Any(palavra => texto.Contains(palavra, StringComparison.OrdinalIgnoreCase));
        }

        /// Tenta descriptografar um texto cifrado com a Cifra de Vigenère usando força bruta.

        public static void QuebrarVigenereForcaBruta(string texto)
        {
            texto = NormalizarTexto(texto);

            foreach (var chave in PalavrasValidas) // Tenta cada palavra válida como chave
            {
                string tentativa = DescriptografarVigenere(texto, chave);
                Console.WriteLine($"Tentando com chave '{chave}': {tentativa}");

                // Verifica se a tentativa contém palavras válidas
                foreach (var palavra in PalavrasValidas)
                {
                    if (tentativa.Contains(palavra, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine($"Texto decifrado com chave '{chave}': {tentativa}");
                        break; // Sai do loop interno e continua tentando outras chaves
                    }
                }
            }

            Console.WriteLine("Não foi possível decifrar o texto com força bruta.");
        }


        /// Descriptografa um texto cifrado com a Cifra de Vigenère usando a chave fornecida.

        private static string DescriptografarVigenere(string texto, string chave)
        {
            var resultado = new List<char>();
            int chaveIndex = 0; // Índice para percorrer a chave

            foreach (char c in texto)
            {
                if (!char.IsLetter(c))
                {
                    resultado.Add(c); // Mantém caracteres não alfabéticos
                    continue;
                }

                char baseLetra = char.IsUpper(c) ? 'A' : 'a'; // Determina a base (A ou a)
                char novaLetra = (char)((c - baseLetra - (chave[chaveIndex] - 'A') + 26) % 26 + baseLetra); // Descriptografa
                resultado.Add(novaLetra);

                chaveIndex = (chaveIndex + 1) % chave.Length; // Avança na chave, voltando ao início se necessário
            }

            return new string(resultado.ToArray());
        }


        /// Gera todas as combinações possíveis de um alfabeto com um tamanho fixo.

        private static IEnumerable<string> GerarCombinacoes(string alfabeto, int tamanho)
        {
            if (tamanho == 1)
                return alfabeto.Select(c => c.ToString());

            var menores = GerarCombinacoes(alfabeto, tamanho - 1);
            return menores.SelectMany(menor => alfabeto.Select(c => menor + c));
        }


        /// Remove caracteres não alfabéticos e converte o texto para maiúsculas.

        private static string NormalizarTexto(string texto)
        {
            return new string(texto.Where(c => char.IsLetter(c)).Select(c => char.ToUpper(c)).ToArray());
        }
    }
}
