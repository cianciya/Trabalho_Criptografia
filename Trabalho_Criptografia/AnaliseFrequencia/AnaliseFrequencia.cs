using System;
using System.Collections.Generic;
using System.Linq;

namespace Trabalho_Criptografia.AnaliseFrequencia
{
    public class AnaliseDeFrequencia
    {
        /// Analisa a frequência de sequências de caracteres (ex.: duplas, triplas) em um texto.

        /// <param name="texto">O texto a ser analisado.</param>
        /// <param name="tamanhoSequencia">O tamanho das sequências de caracteres a serem analisadas (ex.: 2 para pares).</param>
        /// <returns>Um dicionário contendo as sequências e suas respectivas frequências.</returns>
        public static Dictionary<string, int> Analisar(string texto, int tamanhoSequencia = 2)
        {
            // Filtra o texto, considerando apenas caracteres alfabéticos e convertendo-os para minúsculos.
            // Isso garante que o algoritmo ignore símbolos, números e diferenças entre maiúsculas e minúsculas.
            var textoFiltrado = new string(texto.Where(char.IsLetter).Select(char.ToLower).ToArray());

            // Gera as sequências de tamanho especificado:
            // - Enumerable.Range cria uma sequência de índices válidos para extrair substrings.
            // - Substring é usada para capturar partes do texto do tamanho especificado.
            var sequencias = Enumerable.Range(0, textoFiltrado.Length - tamanhoSequencia + 1)
                                        .Select(i => textoFiltrado.Substring(i, tamanhoSequencia));

            // Agrupa as sequências pelo valor (ex.: "ab") e conta quantas vezes cada sequência aparece no texto.
            return sequencias.GroupBy(seq => seq)
                             .ToDictionary(grupo => grupo.Key, grupo => grupo.Count());
        }



        /// Exibe as frequências das sequências em ordem decrescente de frequência e alfabética em caso de empate.
        /// <param name="frequencia">Dicionário contendo as sequências e suas frequências.</param>
        public static void ExibirFrequencia(Dictionary<string, int> frequencia)
        {
            // Ordena os resultados:
            // - Primeiro, pela frequência em ordem decrescente (mais frequentes aparecem primeiro).
            // - Em caso de empate na frequência, ordena pela sequência em ordem alfabética.
            foreach (var par in frequencia.OrderByDescending(par => par.Value).ThenBy(par => par.Key))
            {
                // Exibe cada sequência e sua frequência no formato "sequência: frequência".
                Console.WriteLine($"{par.Key}: {par.Value}");
            }
        }
    }
}
