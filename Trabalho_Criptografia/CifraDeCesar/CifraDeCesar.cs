namespace Trabalho_Criptografia.CifraDeCesar
{
    public class CifraDeCesar
    {
        // Método para criptografar o texto usando a fórmula da Cifra de César.
        public static string Criptografar(string texto, int deslocamento)
        {
            /*
              Fórmula Matemática:
              C = (P + o) mod 26
              Onde:
              - C: Índice da letra cifrada. (retorno)
              - P: Índice da letra original.
              - o: Deslocamento.
              - mod: Garante que o índice "circulará" dentro do alfabeto.
              - C = (P + o) mod 26
            */

            return new string(texto.Select(caracter =>
            {
                if (char.IsLetter(caracter))
                {
                    // Define o ponto de partida no alfabeto ('A' para maiúsculas, 'a' para minúsculas).
                    var baseLetra = char.IsUpper(caracter) ? 'A' : 'a';

                    /*
                      Calcula o novo caractere:
                      1. Subtrai baseLetra para obter o índice relativo.
                      2. Adiciona o deslocamento.
                      3. Usa % 26 para circular dentro do alfabeto.
                      4. Soma baseLetra para retornar ao código ASCII correto.
                    */
                    return (char)((caracter - baseLetra + deslocamento) % 26 + baseLetra);
                }
                return caracter; // Mantém caracteres não alfabéticos inalterados.
            }).ToArray());
        }

        // Método para descriptografar o texto, revertendo o deslocamento.
        public static string Descriptografar(string texto, int deslocamento)
        {
            // Reverte o deslocamento: 26 - deslocamento.
            return Criptografar(texto, 26 - deslocamento);
        }
    }
}
