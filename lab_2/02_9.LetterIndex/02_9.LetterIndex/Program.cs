using System;
using System.Linq;


class LetterIndex
{
    static void Main()
    {
        char[] alphabet = new char[26];

        for (int i = 0; i < 26; i++)
        {
            alphabet[i] = (char)('A' + i);
        }

        Console.WriteLine("Enter a word: ");
        string word = Console.ReadLine().ToUpper();

        for(int i = 0; i < word.Length; i++)
        {
            for(int j = 0;  j < alphabet.Length; j++)
            {
                if(word[i] == alphabet[j])
                {
                    Console.Write(word[i] + " -> " + j + "\n");
                    break;
                }
            }
        }
    }
}
