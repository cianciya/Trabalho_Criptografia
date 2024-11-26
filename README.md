🔐 Projeto de Criptografia: Cifra de César e Vigenère, Análise de Frequência e Detector de Criptografia
Este projeto consiste em uma aplicação completa que implementa algoritmos clássicos de criptografia, ferramentas de análise de frequência e um detector para identificar e tentar decifrar mensagens criptografadas. Ele foi desenvolvido com o objetivo de estudar e demonstrar técnicas básicas de segurança da informação e criptografia.

🛠️ Funcionalidades
1. Cifra de César
Criptografia : Aplicar uma posição no alfabeto para transformar o texto original em uma mensagem cifrada.
Descriptografia : Reverter a mensagem cifrada para o texto original, utilizando a posição correta.
Tentativa de Quebra : Testa posições possíveis para tentar identificar o texto original automaticamente.
2. Cifra de Vigenère
Criptografia : Utilize uma chave alfanumérica para cifrar mensagens, alternando posições com base na chave fornecida.
Descriptografia : Decifrar mensagens utilizando a chave correspondente.
Tentativa de Força Bruta : Teste várias chaves conhecidas para tentar decifrar mensagens criptografadas.
3. Analisador de Frequência
Contagem de Sequências : Realiza uma análise estatística sobre a frequência de letras, pares de letras (bigramas) ou outras sequências, permitindo identificar padrões no texto.
Visualização : Exiba as frequências de forma ordenada para facilitar a interpretação dos resultados.
4. Detector de Criptografia
Cifra de César : Identifique se um texto foi criptografado usando a Cifra de César e tente decifrá-lo automaticamente.
Cifra de Vigenère : Detecta possíveis padrões criptográficos e utiliza força bruta para tentar decifrar mensagens.
🎯 Objetivo do Projeto
Este projeto foi criado como uma ferramenta educacional e de portfólio para explorar os fundamentos de criptografia e suas aplicações práticas. Ele demonstra como conceitos básicos podem ser combinados para resolver problemas reais, como análise de textos criptografados.

🚀 Tecnologias Utilizadas
Linguagem : C#
Paradigmas : Programação Orientada a Objetos (POO) para organização em classes e métodos.
Ambiente : Aplicativo de console para interação simples e direta.
🗂️ Organização do Código
CriptografiaCesar: Implementação de funções para a Cifra de César.
CriptografiaVigenere: Implementação de funções para a Cifra de Vigenère.
AnaliseFrequencia: Ferramentas para análise estatística de frequências.
DetectorDeCriptografia: Lógica para detectar e tentar decifrar criptografias automaticamente.
Menu: Interface de texto para navegar entre as funcionalidades.
