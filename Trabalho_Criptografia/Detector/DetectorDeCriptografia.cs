using System;
using System.Collections.Generic;
using System.Linq;

namespace Trabalho_Criptografia.DetectorDeCriptografia
{
    public class DetectorDeCriptografia
    {
        // Conjunto de palavras válidas usado para validar se o texto decifrado faz sentido.
        private static readonly HashSet<string> PalavrasValidas = new()
        {
            // Adicione palavras comuns para validação (podem ser ajustadas conforme o idioma ou o contexto).
            "A", "AS", "EU", "ELA", "ELE", "ESTÁ",
            "COUNTRY", "JOURNEY", "TRAVEL", "VACATION"
        };

        /// <summary>
        /// Verifica se o texto foi criptografado com a Cifra de César.
        /// Testa deslocamentos de 1 a 25 para tentar descriptografar.
        /// <param name="texto">O texto cifrado.</param>
        /// <returns>Retorna true se o texto parecer uma Cifra de César; caso contrário, false.</returns>
        public static bool EhCifraDeCesar(string texto)
        {
            texto = NormalizarTexto(texto);

            for (int deslocamento = 1; deslocamento < 26; deslocamento++)
            {
                // Tenta descriptografar usando o deslocamento atual.
                string tentativa = DescriptografarCesar(texto, deslocamento);

                // Verifica se o texto decifrado contém palavras válidas.
                if (ContemPalavraValida(tentativa))
                {
                    Console.WriteLine($"Texto decifrado com deslocamento {deslocamento}: {tentativa}");
                    return true; // Indica que o texto provavelmente é uma Cifra de César.
                }
            }

            // Nenhum deslocamento produziu um texto válido.
            return false;
        }


        /// Descriptografa um texto usando a Cifra de César com base em um deslocamento.
        /// <param name="texto">O texto cifrado.</param>
        /// <param name="deslocamento">O deslocamento usado na cifra.</param>
        /// <returns>O texto descriptografado.</returns>
        public static string DescriptografarCesar(string texto, int deslocamento)
        {
            return new string(texto.Select(c =>
            {
                if (!char.IsLetter(c)) return c; // Mantém caracteres não alfabéticos inalterados.

                char baseLetra = char.IsUpper(c) ? 'A' : 'a'; // Determina a base (A para maiúsculas, a para minúsculas).
                return (char)((c - baseLetra - deslocamento + 26) % 26 + baseLetra); // Aplica a descriptografia circular.
            }).ToArray());
        }


        /// Verifica se o texto contém pelo menos uma palavra válida.
        /// <param name="texto">O texto a ser verificado.</param>
        /// <returns>Retorna true se contiver palavras válidas; caso contrário, false.</returns>
        private static bool ContemPalavraValida(string texto)
        {
            return PalavrasValidas.Any(palavra => texto.Contains(palavra, StringComparison.OrdinalIgnoreCase));
        }


        /// Tenta quebrar uma criptografia de Vigenère usando força bruta com as palavras válidas como possíveis chaves.
        /// <param name="texto">O texto cifrado.</param>
        public static void QuebrarVigenereForcaBruta(string texto)
        {
            texto = NormalizarTexto(texto);

            foreach (var chave in PalavrasValidas) // Testa cada palavra válida como chave.
            {
                string tentativa = DescriptografarVigenere(texto, chave);
                Console.WriteLine($"Tentando com chave '{chave}': {tentativa}");

                // Verifica se o texto decifrado contém palavras válidas.
                if (ContemPalavraValida(tentativa))
                {
                    Console.WriteLine($"Texto decifrado com chave '{chave}': {tentativa}");
                    return;
                }
            }

            Console.WriteLine("Não foi possível decifrar o texto com força bruta.");
        }


        /// Descriptografa um texto cifrado com a Cifra de Vigenère usando uma chave fornecida.
        /// <param name="texto">O texto cifrado.</param>
        /// <param name="chave">A chave usada na cifra.</param>
        /// <returns>O texto descriptografado.</returns>
        private static string DescriptografarVigenere(string texto, string chave)
        {
            var resultado = new List<char>();
            int chaveIndex = 0; // Índice para percorrer a chave.

            foreach (char c in texto)
            {
                if (!char.IsLetter(c))
                {
                    resultado.Add(c); // Mantém caracteres não alfabéticos inalterados.
                    continue;
                }

                char baseLetra = char.IsUpper(c) ? 'A' : 'a'; // Determina a base (A ou a).
                char novaLetra = (char)((c - baseLetra - (char.ToUpper(chave[chaveIndex]) - 'A') + 26) % 26 + baseLetra); // Aplica descriptografia.
                resultado.Add(novaLetra);

                chaveIndex = (chaveIndex + 1) % chave.Length; // Avança o índice da chave, reiniciando se necessário.
            }

            return new string(resultado.ToArray());
        }

        /// Remove caracteres não alfabéticos e converte o texto para letras maiúsculas.
        /// <param name="texto">O texto original.</param>
        /// <returns>O texto normalizado.</returns>
        private static string NormalizarTexto(string texto)
        {
            return new string(texto.Where(c => char.IsLetter(c)).Select(c => char.ToUpper(c)).ToArray());
        }
    }
}
