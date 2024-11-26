using System;
using System.Linq;

namespace Trabalho_Criptografia.CriptografiaVigenere
{
    public class CifraDeVigenere
    {
        // Método para criptografar usando a Cifra de Vigenère.
        public static string Criptografar(string texto, string chave)
        {
            // Normaliza a chave para maiúsculas (padrão da cifra de Vigenère).
            chave = chave.ToUpper();
            var indiceChave = 0;

            return new string(texto.Select(Caracter =>
            {
                if (char.IsLetter(Caracter))
                {
                    // Determina o ponto de referência do alfabeto ('A' ou 'a').
                    char baseLetra = char.IsUpper(Caracter) ? 'A' : 'a';

                    // Obtém a letra da chave correspondente.
                    char letraChave = chave[indiceChave % chave.Length];

                    // Avança o índice da chave.
                    indiceChave++;

                    /*
                      Fórmula Matemática:
                      C = (P + K) mod 26
                      Onde:
                      - C: Índice da letra cifrada. (retorno)
                      - P: Índice da letra original. (Caracter - baseLetra)
                      - K: Índice da letra da chave. (letraChave - 'A')
                      - mod: Garante a operação circular dentro do alfabeto.
                    */
                    return (char)((Caracter - baseLetra + (letraChave - 'A')) % 26 + baseLetra);
                }

                // Caracteres não alfabéticos permanecem inalterados.
                return Caracter;
            }).ToArray());
        }

        // Método para descriptografar usando a Cifra de Vigenère.
        public static string Descriptografar(string texto, string chave)
        {
            // Normaliza a chave para maiúsculas.
            chave = chave.ToUpper();
            var indiceChave = 0;

            return new string(texto.Select(caracter =>
            {
                if (char.IsLetter(caracter))
                {
                    // Determina o ponto de referência do alfabeto ('A' ou 'a').
                    char baseLetra = char.IsUpper(caracter) ? 'A' : 'a';

                    // Obtém a letra da chave correspondente.
                    char letraChave = chave[indiceChave % chave.Length];

                    // Avança o índice da chave.
                    indiceChave++;

                    /*
                      Fórmula Matemática:
                      P = (C - K + 26) mod 26
                      Onde:
                      - P: Índice da letra original. (retorno) 
                      - C: Índice da letra cifrada. (caracter - baseLetra - )
                      - K: Índice da letra da chave. (letraChave - 'A')
                      - mod: Garante a operação circular dentro do alfabeto.
                      O "+ 26" evita resultados negativos no cálculo.
                    */
                    return (char)((caracter - baseLetra - (letraChave - 'A') + 26) % 26 + baseLetra);
                }

                // Caracteres não alfabéticos permanecem inalterados.
                return caracter;
            }).ToArray());
        }
    }
}
