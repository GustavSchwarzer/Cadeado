using System;
using System.Collections.Generic;

class Program
{
    static List<string> sequences = new List<string>();

    static void Main(string[] args)


    {

        Console.WriteLine("Welcome to System |unlock your padlock|");


        Console.WriteLine("Uma breve explicação:");
        Console.WriteLine("Neste cadeado de 10 chaves seletoras, para cada chave ha apena 2 possibilidades,\n" +
                          "então em cada chave temos a posição A e posição B, desta forma cada vez que alteremos\n" +
                          "a posição de uma das chaves, geramos uma combinação nova! \n" +
                          "Muito facil se confundir neste 'problema', pois a primeira impressão que temos \n" +
                          "é de que se trata de um exercicio de permutação simples, mas analizando melhor chega a pensar \n" +
                          "em se tratar de Analise combinatória (Arranjo ou Combinação), mas em nenhum dos casos se enquandra...\n" +
                          "Desta forma cheguei a conclusão que para calcular a quantidade de posições seria 2^10, pois são 2 posições para 10 chaves. \n" +
                          "-------Nome fictício no primeiro CW--------- ");
        Console.WriteLine("");


        char[] sequence = { 'A', 'B', 'A', 'A', 'B', 'B', 'A', 'B', 'A', 'B' };
        int count = 0;
        int position = 0;

        GenerateSequences(sequence, 0, ref count, ref position, sequences);

        Console.WriteLine($"Total sequences generated: {count}");
        Console.WriteLine($"Position of correct combination: {position}");
        Console.WriteLine($"The correct value is: {sequences[position]} in the position: {position}");
        Console.WriteLine("");





        Console.WriteLine("If wanna you print the sequences press 'Y' else 'N'");
        string response = Console.ReadLine();
        response = response.ToUpper();
        
        if(response == "Y")
        {
            Console.WriteLine("Generated sequences:");
                    foreach (string s in sequences)
                    {
                        Console.WriteLine(s);
                    }
        }
        else
        {
            Console.WriteLine("All rigth! Nice to meet you.");
        }
        
    }

    static void GenerateSequences(char[] sequence, int index, ref int count, ref int position, List<string> sequences)
    {
        if (index == sequence.Length)
        {
            count++;
            if (IsCorrectCombination(sequence))
            {
                position = count;
            }
            sequences.Add(new string(sequence));
        }
        else
        {
            for (int i = 0; i < 2; i++)
            {
                sequence[index] = (i == 0) ? 'A' : 'B';
                GenerateSequences(sequence, index + 1, ref count, ref position, sequences);
            }
        }
    }

    static bool IsCorrectCombination(char[] sequence)
    {
        char[] correctCombination = { 'A', 'B', 'A', 'A', 'B', 'B', 'A', 'B', 'A', 'B' };
        for (int i = 0; i < sequence.Length; i++)
        {
            if (sequence[i] != correctCombination[i])
            {
                return false;
            }
        }
        return true;
    }
}
