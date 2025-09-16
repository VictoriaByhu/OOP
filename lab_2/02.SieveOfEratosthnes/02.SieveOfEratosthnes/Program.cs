using System;


class SieveOfEratosthnes
{
    static void Main()
    {
        Console.Write("Введіть число n: ");
        int n = int.Parse(Console.ReadLine());

        // Створюємо масив, який позначає прості числа
        bool[] primes = new bool[n + 1];

        // Крок 1: спочатку всі числа позначаємо як прості
        for (int i = 0; i <= n; i++)
        {
            primes[i] = true;
        }

        // Крок 2: 0 і 1 не є простими
        primes[0] = false;
        primes[1] = false;

        // Крок 3: перебираємо числа від 2 до n
        for (int p = 2; p * p <= n; p++)
        {
            if (primes[p])
            {
                // Всі кратні p > p помічаємо як непрості
                for (int multiple = 2 * p; multiple <= n; multiple += p)
                {
                    primes[multiple] = false;
                }
            }
        }

        // Виводимо всі прості числа
        Console.WriteLine("Прості числа від 1 до " + n + ":");
        for (int i = 2; i <= n; i++)
        {
            if (primes[i])
            {
                Console.Write(i + " ");
            }
        }
    }
}
