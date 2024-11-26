using System;
using System.Collections.Generic;
using System.Linq;

namespace Trabalho_Criptografia.AnaliseFrequencia
{
    public class AnaliseDeFrequencia
    {
        // Analisar sequências de caracteres (tuplas, triplas, etc.)
        public static Dictionary<string, int> Analisar(string texto, int tamanhoSequencia = 2)
        {
            // Considera apenas letras e converte para minúsculas para uniformizar
            var textoFiltrado = new string(texto.Where(char.IsLetter).Select(char.ToLower).ToArray());

            // Cria as sequências de tamanho especificado
            var sequencias = Enumerable.Range(0, textoFiltrado.Length - tamanhoSequencia + 1)
                                        .Select(i => textoFiltrado.Substring(i, tamanhoSequencia));

            // Agrupa e conta as sequências
            return sequencias.GroupBy(seq => seq)
                             .ToDictionary(grupo => grupo.Key, grupo => grupo.Count());
        }

        // Exibir frequência das sequências
        public static void ExibirFrequencia(Dictionary<string, int> frequencia)
        {
            foreach (var par in frequencia.OrderByDescending(par => par.Value).ThenBy(par => par.Key))
            {
                Console.WriteLine($"{par.Key}: {par.Value}");
            }
        }
    }
}
